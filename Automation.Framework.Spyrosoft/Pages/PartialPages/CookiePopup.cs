using System.Net;
using Automation.Framework.Spyrosoft.Extensions;
using Automation.Framework.Spyrosoft.Pages.Interfaces;
using OpenQA.Selenium;

namespace Automation.Framework.Spyrosoft.Pages.PartialPages
{
    public sealed class CookiePopup : ICookiePopup
    {
        private readonly IWebDriver _driver;
        private IWebElement CookieContainer => GetCookieContainer();

        public CookiePopup(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool IsCookiesPopupVisible(bool shouldBe = true)
        {
            if (shouldBe)
                return _driver.IsElementDisplayed(By.XPath(Controls.XPath.CookiesPopupContainer), shouldBe: shouldBe);
            else
            {

                return _driver.IsElementNotDisplayed(By.XPath(Controls.XPath.CookiesPopupContainer), shouldBe: shouldBe);
            }
        }

        public void ClickAllowAll()
        {
            if (_driver.IsElementDisplayed(By.XPath(Controls.XPath.AllowAllPopupButton)))
                CookieContainer.FindElement(By.XPath(Controls.XPath.AllowAllPopupButton)).Click();
            else
                throw new NoSuchElementException($"Element with xpath {Controls.XPath.AllowAllPopupButton} cannot be found after given time.");
        }

        private IWebElement GetCookieContainer()
        {
           // if (IsCookiePopupDisplayed())
                return _driver.FindElement(By.XPath(Controls.XPath.CookiesPopupContainer));

            throw new NoSuchElementException($"Element with xpath {Controls.XPath.CookiesPopupContainer} cannot be found after given time.");
        }
    }
}
