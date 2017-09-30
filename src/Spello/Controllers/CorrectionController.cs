using Microsoft.AspNetCore.Mvc;
using Spello.Models;
using Swashbuckle.SwaggerGen.Annotations;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Cors;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System;
using Spello.Services;

namespace Spello.Controllers
{
    /// <summary>
    /// todo
    /// </summary>
    /// <remarks>todo</remarks>
    //[Route("/")]
    [Route("/")]
    public class RootController : Controller
    {
        /// <summary>
        /// Get ok
        /// </summary>
        /// <remarks>Get ok</remarks>
        /// <returns>ok</returns>
        [HttpGet]
        [Route("")]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(MainResult))]
        [ResponseCache(Duration = 3600 * 1000)] //1h de cache
        public IActionResult Root()
        {
            return Ok("ok");
        }
    }

    /// <summary>
    /// todo
    /// </summary>
    /// <remarks>todo</remarks>
    //[Route("api/v1/[controller]")]
    [Route("api/v1")]
    [EnableCors("CorsPolicy")]
    public class CorrectionController : Controller
    {

        /// <summary>
        /// Get Spello correction
        /// </summary>
        /// <remarks>Get Spello correction</remarks>
        /// <returns>corrected text</returns>
        [HttpGet]
        [Route("correct")]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(MainResult))]
        [ResponseCache(Duration = 3600)] //1h de cache
        public IActionResult GetCorrection(string text)
        {
            string input = "voiciun essai" ;

            var correct = SymSpell.Correct(input, "");

            return Ok("faux: " + input + " >> vrai: " + correct);
        }


    }
}
