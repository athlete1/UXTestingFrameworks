// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SeleniumBaseTests.cs" company="">
//   
// </copyright>
// <summary>
//   The selenium base tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UX.Testing.Selenium
{
	using OpenQA.Selenium;

	/// <summary>The selenium base tests.</summary>
	public class SeleniumBaseTests : Core.BaseTests
	{
		protected SeleniumBaseTests()
		{
		}

		protected SeleniumBaseTests(bool newBrowserPerIteration)
			: base(newBrowserPerIteration)
		{
		}

		#region Public Properties

		/// <summary>Gets the driver.</summary>
		public IWebDriver Driver
		{
			get
			{
				return (IWebDriver)this.Browser.NativeBrowser;
			}
		}

		#endregion
	}
}