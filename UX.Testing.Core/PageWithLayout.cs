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
	using System.Reflection;

	using UX.Testing.Core.TestFramework;

	/// <summary>The page base.</summary>
	public abstract class PageWithLayout<T> : PageBase where T : ViewBase
	{
		private T layout;

		#region Constructors and Destructors

		public PageWithLayout(Browser browser, string url)
			: base(browser, url)
		{
			try
			{
				this.layout = (T)Activator.CreateInstance(typeof(T), browser);
			}
			catch (Exception)
			{
				throw new Exception("Layout could not be initialized with expected constructor signature. Ex: (Browser)");
			}
			
		}

		public PageWithLayout(Browser browser, string url, bool retry)
			: base(browser, url, retry)
		{
			try
			{
				this.layout = (T)Activator.CreateInstance(typeof(T), browser, retry);
			}
			catch (Exception)
			{
				throw new Exception("Layout could not be initialized with expected constructor signature. Ex: (Browser, retry)");
			}
		}

		public PageWithLayout(Browser browser, string url, int timeout, int interval)
			: base(browser, url, timeout, interval)
		{
			try
			{ 
				this.layout = (T)Activator.CreateInstance(typeof(T), browser, timeout, interval);
			}
			catch (Exception)
			{
				throw new Exception("Layout could not be initialized with expected constructor signature. Ex: (Browser, timeout, interval)");
			}
		}

		#endregion

		public T Layout
		{
			get
			{
				return this.layout;
			}

			set
			{
				this.layout = value;
			}
		}
	}
}