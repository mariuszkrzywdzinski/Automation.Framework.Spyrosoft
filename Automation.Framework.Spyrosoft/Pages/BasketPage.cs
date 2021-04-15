using Automation.Framework.Spyrosoft.Pages.Interfaces;
using OpenQA.Selenium;

namespace Automation.Framework.Spyrosoft.Pages
{
    public sealed class BasketPage : Page, IBasketPage
    {
        private IWebDriver _driver;

        public BasketPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void ClickRemoveItem()
        {
            base.GetElementByXpath(Controls.XPath.RemoveItemButton).Click();
        }

        public bool IsYourBasketIsEmptyMessageDisplayed()
        {
            return base.GetElementByXpath(Controls.XPath.BasketEmptyConfirmationMessage).Text
                .Equals(Controls.StaticText.YourBasketIsEmpty);
        }
    }
}
