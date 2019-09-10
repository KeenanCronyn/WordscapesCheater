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
        /// <summary>
        /// This returns a list that functions as a dictionary.
        /// </summary>
        public static List<string> GetDictionary()
        {
            return Resources._2of12inf.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.TrimEnd(new[] { '%', '!' }))
                .ToList();
        }

        /// <summary>
        /// Takes an input string and turns it into an array that shows how many times each A-Z letter appears in a given string.
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static int[] BuildOccurenceArray(string inputString)
        {
            // Sets an ASCII count from "a", and initializes an array that matches the alphabet
            const int A_ASCII = 97;
            int[] occurenceArray = new int[26];

            // For each character in the input string, based on its ASCII code, add it to the above array at the appropriate point.
            foreach (byte b in Encoding.ASCII.GetBytes(inputString.ToLower()))
            {
                occurenceArray[b - A_ASCII]++;
            }

            return occurenceArray;
        }

        /// <summary>
        /// This takes a string of letters and a list, and returns an array of words that match.
        /// </summary>
        /// <param name="givenLetters"></param>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static string[] BuildMatchingWordsArray(string givenLetters, List<string> dictionary)
        {
            // Turns the character set into an "occurence array" and initilizes a list to store matching words
            List<string> matchingWordsList = new List<string>();
            int[] givenLettersArray = BuildOccurenceArray(givenLetters);

            // Take each word and if it's of an appropriate length, turn it into an occurency array and measure it against the character set.
            foreach (string word in dictionary)
            {
                if (word.Length > 2 && word.Length < 8)
                {
                    int[] wordArray = BuildOccurenceArray(word);

                    // If it matches, add it to the list.
                    if (TestIfMatching(givenLettersArray, wordArray) == true)
                        matchingWordsList.Add(word);
                }
            }

            string[] matchingWordsArray = matchingWordsList.ToArray();
            return matchingWordsArray;
        }

        /// <summary>
        /// This take a string of letters, a list of words, and an int, and then returns words of a certain length in the list that match the string.
        /// </summary>
        /// <param name="givenLetters"></param>
        /// <param name="dictionary"></param>
        /// <param name="wordLength"></param>
        /// <returns></returns>
        public static string[] BuildMatchingWordsArray(string givenLetters, List<string> dictionary, int wordLength)
        {
            List<string> matchingWordsList = new List<string>();
            int[] givenLettersArray = BuildOccurenceArray(givenLetters);

            foreach (string word in dictionary)
            {
                // Behaves the same as the previous method, but this time only returns word of a length thst is passed to it.
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

        /// <summary>
        /// Tests if a word array matches a character set array, and returns true/false.
        /// </summary>
        /// <param name="givenLettersArray"></param>
        /// <param name="wordArray"></param>
        /// <returns></returns>
        internal static bool TestIfMatching(int[] givenLettersArray, int[] wordArray)
            // I changed this from private to protected so that the tests class could inherit it
        {
            // For each element in the array of a word, if it isn't greater than what's in the array of the character set, then return false. 
            for (int i = 0; i < givenLettersArray.Length; i++)
            {
                if (wordArray[i] > givenLettersArray[i])
                    return false;
            }
            return true;
        }
    }
}
