using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordscapesCheat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordscapesCheat.Tests
{
    [TestClass]
    public class CheatFunctionsTests : CheatFunctions
        // I derived this class from CheatFunctions because otherwise I could not test the private functions
    {
        [DataTestMethod]
        [DataRow("abc", new int[] { 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 })]
        [DataRow("azaza", new int[] { 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2 })]
        [DataRow("", new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 })]
        public void BuildOccurenceArray_PassValidString_Succeed(string input, int[] expected)
        {
            CollectionAssert.AreEqual(expected, CheatFunctions.BuildOccurenceArray(input));
        }

        [DataTestMethod]
        [DataRow("abc", "cab")]
        [DataRow("test", "set;stet;test")]
        public void BuildMatchingWordsArray_ValidString_Succeed(string input, string stringResult)
        {
            string[] expectedResult = stringResult.Split(';').ToArray();

            string[] arrayResult = CheatFunctions.BuildMatchingWordsArray(input, CheatFunctions.GetDictionary());

            CollectionAssert.AreEquivalent(arrayResult, expectedResult);
        }

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