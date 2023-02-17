using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFramework.Helpers
{
    public class WaitHelpers
    {
        public static void WaitForUrl(IWebDriver driver, string url, int totalSeconds, int checkInterval)
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(1));
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(totalSeconds));
                wait.PollingInterval = TimeSpan.FromMilliseconds(checkInterval);
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
                wait.Until(ExpectedConditions.UrlToBe(url));
            }
            catch (WebDriverException ex)
            {
                throw;
            }
        }

        public static void WaitForUrlToContain(IWebDriver driver, string url, int totalSeconds, int checkInterval)
        {
            driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(1));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(totalSeconds));
            wait.PollingInterval = TimeSpan.FromMilliseconds(checkInterval);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            wait.Until(ExpectedConditions.UrlContains(url));
        }

        public static IWebElement WaitForElement(IWebDriver driver, By locator, int totalSeconds, int checkInterval)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(totalSeconds));
            wait.PollingInterval = TimeSpan.FromMilliseconds(checkInterval);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
            IWebElement element = GenericHelpers.GetElement(driver, locator);
            return element;
        }

        public static void WaitForElementToBeVisible(IWebDriver driver, By locator, int totalSeconds, int checkInterval)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(totalSeconds));
            wait.PollingInterval = TimeSpan.FromMilliseconds(checkInterval);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
    }
}
