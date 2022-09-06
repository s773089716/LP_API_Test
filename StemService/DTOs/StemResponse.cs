/**************************************************************************************************
 * Author   : Sampath Kumara
 * Date     : 2022-09-05
 *************************************************************************************************/
using StemService.Core.DTOs;
using System.Collections.Generic;

namespace StemService.DTOs
{
    public class StemResponse : IResponseBase
    {
        public IList<string> data = null;
    }
}
