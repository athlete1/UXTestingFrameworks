// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestSettings.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the Settings type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core
{
	using System;
	using System.Configuration;

	using UX.Testing.Core.TestFramework;

	/// <summary>The settings.</summary>
	public class TestSettings : ConfigurationSection
	{
		/// <summary>Gets or sets the base url.</summary>
		[ConfigurationProperty("baseUrl", DefaultValue = "", IsRequired = true)]
		public string BaseUrl
		{
			get
			{
				// appsetting override to support legacy test framework test runner code
				var baseurl = ConfigurationManager.AppSettings["BaseUrl"];
				if (!string.IsNullOrEmpty(baseurl))
				{
					return baseurl;
				}

				return (string)this["baseUrl"];
			}

			set
			{
				this["baseUrl"] = value;
			}
		}

		/// <summary>Gets or sets the browser.</summary>
		[ConfigurationProperty("browser", DefaultValue = "InternetExplorer", IsRequired = true)]
		private string BrowserInternal
		{
			get
			{
				return (string)this["browser"];
			}

			set
			{
				this["browser"] = value;
			}
		}

		/// <summary>Gets or sets the browser.</summary>
		public Browser.BrowserType Browser
		{
			get
			{
				// appsetting override to support legacy test framework test runner code
				Browser.BrowserType browser;
				var browserSetting = ConfigurationManager.AppSettings["Browser"];
				if (!string.IsNullOrEmpty(browserSetting) && Enum.TryParse(browserSetting, true, out browser))
				{
					return browser;
				}

				if (Enum.TryParse(this.BrowserInternal, true, out browser))
				{
					return browser;
				}

				return TestFramework.Browser.BrowserType.InternetExplorer;
			}

			set
			{
				this.BrowserInternal = value.ToString();
			}
		}

		/// <summary>Gets or sets the interval.</summary>
		[ConfigurationProperty("interval", DefaultValue = 500, IsRequired = true)]
		public int Interval
		{
			get
			{
				return (int)this["interval"];
			}

			set
			{
				this["interval"] = value;
			}
		}

		/// <summary>Gets or sets the timeout.</summary>
		[ConfigurationProperty("timeout", DefaultValue = 5000, IsRequired = true)]
		public int Timeout
		{
			get
			{
				return (int)this["timeout"];
			}

			set
			{
				this["timeout"] = value;
			}
		}

		/// <summary>Gets or sets the provider.</summary>
		[ConfigurationProperty("provider")]
		public Provider Provider
		{
			get
			{
				return (Provider)this["provider"];
			}

			set
			{
				this["provider"] = value;
			}
		}

		/// <summary>Gets the instance.</summary>
		public static TestSettings Instance
		{
			get
			{
				return (TestSettings)ConfigurationManager.GetSection("testSettings");
			}
		}

		[ConfigurationProperty("debug", DefaultValue = false, IsRequired = false)]
		public bool Debug
		{
			get
			{
				return (bool)this["debug"];
			}

			set
			{
				this["debug"] = value;
			}
		}

		[ConfigurationProperty("DisableDiagnosticLogging", DefaultValue = false, IsRequired = false)]
		public bool DisableDiagnosticLogging
		{
			get
			{
				var screencapture = ConfigurationManager.AppSettings["DisableDiagnosticLogging"];
				if (!string.IsNullOrEmpty(screencapture))
				{
					return bool.Parse(screencapture);
				}

				return (bool)this["DisableDiagnosticLogging"];
			}

			set
			{
				this["DisableDiagnosticLogging"] = value;
			}
		}

		[ConfigurationProperty("screencapture", DefaultValue = false, IsRequired = false)]
		public bool ScreenCapture
		{
			get
			{
				var screencapture = ConfigurationManager.AppSettings["screencapture"];
				if (!string.IsNullOrEmpty(screencapture))
				{
					return bool.Parse(screencapture);
				}

				return (bool)this["screencapture"];
			}

			set
			{
				this["screencapture"] = value;
			}
		}

		[ConfigurationProperty("autowaitforpageload", DefaultValue = false, IsRequired = false)]
		public bool AutoWaitForPageLoad
		{
			get
			{
				var autowaitforpageload = ConfigurationManager.AppSettings["autowaitforpageload"];
				if (!string.IsNullOrEmpty(autowaitforpageload))
				{
					return bool.Parse(autowaitforpageload);
				}

				return (bool)this["autowaitforpageload"];
			}

			set
			{
				this["autowaitforpageload"] = value;
			}
		}

		[ConfigurationProperty("ScrollToMiddleWaitTime", DefaultValue = 500, IsRequired = false)]
		public int ScrollToMiddleWaitTime
		{
			get
			{
				var waitTime = ConfigurationManager.AppSettings["ScrollToMiddleWaitTime"];
				if (!string.IsNullOrEmpty(waitTime))
				{
					return int.Parse(waitTime);
				}

				return (int)this["ScrollToMiddleWaitTime"];
			}

			set
			{
				this["ScrollToMiddleWaitTime"] = value;
			}
		}

		[ConfigurationProperty("MouseOverWaitTime", DefaultValue = 150, IsRequired = false)]
		public int MouseOverWaitTime
		{
			get
			{
				var waitTime = ConfigurationManager.AppSettings["MouseOverWaitTime"];
				if (!string.IsNullOrEmpty(waitTime))
				{
					return int.Parse(waitTime);
				}

				return (int)this["MouseOverWaitTime"];
			}

			set
			{
				this["MouseOverWaitTime"] = value;
			}
		}

		[ConfigurationProperty("MouseOutWaitTime", DefaultValue = 150, IsRequired = false)]
		public int MouseOutWaitTime
		{
			get
			{
				var waitTime = ConfigurationManager.AppSettings["MouseOutWaitTime"];
				if (!string.IsNullOrEmpty(waitTime))
				{
					return int.Parse(waitTime);
				}

				return (int)this["MouseOutWaitTime"];
			}

			set
			{
				this["MouseOutWaitTime"] = value;
			}
		}

		[ConfigurationProperty("MouseHoverWaitTime", DefaultValue = 150, IsRequired = false)]
		public int MouseHoverWaitTime
		{
			get
			{
				var waitTime = ConfigurationManager.AppSettings["MouseHoverWaitTime"];
				if (!string.IsNullOrEmpty(waitTime))
				{
					return int.Parse(waitTime);
				}

				return (int)this["MouseHoverWaitTime"];
			}

			set
			{
				this["MouseHoverWaitTime"] = value;
			}
		}

		[ConfigurationProperty("MouseLeaveWaitTime", DefaultValue = 150, IsRequired = false)]
		public int MouseLeaveWaitTime
		{
			get
			{
				var waitTime = ConfigurationManager.AppSettings["MouseLeaveWaitTime"];
				if (!string.IsNullOrEmpty(waitTime))
				{
					return int.Parse(waitTime);
				}

				return (int)this["MouseLeaveWaitTime"];
			}

			set
			{
				this["MouseLeaveWaitTime"] = value;
			}
		}

		[ConfigurationProperty("MouseEnterWaitTime", DefaultValue = 150, IsRequired = false)]
		public int MouseEnterWaitTime
		{
			get
			{
				var waitTime = ConfigurationManager.AppSettings["MouseEnterWaitTime"];
				if (!string.IsNullOrEmpty(waitTime))
				{
					return int.Parse(waitTime);
				}

				return (int)this["MouseEnterWaitTime"];
			}

			set
			{
				this["MouseEnterWaitTime"] = value;
			}
		}
	}

	/// <summary>The provider.</summary>
	public class Provider : ConfigurationElement
	{
		/// <summary>Gets or sets the assembly.</summary>
		[ConfigurationProperty("assembly", DefaultValue = "", IsRequired = true)]
		public string Assembly
		{
			get
			{
				return (string)this["assembly"];
			}

			set
			{
				this["assembly"] = value;
			}
		}

		/// <summary>Gets or sets the type.</summary>
		[ConfigurationProperty("type", DefaultValue = "", IsRequired = true)]
		public string Type
		{
			get
			{
				return (string)this["type"];
			}

			set
			{
				this["type"] = value;
			}
		}
	}
}