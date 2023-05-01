using log4net;
using System.Diagnostics;


namespace CalculatorTesting
{

    public class BaseCalculatorTesting : ICalcTesting
    {
        private CalculatorMethods driver;
        private static readonly ILog log = LogManager.GetLogger("RollingFileAppender");

        public void SetupLogging()
        {
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));
        }

        public void StartWindowsApplicationDriver()
        {
            log.Info("ClassInitialize()");
            Process.Start(@"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe");
        }

        public void StartCalculatorDriver()
        {
            log.Info("Before");
            driver = new CalculatorMethods();
        }

        public void RunCalculatorTest()
        {
            log.Info("ShouldTesting()");
            driver.FindElementByName(CalculatorVariables.два).Click();
            driver.FindElementByName(CalculatorVariables.плюс).Click();
            driver.FindElementByName(CalculatorVariables.два).Click();
            driver.FindElementByName(CalculatorVariables.равно).Click();
            Assert.AreEqual("Отображать как 4", driver.GetCalculatorResultText());
            driver.Sleep(2000);
        }

        public void QuitCalculatorDriver()
        {
            log.Info("Cleanup");
            try
            {
                driver.Quit();
            }
            catch (Exception ex)
            {
                log.Error($"Exception during cleanup: {ex}");
            }
        }

        public void StopWindowsApplicationDriver()
        {
            log.Info("WinAppDriver close");
            // Завершение процесса WinAppDriver после выполнения всех тестов.
            var winAppDriverProcesses = Process.GetProcesses().Where(p => p.ProcessName == "WinAppDriver");

            foreach (var process in winAppDriverProcesses)
            {
                process.Kill();
            }

        }

        public void Dispose()
        {
            LogManager.Shutdown();
        }
    }
}



