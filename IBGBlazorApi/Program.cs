using IBGBlazorApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using IBGBlazorApi.Services;
using Microsoft.AspNetCore.Antiforgery;
using System.Collections.Generic;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddTransient<ILocalidadeService, LocalidadeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/run-queries", async(List < SqlQueryDto > sqlQueries, ILocalidadeService _localidadeService) =>
{
    await _localidadeService.RunQueries (sqlQueries);
    return Results.Created();
})
    .WithName("ImportLocalidades")
    .WithOpenApi(x => new Microsoft.OpenApi.Models.OpenApiOperation(x)
    {
        Summary = "Importar dados",
        Description = "Importar dados de uma planilha Excel"
    });




app.Run();

