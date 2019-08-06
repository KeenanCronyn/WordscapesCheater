using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordscapesCheat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordscapesCheat.Tests
{
    [TestClass()]
    public class CheatFunctionsTests
    {
        [TestMethod()]
        public void BuildOccurenceArray_PassValidString_Succeed()
        {
            // arrange
            string validString = "abc";
            // below is an array of the same size, of what I think should be the same result, but the test fails.
            int[] expectedArray = new int[26] { 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            // act
            int[] arrayResult = CheatFunctions.BuildOccurenceArray(validString);

            // assert
            Assert.AreEqual(expectedArray, arrayResult);
        }
    }
}