using log4net;

namespace CalculatorTesting
{
    [TestClass]
    public class BaseCalculatorTesting
    {
        private CalculatorDriver driver;
        private static readonly ILog log = LogManager.GetLogger("RollingFileAppender");

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));
            log.Info("ClassInitialize()");
            System.Diagnostics.Process.Start(@"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe");
        }

        [TestInitialize]
        public void Before()
        {
            log.Info("Before");
            driver = new CalculatorDriver();
        }

        [TestMethod]
        public void ShouldTesting()
        {
            log.Info("ShouldTesting()");
            driver.FindElementByName(CalculatorVariables.два).Click();
            driver.FindElementByName(CalculatorVariables.плюс).Click();
            driver.FindElementByName(CalculatorVariables.два).Click();
            driver.FindElementByName(CalculatorVariables.равно).Click();
            Assert.AreEqual("Отображать как 4", driver.GetCalculatorResultText());
            driver.Sleep(2000);
        }

        [TestCleanup]
        public void ShouldCleanup()
        {
            log.Info("Cleanup");
            driver.Quit();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            log.Info("WinAppDriver close");
            // Завершение процесса WinAppDriver после выполнения всех тестов.
            var winAppDriverProcesses = System.Diagnostics.Process.GetProcesses().Where(p => p.ProcessName == "WinAppDriver");

            foreach (var process in winAppDriverProcesses)
            {
                process.Kill();
                log4net.LogManager.Shutdown();
            }
        }
    }
}


