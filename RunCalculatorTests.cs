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
        public void TestInitialize()
        {
            calculatorTesting = new BaseCalculatorTesting();
            calculatorTesting.SetupLogging();
            calculatorTesting.StartWindowsApplicationDriver();
            calculatorTesting.StartCalculatorDriver();
        }

        [TestMethod]
        public void TestCalculatorAddition()
        {
            calculatorTesting.RunCalculatorTest();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            calculatorTesting.QuitCalculatorDriver();
            calculatorTesting.StopWindowsApplicationDriver();
            calculatorTesting.Dispose();
        }
    }
}
