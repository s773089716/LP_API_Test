/**************************************************************************************************
 * Author   : Sampath Kumara
 * Date     : 2022-09-05
 *************************************************************************************************/
#region Packages/Usings ---------------------------------------------------------------------------
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StemService.Core.Services;
using StemService.DTOs;
using StemService.Infrastructure;
#endregion

namespace StemService.Controllers
{
    /// <summary>
    /// Provides stem related web methods
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StemsController : ControllerBase
    {
        #region Private Variables -----------------------------------------------------------------
        private IStemService _stemService = null;
        private readonly ILogger<StemsController> _logger;
        #endregion

        #region Constructors ----------------------------------------------------------------------
        // GET: api/Stems
        /// <summary>
        /// Stem constructor. Injected instances will be assigned here.
        /// </summary>
        /// <param name="stemService">Service which is used to get data</param>
        /// <param name="logger">Logger service to be used</param>
        public StemsController(IStemService stemService, ILogger<StemsController> logger)
        {
            //TODO: Need to use proper logging provider and be injected through middleware
            _logger         = logger;
            _stemService    = stemService;
        }
        #endregion

        #region Web Methods -----------------------------------------------------------------------
        /// <summary>
        /// Returns the requested stem data. And returns 404 if data not found.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[Route("GET")]
        public async Task<ActionResult<StemResponse>> Get()
        {
            string prefix = Request.Query[QueryStringKey.Stem];

            if (!String.IsNullOrEmpty(prefix))
            {
                StemRequest request = new StemRequest { Prefix = prefix };
                StemResponse response = await _stemService.GetSearchData(request);

                if (response.data != null && response.data.Count > 0)
                    return Ok(response);
            }

                return NotFound();            
        }
        //public StemResponse Get()
        //{
        //    return new StemResponse() { data = new string[] { "test" } };
        //}

        #endregion
    }
}
