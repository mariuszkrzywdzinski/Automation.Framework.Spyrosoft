using System;
using System.Collections.Generic;
using System.Linq;
using Automation.Framework.Spyrosoft.Extensions;
using Automation.Framework.Spyrosoft.Pages.Interfaces;
using OpenQA.Selenium;

namespace Automation.Framework.Spyrosoft.Pages.PartialPages
{
    public class ProductItem : IProductItem
    {
        private readonly IWebDriver _driver;

        public ProductItem(IWebDriver driver)
        {
            _driver = driver;
        }
        public Item this[string option] => GetByName(option);
        private IWebElement MainMenuContainer => _driver.WaitUntilElementIsReady(By.XPath(Controls.XPath.ProductContainer));

        public Item GetByName(string option)
        {
            IReadOnlyCollection<IWebElement> collection = MainMenuContainer.WaitUntilCollectionIsReady(By.XPath(Controls.XPath.ProductCard));

            if (collection.Any())
            {
                var element = collection?.Where(x => x.FindElement(By.TagName("h2")).Text.Equals(option)).First();
                return new Item(_driver, element);
            }

            throw new ArgumentOutOfRangeException(nameof(option), "Product with given name cannot be found.");
        }
    }
}
