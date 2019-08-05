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
        public void OccurenceArray_PassValidString_Succeed()
        {
            // arrange
            string validString = "abc";
            string[] expectedArray = new string[26];

            const int A_ASCII = 97;
            int[] occurenceArray = new int[26];

            // act

            // assert

            Assert.Fail();
        }
    }
}