using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace UX.Testing.Selenium.Extensions
{
    public static class WebElementExtensions
    {
        public static void SendKeys(this IWebElement element, string value, bool clearFirst)
        {
            if (clearFirst) element.Clear();
            element.SendKeys(value);
        }

        public static bool HasElement(this IWebElement element, By by)
        {
            try
            {
                element.FindElement(by);
            }
            catch (NoSuchElementException)
            {
                return false;
            }

            return true;
        }

        public static void SetAttribute(this IWebElement element, string attributeName, string value)
        {
            IWrapsDriver wrappedElement = element as IWrapsDriver;
            if (wrappedElement == null)
                throw new ArgumentException("element", "Element must wrap a web driver");

            IWebDriver driver = wrappedElement.WrappedDriver;
            IJavaScriptExecutor javascript = driver as IJavaScriptExecutor;
            if (javascript == null)
                throw new ArgumentException("element", "Element must wrap a web driver that supports javascript execution");

            javascript.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])", element, attributeName, value);
        }

        public static T GetAttributeAsType<T>(this IWebElement element, string attributeName)
        {
            string value = element.GetAttribute(attributeName) ?? string.Empty;
            return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(value);
        }

        public static T TextAsType<T>(this IWebElement element)
        {
            string value = element.Text;
            return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(value);
        }

        public static bool IsElementVisible(this IWebElement element)
        {
            return element.Displayed && element.Enabled;
        }

		public static bool IsElementEnabled(this IWebElement element)
		{
			return element.Enabled;
		}

    }
    
}
