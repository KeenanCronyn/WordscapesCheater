using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordscapesCheat;

namespace WordscapesCheat.CLI
{
    class Program
    {        
        static void Main(string[] args)
        {
            string characterSet = "penis";
            List<string> dictionary = CheatFunctions.GetDictionary();
            
            PrintMatchingWords(CheatFunctions.BuildMatchingWordsArray(characterSet, dictionary));
        }

        public static void PrintMatchingWords(string[] matchingWordsArray)
        {
            // this prints out the words in the array if successful. 
            // I could include something that prints if nothing is in the array.
            if (matchingWordsArray.Length == 0)
                Console.WriteLine("No words could be found that match what you asked for");
            else
            {
                foreach (var word in matchingWordsArray)
                {
                    Console.WriteLine(word);
                }
            }            
        }

    }
}
