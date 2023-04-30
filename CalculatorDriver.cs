using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;

namespace CalculatorTesting
{
    public class CalculatorDriver
    {
        protected WindowsDriver<WindowsElement>? driver;

        public CalculatorDriver()
        {
            if (driver == null)
            {
                AppiumOptions options = new AppiumOptions();
                options.AddAdditionalCapability("app", CalculatorVariables.calculatorAppId);
                options.AddAdditionalCapability("deviceName", CalculatorVariables.deviceNameWindowsdPS);
                driver = new WindowsDriver<WindowsElement>(new Uri(CalculatorVariables.windowsApplicationDriverUrl), options);
            }
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
