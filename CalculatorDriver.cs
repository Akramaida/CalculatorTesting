using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;

namespace CalculatorTesting
{
    public class CalculatorDriver : ICalculatorDriver
    {
        protected WindowsDriver<WindowsElement>? driver;

        public CalculatorDriver()
        {
            try
            {
                if (driver == null)
                {
                    AppiumOptions options = new AppiumOptions();
                    options.AddAdditionalCapability("app", CalculatorVariables.calculatorAppId);
                    options.AddAdditionalCapability("deviceName", CalculatorVariables.deviceNameWindowsdPS);
                    driver = new WindowsDriver<WindowsElement>(new Uri(CalculatorVariables.windowsApplicationDriverUrl), options);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error initializing WindowsDriver: " + ex.Message);
                throw;
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
