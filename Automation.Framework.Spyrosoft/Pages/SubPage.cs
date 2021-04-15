using Automation.Framework.Spyrosoft.Pages.Interfaces;
using OpenQA.Selenium;

namespace Automation.Framework.Spyrosoft.Pages
{
    public class SubPage : Page, ISubPage
    {
        private readonly IWebDriver _driver;
        private ICategoryItem _categoryItem;

        public SubPage(IWebDriver driver, ICategoryItem categoryItem) : base(driver)
        {
            _driver = driver;
            _categoryItem = categoryItem;
        }

        public bool IsSubPageVisible(string name)
        {
            IWebElement element = base.GetElementByXpath(Controls.XPath.HeaderPage);

            return GetPageHeader().Equals(name);
        }
        public string GetPageHeader()
        {
            IWebElement element = base.GetElementByXpath(Controls.XPath.HeaderPage);

            return element.Text;
        }

        public void ClickCategory(string option)
        {
            _categoryItem[option].Click();
        }
    }
}
