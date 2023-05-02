using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using System.Diagnostics;

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
                    Process.Start(@"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe");
                    AppiumOptions options = new();
                    options.AddAdditionalCapability("app", DriverVariables.calculatorAppId);
                    options.AddAdditionalCapability("deviceName", DriverVariables.deviceNameWindowsdPS);
                    driver = new WindowsDriver<WindowsElement>(new Uri(DriverVariables.windowsApplicationDriverUrl), options);
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
