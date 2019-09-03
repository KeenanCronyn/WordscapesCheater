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
        public void BuildMatchingWordsArray_BadString_ReturnsFalse(string givenLetters, string[] expected)
        {
            string givenLetters = "ab-c";
            List<string> dictionary = CheatFunctions.GetDictionary();

            string[] ArrayResult = CheatFunctions.BuildMatchingWordsArray(givenLetters, dictionary);

            Assert.

        }
    }
}
