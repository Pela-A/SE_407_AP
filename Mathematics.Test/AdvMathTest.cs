using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathematics.Test
{
    public class AdvMathTest : IClassFixture<AdvMathTestFixture>
    {

        // Create a fixture/class access point for various unit test functions
        private AdvMathTestFixture _fixture;

        public AdvMathTest(AdvMathTestFixture fixture)
        {
            _fixture = fixture;
        }


        // Test area function
        [Fact]
        public void TestArea()
        {
            
            var result = _fixture.TestObject.CalculateArea(5, 4);
            Assert.True(result == 20);
        }

        // Test average function
        [Fact]
        public void TestAverage()
        {
            double[] listDouble = { 3, 4, 5, 6, 8 };
            var result = _fixture.TestObject.CalculateAverage(listDouble);
           
            Assert.True(result == 5.2);
        }

        // Test square function
        [Fact]
        public void TestSquare()
        {
            var result = _fixture.TestObject.CalculateSquare(7);
            Assert.True(result == 49);
        }

        // Test pythagorean theorem solver function
        [Fact]
        public void TestPythagorean()
        {
            var result = _fixture.TestObject.CalculatePythagorean(3, 4);
            Assert.True(result == 5);
        }
    }
}
