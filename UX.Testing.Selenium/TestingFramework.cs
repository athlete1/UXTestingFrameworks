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
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;

namespace UX.Testing.Selenium
{
	using System;
	using System.Configuration;
	using System.IO;
	using System.Reflection;

	using UX.Testing.Core.Logging;
	using UX.Testing.Core.TestFramework;

	using OpenQA.Selenium.PhantomJS;
	using OpenQA.Selenium.Remote;

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
			this.InitializeResources();
			this.Logger.Trace("Setting Browser to {0}", browserType);
			var driver = this.MapWebDriver(browserType);
			driver.Manage().Window.Maximize();
		    this.Browser = new Browser(driver);
			this.Logger.Trace("Launching browser...");
	        this.Browser.NavigateTo(baseUrl);
		}

		private void InitializeResources()
		{
			ExtractManifestResourceToDisk("chromedriver.exe", @".\chromedriver.exe");
			ExtractManifestResourceToDisk("IEDriverServer.exe", @".\IEDriverServer.exe");
			ExtractManifestResourceToDisk("phantomjs.exe", @".\phantomjs.exe");
			ExtractManifestResourceToDisk("jquery.min.js", @".\jquery.min.js");
		}

		private static void ExtractManifestResourceToDisk(string relativeManifestUri, string targetPath)
		{
			var assembly = Assembly.GetCallingAssembly();

			if (File.Exists(targetPath))
				return;

			var targetFolder = Path.GetDirectoryName(targetPath);
			Directory.CreateDirectory(targetFolder);

			var uri = String.Format("{0}.{1}", assembly.GetName().Name, relativeManifestUri);

			using (Stream input = assembly.GetManifestResourceStream(uri))
			using (Stream output = File.Create(targetPath))
			{
				input.CopyTo(output);
			}
		}

		/// <summary>The cleanup.</summary>
		public void Cleanup()
		{
			this.Logger.Trace("Closing browser...");
		    this.Browser.Close();
		}

		/// <summary>The map browser type.</summary>
		/// <param name="browserType">The browser type.</param>
		/// <returns>The <see cref="IWebDriver"/>.</returns>
		private IWebDriver MapWebDriver(Core.TestFramework.Browser.BrowserType browserType)
		{
			string webDriverPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			var commandTimeout = TimeSpan.FromMilliseconds(TestSettings.Instance.CommandTimeout);
			switch (browserType)
			{
				case Core.TestFramework.Browser.BrowserType.Chrome:
					return new ChromeDriver(webDriverPath, new ChromeOptions(), commandTimeout);
				case Core.TestFramework.Browser.BrowserType.FireFox:
					return new FirefoxDriver(new FirefoxBinary(), null, commandTimeout);
				case Core.TestFramework.Browser.BrowserType.InternetExplorer:
                    return new InternetExplorerDriver(webDriverPath, new InternetExplorerOptions() { IntroduceInstabilityByIgnoringProtectedModeSettings = true }, commandTimeout);
				case Core.TestFramework.Browser.BrowserType.Safari:
					return new SafariDriver(new SafariOptions() { });
				case Core.TestFramework.Browser.BrowserType.PhantomJS:
					return new PhantomJSDriver(webDriverPath, new PhantomJSOptions(), commandTimeout);
				default:
					throw new NotSupportedException("Unsupported browser type: " + browserType);
			}
		}
	}
}