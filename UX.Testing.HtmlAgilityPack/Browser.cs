------------------------------------------------------------------------------------------------------------

namespace UX.Testing.HtmlAgilityPack
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Diagnostics;
	using System.Linq;
	using System.Text;
	using System.Text.RegularExpressions;

	using global::HtmlAgilityPack;

	using UX.Testing.Core;
	using UX.Testing.Core.Controls;
	using UX.Testing.Core.Enums;
	using UX.Testing.Core.Extensions;
	using UX.Testing.Core.Logging;

	/// <summary>The browser.</summary>
	internal class Browser : Core.TestFramework.Browser
	{
		#region Fields

		/// <summary>The framework browser.</summary>
		private HtmlDocument frameworkBrowser;

		#endregion

		#region Constructors and Destructors

		/// <summary>Initializes a new instance of the <see cref="Browser"/> class.</summary>
		/// <param name="frameworkBrowser">The framework browser.</param>
		public Browser(HtmlDocument frameworkBrowser)
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
		/// <exception cref="NotImplementedException"></exception>
		public override string Url
		{
			get
			{
				throw new NotImplementedException();
			}
		}

        public override string PageTitle { get { return string.Empty; } }

        #endregion

        #region Properties

        /// <summary>Gets the logger.</summary>
        protected override sealed ILogger Logger { get; set; }

		#endregion

		#region Public Methods and Operators

		/// <summary>The check is enabled.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <returns>The <see cref="bool"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override bool CheckIsEnabled(HtmlControl htmlControl)
		{
			var nativeControl = this.GetFrameworkControl(htmlControl);

			return nativeControl.Attributes.Select(p => p.Name.ToLower() == "disabled") == null;
		}

		/// <summary>The check visibility.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <returns>The <see cref="bool"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override bool CheckVisibility(HtmlControl htmlControl)
		{
			throw new NotImplementedException();
		}

		/// <summary>The close.</summary>
		/// <exception cref="NotImplementedException"></exception>
		public override void Close()
		{
			this.frameworkBrowser = null;
		}

		/// <summary>The current window name.</summary>
		/// <returns>The <see cref="string"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override string CurrentWindowName()
		{
			throw new NotImplementedException();
		}

		/// <summary>The find.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <param name="containingControl">The containing control.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
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
			var searchContext = this.frameworkBrowser.DocumentNode;

			if (containingControl != null)
			{
				var parentLocator = (Locator)containingControl.Locator;
				xpath = this.GetXPath(parentLocator, containingControl) + xpath;
				searchContext = (HtmlNode)containingControl.FrameworkControl;
			}

			T control = null;
			try
			{
				logger.Trace("Find Element using '{0}'", xpath);
				var nativeControl = this.FindNativeControl(htmlControl, searchContext);

				if (nativeControl == null)
				{
					logger.Trace("Could not Find Element using the following expression '{0}'", xpath);
					return null;
				}

				control = this.PopulateControl(htmlControl, nativeControl);
				control.Locator = new Locator { FindBy = FindBy.XPath, Term = xpath };
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
		/// <returns>The <see cref="IEnumerable"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
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
			var searchContext = this.frameworkBrowser.DocumentNode;
			try
			{
				if (containingControl != null)
				{
					var parentLocator = (Locator)containingControl.Locator;
					xpath = this.GetXPath(parentLocator, containingControl) + xpath;
					searchContext = this.GetFrameworkControl(containingControl);
				}

				logger.Trace("Find All Elements using '{0}'", xpath);

				var controls = this.FindNativeControls(htmlControl, searchContext).Select(p => this.PopulateControl(new T(), p)).ToArray();
				if (controls == null || !controls.Any())
				{
					logger.Trace("Could not Find All Elements using the following expression '{0}'", xpath);
					return new List<T>();
				}

				for (int i = 0; i < controls.Length; i++)
				{
					controls[i].Locator = new Locator { FindBy = FindBy.XPath, Term = "(" + xpath + ")[" + (i + 1) + "]" };
				}

				return controls;
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

		/// <summary>The find all by class.</summary>
		/// <param name="cssClass">The css class.</param>
		/// <param name="containingControl">The containing control.</param>
		/// <param name="additionalClasses">The additional classes.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="IEnumerable"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override IEnumerable<T> FindAllByClass<T>(
			string cssClass, HtmlControl containingControl = null, params string[] additionalClasses)
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
				return this.FindAllByAttributes<T>(classes, containingControl);
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

		/// <summary>The find all by id.</summary>
		/// <param name="id">The id.</param>
		/// <param name="findOperator">The find operator.</param>
		/// <param name="containingControl">The containing control.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="IEnumerable"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override IEnumerable<T> FindAllById<T>(
			string id, FindOperator findOperator = FindOperator.Equals, HtmlControl containingControl = null)
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

		/// <summary>The find all by inner text.</summary>
		/// <param name="innerText">The inner text.</param>
		/// <param name="findOperator">The find operator.</param>
		/// <param name="containingControl">The containing control.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="IEnumerable"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override IEnumerable<T> FindAllByInnerText<T>(
			string innerText, FindOperator findOperator = FindOperator.Equals, HtmlControl containingControl = null)
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

		/// <summary>The find all by name.</summary>
		/// <param name="name">The name.</param>
		/// <param name="containingControl">The containing control.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="IEnumerable"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override IEnumerable<T> FindAllByName<T>(string name, HtmlControl containingControl = null)
		{
			return this.FindAll(new T { Name = name }, containingControl);
		}

		/// <summary>The find ancestor.</summary>
		/// <param name="childControl">The child control.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override T FindAncestor<T>(HtmlControl childControl)
		{
			if (childControl == null)
			{
				return null;
			}

			HtmlNode nativeControl;
			var htmlControl = new T();

			return this.FindAncestor<T>(childControl, htmlControl);
		}

		/// <summary>The find ancestor.</summary>
		/// <param name="childControl">The child control.</param>
		/// <param name="ancestorControl">The ancestor control.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
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

			HtmlNode nativeControl;
			var htmlControl = new T();

			var stopwatch = new Stopwatch();
			stopwatch.Start();
			var logger = new Logger();
			var tmpXPath = "/ancestor::" + this.GetXPath(ancestorControl).TrimStart('/', '/');

			try
			{
				var parentControl = childControl.FrameworkControl.CastTo<HtmlNode>();
				nativeControl = (parentControl.SelectNodes("." + tmpXPath) ?? new HtmlNodeCollection(parentControl)).LastOrDefault();
				
				if (this.TestSettings.Debug)
				{
					this.Logger.Debug("Find Ancestor - Path '{0}'", tmpXPath);
				}

				if (nativeControl == null)
				{
					return null;
				}

				if (nativeControl.Name != htmlControl.TagName)
				{
					return null;
				}

				if (nativeControl.Name == HtmlTag.input.GetHtmlTag())
				{
					if (nativeControl.Attributes.FirstOrDefault(p => p.Name.ToLower() == "type").Value != htmlControl.CastTo<HtmlInput>().Type.ToString().ToLower())
					{
						return null;
					}
				}
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

		/// <summary>The find by class.</summary>
		/// <param name="cssClass">The css class.</param>
		/// <param name="containingControl">The containing control.</param>
		/// <param name="additionalClasses">The additional classes.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override T FindByClass<T>(
			string cssClass, HtmlControl containingControl = null, params string[] additionalClasses)
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
				return this.FindByAttributes<T>(classes, containingControl);
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

		/// <summary>The find by id.</summary>
		/// <param name="id">The id.</param>
		/// <param name="findOperator">The find operator.</param>
		/// <param name="containingControl">The containing control.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override T FindById<T>(
			string id, FindOperator findOperator = FindOperator.Equals, HtmlControl containingControl = null)
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

		/// <summary>The find by inner text.</summary>
		/// <param name="innerText">The inner text.</param>
		/// <param name="findOperator">The find operator.</param>
		/// <param name="containingControl">The containing control.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override T FindByInnerText<T>(
			string innerText, FindOperator findOperator = FindOperator.Equals, HtmlControl containingControl = null)
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

		/// <summary>The find by name.</summary>
		/// <param name="name">The name.</param>
		/// <param name="containingControl">The containing control.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
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

		/// <summary>The find control.</summary>
		/// <param name="by">The by.</param>
		/// <returns>The <see cref="HtmlControl"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override HtmlControl FindControl(By by)
		{
			if (by == null)
			{
				throw new ArgumentNullException("by", "by cannot be null");
			}

			return @by.FindControl(this);
		}

		/// <summary>The find control by class name.</summary>
		/// <param name="className">The class name.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="HtmlControl"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override HtmlControl FindControlByClassName(
			string className, HtmlControl parentControl = null)
		{
			throw new NotImplementedException();
		}

		/// <summary>The find control by css selector.</summary>
		/// <param name="cssSelecto">The css selecto.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="HtmlControl"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override HtmlControl FindControlByCssSelector(
			string cssSelecto, HtmlControl parentControl = null)
		{
			throw new NotImplementedException();
		}

		/// <summary>The find control by id.</summary>
		/// <param name="id">The id.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="HtmlControl"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override HtmlControl FindControlById(string id, HtmlControl parentControl = null)
		{
			throw new NotImplementedException();
		}

		/// <summary>The find control by link text.</summary>
		/// <param name="linkText">The link text.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="HtmlControl"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override HtmlControl FindControlByLinkText(string linkText, HtmlControl parentControl = null)
		{
			throw new NotImplementedException();
		}

		/// <summary>The find control by name.</summary>
		/// <param name="name">The name.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="HtmlControl"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override HtmlControl FindControlByName(string name, HtmlControl parentControl = null)
		{
			throw new NotImplementedException();
		}

		/// <summary>The find control by partial link text.</summary>
		/// <param name="partialLinkText">The partial link text.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="HtmlControl"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override HtmlControl FindControlByPartialLinkText(
			string partialLinkText, HtmlControl parentControl = null)
		{
			throw new NotImplementedException();
		}

		/// <summary>The find control by tag name.</summary>
		/// <param name="tagName">The tag name.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="HtmlControl"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override HtmlControl FindControlByTagName(string tagName, HtmlControl parentControl = null)
		{
			throw new NotImplementedException();
		}

		/// <summary>The find controls.</summary>
		/// <param name="by">The by.</param>
		/// <returns>The <see cref="ReadOnlyCollection"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override ReadOnlyCollection<HtmlControl> FindControls(By by)
		{
			if (by == null)
			{
				throw new ArgumentNullException("by", "by cannot be null");
			}

			return @by.FindControls(this);
		}

		/// <summary>The find controls by class name.</summary>
		/// <param name="className">The class name.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="ReadOnlyCollection"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override ReadOnlyCollection<HtmlControl> FindControlsByClassName(
			string className, HtmlControl parentControl = null)
		{
			throw new NotImplementedException();
		}

		/// <summary>The find controls by css selector.</summary>
		/// <param name="cssSelector">The css selector.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="ReadOnlyCollection"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override ReadOnlyCollection<HtmlControl> FindControlsByCssSelector(
			string cssSelector, HtmlControl parentControl = null)
		{
			throw new NotImplementedException();
		}

		/// <summary>The find controls by id.</summary>
		/// <param name="id">The id.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="ReadOnlyCollection"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override ReadOnlyCollection<HtmlControl> FindControlsById(
			string id, HtmlControl parentControl = null)
		{
			throw new NotImplementedException();
		}

		/// <summary>The find controls by link text.</summary>
		/// <param name="linkText">The link text.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="ReadOnlyCollection"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override ReadOnlyCollection<HtmlControl> FindControlsByLinkText(
			string linkText, HtmlControl parentControl = null)
		{
			throw new NotImplementedException();
		}

		/// <summary>The find controls by name.</summary>
		/// <param name="name">The name.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="ReadOnlyCollection"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override ReadOnlyCollection<HtmlControl> FindControlsByName(
			string name, HtmlControl parentControl = null)
		{
			throw new NotImplementedException();
		}

		/// <summary>The find controls by partial link text.</summary>
		/// <param name="partialLinkText">The partial link text.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="ReadOnlyCollection"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override ReadOnlyCollection<HtmlControl> FindControlsByPartialLinkText(
			string partialLinkText, HtmlControl parentControl = null)
		{
			throw new NotImplementedException();
		}

		/// <summary>The find controls by tag name.</summary>
		/// <param name="tagName">The tag name.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="ReadOnlyCollection"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override ReadOnlyCollection<HtmlControl> FindControlsByTagName(
			string tagName, HtmlControl parentControl = null)
		{
			throw new NotImplementedException();
		}

		/// <summary>The find parent.</summary>
		/// <param name="childControl">The child control.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override T FindParent<T>(HtmlControl childControl)
		{
			if (childControl == null)
			{
				return null;
			}

			HtmlNode nativeControl;
			var htmlControl = new T();

			nativeControl = childControl.FrameworkControl.CastTo<HtmlNode>().SelectSingleNode("./..");

			if (nativeControl == null)
			{
				return null;
			}

			if (nativeControl.Name != htmlControl.TagName)
			{
				return null;
			}

			if (nativeControl.Name == HtmlTag.input.GetHtmlTag())
			{
				if (nativeControl.Attributes.FirstOrDefault(p => p.Name.ToLower() == "type").Value != htmlControl.CastTo<HtmlInput>().Type.ToString().ToLower())
				{
					return null;
				}
			}
			
			htmlControl.Locator = new Locator
								  {
									  FindBy = FindBy.XPath, 
									  Term = this.GetXPath((Locator)childControl.Locator, childControl) + "/.."
								  };

			return this.PopulateControl(htmlControl, nativeControl);
		
		}

		/// <summary>The find range.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <param name="count">The count.</param>
		/// <param name="startIndex">The start index.</param>
		/// <param name="containingControl">The containing control.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="IEnumerable"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override IEnumerable<T> FindRange<T>(
			T htmlControl, int count, int startIndex = 0, HtmlControl containingControl = null)
		{
			if (htmlControl == null)
			{
				htmlControl = new T();
			}

			var xpath = this.GetXPath(htmlControl);

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

		/// <summary>The focus.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <exception cref="NotImplementedException"></exception>
		public override void Focus(HtmlControl htmlControl)
		{
			throw new NotImplementedException();
		}

		/// <summary>The get attribute.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <param name="attribute">The attribute.</param>
		/// <returns>The <see cref="string"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override string GetAttribute(HtmlControl htmlControl, string attribute)
		{
			if (attribute.ToLower() == "innerText".ToLower())
			{
				attribute = "textContent";
			}

			var control = this.GetFrameworkControl(htmlControl);
			if (attribute == "textContent")
			{
				return Regex.Replace(control.InnerText.Trim(), "\\s+", " ");
			}

			if (attribute.ToLower() == "innerhtml")
			{
				return Regex.Replace(control.InnerHtml.Trim(), "\\s+", " ");
			}

			var attr = control.Attributes.FirstOrDefault(p => p.Name.ToLower() == attribute.ToLower());
			return attr != null ? attr.Value : null;
		}

		/// <summary>The go back.</summary>
		/// <exception cref="NotImplementedException"></exception>
		public override void GoBack()
		{
			throw new NotImplementedException();
		}

		/// <summary>The go forward.</summary>
		/// <exception cref="NotImplementedException"></exception>
		public override void GoForward()
		{
			throw new NotImplementedException();
		}

		/// <summary>The handle alert.</summary>
		/// <param name="action">The action.</param>
		/// <param name="waitForCondition">The wait for condition.</param>
		/// <exception cref="NotImplementedException"></exception>
		public override void HandleAlert(AlertAction action, Func<Core.TestFramework.Browser, bool> waitForCondition = null)
		{
			throw new NotImplementedException();
		}

		/// <summary>The handle alert.</summary>
		/// <param name="actionThatCausesAlert">The action that causes alert.</param>
		/// <param name="action">The action.</param>
		/// <param name="waitForCondition">The wait for condition.</param>
		/// <exception cref="NotImplementedException"></exception>
		public override void HandleAlert(
			Action actionThatCausesAlert, AlertAction action, Func<Core.TestFramework.Browser, bool> waitForCondition = null)
		{
			throw new NotImplementedException();
		}

		/// <summary>The mouse enter.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <exception cref="NotImplementedException"></exception>
		public override void MouseEnter(HtmlControl htmlControl)
		{
			throw new NotImplementedException();
		}

		/// <summary>The mouse hover.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <exception cref="NotImplementedException"></exception>
		public override void MouseHover(HtmlControl htmlControl)
		{
			throw new NotImplementedException();
		}

		/// <summary>The mouse leave.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <exception cref="NotImplementedException"></exception>
		public override void MouseLeave(HtmlControl htmlControl)
		{
			throw new NotImplementedException();
		}

		/// <summary>The mouse out.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <exception cref="NotImplementedException"></exception>
		public override void MouseOut(HtmlControl htmlControl)
		{
			throw new NotImplementedException();
		}

		/// <summary>The mouse over.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <exception cref="NotImplementedException"></exception>
		public override void MouseOver(HtmlControl htmlControl)
		{
			throw new NotImplementedException();
		}

		/// <summary>The navigate to.</summary>
		/// <param name="url">The url.</param>
		/// <exception cref="NotImplementedException"></exception>
		public override void NavigateTo(string url)
		{
			throw new NotImplementedException();
		}

		/// <summary>The perform click.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <param name="waitForBehavior">The wait for behavior.</param>
		/// <exception cref="NotImplementedException"></exception>
		public override void PerformClick(
			HtmlControl htmlControl, Func<Core.TestFramework.Browser, bool> waitForBehavior = null)
		{
			throw new NotImplementedException();
		}

		/// <summary>The perform click.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <param name="clickAction">The click action.</param>
		/// <param name="waitForBehavior">The wait for behavior.</param>
		/// <exception cref="NotImplementedException"></exception>
		public override void PerformClick(
			HtmlControl htmlControl, 
			ClickAction clickAction, 
			Func<Core.TestFramework.Browser, bool> waitForBehavior = null)
		{
			throw new NotImplementedException();
		}

		/// <summary>The perform refresh.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <returns>The <see cref="bool"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override bool PerformRefresh(HtmlControl htmlControl)
		{
			throw new NotImplementedException();
		}

		/// <summary>The refresh.</summary>
		/// <exception cref="NotImplementedException"></exception>
		public override void Refresh()
		{
			throw new NotImplementedException();
		}

		/// <summary>The scroll to middle.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <exception cref="NotImplementedException"></exception>
		public override void ScrollToMiddle(HtmlControl htmlControl)
		{
			throw new NotImplementedException();
		}

		/// <summary>The set value.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <param name="value">The value.</param>
		/// <exception cref="NotImplementedException"></exception>
		public override void SetValue(HtmlControl htmlControl, string value)
		{
			throw new NotImplementedException();
		}

		/// <summary>The set value.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <param name="value">The value.</param>
		/// <param name="clearFirst">The clear first.</param>
		/// <exception cref="NotImplementedException"></exception>
		public override void SetValue(HtmlControl htmlControl, string value, bool clearFirst)
		{
			throw new NotImplementedException();
		}

		/// <summary>The switch window.</summary>
		/// <param name="windowName">The window name.</param>
		/// <param name="findOperator">The find operator.</param>
		/// <exception cref="NotImplementedException"></exception>
		public override void SwitchWindow(string windowName = "", FindOperator findOperator = FindOperator.Equals)
		{
			throw new NotImplementedException();
		}

		/// <summary>The take screen shot.</summary>
		/// <returns>The <see cref="string"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override string TakeScreenShot()
		{
			throw new NotImplementedException();
		}

		/// <summary>The take screen shot.</summary>
		/// <param name="filename">The filename.</param>
		/// <returns>The <see cref="string"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override string TakeScreenShot(string filename)
		{
			throw new NotImplementedException();
		}

		/// <summary>The wait.</summary>
		/// <param name="interval">The interval.</param>
		/// <param name="ajaxTimeout">The ajax timeout.</param>
		/// <exception cref="NotImplementedException"></exception>
		public override void Wait(int interval, int ajaxTimeout)
		{
			throw new NotImplementedException();
		}

		/// <summary>The window names.</summary>
		/// <returns>The <see cref="IReadOnlyCollection"/>.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override IReadOnlyCollection<string> WindowNames()
		{
			throw new NotImplementedException();
		}

		#endregion


		/// <summary>The cast web element.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <returns>The <see cref="IWebElement"/>.</returns>
		/// <exception cref="InvalidCastException"></exception>
		private static HtmlNode CastWebElement(HtmlControl htmlControl)
		{
			var control = htmlControl.FrameworkControl as HtmlNode;
			if (control == null)
			{
				throw new InvalidCastException("Native framework control is either null or otherwise not castable to HtmlNode.");
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

		/// <summary>The find native control.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <param name="container">The container.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="IWebElement"/>.</returns>
		private HtmlNode FindNativeControl<T>(T htmlControl, HtmlNode container) where T : HtmlControl
		{
			var xpath = this.GetXPath(htmlControl);
			HtmlNode nativeControl = null;

			if (container != this.frameworkBrowser.DocumentNode)
			{
				xpath = "." + xpath;
			}

			nativeControl = container.SelectSingleNode(xpath);

			htmlControl.FrameworkControl = nativeControl;
			htmlControl.Locator = new Locator { FindBy = FindBy.XPath, Term = xpath };
			return nativeControl;
		}

		/// <summary>The find native control.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="IWebElement"/>.</returns>
		private HtmlNode FindNativeControl<T>(T htmlControl) where T : HtmlControl
		{
			return this.FindNativeControl(htmlControl, this.frameworkBrowser.DocumentNode);
		}

		/// <summary>The find native controls.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <param name="container">The container.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="IEnumerable"/>.</returns>
		private IEnumerable<HtmlNode> FindNativeControls<T>(T htmlControl, HtmlNode container) where T : HtmlControl
		{
			var xpath = this.GetXPath(htmlControl);

			if (container != this.frameworkBrowser.DocumentNode)
			{
				xpath = "." + xpath;
			}

			htmlControl.Locator = new Locator { FindBy = FindBy.XPath, Term = xpath };
			return container.SelectNodes(xpath) ?? new HtmlNodeCollection(container);
		}

		/// <summary>The find native controls.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="IEnumerable"/>.</returns>
		private IEnumerable<HtmlNode> FindNativeControls<T>(T htmlControl) where T : HtmlControl
		{
			return this.FindNativeControls(htmlControl, this.frameworkBrowser.DocumentNode);
		}

		/// <summary>The get framework control.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <returns>The <see cref="IWebElement"/>.</returns>
		private HtmlNode GetFrameworkControl(HtmlControl htmlControl)
		{
			var control = CastWebElement(htmlControl);

			return control;
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
			
			if (containingControl != null)
			{
				var parentLocator = (Locator)containingControl.Locator;
				var parentXpath = this.GetXPath(parentLocator, containingControl);
				xpath = string.Format("({0}){1}", parentXpath, xpath);
			}

			htmlControl.Locator = new Locator { FindBy = FindBy.XPath, Term = xpath };

			logger.Trace("Search for Element using '{0}'", xpath);
			var nativeControl = this.frameworkBrowser.DocumentNode.SelectSingleNode(xpath);

			if (nativeControl == null)
			{
				logger.Trace("Could Not find Elements using the following expression '{0}'", xpath);
				return null;
			}

			return this.PopulateControl(htmlControl, nativeControl);
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
			
			if (containingControl != null)
			{
				var parentLocator = (Locator)containingControl.Locator;
				var parentXpath = this.GetXPath(parentLocator, containingControl);
				IEnumerable<HtmlNode> controlresults = this.frameworkBrowser.DocumentNode.SelectNodes(parentXpath + xpath)
													   ?? new HtmlNodeCollection(containingControl.FrameworkControl.CastTo<HtmlNode>());
				var childControls = controlresults.Select(p => this.PopulateControl(new T(), p)).ToArray();
				for (int i = 0; i < childControls.Length; i++)
				{
					childControls[i].Locator = new Locator { FindBy = FindBy.XPath, Term = "(" + parentXpath + xpath + ")[" + (i + 1) + "]" };
				}

				return childControls;
			}

			logger.Trace("Search for Element using '{0}'", xpath);
			IEnumerable<HtmlNode> results = this.frameworkBrowser.DocumentNode.SelectNodes(xpath)
											?? new HtmlNodeCollection(this.frameworkBrowser.DocumentNode);

			var controls = results.Select(p => this.PopulateControl(new T(), p)).ToArray();

			if (controls == null)
			{
				logger.Trace("Could Not find Elements using the following expression '{0}'", xpath);
				return new List<T>();
			}

			for (int i = 0; i < controls.Length; i++)
			{
				controls[i].Locator = new Locator { FindBy = FindBy.XPath, Term = "(" + xpath + ")[" + (i + 1) + "]" };
			}

			return controls;
			
		}

		private string GetXPath(Locator locator, HtmlControl htmlControl)
		{
			switch (locator.FindBy)
			{
				case FindBy.XPath:
					return locator.Term;
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
		private T PopulateControl<T>(T htmlControl, HtmlNode element) where T : HtmlControl
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
					if (Enum.TryParse(element.Name, true, out resultTag))
					{
						htmlControl.CastTo<HtmlDynamic>().SetHtmlTag(resultTag);
					}
				}

				var outerhtml = string.Empty;
				try
				{
					outerhtml = element.OuterHtml;
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


	}
}