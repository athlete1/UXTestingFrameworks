using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UX.Testing.Selenium
{
	using System.Linq;

	public static class WebDriverExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }

        public static ReadOnlyCollection<IWebElement> FindElements(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => (drv.FindElements(by).Count > 0) ? drv.FindElements(by) : null);
            }
            return driver.FindElements(by);
        }

        /// <summary>
        /// Find an element, waiting until a timeout is reached if necessary.
        /// </summary>
        /// <param name="context">The search context.</param>
        /// <param name="by">Method to find elements.</param>
        /// <param name="timeout">How many seconds to wait.</param>
        /// <param name="displayed">Require the element to be displayed?</param>
        /// <returns>The found element.</returns>
        public static IWebElement FindElement(this ISearchContext context, By by, uint timeout, bool displayed = false)
        {
            var wait = new DefaultWait<ISearchContext>(context);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return wait.Until(ctx =>
            {
                var elem = ctx.FindElement(by);
                if (displayed && !elem.Displayed)
                    return null;

                return elem;
            });
        }

        public static bool isPresent(this IWebDriver driver, By bylocator)
        {

            bool variable = false;
            try
            {
                IWebElement element = driver.FindElement(bylocator);
                variable = element != null;
            }
            catch (NoSuchElementException)
            {

            }
            return variable;
        }

        public static string GetBodyAsText(this IWebDriver driver)
        {
            return driver.FindElement(By.TagName("body")).Text;
        }

        public static bool HasElement(this IWebDriver driver, By by)
        {
            try
            {
                driver.FindElement(by);
            }
            catch (NoSuchElementException)
            {
                return false;
            }

            return true;
        }

	    public static void WaitForPageLoad(this IWebDriver driver, int maxWaitTimeInSeconds)
	    {
		    string state = string.Empty;
		    try
		    {
			    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(maxWaitTimeInSeconds));

			    // Checks every 500 ms whether predicate returns true if returns exit otherwise keep trying till it returns ture
			    wait.Until(
				    Delegate =>
				    {
						try
						{
							state = ((IJavaScriptExecutor)driver).ExecuteScript(@"return document.readyState").ToString();
						}
						catch (InvalidOperationException)
						{
							// Ignore
						}
						catch (NoSuchWindowException)
						{
							// when popup is closed, switch to last windows
							driver.SwitchTo().Window(driver.WindowHandles.Last());
						}

						// In IE7 there are chances we may get state as loaded instead of complete
						return state.Equals("complete", StringComparison.InvariantCultureIgnoreCase)
							|| state.Equals("loaded", StringComparison.InvariantCultureIgnoreCase);
				    });
		    }
		    catch (TimeoutException)
		    {
			    // sometimes Page remains in Interactive mode and never becomes Complete, then we can still try to access the controls
			    if (!state.Equals("interactive", StringComparison.InvariantCultureIgnoreCase))
			    {
				    throw;
			    }
		    }
		    catch (NullReferenceException)
		    {
			    // sometimes Page remains in Interactive mode and never becomes Complete, then we can still try to access the controls
			    if (!state.Equals("interactive", StringComparison.InvariantCultureIgnoreCase))
			    {
				    throw;
			    }
		    }
		    catch (WebDriverException)
		    {
			    if (driver.WindowHandles.Count == 1)
			    {
				    driver.SwitchTo().Window(driver.WindowHandles[0]);
			    }
			    state = ((IJavaScriptExecutor)driver).ExecuteScript(@"return document.readyState").ToString();
			    if (
				    !(state.Equals("complete", StringComparison.InvariantCultureIgnoreCase)
					    || state.Equals("loaded", StringComparison.InvariantCultureIgnoreCase)))
			    {
				    throw;
			    }
		    }
	    }

	    public static void WaitForPageToLoad(this IWebDriver driver)
        {
            TimeSpan timeout = new TimeSpan(0, 0, 30);
            WebDriverWait wait = new WebDriverWait(driver, timeout);

            IJavaScriptExecutor javascript = driver as IJavaScriptExecutor;
            if (javascript == null)
                throw new ArgumentException("driver", "Driver must support javascript execution");

            wait.Until((d) =>
            {
                try
                {
                    string readyState = javascript.ExecuteScript(
                    "if (document.readyState) return document.readyState;").ToString();
                    return readyState.ToLower() == "complete";
                }
                catch (InvalidOperationException e)
                {
                    //Window is no longer available
                    return e.Message.ToLower().Contains("unable to get browser");
                }
                catch (WebDriverException e)
                {
                    //Browser is no longer available
                    return e.Message.ToLower().Contains("unable to connect");
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

    }
}