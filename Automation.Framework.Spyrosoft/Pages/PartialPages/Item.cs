using System;
using System.Threading;
using Automation.Framework.Spyrosoft.Pages.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Automation.Framework.Spyrosoft.Pages.PartialPages
{
    public class Item : IItem
    {
        private readonly IWebDriver _driver;
        private readonly IWebElement _element;

        public Item(IWebDriver driver, IWebElement element)
        {
            _driver = driver;
            _element = element;
        }

        public void Click()
        {
            int attempts = 10;
            int timeout = 500;

            for (int i = 0; i < attempts; i++)
            {
                try
                {
                    _element.Click();
                    return;
                }
                catch (Exception e)
                {
                    if(i >= attempts)
                        throw new Exception("Cannot click element. " + e.Message);
                }
                Thread.Sleep(timeout);
            }
        }

        public void ClickJs()
        {
            int attempts = 10;
            int timeout = 500;

            for (int i = 0; i < attempts; i++)
            {
                try
                {
                    IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
                    jsExecutor.ExecuteScript("arguments[0].click();", _element);
                    return;
                }
                catch (Exception e)
                {
                    if (i >= attempts)
                        throw new Exception("Cannot click element. " + e.Message);
                }
                Thread.Sleep(timeout);
            }
        }

        public void Focus()
        {
            Thread.Sleep(1000);
            Actions action = new Actions(_driver);
            action.MoveToElement(_element).Build().Perform();
        }
    }
}
