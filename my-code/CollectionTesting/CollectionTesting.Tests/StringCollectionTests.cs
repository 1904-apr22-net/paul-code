using CollectionTesting.Library;
using System;
using Xunit;

namespace CollectionTesting.Tests
{
    // in xUnit, each test is one method, marked with an attribute,
    //  either [Fact], or [Theory]
    public class StringCollectionTests
    {
        [Fact]
        public void CtorZeroThrowsNoExceptions()
        {
            // there are three steps to a good unit test.
            // 1. arrange

            // 2. act (the behavior you are testing)
            var c = new StringCollection();
            
            // 3. assert (verify the behavior was correct)
        }

        [Fact]
        public void AddShouldAdd()
        {
            // arrange
            var c = new StringCollection();

            // act
            c.Add("abc");

            // assert
            var value = c[0];
            Assert.Equal("abc", value);
        }

        [Fact]
        public void GetLongestStringWithEmptyShouldReturnNull()
        {
            // arrange
            var c = new StringCollection();

            // act
            var result = c.GetLongestString();

            // assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("abc", "abc", "ab")]
        [InlineData(null)] // duplicating the above test
        [InlineData("a", "a", "b")]
        [InlineData("abc", "a", null, "abc")]
        public void GetLongestStringShouldBeCorrect(string longest, params string[] values)
        {
            // arrange
            var c = new StringCollection(values);

            // act
            var result = c.GetLongestString();

            // assert
            Assert.Equal(longest, result);
        }

        [Fact]
        public void RemoveShortestRemovesShortest()
        {
            var c = new StringCollection();
            //c.RemoveShortest();
        }

        [Theory]
        [InlineData("abc", "abc", "ab")]
        [InlineData("pabc", "abc", "ab")]
        [InlineData("abc", "abc", "pab")]
        [InlineData("abp", "apc", "abp")]
        [InlineData("apc", "pc", "ap")]
        public void SaveOnlyWordsThatStartWithP(params string[] values)
        {
            var c = new StringCollection(values);

            c.SaveOnlyP();

            foreach(string word in c)
            {
                Assert.Equal("p", word?.Substring(0, 1).ToLower());
            }
        }
    }
}
