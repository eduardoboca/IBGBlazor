using IBGBlazorApi.Data;
using IBGBlazorApi.Models;
using Microsoft.AspNetCore.Components.Forms;
using OfficeOpenXml;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

                Console.WriteLine($"Adicionar localidade: {localidade}");
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

        public async Task ImportFromExcel(IFormFile file)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var tempFileName = Path.GetTempFileName();
            tempFileName = Path.ChangeExtension(tempFileName, "xlsx");
            var destinationStream = new FileStream(tempFileName, FileMode.Create);
            await file.OpenReadStream().CopyToAsync(destinationStream);
            destinationStream.Close();

            var package = new ExcelPackage(new FileInfo(tempFileName));
            var worksheet = package.Workbook.Worksheets[1];
            var lastRow = worksheet.Dimension.End.Row;

            for (int i = 2; i <= lastRow; i++)
            {
                var id = worksheet.Cells[i, 1].Value.ToString();
                string? city = worksheet.Cells[i, 2].Value.ToString();
                city = city.Replace("'", "''");
                var state = worksheet.Cells[i, 3].Value.ToString();
                //var query = $"INSERT INTO [IBGE] VALUES('{id}', '{state}', '{city}')";
                await AddLocalidade(new Localidade { City = city, Id = id, State = state });
            }
        }

        public async Task RunQueries(List<SqlQueryDto> queries)
        {
            foreach (var sqlQueryDto in queries)
            {
                // Execute a lógica para processar a consulta SQL (exemplo: executar no banco de dados)
                Console.WriteLine($"Executing SQL query: {sqlQueryDto.Query}");
                await Task.Yield();

                //await _context.RunQuery(sqlQueryDto.Query.Replace("Municipios", "IBGE"));
            }
        }
    }
}
