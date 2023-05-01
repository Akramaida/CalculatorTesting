using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTesting
{
    [TestClass]
    public class RunCalculatorTests
    {
        private BaseCalculatorTesting calculatorTesting;

        [TestInitialize]
        public void ShouldInitialize()
        {
            calculatorTesting = new BaseCalculatorTesting();
            calculatorTesting.SetupLogging();
            calculatorTesting.StartCalculatorDriver();
            
        }

        [TestMethod]
        public void ShouldCalculatorAddition()
        {
            calculatorTesting.RunCalculatorTest();
        }

        [TestCleanup]
        public void ShouldCleanup()
        {
            calculatorTesting.QuitCalculatorDriver();
            calculatorTesting.StopWindowsApplicationDriver();
            calculatorTesting.Dispose();
        }
    }
}

