using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathematics.Test
{
    public class AdvMathTestFixture : IDisposable
    {
        private AdvMath _testObject;

        public AdvMath TestObject { get => _testObject; }



        public AdvMathTestFixture()
        {
            _testObject = new AdvMath();
        }
        public void Dispose()
        {
            
        }
    }
}
