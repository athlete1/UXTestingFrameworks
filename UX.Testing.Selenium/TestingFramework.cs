// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestingFramework.cs" company="">
//   
// </copyright>
// <summary>
//   The testing framework.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;

namespace UX.Testing.Selenium
{
	using System;
	using System.Runtime.InteropServices;

	using UX.Testing.Core.Logging;
	using UX.Testing.Core.TestFramework;

	/// <summary>The testing framework.</summary>
	public class TestingFramework : ITestingFramework
	{
		private static Core.TestFramework.Browser browser;

		/// <summary>Initializes a new instance of the <see cref="TestingFramework"/> class.</summary>
		public TestingFramework()
		{
			this.Logger = new Logger();
		}

		/// <summary>Gets the logger.</summary>
		public ILogger Logger { get; private set; }

		/// <summary>Gets the browser.</summary>
		public Core.TestFramework.Browser Browser
		{
			get
			{
				return browser;
			}

			private set
			{
				browser = value;
			}
		}

		/// <summary>The initialize.</summary>
		/// <param name="browserType">The browser type.</param>
		/// <param name="baseUrl">The base url.</param>
		public void Initialize(Core.TestFramework.Browser.BrowserType browserType, string baseUrl)
		{
			this.Logger.Trace("Setting Browser to {0}", browserType);
			var driver = this.MapWebDriver(browserType);
			try
			{
				driver.Manage().Window.Maximize();
			}
			catch (WebDriverException)
			{
				// Headless browsers and environments without a window manager cannot maximize.
			}

		    this.Browser = new Browser(driver);
			this.Logger.Trace("Launching browser...");
	        this.Browser.NavigateTo(baseUrl);
		}

		/// <summary>The cleanup.</summary>
		public void Cleanup()
		{
			this.Logger.Trace("Closing browser...");
			this.Browser?.Close();
		}

		/// <summary>The map browser type.</summary>
		/// <param name="browserType">The browser type.</param>
		/// <returns>The <see cref="IWebDriver"/>.</returns>
		private IWebDriver MapWebDriver(Core.TestFramework.Browser.BrowserType browserType)
		{
			var commandTimeout = TimeSpan.FromMilliseconds(TestSettings.Instance.CommandTimeout);
			switch (browserType)
			{
				case Core.TestFramework.Browser.BrowserType.Chrome:
					return new ChromeDriver(ChromeDriverService.CreateDefaultService(), CreateChromeOptions(false), commandTimeout);
				case Core.TestFramework.Browser.BrowserType.FireFox:
					return new FirefoxDriver(FirefoxDriverService.CreateDefaultService(), new FirefoxOptions(), commandTimeout);
				case Core.TestFramework.Browser.BrowserType.InternetExplorer:
					var ieOptions = new InternetExplorerOptions
										{
											IntroduceInstabilityByIgnoringProtectedModeSettings = true
										};
					return new InternetExplorerDriver(InternetExplorerDriverService.CreateDefaultService(), ieOptions, commandTimeout);
				case Core.TestFramework.Browser.BrowserType.Safari:
					return new SafariDriver(new SafariOptions());
				case Core.TestFramework.Browser.BrowserType.Edge:
					return new EdgeDriver(EdgeDriverService.CreateDefaultService(), new EdgeOptions(), commandTimeout);
#pragma warning disable CS0618
				case Core.TestFramework.Browser.BrowserType.PhantomJS:
					this.Logger.Warn("PhantomJS is no longer supported. Launching Chrome in headless mode instead.");
					return new ChromeDriver(ChromeDriverService.CreateDefaultService(), CreateChromeOptions(true), commandTimeout);
#pragma warning restore CS0618
				default:
					throw new NotSupportedException("Unsupported browser type: " + browserType);
			}
		}

		private static ChromeOptions CreateChromeOptions(bool headless)
		{
			var options = new ChromeOptions();
			if (headless)
			{
				options.AddArgument("--headless=new");
				options.AddArgument("--window-size=1920,1080");
			}

			if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
			{
				options.AddArgument("--no-sandbox");
				options.AddArgument("--disable-dev-shm-usage");
			}

			return options;
		}
	}
}
