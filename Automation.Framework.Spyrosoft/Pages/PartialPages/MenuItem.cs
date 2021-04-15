using System;
using System.Collections.Generic;
using System.Linq;
using Automation.Framework.Spyrosoft.Extensions;
using Automation.Framework.Spyrosoft.Pages.Interfaces;
using OpenQA.Selenium;

namespace Automation.Framework.Spyrosoft.Pages.PartialPages
{
    public class MenuItem : IMenuItem
    {
        private IWebDriver _driver;
        public MenuItem(IWebDriver driver)
        {
            _driver = driver;
        }

        //using string indexer, menu options can be selected by name
        public Item this[string index] => GetByName(index);
        private IWebElement MainMenuContainer => _driver.WaitUntilElementIsReady(By.XPath(Controls.XPath.MenuContainer));

        public Item GetByName(string option)
        {
            IReadOnlyCollection<IWebElement> collection = MainMenuContainer.WaitUntilCollectionIsReady(By.XPath(Controls.XPath.MenuItemLevel1));

            if (collection.Any())
                return new Item(_driver, collection?.Where(elements => elements.Displayed).First(item => item.Text.Equals(option)));

            throw new ArgumentOutOfRangeException(nameof(option), "Menu item with given name cannot be found.");
        }
    }
}
