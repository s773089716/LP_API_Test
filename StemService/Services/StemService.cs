/**************************************************************************************************
 * Author   : Sampath Kumara
 * Date     : 2022-09-05
 *************************************************************************************************/
using StemService.Core.Repositories;
using StemService.Core.Services;
using StemService.DTOs;
using System.Threading.Tasks;

namespace StemService.Services
{
    public class StemService : IStemService
    {
        IWordRepository _wordRepository;

        public StemService(IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
        }

        public async Task<StemResponse> GetSearchData(StemRequest request)
        {
            return new StemResponse()
            {
                data = await _wordRepository.FindWordListByPrefix(request.Prefix)
            };
        }
    }
}
