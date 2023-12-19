using IBGBlazor.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IBGBlazor.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Estado> Estados { get; set; }
    public DbSet<Municipio> Municipios { get; set; }

    public async Task ExecuteSqlRaw(string sql)
    {
        await Database.ExecuteSqlRawAsync(sql);
    }
}
