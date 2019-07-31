using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordscapesCheat.Properties;

namespace WordscapesCheat
{
    public static class CheatFunctions
    {   
        public static List<string> GetDictionary()
        {
            return Resources._2of12inf.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.TrimEnd(new[] { '%', '!' }))
                .ToList();
        }

        public static int[] BuildOccurenceArray(string inputString)
        {
            const int A_ASCII = 97;
            int[] occurenceArray = new int[26];

            foreach (byte b in Encoding.ASCII.GetBytes(inputString.ToLower()))
            {
                occurenceArray[b - A_ASCII]++;
            }

            return occurenceArray;
            // the above is Dad's code for building an int array showing how many occurrences of each letter there are in a given inputString
        }

        public static string[] BuildMatchingWordsArray(string givenLetters, List<string> dictionary)
        {
            // The below takes a string of letters and a list, and then spits out a string array of words that match
            List<string> matchingWordsList = new List<string>();
            int[] givenLettersArray = BuildOccurenceArray(givenLetters);

            foreach (string word in dictionary)
            {
                if (word.Length > 2 && word.Length < 8)
                {
                    int[] wordArray = BuildOccurenceArray(word);

                    if (TestIfMatching(givenLettersArray, wordArray) == true)
                        matchingWordsList.Add(word);
                }
            }

            string[] matchingWordsArray = matchingWordsList.ToArray();
            return matchingWordsArray;
        }

        public static string[] BuildMatchingWordsArray(string givenLetters, List<string> dictionary, int wordLength)
        {
            // The below takes a string of letters and a list, and then spits out a string array of words that match
            List<string> matchingWordsList = new List<string>();
            int[] givenLettersArray = BuildOccurenceArray(givenLetters);

            foreach (string word in dictionary)
            {
                if (word.Length == wordLength)
                {
                    int[] wordArray = BuildOccurenceArray(word);

                    if (TestIfMatching(givenLettersArray, wordArray) == true)
                        matchingWordsList.Add(word);
                }
            }

            string[] matchingWordsArray = matchingWordsList.ToArray();
            return matchingWordsArray;
        }

        public static bool TestIfMatching(int[] givenLettersArray, int[] wordArray)
        {
            //this tests if the word matches the letters, and is used in the BuildMatchingWordsArray function
            for (int i = 0; i < givenLettersArray.Length; i++)
            {
                if (wordArray[i] > givenLettersArray[i])
                    return false;
            }
            return true;
        }
    }
}
