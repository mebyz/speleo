﻿using Microsoft.AspNetCore.Mvc;
using Swashbuckle.SwaggerGen.Annotations;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Cors;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System;
using Speleo.Services;

namespace Speleo.Controllers
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
        /// Get Speleo correction
        /// </summary>
        /// <remarks>Get Speleo correction</remarks>
        /// <returns>corrected text</returns>
        [HttpGet]
        [Route("correct")]
        [ResponseCache(Duration = 3600)] //1h de cache
        public IActionResult GetCorrection([FromQuery]string text = "", string language = "en", int editDistanceMax = 0, bool enableCompoundCheck = true)
        {
            var spell = SymSpell.Instance;
            string input = text != "" ? text.ToString() : "";
            if (input != "") {
                var correct = spell.Correct(input, language, editDistanceMax, enableCompoundCheck);
                return Ok(correct != "" ? correct : text);
            } else {
                return Ok(text);
            }
        }


    }
}
