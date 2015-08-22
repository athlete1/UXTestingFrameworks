// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Browser.cs" company="">
//   
// </copyright>
// <summary>
//   The browser.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Selenium
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Diagnostics;
	using System.Drawing.Imaging;
	using System.Linq;
	using System.Text;
	using System.Text.RegularExpressions;
	using System.Threading;

	using UX.Testing.Core.Controls;
	using UX.Testing.Core.Enums;
	using UX.Testing.Core.Extensions;
	using UX.Testing.Core.Logging;
	using UX.Testing.Selenium.Extensions;

	using OpenQA.Selenium;
	using OpenQA.Selenium.Interactions;
	using OpenQA.Selenium.Internal;
	using OpenQA.Selenium.Support.UI;

	/// <summary>The browser.</summary>
	internal class Browser : Core.TestFramework.Browser
	{
		#region Fields

		/// <summary>The framework browser.</summary>
		private IWebDriver frameworkBrowser;

		#endregion

		#region Constructors and Destructors

		/// <summary>Initializes a new instance of the <see cref="Browser"/> class.</summary>
		/// <param name="frameworkBrowser">The framework browser.</param>
		public Browser(IWebDriver frameworkBrowser)
		{
			this.frameworkBrowser = frameworkBrowser;
			this.Logger = new Logger();
		}

		#endregion

		#region Public Properties

		/// <summary>Gets the native browser.</summary>
		public override object NativeBrowser
		{
			get
			{
				return this.frameworkBrowser;
			}
		}

		/// <summary>Gets the url.</summary>
		public override string Url
		{
			get
			{
				return this.frameworkBrowser.Url;
			}
		}

		#endregion

		#region Properties

		/// <summary>Gets the logger.</summary>
		protected override sealed ILogger Logger { get; set; }

		#endregion

		#region FindBy Methods

		public override HtmlControl FindControl(Core.By by)
		{
			if (by == null)
			{
				throw new ArgumentNullException("by", "by cannot be null");
			}

			return @by.FindControl(this);
		}

		public override ReadOnlyCollection<HtmlControl> FindControls(Core.By by)
		{
			if (by == null)
			{
				throw new ArgumentNullException("by", "by cannot be null");
			}

			return @by.FindControls(this);
		}

		public override HtmlControl FindControlById(string id, HtmlControl parentControl = null)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			var logger = new Logger();
			try
			{
				IWebElement nativeControl;
				if (parentControl == null)
				{
					nativeControl = this.frameworkBrowser.FindElement(By.Id(id));
				}
				else
				{
					nativeControl = this.GetFrameworkControl(parentControl).FindElement(By.Id(id));
				}

				var htmlControl = (nativeControl.TagName.ToLower() == "input")
					? this.CreateHtmlControl(nativeControl.TagName, nativeControl.GetAttribute("type"))
					: this.CreateHtmlControl(nativeControl.TagName);
				
				htmlControl.Locator = new Locator { FindBy = FindBy.Id, Term = id };
				return this.PopulateControl(htmlControl, nativeControl);
			}
			catch (NoSuchElementException)
			{
				logger.Trace("Could Not find Element using the following expression 'ID = {0}'", id);
				return null;
			}
			catch (StaleElementReferenceException)
			{
				logger.Trace("Could Not find Element using the following expression 'ID = {0}'", id);
				return null;
			}
			finally
			{
				stopwatch.Stop();
				if (this.TestSettings.Debug)
				{
					logger.Debug("Completed FindControlById - [RUNTIME: {0}]", stopwatch.Elapsed.TotalMilliseconds);
				}
			}
		}

		public override ReadOnlyCollection<HtmlControl> FindControlsById(string id, HtmlControl parentControl = null)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			var logger = new Logger();
			try
			{
				IEnumerable<IWebElement> results;
				if (parentControl == null)
				{
					results = this.frameworkBrowser.FindElements(By.Id(id));
				}
				else
				{
					results = this.GetFrameworkControl(parentControl).FindElements(By.Id(id));
				}
				
				var controls = results.Select(p => this.PopulateControl((p.TagName.ToLower() == "input") ? this.CreateHtmlControl(p.TagName, p.GetAttribute("type")) : this.CreateHtmlControl(p.TagName), p)).ToArray();
				for (int i = 0; i < controls.Length; i++)
				{
					controls[i].Locator = new Locator { FindBy = FindBy.Id, Term = id };
				}

				return new ReadOnlyCollection<HtmlControl>(controls);
			}
			catch (NoSuchElementException)
			{
				logger.Trace("Could Not find Elements using the following expression 'ID = {0}'", id);
				return null;
			}
			catch (StaleElementReferenceException)
			{
				logger.Trace("Could Not find Elements using the following expression 'ID = {0}'", id);
				return null;
			}
			finally
			{
				stopwatch.Stop();
				if (this.TestSettings.Debug)
				{
					logger.Debug("Completed FindControlsById - [RUNTIME: {0}]", stopwatch.Elapsed.TotalMilliseconds);
				}
			}
		}

		public override HtmlControl FindControlByName(string name, HtmlControl parentControl = null)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			var logger = new Logger();
			try
			{
				IWebElement nativeControl;
				if (parentControl == null)
				{
					nativeControl = this.frameworkBrowser.FindElement(By.Name(name));
				}
				else
				{
					nativeControl = this.GetFrameworkControl(parentControl).FindElement(By.Name(name));
				}
				
				var htmlControl = (nativeControl.TagName.ToLower() == "input")
					? this.CreateHtmlControl(nativeControl.TagName, nativeControl.GetAttribute("type"))
					: this.CreateHtmlControl(nativeControl.TagName);

				htmlControl.Locator = new Locator { FindBy = FindBy.Name, Term = name };
				return this.PopulateControl(htmlControl, nativeControl);
			}
			catch (NoSuchElementException)
			{
				logger.Trace("Could Not find Element using the following expression 'NAME = {0}'", name);
				return null;
			}
			catch (StaleElementReferenceException)
			{
				logger.Trace("Could Not find Element using the following expression 'NAME = {0}'", name);
				return null;
			}
			finally
			{
				stopwatch.Stop();
				if (this.TestSettings.Debug)
				{
					logger.Debug("Completed FindControlByName - [RUNTIME: {0}]", stopwatch.Elapsed.TotalMilliseconds);
				}
			}
		}

		public override ReadOnlyCollection<HtmlControl> FindControlsByName(string name, HtmlControl parentControl = null)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			var logger = new Logger();
			try
			{
				IEnumerable<IWebElement> results;
				if (parentControl == null)
				{
					results = this.frameworkBrowser.FindElements(By.Name(name));
				}
				else
				{
					results = this.GetFrameworkControl(parentControl).FindElements(By.Name(name));
				}

				var controls = results.Select(p => this.PopulateControl((p.TagName.ToLower() == "input") ? this.CreateHtmlControl(p.TagName, p.GetAttribute("type")) : this.CreateHtmlControl(p.TagName), p)).ToArray();
				for (int i = 0; i < controls.Length; i++)
				{
					controls[i].Locator = new Locator { FindBy = FindBy.Name, Term = name };
				}

				return new ReadOnlyCollection<HtmlControl>(controls);
			}
			catch (NoSuchElementException)
			{
				logger.Trace("Could Not find Elements using the following expression 'Name = {0}'", name);
				return null;
			}
			catch (StaleElementReferenceException)
			{
				logger.Trace("Could Not find Elements using the following expression 'Name = {0}'", name);
				return null;
			}
			finally
			{
				stopwatch.Stop();
				if (this.TestSettings.Debug)
				{
					logger.Debug("Completed FindControlsByName - [RUNTIME: {0}]", stopwatch.Elapsed.TotalMilliseconds);
				}
			}
		}

		public override HtmlControl FindControlByClassName(string className, HtmlControl parentControl = null)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			var logger = new Logger();
			try
			{
				IWebElement nativeControl;
				if (parentControl == null)
				{
					nativeControl = this.frameworkBrowser.FindElement(By.ClassName(className));
				}
				else
				{
					nativeControl = this.GetFrameworkControl(parentControl).FindElement(By.ClassName(className));
				}

				var htmlControl = (nativeControl.TagName.ToLower() == "input")
					? this.CreateHtmlControl(nativeControl.TagName, nativeControl.GetAttribute("type"))
					: this.CreateHtmlControl(nativeControl.TagName);

				htmlControl.Locator = new Locator { FindBy = FindBy.Class, Term = className };
				return this.PopulateControl(htmlControl, nativeControl);
			}
			catch (NoSuchElementException)
			{
				logger.Trace("Could Not find Element using the following expression 'ClassName = {0}'", className);
				return null;
			}
			catch (StaleElementReferenceException)
			{
				logger.Trace("Could Not find Element using the following expression 'ClassName = {0}'", className);
				return null;
			}
			finally
			{
				stopwatch.Stop();
				if (this.TestSettings.Debug)
				{
					logger.Debug("Completed FindControlByClassName - [RUNTIME: {0}]", stopwatch.Elapsed.TotalMilliseconds);
				}
			}
		}

		public override ReadOnlyCollection<HtmlControl> FindControlsByClassName(string className, HtmlControl parentControl = null)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			var logger = new Logger();
			try
			{
				IEnumerable<IWebElement> results;
				if (parentControl == null)
				{
					results = this.frameworkBrowser.FindElements(By.ClassName(className));
				}
				else
				{
					results = this.GetFrameworkControl(parentControl).FindElements(By.ClassName(className));
				}

				var controls = results.Select(p => this.PopulateControl((p.TagName.ToLower() == "input") ? this.CreateHtmlControl(p.TagName, p.GetAttribute("type")) : this.CreateHtmlControl(p.TagName), p)).ToArray();
				for (int i = 0; i < controls.Length; i++)
				{
					controls[i].Locator = new Locator { FindBy = FindBy.Class, Term = className };
				}

				return new ReadOnlyCollection<HtmlControl>(controls);
			}
			catch (NoSuchElementException)
			{
				logger.Trace("Could Not find Elements using the following expression 'ClassName = {0}'", className);
				return null;
			}
			catch (StaleElementReferenceException)
			{
				logger.Trace("Could Not find Elements using the following expression 'ClassName = {0}'", className);
				return null;
			}
			finally
			{
				stopwatch.Stop();
				if (this.TestSettings.Debug)
				{
					logger.Debug("Completed FindControlsByClassName - [RUNTIME: {0}]", stopwatch.Elapsed.TotalMilliseconds);
				}
			}
		}

		public override HtmlControl FindControlByLinkText(string linkText, HtmlControl parentControl = null)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			var logger = new Logger();
			try
			{
				IWebElement nativeControl;
				if (parentControl == null)
				{
					nativeControl = this.frameworkBrowser.FindElement(By.LinkText(linkText));
				}
				else
				{
					nativeControl = this.GetFrameworkControl(parentControl).FindElement(By.LinkText(linkText));
				}

				var htmlControl = (nativeControl.TagName.ToLower() == "input")
					? this.CreateHtmlControl(nativeControl.TagName, nativeControl.GetAttribute("type"))
					: this.CreateHtmlControl(nativeControl.TagName);

				htmlControl.Locator = new Locator { FindBy = FindBy.LinkText, Term = linkText };
				return this.PopulateControl(htmlControl, nativeControl);
			}
			catch (NoSuchElementException)
			{
				logger.Trace("Could Not find Element using the following expression 'LinkText = {0}'", linkText);
				return null;
			}
			catch (StaleElementReferenceException)
			{
				logger.Trace("Could Not find Element using the following expression 'LinkText = {0}'", linkText);
				return null;
			}
			finally
			{
				stopwatch.Stop();
				if (this.TestSettings.Debug)
				{
					logger.Debug("Completed FindControlByLinkText - [RUNTIME: {0}]", stopwatch.Elapsed.TotalMilliseconds);
				}
			}
		}

		public override ReadOnlyCollection<HtmlControl> FindControlsByLinkText(string linkText, HtmlControl parentControl = null)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			var logger = new Logger();
			try
			{
				IEnumerable<IWebElement> results;
				if (parentControl == null)
				{
					results = this.frameworkBrowser.FindElements(By.LinkText(linkText));
				}
				else
				{
					results = this.GetFrameworkControl(parentControl).FindElements(By.LinkText(linkText));
				}

				var controls = results.Select(p => this.PopulateControl((p.TagName.ToLower() == "input") ? this.CreateHtmlControl(p.TagName, p.GetAttribute("type")) : this.CreateHtmlControl(p.TagName), p)).ToArray();
				for (int i = 0; i < controls.Length; i++)
				{
					controls[i].Locator = new Locator { FindBy = FindBy.LinkText, Term = linkText };
				}

				return new ReadOnlyCollection<HtmlControl>(controls);
			}
			catch (NoSuchElementException)
			{
				logger.Trace("Could Not find Elements using the following expression 'LinkText = {0}'", linkText);
				return null;
			}
			catch (StaleElementReferenceException)
			{
				logger.Trace("Could Not find Elements using the following expression 'LinkText = {0}'", linkText);
				return null;
			}
			finally
			{
				stopwatch.Stop();
				if (this.TestSettings.Debug)
				{
					logger.Debug("Completed FindControlsByLinkText - [RUNTIME: {0}]", stopwatch.Elapsed.TotalMilliseconds);
				}
			}
		}

		public override HtmlControl FindControlByPartialLinkText(string partialLinkText, HtmlControl parentControl = null)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			var logger = new Logger();
			try
			{
				IWebElement nativeControl;
				if (parentControl == null)
				{
					nativeControl = this.frameworkBrowser.FindElement(By.PartialLinkText(partialLinkText));
				}
				else
				{
					nativeControl = this.GetFrameworkControl(parentControl).FindElement(By.PartialLinkText(partialLinkText));
				}

				var htmlControl = (nativeControl.TagName.ToLower() == "input")
					? this.CreateHtmlControl(nativeControl.TagName, nativeControl.GetAttribute("type"))
					: this.CreateHtmlControl(nativeControl.TagName);

				htmlControl.Locator = new Locator { FindBy = FindBy.PartialLinkText, Term = partialLinkText };
				return this.PopulateControl(htmlControl, nativeControl);
			}
			catch (NoSuchElementException)
			{
				logger.Trace("Could Not find Element using the following expression 'PartialLinkText = {0}'", partialLinkText);
				return null;
			}
			catch (StaleElementReferenceException)
			{
				logger.Trace("Could Not find Element using the following expression 'PartialLinkText = {0}'", partialLinkText);
				return null;
			}
			finally
			{
				stopwatch.Stop();
				if (this.TestSettings.Debug)
				{
					logger.Debug("Completed FindControlByPartialLinkText - [RUNTIME: {0}]", stopwatch.Elapsed.TotalMilliseconds);
				}
			}
		}

		public override ReadOnlyCollection<HtmlControl> FindControlsByPartialLinkText(string partialLinkText, HtmlControl parentControl = null)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			var logger = new Logger();
			try
			{
				IEnumerable<IWebElement> results;
				if (parentControl == null)
				{
					results = this.frameworkBrowser.FindElements(By.PartialLinkText(partialLinkText));
				}
				else
				{
					results = this.GetFrameworkControl(parentControl).FindElements(By.PartialLinkText(partialLinkText));
				}

				var controls = results.Select(p => this.PopulateControl((p.TagName.ToLower() == "input") ? this.CreateHtmlControl(p.TagName, p.GetAttribute("type")) : this.CreateHtmlControl(p.TagName), p)).ToArray();
				for (int i = 0; i < controls.Length; i++)
				{
					controls[i].Locator = new Locator { FindBy = FindBy.PartialLinkText, Term = partialLinkText };
				}

				return new ReadOnlyCollection<HtmlControl>(controls);
			}
			catch (NoSuchElementException)
			{
				logger.Trace("Could Not find Elements using the following expression 'PartialLinkText = {0}'", partialLinkText);
				return null;
			}
			catch (StaleElementReferenceException)
			{
				logger.Trace("Could Not find Elements using the following expression 'PartialLinkText = {0}'", partialLinkText);
				return null;
			}
			finally
			{
				stopwatch.Stop();
				if (this.TestSettings.Debug)
				{
					logger.Debug("Completed FindControlsByPartialLinkText - [RUNTIME: {0}]", stopwatch.Elapsed.TotalMilliseconds);
				}
			}
		}

		public override HtmlControl FindControlByTagName(string tagName, HtmlControl parentControl = null)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			var logger = new Logger();
			try
			{
				IWebElement nativeControl;
				if (parentControl == null)
				{
					nativeControl = this.frameworkBrowser.FindElement(By.TagName(tagName));
				}
				else
				{
					nativeControl = this.GetFrameworkControl(parentControl).FindElement(By.TagName(tagName));
				}

				var htmlControl = (nativeControl.TagName.ToLower() == "input")
					? this.CreateHtmlControl(nativeControl.TagName, nativeControl.GetAttribute("type"))
					: this.CreateHtmlControl(nativeControl.TagName);

				htmlControl.Locator = new Locator { FindBy = FindBy.TagName, Term = tagName };
				return this.PopulateControl(htmlControl, nativeControl);
			}
			catch (NoSuchElementException)
			{
				logger.Trace("Could Not find Element using the following expression 'TagName = {0}'", tagName);
				return null;
			}
			catch (StaleElementReferenceException)
			{
				logger.Trace("Could Not find Element using the following expression 'TagName = {0}'", tagName);
				return null;
			}
			finally
			{
				stopwatch.Stop();
				if (this.TestSettings.Debug)
				{
					logger.Debug("Completed FindControlByTagName - [RUNTIME: {0}]", stopwatch.Elapsed.TotalMilliseconds);
				}
			}
		}

		public override ReadOnlyCollection<HtmlControl> FindControlsByTagName(string tagName, HtmlControl parentControl = null)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			var logger = new Logger();
			try
			{
				IEnumerable<IWebElement> results;
				if (parentControl == null)
				{
					results = this.frameworkBrowser.FindElements(By.TagName(tagName));
				}
				else
				{
					results = this.GetFrameworkControl(parentControl).FindElements(By.TagName(tagName));
				}

				var controls = results.Select(p => this.PopulateControl((p.TagName.ToLower() == "input") ? this.CreateHtmlControl(p.TagName, p.GetAttribute("type")) : this.CreateHtmlControl(p.TagName), p)).ToArray();
				for (int i = 0; i < controls.Length; i++)
				{
					controls[i].Locator = new Locator { FindBy = FindBy.TagName, Term = tagName };
				}

				return new ReadOnlyCollection<HtmlControl>(controls);
			}
			catch (NoSuchElementException)
			{
				logger.Trace("Could Not find Elements using the following expression 'TagName = {0}'", tagName);
				return null;
			}
			catch (StaleElementReferenceException)
			{
				logger.Trace("Could Not find Elements using the following expression 'TagName = {0}'", tagName);
				return null;
			}
			finally
			{
				stopwatch.Stop();
				if (this.TestSettings.Debug)
				{
					logger.Debug("Completed FindControlsByTagName - [RUNTIME: {0}]", stopwatch.Elapsed.TotalMilliseconds);
				}
			}
		}

		public override HtmlControl FindControlByCssSelector(string cssSelector, HtmlControl parentControl = null)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			var logger = new Logger();
			try
			{
				IWebElement nativeControl;
				if (parentControl == null)
				{
					nativeControl = this.frameworkBrowser.FindElement(By.CssSelector(cssSelector));
				}
				else
				{
					nativeControl = this.GetFrameworkControl(parentControl).FindElement(By.CssSelector(cssSelector));
				}

				var htmlControl = (nativeControl.TagName.ToLower() == "input")
					? this.CreateHtmlControl(nativeControl.TagName, nativeControl.GetAttribute("type"))
					: this.CreateHtmlControl(nativeControl.TagName);

				htmlControl.Locator = new Locator { FindBy = FindBy.CSSSelector, Term = cssSelector };
				return this.PopulateControl(htmlControl, nativeControl);
			}
			catch (NoSuchElementException)
			{
				logger.Trace("Could Not find Element using the following expression 'CssSelector = {0}'", cssSelector);
				return null;
			}
			catch (StaleElementReferenceException)
			{
				logger.Trace("Could Not find Element using the following expression 'CssSelector = {0}'", cssSelector);
				return null;
			}
			finally
			{
				stopwatch.Stop();
				if (this.TestSettings.Debug)
				{
					logger.Debug("Completed FindControlByCssSelector - [RUNTIME: {0}]", stopwatch.Elapsed.TotalMilliseconds);
				}
			}
		}

		public override ReadOnlyCollection<HtmlControl> FindControlsByCssSelector(string cssSelector, HtmlControl parentControl = null)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			var logger = new Logger();
			try
			{
				IEnumerable<IWebElement> results;
				if (parentControl == null)
				{
					results = this.frameworkBrowser.FindElements(By.CssSelector(cssSelector));
				}
				else
				{
					results = this.GetFrameworkControl(parentControl).FindElements(By.CssSelector(cssSelector));
				}

				var controls = results.Select(p => this.PopulateControl((p.TagName.ToLower() == "input") ? this.CreateHtmlControl(p.TagName, p.GetAttribute("type")) : this.CreateHtmlControl(p.TagName), p)).ToArray();
				for (int i = 0; i < controls.Length; i++)
				{
					controls[i].Locator = new Locator { FindBy = FindBy.CSSSelector, Term = cssSelector };
				}

				return new ReadOnlyCollection<HtmlControl>(controls);
			}
			catch (NoSuchElementException)
			{
				logger.Trace("Could Not find Elements using the following expression 'CssSelector = {0}'", cssSelector);
				return null;
			}
			catch (StaleElementReferenceException)
			{
				logger.Trace("Could Not find Elements using the following expression 'CssSelector = {0}'", cssSelector);
				return null;
			}
			finally
			{
				stopwatch.Stop();
				if (this.TestSettings.Debug)
				{
					logger.Debug("Completed FindControlsByCssSelector - [RUNTIME: {0}]", stopwatch.Elapsed.TotalMilliseconds);
				}
			}
		}

		#endregion

		#region Public Methods and Operators

		/// <summary>The check is enabled.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <returns>The <see cref="bool"/>.</returns>
		public override bool CheckIsEnabled(HtmlControl htmlControl)
		{
			var nativeControl = this.GetFrameworkControl(htmlControl);
			try
			{
				return nativeControl.IsElementEnabled();
			}
			catch (StaleElementReferenceException)
			{
				htmlControl.Refresh();
			}

			return nativeControl.IsElementEnabled();
		}

		/// <summary>The check visibility.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <returns>The <see cref="bool"/>.</returns>
		public override bool CheckVisibility(HtmlControl htmlControl)
		{
			var control = this.GetFrameworkControl(htmlControl);
			return control.IsElementVisible();
		}

		/// <summary>The close.</summary>
		public override void Close()
		{
			this.frameworkBrowser.Quit();
		}

		/// <summary>The go forward.</summary>
		public override void GoForward()
		{
			this.frameworkBrowser.Navigate().Forward();
		}

		/// <summary>The go back.</summary>
		public override void GoBack()
		{
			this.frameworkBrowser.Navigate().Back();
		}

		/// <summary>The refresh.</summary>
		public override void Refresh()
		{
			this.frameworkBrowser.Navigate().Refresh();
		}

		public override IEnumerable<T> FindRange<T>(T htmlControl, int count, int startIndex = 0, HtmlControl containingControl = null)
		{
			if (htmlControl == null)
			{
				htmlControl = new T();
			}

			var xpath = this.GetXPath(htmlControl);

			this.WaitForPageLoad();

			if (containingControl != null)
			{
				var parentLocator = (Locator)containingControl.Locator;
				var parentXpath = this.GetXPath(parentLocator, containingControl);
				var childControls =
					this.FindNativeControls(htmlControl, this.GetFrameworkControl(containingControl))
						.Skip(startIndex)
						.Take(count)
						.Select(p => this.PopulateControl(new T(), p))
						.ToArray();
				for (int i = 0; i < childControls.Length; i++)
				{
					childControls[i].Locator = new Locator { FindBy = FindBy.XPath, Term = "(" + parentXpath + xpath + ")[" + (startIndex + i + 1) + "]" };
				}

				return childControls;
			}

			var controls =
				this.FindNativeControls(htmlControl).Skip(startIndex).Take(count).Select(p => this.PopulateControl(new T(), p)).ToArray();
			for (int i = 0; i < controls.Length; i++)
			{
				controls[i].Locator = new Locator { FindBy = FindBy.XPath, Term = "(" + xpath + ")[" + (startIndex + i + 1) + "]" };
			}

			return controls;
		}

		/// <summary>The find parent.</summary>
		/// <param name="childControl">The child control.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public override T FindParent<T>(HtmlControl childControl)
		{
			if (childControl == null)
			{
				return null;
			}

			IWebElement nativeControl;
			var htmlControl = new T();

			try
			{
				try
				{
					this.WaitForPageLoad();
					nativeControl = childControl.FrameworkControl.CastTo<IWebElement>().FindElement(By.XPath("./.."));
				}
				catch (StaleElementReferenceException)
				{
					childControl.Refresh();
					nativeControl = childControl.FrameworkControl.CastTo<IWebElement>().FindElement(By.XPath("./.."));
				}

				if (nativeControl.TagName != htmlControl.TagName)
				{
					return null;
				}

				if (nativeControl.TagName == HtmlTag.input.GetHtmlTag())
				{
					if (nativeControl.GetAttribute("type") != htmlControl.CastTo<HtmlInput>().Type.ToString().ToLower())
					{
						return null;
					}
				}
			}
			catch (NoSuchElementException)
			{
				return null;
			}

			htmlControl.Locator = new Locator
								  {
									  FindBy = FindBy.XPath, 
									  Term = this.GetXPath((Locator)childControl.Locator, childControl) + "/.."
								  };

			return this.PopulateControl(htmlControl, nativeControl);
		}

		/// <summary>The find Ancestor.</summary>
		/// <param name="childControl">The child control.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public override T FindAncestor<T>(HtmlControl childControl)
		{
			if (childControl == null)
			{
				return null;
			}

			IWebElement nativeControl;
			var htmlControl = new T();

			return this.FindAncestor<T>(childControl, htmlControl);
		}

		/// <summary>The find Ancestor.</summary>
		/// <param name="childControl">The child control.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public override T FindAncestor<T>(HtmlControl childControl, HtmlControl ancestorControl)
		{
			if (childControl == null)
			{
				return null;
			}

			if (ancestorControl == null)
			{
				return null;
			}

			IWebElement nativeControl;
			var htmlControl = new T();

			var stopwatch = new Stopwatch();
			stopwatch.Start();
			var logger = new Logger();
			var tmpXPath = "/ancestor::" + this.GetXPath(ancestorControl).TrimStart('/', '/');

			try
			{
				try
				{
					this.WaitForPageLoad();
					nativeControl = childControl.FrameworkControl.CastTo<IWebElement>().FindElements(By.XPath("." + tmpXPath)).LastOrDefault();
				}
				catch (StaleElementReferenceException)
				{
					childControl.Refresh();
					nativeControl = childControl.FrameworkControl.CastTo<IWebElement>().FindElements(By.XPath("." + tmpXPath)).LastOrDefault();
				}

				if (this.TestSettings.Debug)
				{
					this.Logger.Debug("Find Ancestor - Path '{0}'", tmpXPath);
				}

				if (nativeControl == null)
				{
					return null;
				}

				if (nativeControl.TagName != htmlControl.TagName)
				{
					return null;
				}

				if (nativeControl.TagName == HtmlTag.input.GetHtmlTag())
				{
					if (nativeControl.GetAttribute("type") != htmlControl.CastTo<HtmlInput>().Type.ToString().ToLower())
					{
						return null;
					}
				}
			}
			catch (NoSuchElementException)
			{
				return null;
			}
			finally
			{
				stopwatch.Stop();
				if (this.TestSettings.Debug)
				{
					logger.Debug("Completed FindAncestor - [RUNTIME: {0}]", stopwatch.Elapsed.TotalMilliseconds);
				}
			}

			htmlControl.Locator = new Locator
			{
				FindBy = FindBy.XPath,
				Term = this.GetXPath((Locator)childControl.Locator, childControl) + tmpXPath
			};

			return this.PopulateControl(htmlControl, nativeControl);
		}

		/// <summary>The find.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <param name="containingControl">The containing control.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public override T Find<T>(T htmlControl, HtmlControl containingControl = null)
		{
			if (htmlControl == null)
			{
				htmlControl = new T();
			}

			var xpath = this.GetXPath(htmlControl);
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			var logger = new Logger();
			ISearchContext searchContext = this.frameworkBrowser;

			if (containingControl != null)
			{
				var parentLocator = (Locator)containingControl.Locator;
				xpath = this.GetXPath(parentLocator, containingControl) + xpath;
				searchContext = (ISearchContext)containingControl.FrameworkControl;
			}

			T control = null;
			try
			{
				this.WaitForPageLoad();
				logger.Trace("Find Element using '{0}'", xpath);
				control = this.PopulateControl(htmlControl, this.FindNativeControl(htmlControl, searchContext));
				control.Locator = new Locator { FindBy = FindBy.XPath, Term = xpath };
			}
			catch (StaleElementReferenceException)
			{
				if (containingControl != null)
				{
					containingControl.Refresh();
					logger.Trace("Find Element using '{0}'", xpath);
					control = this.PopulateControl(htmlControl, this.FindNativeControl(htmlControl, searchContext));
					control.Locator = new Locator { FindBy = FindBy.XPath, Term = xpath };
				}
			}
			catch (NoSuchElementException)
			{
				logger.Trace("Could not Find Element using the following expression '{0}'", xpath);
				return null;
			}
			finally
			{
				stopwatch.Stop();
				if (this.TestSettings.Debug)
				{
					logger.Debug("Completed Find - [RUNTIME: {0}]", stopwatch.Elapsed.TotalMilliseconds);
				}
			}

			return control;
		}

		/// <summary>The find all.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <param name="containingControl">The containing control.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="IEnumerable{T}"/>.</returns>
		public override IEnumerable<T> FindAll<T>(T htmlControl, HtmlControl containingControl = null)
		{
			if (htmlControl == null)
			{
				htmlControl = new T();
			}

			var xpath = this.GetXPath(htmlControl);
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			var logger = new Logger();
			ISearchContext searchContext = this.frameworkBrowser;
			try
			{
				this.WaitForPageLoad();
				if (containingControl != null)
				{
					var parentLocator = (Locator)containingControl.Locator;
					xpath = this.GetXPath(parentLocator, containingControl) + xpath;
					searchContext = this.GetFrameworkControl(containingControl);
				}

				logger.Trace("Find All Elements using '{0}'", xpath);

				var controls = this.FindNativeControls(htmlControl, searchContext).Select(p => this.PopulateControl(new T(), p)).ToArray();
				for (int i = 0; i < controls.Length; i++)
				{
					controls[i].Locator = new Locator { FindBy = FindBy.XPath, Term = "(" + xpath + ")[" + (i + 1) + "]" };
				}

				return controls;
			}
			catch (NoSuchElementException)
			{
				logger.Trace("Could not Find All Elements using the following expression '{0}'", xpath);
				return new List<T>();
			}
			catch (StaleElementReferenceException)
			{
				logger.Trace("Could not Find All Elements using the following expression '{0}'", xpath);
				return new List<T>();
			}
			finally
			{
				stopwatch.Stop();
				if (this.TestSettings.Debug)
				{
					logger.Debug("Completed FindAll - [RUNTIME: {0}]", stopwatch.Elapsed.TotalMilliseconds);
				}
			}
		}

		/// <summary>The find by inner text.</summary>
		/// <param name="innerText">The inner text.</param>
		/// <param name="findOperator">The find operator.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public override T FindByInnerText<T>(string innerText, FindOperator findOperator = FindOperator.Equals, HtmlControl containingControl = null)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			try
			{
				return
					this.FindByAttributes<T>(
						new List<Tuple<string, string, FindOperator>>
							{
								new Tuple<string, string, FindOperator>("innerText", innerText, findOperator)
							},
						containingControl);
			}
			finally
			{
				stopwatch.Stop();
				if (this.TestSettings.Debug)
				{
					this.Logger.Debug("Completed FindByInnerText - [RUNTIME: {0}]", stopwatch.Elapsed.TotalMilliseconds);
				}
			}
		}

		/// <summary>The find all by inner text.</summary>
		/// <param name="innerText">The inner text.</param>
		/// <param name="findOperator">The find operator.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="IEnumerable"/>.</returns>
		public override IEnumerable<T> FindAllByInnerText<T>(string innerText, FindOperator findOperator = FindOperator.Equals, HtmlControl containingControl = null)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			try
			{
				return
					this.FindAllByAttributes<T>(
						new List<Tuple<string, string, FindOperator>>
							{
								new Tuple<string, string, FindOperator>("innerText", innerText, findOperator)
							},
						containingControl);
			}
			finally
			{
				stopwatch.Stop();
				if (this.TestSettings.Debug)
				{
					this.Logger.Debug("Completed FindAllByInnerText - [RUNTIME: {0}]", stopwatch.Elapsed.TotalMilliseconds);
				}
			}
		}

		/// <summary>The find by id.</summary>
		/// <param name="id">The id.</param>
		/// <param name="findOperator"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public override T FindById<T>(string id, FindOperator findOperator = FindOperator.Equals, HtmlControl containingControl = null)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			var logger = new Logger();
			try
			{
				return
					this.FindByAttributes<T>(
						new List<Tuple<string, string, FindOperator>> { new Tuple<string, string, FindOperator>("id", id, findOperator) },
						containingControl);
			}
			finally
			{
				stopwatch.Stop();
				if (this.TestSettings.Debug)
				{
					logger.Debug("Completed FindById - [RUNTIME: {0}]", stopwatch.Elapsed.TotalMilliseconds);
				}
			}
		}

		/// <summary>The find all by id.</summary>
		/// <param name="id">The id.</param>
		/// <param name="findOperator">The find operator.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="IEnumerable"/>.</returns>
		public override IEnumerable<T> FindAllById<T>(string id, FindOperator findOperator = FindOperator.Equals, HtmlControl containingControl = null)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			try
			{
				return
					this.FindAllByAttributes<T>(
						new List<Tuple<string, string, FindOperator>> { new Tuple<string, string, FindOperator>("id", id, findOperator) },
						containingControl);
			}
			finally
			{
				stopwatch.Stop();
				if (this.TestSettings.Debug)
				{
					this.Logger.Debug("Completed FindAllById - [RUNTIME: {0}]", stopwatch.Elapsed.TotalMilliseconds);
				}
			}
		}

		public override T FindByClass<T>(string cssClass, HtmlControl containerControl = null, params string[] additionalClasses)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			var logger = new Logger();
			try
			{
				var classes = new List<Tuple<string, string, FindOperator>>
								  {
									  new Tuple<string, string, FindOperator>("class", cssClass, FindOperator.Equals)
								  };
				classes.AddRange(additionalClasses.Select(p => new Tuple<string, string, FindOperator>("class", p, FindOperator.Equals)));
				return this.FindByAttributes<T>(classes, containerControl);
			}
			finally
			{
				stopwatch.Stop();
				if (this.TestSettings.Debug)
				{
					logger.Debug("Completed FindByClass - [RUNTIME: {0}]", stopwatch.Elapsed.TotalMilliseconds);
				}
			}
		}

		private T FindByAttributes<T>(IList<Tuple<string, string, FindOperator>> attributes, HtmlControl containingControl = null) where T : HtmlControl, new()
		{
			var logger = new Logger();
			var htmlControl = new T();
			var tagname = htmlControl.TagName;
			if (tagname == HtmlTag.input.GetHtmlTag() && !attributes.Any(p => p.Item1 == "type"))
			{
				attributes.Add(
					new Tuple<string, string, FindOperator>(
						"type", htmlControl.CastTo<HtmlInput>().Type.ToString().ToLower(), FindOperator.Equals));
			}

			var xpath = this.GetXPath(tagname, attributes);
			try
			{
				this.WaitForPageLoad();
				
				if (containingControl != null)
				{
					var parentLocator = (Locator)containingControl.Locator;
					var parentXpath = this.GetXPath(parentLocator, containingControl);
					xpath = string.Format("({0}){1}", parentXpath, xpath);
				}

				htmlControl.Locator = new Locator { FindBy = FindBy.XPath, Term = xpath };

				logger.Trace("Search for Element using '{0}'", xpath);
				var nativeControl = this.frameworkBrowser.FindElement(By.XPath(xpath));

				return this.PopulateControl(htmlControl, nativeControl);
			}
			catch (NoSuchElementException)
			{
				logger.Trace("Could Not find Elements using the following expression '{0}'", xpath);
				return null;
			}
			catch (StaleElementReferenceException)
			{
				logger.Trace("Could Not find Elements using the following expression '{0}'", xpath);
				return null;
			}
		}

		private void WaitForPageLoad()
		{
			var logger = new Logger();
			if (this.TestSettings.AutoWaitForPageLoad)
			{
				var stopwatch = new Stopwatch();
				stopwatch.Start();
				this.frameworkBrowser.WaitForPageToLoad();
				stopwatch.Stop();
				if (this.TestSettings.Debug)
				{
					logger.Debug("Waited For PageLoad!- [RUNTIME: {0}]", stopwatch.Elapsed.TotalMilliseconds);
				}
			}
		}

		private IEnumerable<T> FindAllByAttributes<T>(IList<Tuple<string, string, FindOperator>> attributes, HtmlControl containingControl = null) where T : HtmlControl, new()
		{
			var logger = new Logger();
			var htmlControl = new T();
			var tagname = htmlControl.TagName;
			if (tagname == HtmlTag.input.GetHtmlTag() && !attributes.Any(p => p.Item1 == "type"))
			{
				attributes.Add(
					new Tuple<string, string, FindOperator>(
						"type", htmlControl.CastTo<HtmlInput>().Type.ToString().ToLower(), FindOperator.Equals));
			}

			var xpath = this.GetXPath(tagname, attributes);
			try
			{
				this.WaitForPageLoad();

				if (containingControl != null)
				{
					var parentLocator = (Locator)containingControl.Locator;
					var parentXpath = this.GetXPath(parentLocator, containingControl);
					IEnumerable<IWebElement> controlresults = this.frameworkBrowser.FindElements(By.XPath(parentXpath + xpath));
					var childControls = controlresults.Select(p => this.PopulateControl(new T(), p)).ToArray();
					for (int i = 0; i < childControls.Length; i++)
					{
						childControls[i].Locator = new Locator { FindBy = FindBy.XPath, Term = "(" + parentXpath + xpath + ")[" + (i + 1) + "]" };
					}

					return childControls;
				}

				logger.Trace("Search for Element using '{0}'", xpath);
				IEnumerable<IWebElement> results = this.frameworkBrowser.FindElements(By.XPath(xpath));

				var controls = results.Select(p => this.PopulateControl(new T(), p)).ToArray();
				for (int i = 0; i < controls.Length; i++)
				{
					controls[i].Locator = new Locator { FindBy = FindBy.XPath, Term = "(" + xpath + ")[" + (i + 1) + "]" };
				}

				return controls;
			}
			catch (NoSuchElementException)
			{
				logger.Trace("Could Not find Elements using the following expression '{0}'", xpath);
				return new List<T>();
			}
			catch (StaleElementReferenceException)
			{
				logger.Trace("Could Not find Elements using the following expression '{0}'", xpath);
				return new List<T>();
			}
		}

		/// <summary>The find by name.</summary>
		/// <param name="name">The name.</param>
		/// <param name="containingControl">The containing Control.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public override T FindByName<T>(string name, HtmlControl containingControl = null)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			try
			{
				if (this.TestSettings.Debug)
				{
					this.Logger.Debug("Started FindByName '{0}'", name);
				}

				return this.Find(new T { Name = name }, containingControl);
			}
			finally
			{
				stopwatch.Stop();
				if (this.TestSettings.Debug)
				{
					this.Logger.Debug("Completed FindByName - [RUNTIME: {0}]", stopwatch.Elapsed.TotalMilliseconds);
				}
			}
		}

		/// <summary>The find all by class.</summary>
		/// <param name="cssClass">The css class.</param>
		/// <param name="containerControl"></param>
		/// <param name="additionalClasses">The additional classes.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="IEnumerable"/>.</returns>
		public override IEnumerable<T> FindAllByClass<T>(string cssClass, HtmlControl containerControl = null, params string[] additionalClasses)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			var logger = new Logger();
			try
			{
				var classes = new List<Tuple<string, string, FindOperator>>
								  {
									  new Tuple<string, string, FindOperator>("class", cssClass, FindOperator.Equals)
								  };
				classes.AddRange(additionalClasses.Select(p => new Tuple<string, string, FindOperator>("class", p, FindOperator.Equals)));
				return this.FindAllByAttributes<T>(classes, containerControl);
			}
			finally
			{
				stopwatch.Stop();
				if (this.TestSettings.Debug)
				{
					logger.Debug("Completed FindByClass - [RUNTIME: {0}]", stopwatch.Elapsed.TotalMilliseconds);
				}
			}
		}

		/// <summary>The find all by name.</summary>
		/// <param name="name">The name.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="IEnumerable"/>.</returns>
		public override IEnumerable<T> FindAllByName<T>(string name, HtmlControl containingControl = null)
		{
			return this.FindAll(new T { Name = name }, containingControl);
		}

		/// <summary>The focus.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <exception cref="ArgumentException"></exception>
		public override void Focus(HtmlControl htmlControl)
		{
			// Do Not use this line as primary right now, breaks alot of tests
			//this.ScrollToMiddle(this.GetFrameworkControl(htmlControl));
			var control = this.GetFrameworkControl(htmlControl);

			var wrappedElement = control as IWrapsDriver;
			if (wrappedElement == null)
			{
				throw new ArgumentException("element", "Element must wrap a web driver");
			}

			IWebDriver driver = wrappedElement.WrappedDriver;
			var javascript = driver as IJavaScriptExecutor;
			if (javascript == null)
			{
				throw new ArgumentException("element", "Element must wrap a web driver that supports javascript execution");
			}

			javascript.ExecuteScript("arguments[0].focus()", control);
		}
		 
		/// <summary>The get attribute.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <param name="attribute">The attribute.</param>
		/// <returns>The <see cref="string"/>.</returns>
		public override string GetAttribute(HtmlControl htmlControl, string attribute)
		{
			if (attribute.ToLower() == "innerText".ToLower())
			{
				attribute = "textContent";
			}

			var control = this.GetFrameworkControl(htmlControl);
			var attr = control.GetAttribute(attribute);
			if (attribute == "textContent")
			{
				attr = Regex.Replace(attr.Trim(), "\\s+", " ");
			}

			return attr;
		}

		/// <summary>The handle alert.</summary>
		/// <param name="action">The action.</param>
		/// <param name="waitForCondition">The wait for condition.</param>
		public override void HandleAlert(AlertAction action, Func<Core.TestFramework.Browser, bool> waitForCondition = null)
		{
			var wait = new WebDriverWait(this.frameworkBrowser, TimeSpan.FromMilliseconds(this.TestSettings.Timeout));
			var alert = wait.Until(this.GetActiveAlert);

			switch (action)
			{
				case AlertAction.Ok:
					alert.Accept();
					break;
				case AlertAction.Cancel:
					alert.Dismiss();
					break;
			}

			if (waitForCondition != null)
			{
				this.WaitForCondition(waitForCondition);
			}
		}

		/// <summary>The handle alert.</summary>
		/// <param name="actionThatCausesAlert">The action that causes alert.</param>
		/// <param name="action">The action.</param>
		/// <param name="waitForCondition">The wait for condition.</param>
		public override void HandleAlert(
			Action actionThatCausesAlert, AlertAction action, Func<Core.TestFramework.Browser, bool> waitForCondition = null)
		{
			actionThatCausesAlert();
			this.HandleAlert(action, waitForCondition);
		}

		public override void ScrollToMiddle(HtmlControl htmlControl)
		{
			var control = this.GetFrameworkControl(htmlControl);
			this.ScrollToMiddle(control);
		}

		private void ScrollToMiddle(IWebElement element)
		{
			this.frameworkBrowser.LoadjQuery();

			var control = element;
			var wrappedElement = control as IWrapsDriver;
			if (wrappedElement == null)
			{
				throw new ArgumentException("element", "Element must wrap a web driver");
			}

			IWebDriver driver = wrappedElement.WrappedDriver;
			var javascript = driver as IJavaScriptExecutor;
			if (javascript == null)
			{
				throw new ArgumentException("element", "Element must wrap a web driver that supports javascript execution");
			}

			if (this.TestSettings.Debug)
			{
				this.Logger.Debug("Perform ScrollTo..");
			}

			javascript.ExecuteScript("$(arguments[0]).each(function(){$('html,body').animate({ scrollTop: $(this).offset().top - ($(window).height() - $(this).outerHeight(true) ) /2 }, 200); });", control);
			
			//javascript.ExecuteScript("window.scrollTo($(arguments[0]).offset().left, $(arguments[0]).offset().top)", control);
			//javascript.ExecuteScript("$(arguments[0]).scrollIntoView();", control);
			Thread.Sleep(TestSettings.ScrollToMiddleWaitTime);
		}

		/// <summary>The mouse over.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <exception cref="ArgumentException"></exception>
		public override void MouseOver(HtmlControl htmlControl)
		{
			this.frameworkBrowser.LoadjQuery();

			var control = this.GetFrameworkControl(htmlControl);
			var wrappedElement = control as IWrapsDriver;
			if (wrappedElement == null)
			{
				throw new ArgumentException("element", "Element must wrap a web driver");
			}

			IWebDriver driver = wrappedElement.WrappedDriver;
			var javascript = driver as IJavaScriptExecutor;
			if (javascript == null)
			{
				throw new ArgumentException("element", "Element must wrap a web driver that supports javascript execution");
			}

			if (this.TestSettings.Debug)
			{
				this.Logger.Debug("Perform MouseOver..");
			}
				
			javascript.ExecuteScript("$(arguments[0]).trigger('mouseover')", control);
			
			Thread.Sleep(TestSettings.MouseOverWaitTime);
		}

		/// <summary>The mouse over.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <exception cref="ArgumentException"></exception>
		public override void MouseOut(HtmlControl htmlControl)
		{
				this.frameworkBrowser.LoadjQuery();

				var control = this.GetFrameworkControl(htmlControl);
				var wrappedElement = control as IWrapsDriver;
				if (wrappedElement == null)
				{
					throw new ArgumentException("element", "Element must wrap a web driver");
				}

				IWebDriver driver = wrappedElement.WrappedDriver;
				var javascript = driver as IJavaScriptExecutor;
				if (javascript == null)
				{
					throw new ArgumentException("element", "Element must wrap a web driver that supports javascript execution");
				}

				if (this.TestSettings.Debug)
				{
					this.Logger.Debug("Perform MouseOver..");
				}
				
			javascript.ExecuteScript("$(arguments[0]).trigger('mouseout')", control);
			
			Thread.Sleep(TestSettings.MouseOutWaitTime);
		}

		/// <summary>The mouse over.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <exception cref="ArgumentException"></exception>
		public override void MouseHover(HtmlControl htmlControl)
		{
			this.frameworkBrowser.LoadjQuery();

			var control = this.GetFrameworkControl(htmlControl);
			var wrappedElement = control as IWrapsDriver;
			if (wrappedElement == null)
			{
				throw new ArgumentException("element", "Element must wrap a web driver");
			}

			IWebDriver driver = wrappedElement.WrappedDriver;
			var javascript = driver as IJavaScriptExecutor;
			if (javascript == null)
			{
				throw new ArgumentException("element", "Element must wrap a web driver that supports javascript execution");
			}

			if (this.TestSettings.Debug)
			{
				this.Logger.Debug("Perform MouseOver..");
			}

				javascript.ExecuteScript("$(arguments[0]).trigger('hover')", control);
				Thread.Sleep(TestSettings.MouseHoverWaitTime);
		}

		public override void MouseLeave(HtmlControl htmlControl)
		{
			this.frameworkBrowser.LoadjQuery();

			var control = this.GetFrameworkControl(htmlControl);
			var wrappedElement = control as IWrapsDriver;
			if (wrappedElement == null)
			{
				throw new ArgumentException("element", "Element must wrap a web driver");
			}

			IWebDriver driver = wrappedElement.WrappedDriver;
			var javascript = driver as IJavaScriptExecutor;
			if (javascript == null)
			{
				throw new ArgumentException("element", "Element must wrap a web driver that supports javascript execution");
			}

			if (this.TestSettings.Debug)
			{
				this.Logger.Debug("Perform MouseOver..");
			}

			javascript.ExecuteScript("$(arguments[0]).trigger('mouseleave')", control);
			
			Thread.Sleep(TestSettings.MouseLeaveWaitTime);
		}

		public override void MouseEnter(HtmlControl htmlControl)
		{
			//if (this.TestSettings.Browser == BrowserType.FireFox)
			//{
			//	Actions actions = new Actions(this.frameworkBrowser);
			//	actions.MoveToElement(this.GetFrameworkControl(htmlControl)).Build().Perform();
			//}
			//else
			//{
				this.frameworkBrowser.LoadjQuery();

				var control = this.GetFrameworkControl(htmlControl);
				var wrappedElement = control as IWrapsDriver;
				if (wrappedElement == null)
				{
					throw new ArgumentException("element", "Element must wrap a web driver");
				}

				IWebDriver driver = wrappedElement.WrappedDriver;
				var javascript = driver as IJavaScriptExecutor;
				if (javascript == null)
				{
					throw new ArgumentException("element", "Element must wrap a web driver that supports javascript execution");
				}

				if (this.TestSettings.Debug)
				{
					this.Logger.Debug("Perform MouseOver..");
				}

				javascript.ExecuteScript("$(arguments[0]).trigger('mouseenter')", control);

				Thread.Sleep(TestSettings.MouseEnterWaitTime);
		}

		/// <summary>The navigate to.</summary>
		/// <param name="url">The url.</param>
		/// <exception cref="UriFormatException"></exception>
		public override void NavigateTo(string url)
		{
			Uri uri;
			try
			{
				if (url.StartsWith("~") || url.StartsWith("/"))
				{
					string uriString = url.TrimStart(new[] { '~' });
					if (!uriString.StartsWith("/"))
					{
						uriString = "/" + uriString;
					}

					var baseUrl = new Uri(this.frameworkBrowser.Url);
					var stringUrl = string.IsNullOrEmpty(baseUrl.PathAndQuery.Trim('/'))
										? baseUrl.AbsoluteUri.Trim('/')
										: baseUrl.AbsoluteUri.Replace(baseUrl.PathAndQuery, string.Empty);
					if (!string.IsNullOrEmpty(baseUrl.Fragment))
					{
						stringUrl = stringUrl.Replace(baseUrl.Fragment, string.Empty);
					}

					uri = new Uri(stringUrl + uriString);

				}
				else
				{
					uri = new Uri(url);
				}
			}
			catch (UriFormatException ex)
			{
				throw new UriFormatException(
					"Url passed in has invalid format. If you are trying to use relative paths, please make sure your url starts with '/' or '~/'. If you are using fully qualified paths, make sure they are propertly prefixed (i.e. start with 'http://', 'file://' or 'c:'). InnerException: "
						+ ex.ToString());
			}

			this.frameworkBrowser.Navigate().GoToUrl(uri);
		}

		/// <summary>The perform click.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <param name="waitForBehavior">The wait for behavior.</param>
		public override void PerformClick(HtmlControl htmlControl, Func<Core.TestFramework.Browser, bool> waitForBehavior = null)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();

			try
			{
				var control = this.GetFrameworkControl(htmlControl);

				var stopwatchVisible = new Stopwatch();
				stopwatchVisible.Start();

				try
				{
					if (this.TestSettings.Debug)
					{
						this.Logger.Debug("Started IsElementVisible Check");
					}

					this.WaitForCondition(delegate { return control.IsElementVisible(); });
				}
				finally
				{
					stopwatch.Stop();
					if (this.TestSettings.Debug)
					{
						this.Logger.Debug("Completed IsElementVisible Check - [RUNTIME: {0}]", stopwatch.Elapsed.TotalMilliseconds);
					}
				}

				// if IE loses focus, the click event will not behave as expected, instead
				// returning focus to the browser via that element
				if (TestSettings.Browser == BrowserType.InternetExplorer)
				{
					this.frameworkBrowser.SwitchTo();
				}

				//var action = new Actions(this.frameworkBrowser);
				//action.Click(control).Build().Perform();
				
				control.Click();

				if (waitForBehavior != null)
				{
					this.WaitForCondition(waitForBehavior);
				}
			}
			catch (ElementNotVisibleException)
			{
				var control = this.GetFrameworkControl(htmlControl);
				this.ScrollToMiddle(control);
				control.Click();
				if (waitForBehavior != null)
				{
					this.WaitForCondition(waitForBehavior);
				}
			}
			catch (InvalidOperationException)
			{
				var control = this.GetFrameworkControl(htmlControl);
				this.ScrollToMiddle(control);
				control.Click();
				if (waitForBehavior != null)
				{
					this.WaitForCondition(waitForBehavior);
				}
			}
			finally
			{
				stopwatch.Stop();
				if (this.TestSettings.Debug)
				{
					this.Logger.Debug("Completed Click - [RUNTIME: {0}]", stopwatch.Elapsed.TotalMilliseconds);
				}
			}
		}

		/// <summary>The perform click.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <param name="clickAction">The click action.</param>
		/// <param name="waitForBehavior">The wait for behavior.</param>
		public override void PerformClick(
			HtmlControl htmlControl, ClickAction clickAction, Func<Core.TestFramework.Browser, bool> waitForBehavior = null)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();

			try
			{
				var control = this.GetFrameworkControl(htmlControl);
				this.WaitForCondition(delegate { return control.IsElementVisible(); });

				var action = new Actions(this.frameworkBrowser);
				switch (clickAction)
				{
					case ClickAction.LeftClick:
						// action.Click(control).Build().Perform();
						control.Click();
						break;
					case ClickAction.DoubleLeftClick:
						action.DoubleClick(control).Build().Perform();
						break;
					case ClickAction.RightClick:
						action.ContextClick(control).Build().Perform();
						break;
				}

				if (waitForBehavior != null)
				{
					this.WaitForCondition(waitForBehavior);
				}
			}
			finally
			{
				stopwatch.Stop();
				if (this.TestSettings.Debug)
				{
					this.Logger.Debug("Completed Click - [RUNTIME: {0}]", stopwatch.Elapsed.TotalMilliseconds);
				}
			}
		}

		/// <summary>The perform refresh.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <returns>The <see cref="bool"/>.</returns>
		public override bool PerformRefresh(HtmlControl htmlControl)
		{
			this.Logger.Trace("Performing Refresh [{0}]", ((Locator)htmlControl.Locator).Term);
			var stopwatch = new Stopwatch();
			stopwatch.Start();

			var locator = (Locator)htmlControl.Locator;

			IWebElement nativeControl = null;

			try
			{
				switch (locator.FindBy)
				{
					case FindBy.XPath:
						nativeControl = this.frameworkBrowser.FindElement(OpenQA.Selenium.By.XPath(locator.Term));
						break;
					case FindBy.Id:
						nativeControl = this.frameworkBrowser.FindElement(OpenQA.Selenium.By.Id(locator.Term));
						break;
					case FindBy.Class:
						nativeControl = this.frameworkBrowser.FindElement(OpenQA.Selenium.By.ClassName(locator.Term));
						break;
					case FindBy.CSSSelector:
						nativeControl = this.frameworkBrowser.FindElement(OpenQA.Selenium.By.CssSelector(locator.Term));
						break;
					case FindBy.LinkText:
						nativeControl = this.frameworkBrowser.FindElement(OpenQA.Selenium.By.LinkText(locator.Term));
						break;
					case FindBy.PartialLinkText:
						nativeControl = this.frameworkBrowser.FindElement(OpenQA.Selenium.By.PartialLinkText(locator.Term));
						break;
					case FindBy.TagName:
						nativeControl = this.frameworkBrowser.FindElement(OpenQA.Selenium.By.TagName(locator.Term));
						break;
					case FindBy.Name:
						nativeControl = this.frameworkBrowser.FindElement(OpenQA.Selenium.By.Name(locator.Term));
						break;
				}
			}
			catch (Exception exception)
			{
				this.Logger.Error(exception.Message);
				nativeControl = null;
			}
			finally
			{
				stopwatch.Stop();
				if (this.TestSettings.Debug)
				{
					this.Logger.Debug(
						"Completed Refresh [{1}] - [RUNTIME: {0}]", stopwatch.Elapsed.TotalMilliseconds, ((Locator)htmlControl.Locator).Term);
				}
			}

			if (nativeControl == null)
			{
				return false;
			}

			this.PopulateControl(htmlControl, nativeControl);
			return true;
		}

		public override void SetValue(HtmlControl htmlControl, string value)
		{
			var control = this.GetFrameworkControl(htmlControl);
			control.SendKeys(value, true);
		}
		/// <summary>The set text.</summary>
		/// <param name="htmlControl"></param>
		/// <param name="value">The value.</param>
		public override void SetValue(HtmlControl htmlControl, string value, bool clearFirst)
		{
			var control = this.GetFrameworkControl(htmlControl);
			control.SendKeys(value, clearFirst);
		}

		/// <summary>The wait.</summary>
		/// <param name="interval">The interval.</param>
		/// <param name="ajaxTimeout">The ajax timeout.</param>
		public override void Wait(int interval, int ajaxTimeout)
		{
			this.Logger.Trace("Waiting...");
			var stopwatch = new Stopwatch();
			stopwatch.Start();

			try
			{
				this.frameworkBrowser.WaitForPageLoad(ajaxTimeout);
			}
			finally
			{
				stopwatch.Stop();
				if (this.TestSettings.Debug)
				{
					this.Logger.Debug("Completed PageLoad Wait - [RUNTIME: {0}]", stopwatch.Elapsed.TotalMilliseconds);
				}
			}

			System.Threading.Thread.Sleep(interval);
		}

		
		#endregion

		#region Methods

		/// <summary>The cast web element.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <returns>The <see cref="IWebElement"/>.</returns>
		/// <exception cref="InvalidCastException"></exception>
		private static IWebElement CastWebElement(HtmlControl htmlControl)
		{
			var control = htmlControl.FrameworkControl as IWebElement;
			if (control == null)
			{
				throw new InvalidCastException("Native framework control is either null or otherwise not castable to IWebElement.");
			}

			return control;
		}

		/// <summary>The get attributes.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <returns>The <see cref="Dictionary"/>.</returns>
		private static Dictionary<string, string> GetAttributes(HtmlControl htmlControl)
		{
			var attributes = new Dictionary<string, string>();

			foreach (var attr in htmlControl.Attributes)
			{
				var attrName = attr.Key.ToLower();
				var attrValue = attr.Value;
				if (!attributes.ContainsKey(attrName) && !string.IsNullOrEmpty(attrValue))
				{
					attributes.Add(attrName, attrValue);
				}
			}

			return attributes;
		}

		/// <summary>The do wait.</summary>
		/// <param name="milliseconds">The milliseconds.</param>
		private void DoWait(int milliseconds)
		{
			var wait = new WebDriverWait(this.frameworkBrowser, TimeSpan.FromMilliseconds(milliseconds));
			var waitComplete = wait.Until<bool>(
				arg =>
				{
					System.Threading.Thread.Sleep(milliseconds);
					return true;
				});
		}

		/// <summary>The find native control.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <param name="container">The container.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="IWebElement"/>.</returns>
		private IWebElement FindNativeControl<T>(T htmlControl, ISearchContext container) where T : HtmlControl
		{
			var xpath = this.GetXPath(htmlControl);
			IWebElement nativeControl = null;

			if (container != this.frameworkBrowser)
			{
				xpath = "." + xpath;
			}

			nativeControl = container.FindElement(OpenQA.Selenium.By.XPath(xpath));

			htmlControl.FrameworkControl = nativeControl;
			htmlControl.Locator = new Locator { FindBy = FindBy.XPath, Term = xpath };
			return nativeControl;
		}

		/// <summary>The find native control.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="IWebElement"/>.</returns>
		private IWebElement FindNativeControl<T>(T htmlControl) where T : HtmlControl
		{
			return this.FindNativeControl(htmlControl, this.frameworkBrowser);
		}

		/// <summary>The find native controls.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <param name="container">The container.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="IEnumerable"/>.</returns>
		private IEnumerable<IWebElement> FindNativeControls<T>(T htmlControl, ISearchContext container) where T : HtmlControl
		{
			var xpath = this.GetXPath(htmlControl);

			if (container != this.frameworkBrowser)
			{
				xpath = "." + xpath;
			}

			htmlControl.Locator = new Locator { FindBy = FindBy.XPath, Term = xpath };
			return container.FindElements(OpenQA.Selenium.By.XPath(xpath));
		}

		/// <summary>The find native controls.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="IEnumerable"/>.</returns>
		private IEnumerable<IWebElement> FindNativeControls<T>(T htmlControl) where T : HtmlControl
		{
			return this.FindNativeControls(htmlControl, this.frameworkBrowser);
		}

		/// <summary>The get active alert.</summary>
		/// <param name="driver">The driver.</param>
		/// <returns>The <see cref="IAlert"/>.</returns>
		private IAlert GetActiveAlert(IWebDriver driver)
		{
			try
			{
				return driver.SwitchTo().Alert();
			}
			catch (NoAlertPresentException)
			{
				return null;
			}
		}

		/// <summary>The get framework control.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <returns>The <see cref="IWebElement"/>.</returns>
		private IWebElement GetFrameworkControl(HtmlControl htmlControl)
		{
			var control = CastWebElement(htmlControl);

			try
			{
				var testcontrol = control.Enabled;
			}
			catch (StaleElementReferenceException)
			{
				htmlControl.Refresh();
				control = CastWebElement(htmlControl);
			}

			return control;
		}

		/// <summary>The get xpath.</summary>
		/// <param name="locator">The locator.</param>
		/// <param name="htmlControl">The html control.</param>
		/// <returns>The <see cref="string"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		private string GetXPath(Locator locator, HtmlControl htmlControl)
		{
			switch (locator.FindBy)
			{
				case FindBy.XPath:
					return locator.Term;
				case FindBy.Id:
					var type = htmlControl.GetType();
					var newControl = (HtmlControl)Activator.CreateInstance(type);
					newControl.Id = locator.Term;
					return this.GetXPath(newControl);
				default:
					throw new NotImplementedException();
			}
		}

		/// <summary>The get x path.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <returns>The <see cref="string"/>.</returns>
		/// <exception cref="ArgumentNullException"></exception>
		private string GetXPath(HtmlControl htmlControl)
		{
			if (htmlControl == null)
			{
				throw new ArgumentNullException("htmlControl");
			}

			var tagname = htmlControl.TagName;

			var attributes = GetAttributes(htmlControl);
			if (!htmlControl.ControlPopulated && !string.IsNullOrEmpty(htmlControl.InnerText))
			{
				attributes.Add("innerText", htmlControl.InnerText);
			}

			if (tagname == HtmlTag.input.GetHtmlTag())
			{
				attributes.Add("type", htmlControl.CastTo<HtmlInput>().Type.ToString().ToLower());
			}

			return this.GetXPath(
				tagname, attributes.Select(p => new Tuple<string, string, FindOperator>(p.Key, p.Value, FindOperator.Equals)).ToList());
		}

		/// <summary>The get x path.</summary>
		/// <param name="tagname">The tagname.</param>
		/// <param name="attributes">The attributes.</param>
		/// <returns>The <see cref="string"/>.</returns>
		private string GetXPath(string tagname, IList<Tuple<string, string, FindOperator>> attributes)
		{
			var sb = new StringBuilder();
			sb.AppendFormat("//{0}", tagname);
			if (attributes.Any())
			{
				var firstAttr = attributes.First();
				sb.AppendFormat("[{0}", this.GetAttributeXPath(firstAttr.Item1, firstAttr.Item2, firstAttr.Item3));
				for (int i = 1; i < attributes.Count; i++)
				{
					if (attributes.ElementAt(i).Item1 == "innerhtml" || attributes.ElementAt(i).Item1 == "outerhtml")
					{
						continue;
					}

					var attr = attributes.ElementAt(i);
					sb.AppendFormat(" and {0}", this.GetAttributeXPath(attr.Item1, attr.Item2, attr.Item3));
				}

				sb.Append("]");
			}

			return sb.ToString();
		}

		/// <summary>The get attribute x path.</summary>
		/// <param name="attributeName">The attribute name.</param>
		/// <param name="attributeValue">The attribute value.</param>
		/// <param name="findOperator">The find operator.</param>
		/// <returns>The <see cref="string"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		private string GetAttributeXPath(string attributeName, string attributeValue, FindOperator findOperator)
		{
			attributeName = attributeName.ToLower();
			switch (findOperator)
			{
				case FindOperator.Equals:
					switch (attributeName)
					{
						case "class":
							return string.Format("contains(concat(' ', normalize-space(@{0}), ' '), ' {1} ')", attributeName, attributeValue);
						case "innertext":
							return string.Format("normalize-space(.)={0}", GenerateConcatForXPath(attributeValue)); 
						default:
							return string.Format("@{0}='{1}'", attributeName, attributeValue);
					}

				case FindOperator.StartsWith:
					switch (attributeName)
					{
						case "innertext":
							return string.Format("starts-with(normalize-space(.), {0})", GenerateConcatForXPath(attributeValue));
						default:
							return string.Format("starts-with(@{0}, '{1}')", attributeName, attributeValue);
					}

				case FindOperator.Contains:
					switch (attributeName)
					{
						case "innertext":
							return string.Format("contains(normalize-space(.), {0})", GenerateConcatForXPath(attributeValue));
						default:
							return string.Format("contains(@{0}, '{1}')", attributeName, attributeValue);
					}

				case FindOperator.EndsWith:
					switch (attributeName)
					{
						case "innertext":
							return string.Format("{0} = substring(normalize-space(.), string-length(normalize-space(.)) - string-length({0}) + 1)", GenerateConcatForXPath(attributeValue));
						default:
							return string.Format(
								"'{1}' = substring(@{0}, string-length(@{0}) - string-length('{1}') + 1)", attributeName, attributeValue);
					}

				default:
					throw new NotImplementedException("Unhandled FindOperator: '" + findOperator);
			}
		}

		/// <summary>Generates a concat function to stand in for strings containing apostrophes and/or quotation marks.</summary>
		/// <param name="xpathQueryString">The string in xpath query requiring escaped quote characters.</param>
		/// <returns>The <see cref="string"/>.</returns>
		private static string GenerateConcatForXPath(string xpathQueryString)
		{
			var returnString = new StringBuilder();
			var searchString = xpathQueryString;
			var quoteChars = new char[] { '\'', '"' };

			var quotePos = searchString.IndexOfAny(quoteChars);
			if (quotePos == -1)
			{
				returnString.AppendFormat("'{0}'", searchString);
			}
			else
			{
				returnString.Append("concat(");
				while (quotePos != -1)
				{
					string subString = searchString.Substring(0, quotePos);
					returnString.AppendFormat("'{0}', ", subString);
					if (searchString.Substring(quotePos, 1) == "'")
					{
						returnString.Append("\"'\", ");
					}
					else
					{
						// must be a double quote
						returnString.Append("'\"', ");
					}

					searchString = searchString.Substring(quotePos + 1, searchString.Length - quotePos - 1);
					quotePos = searchString.IndexOfAny(quoteChars);
				}

				returnString.AppendFormat("'{0}')", searchString);
			}

			return returnString.ToString();
		}

		/// <summary>The populate control.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <param name="element">The element.</param>
		/// <typeparam name="T">The type of HtmlControl</typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		private T PopulateControl<T>(T htmlControl, IWebElement element) where T : HtmlControl
		{
			if (element == null)
			{
				return null;
			}

			var stopwatch = new Stopwatch();
			stopwatch.Start();

			try
			{
				double propertytime = 0;
				double attributetime = 0;

				htmlControl.ClearAttributes();
				htmlControl.Browser = this;
				htmlControl.FrameworkControl = element;
				if (htmlControl.HtmlTag == HtmlTag.any)
				{
					HtmlTag resultTag;
					if (Enum.TryParse(element.TagName, true, out resultTag))
					{
						htmlControl.CastTo<HtmlDynamic>().SetHtmlTag(resultTag);
					}
				}

				var outerhtml = string.Empty;
				try
				{
					outerhtml = element.GetAttribute("outerHTML");
					var outerhtmlregex = new Regex("^<(.*?)\\>", RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);
					outerhtml = outerhtmlregex.Match(outerhtml).Value;

					htmlControl.OuterHtml = outerhtml.Trim();

					propertytime = stopwatch.Elapsed.TotalMilliseconds;
					if (this.TestSettings.Debug)
					{
						this.Logger.Debug("Completed Populate - Properties - [RUNTIME: {0}]", propertytime);
					}
				}
				catch (NotSupportedException)
				{
				}

				var attributesRegEx = new Regex(
					"(?<name>.[^\"'=\\s]*)\\s*=\\s*(?<value>(\"[^\"]*\"|'[^']*')|([^\\s].*?)+)\\s*", 
					RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);
				var matches = attributesRegEx.Matches(outerhtml.Trim());
				
				foreach (Match match in matches)
				{
					string name = match.Groups["name"].Value.Trim();
					string value = match.Groups["value"].Value.Trim().Trim('\"');

					htmlControl.AddAttribute(name, value);
				}
				attributetime = stopwatch.Elapsed.TotalMilliseconds - propertytime;
				if (this.TestSettings.Debug)
				{
					this.Logger.Debug("Completed Populate - Attributes - [RUNTIME: {0}]", attributetime);
				}
			}
			finally
			{
				stopwatch.Stop();
				if (this.TestSettings.Debug)
				{
					this.Logger.Debug("Completed Populate Control - [RUNTIME: {0}]", stopwatch.Elapsed.TotalMilliseconds);
				}
			}
			htmlControl.ControlPopulated = true;
			return htmlControl;
		}

		#endregion

		public override string TakeScreenShot()
		{
			return this.TakeScreenShot(Guid.NewGuid().ToString());
		}

		public override string TakeScreenShot(string filename)
		{
			if (!filename.ToLower().EndsWith(".png"))
			{
				filename += ".png";
			}

			try
			{
				var screenShot = ((ITakesScreenshot)this.frameworkBrowser).GetScreenshot();
				screenShot.SaveAsFile(filename, ImageFormat.Png);
			}
			catch (Exception ex)
			{
				this.Logger.Warn("An error occurred adding screenshot of confirmationPage: {0}", ex.Message);
			}

			return filename;
		}

		public override string CurrentWindowName()
		{
			return this.frameworkBrowser.CurrentWindowHandle;
		}

		public override IReadOnlyCollection<string> WindowNames()
		{
			return this.frameworkBrowser.WindowHandles;
		}

		public override void SwitchWindow(string windowName = "", FindOperator findOperator = FindOperator.Equals)
		{
			var originalHandle = this.frameworkBrowser.CurrentWindowHandle;
			var allWindows = this.frameworkBrowser.WindowHandles;

			IList<string> handleList = new List<string>();

			if (string.IsNullOrWhiteSpace(windowName))
			{
				handleList = (from w in allWindows
							  where w != originalHandle
							  select w).ToList();
			}
			else
			{
				handleList = (from w in allWindows
							  where w == windowName
							  select w).ToList();
			}

			if (handleList.Any())
			{
				this.frameworkBrowser.SwitchTo().Window(handleList.First());
				return;
			}

			foreach (var curWindow in allWindows)
			{
				this.frameworkBrowser.SwitchTo().Window(curWindow);

				switch (findOperator)
				{
					case FindOperator.Equals:
						if (this.frameworkBrowser.Title == windowName)
						{
							return;
						}

						break;
					case FindOperator.EndsWith:
						if (this.frameworkBrowser.Title.EndsWith(windowName))
						{
							return;
						}

						break;
					case FindOperator.StartsWith:
						if (this.frameworkBrowser.Title.StartsWith(windowName))
						{
							return;
						}

						break;
					case FindOperator.Contains:
						if (this.frameworkBrowser.Title.Contains(windowName))
						{
							return;
						}

						break;
				}
			}
		}
	}
}