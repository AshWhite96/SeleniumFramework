using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFramework.Helpers
{
    public class GenericHelpers
    {
        public static bool IsElementPresent(IWebDriver driver, By locator)
        {
            try
            {
                return driver.FindElements(locator).Count == 1;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public static IWebElement GetElement(IWebDriver driver, By locator)
        {
            if (IsElementPresent(driver, locator))
            {
                return driver.FindElement(locator);
            }
            else
            {
                throw new NoSuchElementException("Element not found: " + locator.ToString());
            }
        }

        public static IList<IWebElement> GetElements(IWebDriver driver, By locator)
        {
            return driver.FindElements(locator);
        }

        public static void ActionMoveToElementAndClickSeperateElement(IWebDriver driver, By moveElement, By clickElement)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(GenericHelpers.GetElement(driver, moveElement));
            action.Click(GenericHelpers.GetElement(driver, clickElement));
            action.Build();
            action.Perform();
        }

        public static void MoveToElement(IWebDriver driver, By locator)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(GenericHelpers.GetElement(driver, locator));
            action.Build();
            action.Perform();
        }

        public static void ClickOkayOnJSPopUp(IWebDriver driver)
        {
            driver.SwitchTo().Alert().Accept();
        }
    }
}
