using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UX.Testing.HtmlAgilityPack
{
	using UX.Testing.Core.Logging;
	using UX.Testing.Core.TestFramework;

	using global::HtmlAgilityPack;

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
			this.Browser = new Browser(new HtmlDocument());
			this.Logger.Trace("Launching browser document...");
		}

		public void Cleanup()
		{
			this.Logger.Trace("Closing browser document...");
			this.Browser.Close();
		}
	}
}
