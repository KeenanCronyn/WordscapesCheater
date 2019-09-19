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
    /// Tests dictionary data. Has access to internal members.
    /// </summary>
    [TestClass]
    public class DictionaryTests
    {
        /// <summary>
        /// Tests that valid input strings result in valid dictionaries.
        /// </summary>
        /// <param name="input">The test data.</param>
        /// <param name="expected">The expected result.</param>
        [DataTestMethod]
        [DataRow("a", "a")]
        [DataRow("a\r\nb", "a;b")]
        [DataRow("a\r\n\r\nb", "a;b")]
        [DataRow("a\r\n \r\nb", "a; ;b")]
        [DataRow("a%!\r\nb%\r\nc!\r\nd!%", "a;b;c;d")]
        public void CreateDictionaryFromOfTwelveText_Succeed(string input, string expected)
        {
            List<string> expectedList = expected.Split(';').ToList();
            CollectionAssert.AreEquivalent(expectedList, Data.DictionaryInstances.CreateDictionaryFromOfTwelveText(input));
        }

    }
}