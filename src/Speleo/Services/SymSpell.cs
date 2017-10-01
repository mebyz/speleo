using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Speleo.Services
{

    /// <summary>
    /// todo
    /// </summary>
    /// <remarks>todo</remarks>     
    public sealed class SymSpell
    {
        
        private string _lang = "en";       
    
        private static readonly Lazy<SymSpell> lazy =
            new Lazy<SymSpell>(() => new SymSpell());
        
        /// <summary>
        /// todo
        /// </summary>
        /// <remarks>todo</remarks>     
        public static SymSpell Instance { get { return lazy.Value; } }
        /// <summary>
        /// todo
        /// </summary>
        /// <remarks>todo</remarks>     

        public string Correct(string input, string language = "en", int editDistanceMax = 2, bool enableCompoundCheck = true)
        {
            if (_lang != language) {
                loadLanguage(language);
            }

			SymSpellCompound.enableCompoundCheck=enableCompoundCheck;
            SymSpellCompound.verbose = 0;
            SymSpellCompound.editDistanceMax = editDistanceMax;

            List<SymSpellCompound.suggestItem> suggestions = null;

            //check if input term or similar terms within edit-distance are in dictionary, return results sorted by ascending edit distance, then by descending word frequency     
			if (SymSpellCompound.enableCompoundCheck) suggestions = SymSpellCompound.LookupCompound(input, language, SymSpellCompound.editDistanceMax); else suggestions = SymSpellCompound.Lookup(input, language, SymSpellCompound.editDistanceMax);

            return suggestions.FirstOrDefault() != null ? suggestions.FirstOrDefault().term : input;
        }

        /// <summary>
        /// todo
        /// </summary>
        /// <remarks>todo</remarks>  
        private void loadLanguage(string lang = "en")
        {

            string path = lang + ".txt";  //path when using SymSpellCompound.cs
            if (!SymSpellCompound.LoadDictionary(path, lang, 0, 1)) 
                Console.Error.WriteLine("File not found: " + Path.GetFullPath(path)); 

            Console.WriteLine("\rDictionary: " + SymSpellCompound.wordlist.Count.ToString("N0") + " words, " + SymSpellCompound.dictionary.Count.ToString("N0") + " entries, edit distance=" + SymSpellCompound.editDistanceMax.ToString() );
            _lang = lang;
        }

        /// <summary>
        /// todo
        /// </summary>
        /// <remarks>todo</remarks>  
        public SymSpell()
        {
            loadLanguage(_lang);
        }
    }
}