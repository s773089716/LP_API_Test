/**************************************************************************************************
 * Author   : Sampath Kumara
 * Date     : 2022-09-05
 *************************************************************************************************/
#region Packages/Imports --------------------------------------------------------------------------
using StemService.Core.Infrastructure;
using System.Collections.Generic;
using System.IO;
using System.Net;
#endregion

namespace StemService.Infrastructure
{
    public class WebTextFileDataProvider : IDataProvider
    {
        #region Static/Cont Variables -------------------------------------------------------------
        private const string WebTextFileURI = "https://raw.githubusercontent.com/qualified/challenge-data/master/words_alpha.txt";
        #endregion

        #region Public methods --------------------------------------------------------------------
        /// <summary>
        /// This method connect to the text file and scrape data
        /// </summary>
        /// <returns></returns>
        public IList<string> GetWordsData()
        {
            using (var client = new WebClient())
            {
                string line;
                IList<string> list = new List<string>();
                MemoryStream stream = new MemoryStream();
                                
                byte[] file = client.DownloadData(WebTextFileURI);

                stream.Write(file, 0, file.Length);
                stream.Seek(0, SeekOrigin.Begin);

                StreamReader reader = new StreamReader(stream);

                while ((line = reader.ReadLine()) != null) //TODO: This method should be able to improved
                    list.Add(line);

                //Assumed that file is not empty
                return list;
            }
        }
        #endregion
    }
}
