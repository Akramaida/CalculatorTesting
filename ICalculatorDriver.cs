using OpenQA.Selenium.Appium.Windows;

public interface ICalculatorDriver
{
    WindowsElement FindElementByName(string name);
    string GetCalculatorResultText();
    void Quit();
    void Sleep(int num);
}

