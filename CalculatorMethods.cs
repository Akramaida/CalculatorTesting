using OpenQA.Selenium.Appium.Windows;

namespace CalculatorTesting
{
    public class CalculatorMethods : ICalculatorMethods
    {
        private readonly CalculatorDriver calculatorDriver;
        private WindowsDriver<WindowsElement> driver;

        public CalculatorMethods()
        {

            calculatorDriver = new CalculatorDriver();
            driver = calculatorDriver.GetCalculatorDriver();
          
        }

        public string GetCalculatorResultText()
        {
            return driver.FindElementByAccessibilityId(CalculatorVariables.calculatorResultsText).Text;
        }

        public WindowsElement FindElementByName(string name)
        {
            return driver.FindElementByName(name);
        }

        public void Sleep(int num)
        {
            Thread.Sleep(num);
        }

        public void Quit()
        {
            driver?.Quit();
            driver = null;
        }
    }
}
