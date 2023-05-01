using OpenQA.Selenium.Appium.Windows;

namespace CalculatorTesting
{
    public interface ICalculatorDriver
    {
        public WindowsDriver<WindowsElement> GetCalculatorDriver();
    }
}