using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFramework.Helpers
{
    public class ButtonHelpers
    {
        public static IWebElement? element;

        public static void ClickButton(IWebDriver driver, By locator)
        {
            element = GenericHelpers.GetElement(driver, locator);
            element.Click();
        }
        public static void ClickButtonDirectly(IWebDriver driver, IWebElement ele)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", ele);
        }
    }
}
