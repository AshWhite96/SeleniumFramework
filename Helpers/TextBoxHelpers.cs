using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFramework.Helpers
{
    public class TextBoxHelpers
    {
        private static IWebElement? element;

        public static void TypeInTextBox(IWebDriver driver, By locator, string inputText)
        {
            element = GenericHelpers.GetElement(driver, locator);
            element.SendKeys(inputText);
        }
    }
}
