using IBGBlazorApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IBGBlazorApi.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Localidade> IBGE { get; set; }

    public async Task RunQuery(string query)
    {
        await Database.ExecuteSqlRawAsync(query);
    }
}
