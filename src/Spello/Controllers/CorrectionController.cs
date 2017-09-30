using Microsoft.AspNetCore.Mvc;
using Spello.Models;
using Swashbuckle.SwaggerGen.Annotations;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Cors;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System;

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


        private static string Correct(string input, string language)
        {
            List<SymSpellCompound.suggestItem> suggestions = null;

            //check if input term or similar terms within edit-distance are in dictionary, return results sorted by ascending edit distance, then by descending word frequency     
			if (SymSpellCompound.enableCompoundCheck) suggestions = SymSpellCompound.LookupCompound(input, language, SymSpellCompound.editDistanceMax); else suggestions = SymSpellCompound.Lookup(input, language, SymSpellCompound.editDistanceMax);

            //display term and frequency
            foreach (var suggestion in suggestions)
            {
                Console.WriteLine( suggestion.term + " " + suggestion.distance.ToString() + " " + suggestion.count.ToString("N0"));
            }

            return suggestions[0].term;
            //if (SymSpellCompound.verbose != 0) Console.WriteLine(suggestions.Count.ToString() + " suggestions");
        }

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
            //set global parameters
			SymSpellCompound.enableCompoundCheck=true;
            SymSpellCompound.verbose = 1;
            SymSpellCompound.editDistanceMax = 1;

            Console.Write("Creating dictionary ...");//neuneu
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            string path = "fr.txt";  //path when using SymSpellCompound.cs
            if (!SymSpellCompound.LoadDictionary(path, "", 0, 1)) 
                Console.Error.WriteLine("File not found: " + Path.GetFullPath(path)); 

            Console.WriteLine("\rDictionary: " + SymSpellCompound.wordlist.Count.ToString("N0") + " words, " + SymSpellCompound.dictionary.Count.ToString("N0") + " entries, edit distance=" + SymSpellCompound.editDistanceMax.ToString() + " in " + stopWatch.ElapsedMilliseconds.ToString() + "ms "/*+ (Process.GetCurrentProcess().PrivateMemorySize64/1000000).ToString("N0")+ " MB"*/);//neuneu

            string input = "voiciun essai" ;
            
            var correct = Correct(input, "");

            return Ok("faux: " + input + " >> vrai: " + correct);
        }


    }
}
