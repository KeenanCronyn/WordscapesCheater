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
            // \n is a newline
            // \t is a tab space
            const string HelpMessage = "###Wordscapes Cheater###\n\n" + 
                "Returns matching words based on the characters you provide.\n\n" + 
                "wsc characters\n\n  characters  The characters that Wordscapes gives you.\n\n" + 
                "Example:\nwsc cat\nact\ncat";

            if (ArgsNeedsHelp(args))
            {
                Console.WriteLine(HelpMessage);
                return;
            }

            //We can use the other args for other stuff later
            //e.g. word count or letter position
            string characterSet = args[0];
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

        private static bool ArgsNeedsHelp(string[] args)
        {
            string[] HelpArgs = new[] { "/?", "--help", "/help", "?" };

            return (args == null || args.Length == 0) //no args at all
                || args.All(x => string.IsNullOrEmpty(x)) //all args are null or empty string
                || args.Any(x => HelpArgs.Contains(x)); //any arg contains a help string
        }
    }
}
