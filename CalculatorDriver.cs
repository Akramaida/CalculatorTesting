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
                    AppiumOptions options = new();
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

        public WindowsDriver<WindowsElement> GetCalculatorDriver()
        {
            return driver;
        }


    }

}
