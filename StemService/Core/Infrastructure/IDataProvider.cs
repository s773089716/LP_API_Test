using System.Collections.Generic;

namespace StemService.Core.Infrastructure
{
    public interface IDataProvider
    {
        IList<string> GetWordsData();
    }
}
