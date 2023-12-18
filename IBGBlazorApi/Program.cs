using IBGBlazorApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using IBGBlazorApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Antiforgery;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Just setting the name of XSRF token
builder.Services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");
builder.Services.AddAuthorization();

builder.Services.AddTransient<ILocalidadeService, LocalidadeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseAntiforgery();
app.UseHttpsRedirection();

app.MapGroup("/identity").MapIdentityApi<IdentityUser>();

// Get token
app.MapGet("/antiforgery/token", (IAntiforgery forgeryService, HttpContext context) =>
{
    var tokens = forgeryService.GetAndStoreTokens(context);
    var xsrfToken = tokens.RequestToken!;
    return TypedResults.Content(xsrfToken, "text/plain");
})
    .RequireAuthorization();

app.MapPost("/import-from-excel", async (IFormFile excelFile, ILocalidadeService _localidadeService) =>
{
    await _localidadeService.ImportFromExcel (excelFile);
    return Results.Created();
})
    .RequireAuthorization()    
    .WithName("ImportLocalidades")
    .WithOpenApi(x => new Microsoft.OpenApi.Models.OpenApiOperation(x)
    {
        Summary = "Importar dados",
        Description = "Importar dados de uma planilha Excel"
    });

app.MapPost("/run-queries", async(List < SqlQueryDto > sqlQueries, ILocalidadeService _localidadeService) =>
{
    await _localidadeService.RunQueries (sqlQueries);
    return Results.Created();
})
    .RequireAuthorization()
    .WithName("RunQueries")
    .WithOpenApi(x => new Microsoft.OpenApi.Models.OpenApiOperation(x)
    {
        Summary = "Importar dados",
        Description = "Importar dados de uma planilha Excel"
    });

app.Run();

