using IBGBlazorApi.Models;
using Microsoft.EntityFrameworkCore;

namespace IBGBlazorApi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Localidade> IBGE { get; set; }

    public async Task RunQuery(string query)
    {
        await Database.ExecuteSqlRawAsync(query);
    }
}
