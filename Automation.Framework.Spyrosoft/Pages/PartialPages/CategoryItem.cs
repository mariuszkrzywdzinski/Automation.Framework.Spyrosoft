using System;
using System.Collections.Generic;
using System.Linq;
using Automation.Framework.Spyrosoft.Extensions;
using Automation.Framework.Spyrosoft.Pages.Interfaces;
using OpenQA.Selenium;

namespace Automation.Framework.Spyrosoft.Pages.PartialPages
{
    public class CategoryItem : ICategoryItem
    {
        private readonly IWebDriver _driver;

        public CategoryItem(IWebDriver driver)
        {
            _driver = driver;
        }

        public Item this[string option] => GetByName(option);
        private IWebElement MainMenuContainer => _driver.WaitUntilElementIsReady(By.XPath(Controls.XPath.CategoryContainer));

        public Item GetByName(string option)
        {
            IReadOnlyCollection<IWebElement> collection = MainMenuContainer.WaitUntilCollectionIsReady(By.XPath(Controls.XPath.CategoryItemLevel1));

            if (collection.Any())
                return new Item(_driver, collection?.Where(elements => elements.Displayed).First(item => item.Text.Equals(option)));

            throw new ArgumentOutOfRangeException(nameof(option), "Element with given index cannot be found.");
        }
    }
}
