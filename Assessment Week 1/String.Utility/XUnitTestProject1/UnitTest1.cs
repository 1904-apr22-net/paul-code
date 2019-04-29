using System;
using Xunit;
using String.Utility;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //arrange
            StringFunctions Test = new StringFunctions();
            bool bTest;
            //act
            bTest = f.Palindrome("pap");
            //assert
            Assert.True(bTest);
        }
    }
}
