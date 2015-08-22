using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace UX.Testing.Selenium.Extensions
{
	using System.IO;

	public static class SeleniumExtensions
    {
        /// <summary>
        /// Return whether jQuery is loaded in the current page
        /// </summary>
        public static bool jQueryLoaded(this IWebDriver driver)
        {
            bool result = false;
            try
            {

                result = (bool)((IJavaScriptExecutor)driver).ExecuteScript("return typeof jQuery == 'function'");

            }
            catch (WebDriverException)
            {
            }

            return result;
        }

        /// <summary>
        /// Load jQuery from an external URL to the current page
        /// </summary>
        public static void LoadjQuery(this IWebDriver driver, string version = "any", TimeSpan? timeout = null)
        {
            // Get the url to load jQuery from
            string jQueryURL = string.Empty;
	        if (version == "any" || string.IsNullOrEmpty(version))
	        {
		        jQueryURL = string.Empty;
	        }
	        else if (version.ToLower() == "latest")
	        {
				jQueryURL = "http://code.jquery.com/jquery-latest.min.js";
	        }
	        else
	        {
		        jQueryURL = "https://ajax.googleapis.com/ajax/libs/jquery/" + version + "/jquery.min.js";
	        }

	        // Script to load jQuery from external site
	        string versionEnforceScript = (version ?? string.Empty).ToLower() != "any"
											  ? string.Format("if (typeof jQuery == 'function' && jQuery.fn.jquery != '{0}') jQuery.noConflict(true);", version)
											  : string.Empty;
	        string loadingScript = string.Empty;
			if (string.IsNullOrWhiteSpace(jQueryURL))
			{
				string inlineScript = string.Empty;
				inlineScript =
					File.ReadAllText(
						Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "jquery.min.js"));


				loadingScript =
				@"if (typeof jQuery != 'function')
                  {
                      var headID = document.getElementsByTagName('head')[0];
                      var newScript = document.createElement('script');
                      newScript.type = 'text/javascript';
                      newScript.text = '" + inlineScript.Replace(@"\", @"\\").Replace("'", @"\'") + @"';
                      headID.appendChild(newScript);
                  }
                  return (typeof jQuery == 'function');";
			}
			else
			{
				loadingScript =
				@"if (typeof jQuery != 'function')
                  {
                      var headID = document.getElementsByTagName('head')[0];
                      var newScript = document.createElement('script');
                      newScript.type = 'text/javascript';
                      newScript.src = '" + jQueryURL + @"';
                      headID.appendChild(newScript);
                  }
                  return (typeof jQuery == 'function');";
			}
            
            bool loaded = (bool)((IJavaScriptExecutor)driver).ExecuteScript(versionEnforceScript + loadingScript);

            if (!loaded)
            {
                //Wait for the script to load
                //Verify library loaded
                if (!timeout.HasValue)
                    timeout = new TimeSpan(0, 0, 30);

                int timePassed = 0;
                while (!driver.jQueryLoaded())
                {
                    Thread.Sleep(500);
                    timePassed += 500;

                    if (timePassed > timeout.Value.TotalMilliseconds)
                        throw new Exception("Could not load jQuery");
                }
            }

            string v = ((IJavaScriptExecutor)driver).ExecuteScript("return jQuery.fn.jquery").ToString();
        }

        /// <summary>
        /// Overloads the FindElement function to include support for the jQuery selector class
        /// </summary>
        public static IWebElement FindElement(this IWebDriver driver, By.jQueryBy by)
        {
            //First make sure we can use jQuery functions
			driver.LoadjQuery();

            //Execute the jQuery selector as a script
            IWebElement element = ((IJavaScriptExecutor)driver).ExecuteScript("return jQuery" + by.Selector + ".get(0)") as IWebElement;

            if (element != null)
                return element;
            else
                throw new NoSuchElementException("No element found with jQuery command: jQuery" + by.Selector);
        }

        /// <summary>
        /// Overloads the FindElements function to include support for the jQuery selector class
        /// </summary>
        public static ReadOnlyCollection<IWebElement> FindElements(this IWebDriver driver, By.jQueryBy by)
        {
            //First make sure we can use jQuery functions
			driver.LoadjQuery();

            //Execute the jQuery selector as a script
            ReadOnlyCollection<IWebElement> collection = ((IJavaScriptExecutor)driver).ExecuteScript("return jQuery" + by.Selector + ".get()") as ReadOnlyCollection<IWebElement>;

            //Unlike FindElement, FindElements does not throw an exception if no elements are found
            //and instead returns an empty list
            if (collection == null)
                collection = new ReadOnlyCollection<IWebElement>(new List<IWebElement>()); //empty list

            return collection;
        }
    }
}
