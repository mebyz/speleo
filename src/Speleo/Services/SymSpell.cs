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
        public string Correct(string input, string language)
        {
            List<SymSpellCompound.suggestItem> suggestions = null;
            if (SymSpellCompound.enableCompoundCheck)
            {
                suggestions = SymSpellCompound.LookupCompound(input, language, SymSpellCompound.editDistanceMax);
            }
            else
            {
                suggestions = SymSpellCompound.Lookup(input, language, SymSpellCompound.editDistanceMax);
            }

            if (suggestions.Count() >= 0 && suggestions[0].term.Count() > 0) 
            {
                return suggestions[0].term;
            } 
            else 
            {
                return input;
            }
            //if (SymSpellCompound.verbose != 0) Console.WriteLine(suggestions.Count.ToString() + " suggestions");
        }

        /// <summary>
        /// todo
        /// </summary>
        /// <remarks>todo</remarks>  
        public SymSpell()
        {
            //set global parameters
			SymSpellCompound.enableCompoundCheck=true;
            SymSpellCompound.verbose = 1;
            SymSpellCompound.editDistanceMax = 0;

            string path = "fr.txt";  //path when using SymSpellCompound.cs
            if (!SymSpellCompound.LoadDictionary(path, "", 0, 1)) 
                Console.Error.WriteLine("File not found: " + Path.GetFullPath(path)); 

            Console.WriteLine("\rDictionary: " + SymSpellCompound.wordlist.Count.ToString("N0") + " words, " + SymSpellCompound.dictionary.Count.ToString("N0") + " entries, edit distance=" + SymSpellCompound.editDistanceMax.ToString() );
        }
    }
}