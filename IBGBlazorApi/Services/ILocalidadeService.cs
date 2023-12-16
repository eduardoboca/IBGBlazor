using IBGBlazorApi.Models;
using Microsoft.Extensions.Primitives;

namespace IBGBlazorApi.Services
{
    public interface ILocalidadeService
    {
        Task<Localidade> AddLocalidade(Localidade localidade);
        Task RunQueries(List<SqlQueryDto> queries);
    }
}
