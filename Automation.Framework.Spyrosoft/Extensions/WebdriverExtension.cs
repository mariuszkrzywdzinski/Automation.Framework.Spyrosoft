using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Automation.Framework.Spyrosoft.Extensions
{
    public static class WebDriverExtension
    {
        /// <summary>
        /// Fluent wait, it can be used for waiting for an element on page
        /// </summary>
        /// <param name="driver">WebDriver</param>
        /// <param name="timeout">checking timeout [seconds]</param>
        /// <param name="pooling">checking time interval [milliseconds]</param>
        public static IWebElement WaitUntilElementIsReady(this IWebDriver driver, By by, int timeout = 10, int pooling = 1000)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(timeout);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(pooling);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            return fluentWait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        public static IReadOnlyCollection<IWebElement> WaitUntilCollectionIsReady(this IWebDriver driver, By by, int timeout = 10, int pooling = 1000)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(timeout);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(pooling);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            return fluentWait.Until(x => x.FindElements(by));
        }

        public static IReadOnlyCollection<IWebElement> WaitUntilCollectionIsReady(this IWebElement element, By by, int timeout = 10, int pooling = 1000)
        {
            DefaultWait<IWebElement> fluentWait = new DefaultWait<IWebElement>(element);
            fluentWait.Timeout = TimeSpan.FromSeconds(timeout);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(pooling);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            return fluentWait.Until(x => x.FindElements(by));
        }

        public static IWebElement WaitUntilElementIsReady(this IWebElement element, By by, int timeout = 10, int pooling = 1000)
        {
            DefaultWait<IWebElement> fluentWait = new DefaultWait<IWebElement>(element);
            fluentWait.Timeout = TimeSpan.FromSeconds(timeout);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(pooling);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            return fluentWait.Until(x => x.FindElement(by));
        }

        public static bool IsElementDisplayed(this IWebDriver driver, By by, int timeout = 10, int pooling = 1000, bool shouldBe = true)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(timeout);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(pooling);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            if(!shouldBe)
                return fluentWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by)).Displayed;

            return fluentWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by)).Displayed;
        }

        public static bool IsElementNotDisplayed(this IWebDriver driver, By by, int timeout = 10, int pooling = 1000, bool shouldBe = true)
        {
            bool isVisible = true;
            int attempts = 10;

            while (isVisible != false && attempts > 0)
            {
                Thread.Sleep(pooling);
                isVisible = driver.FindElements(by).Any();

                if (attempts == 0)
                {
                    return false;
                }

                attempts--;
            }

            return true;
        }
    }
}
