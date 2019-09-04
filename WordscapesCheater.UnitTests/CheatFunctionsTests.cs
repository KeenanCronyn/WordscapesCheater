using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WordscapesCheat.UnitTests
{
    public class CheatFunctionsTests
    {
        [TestCase()]
        [TestCase("abc", new int[] { 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 })]
        [TestCase("azaza", new int[] { 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2 })]
        [TestCase("", new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 })]
        public void BuildMatchingWordsArray_BadString_ReturnsFalse(string input, string[] expectedResult)
        {

            string[] arrayResult = CheatFunctions.BuildMatchingWordsArray(input, CheatFunctions.GetDictionary());

            CollectionAssert.AreEqual(arrayResult, expectedResult);

        }
    }
}
