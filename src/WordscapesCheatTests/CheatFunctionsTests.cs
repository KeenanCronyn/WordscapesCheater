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
            int[] expectedArray = new int[26] { 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            // act
            // assert
            CollectionAssert.AreEqual(expectedArray, CheatFunctions.BuildOccurenceArray(validString));
        }
    }
}