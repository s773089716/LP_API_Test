/**************************************************************************************************
 * Author   : Sampath Kumara
 * Date     : 2022-09-05
 *************************************************************************************************/
using StemService.Core.DTOs;

namespace StemService.DTOs
{
    public class StemRequest : IRequestBase
    {
        public string Prefix { get; set; }
    }
}
