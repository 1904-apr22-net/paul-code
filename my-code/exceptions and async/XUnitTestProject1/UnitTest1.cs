using System;
using Xunit;
using ConsoleApp2;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Theory]
        [InlineData ("Paul")]
        public void Test1(string name)
        {
            //arrange
            //act

            Assert.ThrowsAny<CustomEx>(() => Program.throwOrNah(name));
            //Assert.Throws<CustomEx>(() => Program.throwOrNah("Paul"));
            //assert
        }
    }
}
