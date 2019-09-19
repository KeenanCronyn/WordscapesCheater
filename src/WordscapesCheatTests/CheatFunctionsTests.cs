using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordscapesCheat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordscapesCheat.Tests
{
    /// <summary>
    /// Tests all CheatFunctions types. Has access to internal members.
    /// </summary>
    [TestClass]
    public class CheatFunctionsTests
    {
        /// <summary>
        /// Tests that valid input strings result in integer arrays.
        /// </summary>
        /// <param name="input">The test data.</param>
        /// <param name="expected">The expected result.</param>
        [DataTestMethod]
        [DataRow("abc", new int[] { 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 })]
        [DataRow("azaza", new int[] { 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2 })]
        [DataRow("", new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 })]
        public void BuildOccurenceArray_PassValidString_Succeed(string input, int[] expected)
        {
            CollectionAssert.AreEqual(expected, CheatFunctions.BuildOccurenceArray(input));
        }

        /// <summary>
        /// Tests that valid input strings contain expected matching words.
        /// </summary>
        /// <param name="input">The test data.</param>
        /// <param name="stringResult">The expected result.</param>
        [DataTestMethod]
        [DataRow("abc", "cab")]
        [DataRow("test", "set;stet;test")]
        public void BuildMatchingWordsArray_ValidString_Succeed(string input, string stringResult)
        {
            string[] expectedResult = stringResult.Split(';').ToArray();
            string[] arrayResult = CheatFunctions.BuildMatchingWordsArray(input, Data.DictionaryInstances.TwoOfTwelveInf);
            CollectionAssert.AreEquivalent(arrayResult, expectedResult);
        }

        /// <summary>
        /// Tests that occurence arrays match.
        /// </summary>
        /// <param name="givenLetters">The test data.</param>
        /// <param name="wordInDictionary">The word in the dictionary.</param>
        [DataTestMethod]
        [DataRow("abc", "cab")]
        public void TestIfMatching_PassValidArray_Succeed(string givenLetters, string wordInDictionary)
        {
            int[] givenLettersArray = CheatFunctions.BuildOccurenceArray(givenLetters);
            int[] wordArray = CheatFunctions.BuildOccurenceArray(wordInDictionary);
            Assert.IsTrue(CheatFunctions.TestIfMatching(givenLettersArray, wordArray));
        }
    }
}