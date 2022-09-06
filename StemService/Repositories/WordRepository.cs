/**************************************************************************************************
 * Author   : Sampath Kumara
 * Date     : 2022-09-05
 *************************************************************************************************/
#region Packages/Usings ---------------------------------------------------------------------------
using Microsoft.Extensions.Caching.Memory;
using StemService.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#endregion

namespace StemService.Repositories
{
    public class WordRepository : IWordRepository
    {
        #region Private Variables -----------------------------------------------------------------
        private static IList<string> _wordsDictionary = null;
        private IMemoryCache _cache;
        #endregion

        #region Constructors ----------------------------------------------------------------------
        public WordRepository(IMemoryCache cache)
        {
            _cache = cache;
        }
        #endregion

        #region Properties ------------------------------------------------------------------------
        private IList<string> WordsDictionary
        {
            get
            {
                if (_wordsDictionary == null)                
                    _wordsDictionary = _cache.Get<IList<string>>("WordsDictionary");                

                return _wordsDictionary;

            }
        }
        #endregion

        #region Methods ---------------------------------------------------------------------------
        /// <summary>
        /// Service method to search data related to the prefix
        /// </summary>
        /// <param name="prefix">Prefix to be searched</param>
        /// <returns>String array</returns>
        public async Task<IList<string>> FindWordListByPrefix(string prefix)
        {
            IList<string> data = null;            

            await Task.Run(() =>
            {
                data =
                (
                    from w in WordsDictionary
                    where w.StartsWith(prefix)
                    select w
                ).ToList<string>();
            });

            return data;
        }        
        #endregion
    }
}
