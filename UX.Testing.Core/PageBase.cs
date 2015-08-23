// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PageBase.cs" company="">
//   
// </copyright>
// <summary>
//   The page base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core
{
	using System;

    using UX.Testing.Core.Extensions;
	using UX.Testing.Core.TestFramework;

	/// <summary>The page base.</summary>
	public abstract class PageBase : ViewBase
	{
		#region Fields

		/// <summary>The url.</summary>
		public readonly string Url;

		#endregion

		#region Constructors and Destructors

		/// <summary>Initializes a new instance of the <see cref="PageBase"/> class.</summary>
		/// <param name="browser">The testing framework.</param>
		/// <param name="url">The url.</param>
		protected PageBase(Browser browser, string url)
			: base(browser)
		{
			this.Url = url;
		}

		/// <summary>Initializes a new instance of the <see cref="PageBase"/> class.</summary>
		/// <param name="browser">The testing framework.</param>
		/// <param name="url">The url.</param>
		/// <param name="retry">The retry.</param>
		protected PageBase(Browser browser, string url, bool retry)
			: base(browser, retry)
		{
			this.Url = url;
		}

		/// <summary>Initializes a new instance of the <see cref="PageBase"/> class.</summary>
		/// <param name="browser">The testing framework.</param>
		/// <param name="url">The url.</param>
		/// <param name="timeout">The timeout.</param>
		/// <param name="interval">The interval.</param>
		protected PageBase(Browser browser, string url, int timeout, int interval)
			: base(browser, timeout, interval)
		{
			this.Url = url;
		}

        #endregion

        #region Public Methods and Operators

        public string Title { get { return this.Browser.PageTitle; } }
       
        /// <summary>The navigate to.</summary>
        /// <returns>The <see cref="bool"/>.</returns>
        public virtual bool NavigateTo()
		{
			return this.NavigateTo(browser => browser.Url.Contains(this.Url));
		}

		/// <summary>The navigate to.</summary>
		/// <param name="condition">The condition.</param>
		/// <returns>The <see cref="bool"/>.</returns>
		public virtual bool NavigateTo(Func<Browser, bool> condition)
		{
			return this.NavigateTo(condition, this.Timeout, this.Interval);
		}

		/// <summary>The navigate to.</summary>
		/// <param name="condition">The condition.</param>
		/// <param name="timeout">The timeout.</param>
		/// <param name="interval">The interval.</param>
		/// <returns>The <see cref="bool"/>.</returns>
		public virtual bool NavigateTo(Func<Browser, bool> condition, int timeout, int interval)
		{
			this.Logger.Trace("Navigating to '{0}'", this.Url);
			this.Browser.NavigateTo(this.Url);
			return this.Browser.WaitForCondition(condition, timeout, interval);
		}

		#endregion
	}
}