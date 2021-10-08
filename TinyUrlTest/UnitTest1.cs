using System;
using TinyUrlBL;
using Xunit;

namespace TinyUrlTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            ITinyUrl obj = new TinyUrl();
            string op = obj.GenerateTinyUrl("");
            string expected = "bitly/BWGU80";

            Assert.Equal(op, expected);
        }
    }
}
