using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Mathematics;

namespace Mathematics.Test
{
    // Unit testing for basic math class
    public class BasicMathTest : IClassFixture<BasicMathTestFixture>
    {
        private BasicMathTestFixture _fixture;
        


        public BasicMathTest(BasicMathTestFixture fixture)
        {
            _fixture = fixture;
        }



        [Theory]
        [InlineData(3, 5, 8)]
        [InlineData(5, 10, 15)]
        [InlineData(2,2,4)]
        [InlineData(10000, 567, 10567)]
        public void TestAddTwoNumbers(double num1, double num2, double expectedResults)
        {
            double result = _fixture.TestObject.AddNumbers(num1, num2);
            Assert.Equal(expectedResults, result);
        }

        [Fact]
        public void TestAddNumbers()
        {
            
            var result = _fixture.TestObject.AddNumbers(5, 5);
            Assert.True(result == 10);
        }

        [Fact]
        public void TestSubtractNumbers()
        {
            
            var result = _fixture.TestObject.SubtractNumbers(10, 3);
            Assert.True(result == 7);
        }

        [Fact]
        public void TestMultiplyNumbers()
        {
            
            var result = _fixture.TestObject.MultiplyNumbers(6, 5);
            Assert.True(result == 30);
        }

        [Fact]
        public void TestDivideNumbers()
        {
            
            var result = _fixture.TestObject.DivideNumbers(50, 5);
            Assert.True(result == 10);
        }
    }
}
