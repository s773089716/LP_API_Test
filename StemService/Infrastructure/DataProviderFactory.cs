/**************************************************************************************************
 * Author   : Sampath Kumara
 * Date     : 2022-09-05
 *************************************************************************************************/
using StemService.Core.Infrastructure;

namespace StemService.Infrastructure
{
    public class DataProviderFactory
    {
        #region Public Methods --------------------------------------------------------------------
        /// <summary>
        /// Provides different data providers according to the requirement
        /// </summary>
        /// <returns>IDataProvider</returns>
        public static IDataProvider GetDataProvider()
        {
            return new WebTextFileDataProvider();
        }
        #endregion
    }
}
