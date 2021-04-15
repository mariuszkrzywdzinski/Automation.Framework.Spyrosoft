using Automation.Framework.Spyrosoft.Pages.Interfaces;
using OpenQA.Selenium;

namespace Automation.Framework.Spyrosoft.Pages
{
    public sealed class MainPage : Page, IMainPage
    {
        private readonly IWebDriver _driver;
        private readonly IMenuItem _menuItem;

        public MainPage(IWebDriver driver, IMenuItem menuItem) : base(driver)
        {
            _driver = driver;
            _menuItem = menuItem;
        }

        public void SelectMainMenuOption(string option)
        {
            this._menuItem[option].Focus();
            this._menuItem[option].Click();
        }
    }
}
