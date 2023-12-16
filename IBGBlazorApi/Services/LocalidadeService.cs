using IBGBlazorApi.Data;
using IBGBlazorApi.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Primitives;
using OfficeOpenXml;
using static System.Net.Mime.MediaTypeNames;

namespace IBGBlazorApi.Services
{
    public class SqlQueryDto
    {
        public string? Query { get; set; }
    }

    public class LocalidadeService : ILocalidadeService
    {
        private readonly ApplicationDbContext _context;

        public LocalidadeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Localidade> AddLocalidade(Localidade localidade)
        {
            try
            {
                if (localidade is null)
                    throw new ArgumentException(nameof(localidade));

                _context.Add(localidade);
                await _context.SaveChangesAsync();

                return localidade;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw; 
            }
        }

        public async Task RunQueries(List<SqlQueryDto> queries)
        {
            foreach (var sqlQueryDto in queries)
            {
                // Execute a lógica para processar a consulta SQL (exemplo: executar no banco de dados)
                Console.WriteLine($"Executing SQL query: {sqlQueryDto.Query}");


                await _context.RunQuery(sqlQueryDto.Query.Replace("Municipios", "IBGE"));
            }
        }
    }
}
