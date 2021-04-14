using OpenQA.Selenium;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Automation.Framework.Spyrosoft.Configuration
{
    [Binding]
    public class Hooks
    {
        private readonly IWebDriver _driver;

        public Hooks(IWebDriver driver)
        {
            _driver = driver;
        }

        [BeforeScenario]
        public void SetUp()
        {
            _driver.Manage().Window.Maximize();
            _driver.Url = ConfigurationManager.AppSettings["BaseUrl"];
        }

        [AfterScenario]
        public void CleanUp()
        {
            _driver.Manage().Cookies.DeleteAllCookies();
            _driver.Close();
            _driver.Quit();
            _driver.Dispose();
        }
    }
}