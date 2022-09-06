using System.Collections.Generic;
using System.Threading.Tasks;

namespace StemService.Core.Repositories
{
    public interface IWordRepository : IRepositoryBase
    {
        Task<IList<string>> FindWordListByPrefix(string prefix);
    }
}
