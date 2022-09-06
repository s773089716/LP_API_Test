using StemService.DTOs;
using System.Threading.Tasks;

namespace StemService.Core.Services
{
    public interface IStemService : IServiceBase
    {
        Task<StemResponse> GetSearchData(StemRequest request);
    }
}
