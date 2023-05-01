using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTesting
{
    public interface ICalculatorMethods
    {
        public string GetCalculatorResultText();
        public WindowsElement FindElementByName(string name);
        public void Sleep(int num);
        public void Quit();
    }
}
