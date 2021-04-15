using Automation.Framework.Spyrosoft.Extensions;
using Automation.Framework.Spyrosoft.Pages.Interfaces;
using OpenQA.Selenium;

namespace Automation.Framework.Spyrosoft.Pages
{
    public sealed class ProductPage : Page, IProductPage
    {
        private readonly IWebDriver _driver;

        public ProductPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void ClickIncreaseTo(int quantity = 1)
        {
            int currentValue = 1;
            while (currentValue != quantity)
            {
                base.ClickJs(Controls.XPath.QuantityIncreaseButton);
                currentValue = GetCurrentValue();
            }
        }

        public void ClickAddToYourBasket()
        {
            base.ClickJs(Controls.XPath.AddToYourBasketButton);
        }

        public void ClickGoToYourBasket()
        {
            base.ClickJs(Controls.XPath.GoToYourBasketButton);
        }

        private int GetCurrentValue()
        {
            var element = base.GetElementByXpath(Controls.XPath.QuantityInput);
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;

            if (!int.TryParse(
                jsExecutor.ExecuteScript("return arguments[0].value", element)
                    .ToString(), out int currentValue))
            {
                throw new JavaScriptException("Quantity parsing failed.");
            }

            return currentValue;
        }

        public string GetProductHeaderTitle()
        {
            return GetElementByXpath(Controls.XPath.ProductHeaderTitle).Text;
        }

        public bool IsConfirmationMessageDisplayed()
        {
            return _driver.WaitUntilElementIsReady(By.XPath(Controls.XPath.ProductConfirmationMessage)).Displayed;
        }
    }
}
