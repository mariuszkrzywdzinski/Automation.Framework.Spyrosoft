using Automation.Framework.Spyrosoft.Pages.Interfaces;
using OpenQA.Selenium;

namespace Automation.Framework.Spyrosoft.Pages
{
    public class ProductGridPage : IProductGridPage
    {
        private readonly IWebDriver _driver;
        private IProductItem _productItem;

        public ProductGridPage(IWebDriver driver, IProductItem productItem)
        {
            _driver = driver;
            _productItem = productItem;
        }

        public void SelectProduct(string productName)
        {
            _productItem[productName].Click();
        }
    }
}
