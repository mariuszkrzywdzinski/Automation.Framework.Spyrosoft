using System;
using Automation.Framework.Spyrosoft.Extensions;
using Automation.Framework.Spyrosoft.Pages.Interfaces;
using OpenQA.Selenium;

namespace Automation.Framework.Spyrosoft.Pages
{
    public abstract class Page : IPage
    {
        private readonly IWebDriver _driver;

        protected Page(IWebDriver driver)
        {
            _driver = driver;
        }

        public virtual string GetPageTitle()
        {
            return this._driver.Title;
        }

        /// <summary>
        /// Find element on page using fluent wait
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="timeout">Waiting for element [seconds]</param>
        /// <param name="pooling">Repeating time [milliseconds]</param>
        /// <returns></returns>
        public virtual IWebElement GetElementByXpath(string selector, int timeout = 10, int pooling = 1000)
        {
            try
            {
                return _driver.WaitUntilElementIsReady(By.XPath(selector), timeout, pooling);
            }
            catch (NoSuchElementException ex)
            {
                throw new NoSuchElementException($"Page: {_driver.Title}, element with selector: [{selector}] cannot be found. {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Unknown exception, element [{selector}] cannot be found. {ex.Message}");
            }
        }

        public virtual void ClickJs(string selector)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;
            executor.ExecuteScript("arguments[0].click();", this.GetElementByXpath(selector));
        }
    }
}
