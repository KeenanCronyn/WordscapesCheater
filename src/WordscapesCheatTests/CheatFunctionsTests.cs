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
    public class CheatFunctionsTests
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
        [DataRow("abc", new string[] { "bac" })]
        public void BuildMatchingWordsArray_ValidString_Succeed(string _input, List<string> _expectedResult)
        {
            string input = "abc";
            List<string> matchingWordsList = new List<string>();
            matchingWordsList.Add("cab");
            string[] expectedResult = matchingWordsList.ToArray();       

            string[] arrayResult = CheatFunctions.BuildMatchingWordsArray(input, CheatFunctions.GetDictionary());

            CollectionAssert.AreEquivalent(arrayResult, expectedResult);
        }        

        //[DataTestMethod]
        //[DataRow("a-c", new int[] { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 })]
        //public void BuildOccurenceArray_PassInvalidString_Fail(string input, int[] expected)
        //{
        //    CollectionAssert.AreEqual(expected, CheatFunctions.BuildOccurenceArray(input));
        //}

    }
}