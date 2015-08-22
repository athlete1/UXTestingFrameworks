// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlControl.cs" company="">
//   
// </copyright>
// <summary>
//   The html control.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Diagnostics;

	using UX.Testing.Core.Enums;
	using UX.Testing.Core.Extensions;
	using UX.Testing.Core.Logging;
	using UX.Testing.Core.TestFramework;

	/// <summary>The html control.</summary>
	public abstract class HtmlControl : IGlobalAttributes, 
		ISearchContext, 
		IFindsById, 
		IFindsByClassName, 
		IFindsByName, 
		IFindsByLinkText, 
		IFindsByPartialLinkText, 
		IFindsByTagName, 
		IFindsByCssSelector
	{
		#region Fields

		/// <summary>The attributes.</summary>
		private Dictionary<string, string> attributes;

		/// <summary>The browser.</summary>
		private Browser browser;

		/// <summary>The inner html.</summary>
		private string innerHtml;

		/// <summary>The inner text.</summary>
		private string innerText;

		#endregion

		#region Constructors and Destructors

		/// <summary>Initializes a new instance of the <see cref="HtmlControl"/> class.</summary>
		protected HtmlControl()
		{
			this.attributes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		}

		#endregion

		#region Public Properties

		/// <summary>Gets or sets the access key.</summary>
		public string AccessKey 
			{
			get
			{
				return this.GetAttribute("class");
			}

			set
			{
				this.AddAttribute("class", value);
			}
		}

		/// <summary>Gets the attributes.</summary>
		public IReadOnlyDictionary<string, string> Attributes
		{
			get
			{
				return this.attributes;
			}
		}

		/// <summary>Gets or sets the parent browser.</summary>
		public Browser Browser
		{
			get
			{
				if (this.browser == null)
				{
					throw new ElementNotRetrievedException(
						"Browser not set - element not retrieved from DOM. Find element before attempting to use.");
				}

				return this.browser;
			}

			set
			{
				this.browser = value;
			}
		}

		/// <summary>Gets or sets the class.</summary>
		public string Class
		{
			get
			{
				return this.GetAttribute("class");
			}

			set
			{
				this.AddAttribute("class", value);
			}
		}

		/// <summary>Gets or sets the content editable.</summary>
		public string ContentEditable
		{
			get
			{
				return this.GetAttribute("contenteditable");
			}

			set
			{
				this.AddAttribute("contenteditable", value);
			}
		}

		/// <summary>Gets or sets the context menu.</summary>
		public string ContextMenu
		{
			get
			{
				return this.GetAttribute("contextmenu");
			}

			set
			{
				this.AddAttribute("contextmenu", value);
			}
		}

		/// <summary>Gets or sets a value indicating whether control populated.</summary>
		public bool ControlPopulated { get; set; }

		/// <summary>Gets or sets the dir.</summary>
		public string Dir
		{
			get
			{
				return this.GetAttribute("dir");
			}

			set
			{
				this.AddAttribute("dir", value);
			}
		}

		/// <summary>Gets or sets the draggable.</summary>
		public string Draggable
		{
			get
			{
				return this.GetAttribute("draggable");
			}

			set
			{
				this.AddAttribute("draggable", value);
			}
		}

		/// <summary>Gets or sets the dropzone.</summary>
		public string Dropzone
		{
			get
			{
				return this.GetAttribute("dropzone");
			}

			set
			{
				this.AddAttribute("dropzone", value);
			}
		}

		/// <summary>Gets or sets the framework control.</summary>
		public object FrameworkControl { get; set; }

		/// <summary>Gets or sets the hidden.</summary>
		public string Hidden
		{
			get
			{
				return this.GetAttribute("hidden");
			}

			set
			{
				this.AddAttribute("hidden", value);
			}
		}

		/// <summary>Gets the tag name.</summary>
		public abstract HtmlTag HtmlTag { get; }

		/// <summary>Gets or sets the id.</summary>
		public string Id
		{
			get
			{
				return this.GetAttribute("id");
			}

			set
			{
				this.AddAttribute("id", value);
			}
		}

		/// <summary>Gets or sets the inner html.</summary>
		public string InnerHtml
		{
			get
			{
				return this.ControlPopulated ? this.GetFrameworkAttribute("innerHTML").Trim() : this.innerHtml;
			}

			set
			{
				this.innerHtml = value;
			}
		}

		/// <summary>Gets or sets the inner text.</summary>
		public virtual string InnerText
		{
			get
			{
				return this.ControlPopulated ? this.GetFrameworkAttribute("innerText").Trim() : this.innerText;
			}

			set
			{
				this.innerText = value;
			}
		}

		/// <summary>Gets or sets the lang.</summary>
		public string Lang
		{
			get
			{
				return this.GetAttribute("lang");
			}

			set
			{
				this.AddAttribute("lang", value);
			}
		}

		/// <summary>Gets or sets the locator.</summary>
		public object Locator { get; set; }

		/// <summary>Gets or sets the name.</summary>
		public string Name
		{
			get
			{
				return this.GetAttribute("name");
			}

			set
			{
				this.AddAttribute("name", value);
			}
		}

		/// <summary>Gets or sets the outer html.</summary>
		public string OuterHtml { get; set; }

		/// <summary>Gets or sets the spellcheck.</summary>
		public string Spellcheck
		{
			get
			{
				return this.GetAttribute("spellcheck");
			}

			set
			{
				this.AddAttribute("spellcheck", value);
			}
		}

		/// <summary>Gets or sets the style.</summary>
		public string Style
		{
			get
			{
				return this.GetAttribute("style");
			}

			set
			{
				this.AddAttribute("style", value);
			}
		}

		/// <summary>Gets or sets the tab index.</summary>
		public string TabIndex
		{
			get
			{
				return this.GetAttribute("tabindex");
			}

			set
			{
				this.AddAttribute("tabindex", value);
			}
		}

		/// <summary>Gets the tag name.</summary>
		public string TagName
		{
			get
			{
				return this.HtmlTag.GetHtmlTag();
			}
		}

		/// <summary>Gets or sets the title.</summary>
		public string Title
		{
			get
			{
				return this.GetAttribute("title");
			}

			set
			{
				this.AddAttribute("title", value);
			}
		}

		/// <summary>Gets or sets the translate.</summary>
		public string Translate
		{
			get
			{
				return this.GetAttribute("translate");
			}

			set
			{
				this.AddAttribute("translate", value);
			}
		}

		#endregion

		#region Public Methods and Operators

		/// <summary>The add attribute method stores an attribute value to the control and if it already exists then it will update it.</summary>
		/// <param name="key">The key.</param>
		/// <param name="value">The value.</param>
		public void AddAttribute(string key, string value)
		{
			if (this.attributes.ContainsKey(key))
			{
				this.attributes[key] = value;
			}
			else
			{
				this.attributes.Add(key, value);
			}
		}

		/// <summary>Finds the first ancestor in the dom tree that maches the HtmlControl Type.</summary>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="T"/>First Ancestor that matches.</returns>
		public T Ancestor<T>() where T : HtmlControl, new()
		{
			return this.Browser.FindAncestor<T>(this);
		}

		/// <summary>Finds the first ancestor in the dom tree that maches the HtmlControl Type and Defined Attributes.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public T Ancestor<T>(T htmlControl) where T : HtmlControl, new()
		{
			return this.Browser.FindAncestor<T>(this, htmlControl);
		}

		/// <summary>The clear attributes method clears the attribute storage.</summary>
		public void ClearAttributes()
		{
			this.attributes.Clear();
		}

		/// <summary>The click method will wait for the control become enabled, scrolls the control to the middle of the browser view port, performs a click on the control, and then will wait until the browsers url contains the passed in url string.</summary>
		/// <param name="waitForUrl">The url to wait for.</param>
		public void Click(string waitForUrl)
		{
			Logger.Instance.Trace("Clicking control '{0}'", this.TagName);
			this.browser.WaitForCondition(args => this.IsEnabled());
			this.ScrollToMiddle();
			this.Browser.PerformClick(this, b => b.Url.Contains(waitForUrl));
		}

		/// <summary>The click method will wait for the control become enabled, scrolls the control to the middle of the browser view port if focus is true, performs a click on the control.</summary>
		/// <param name="focus">Indicate to perform a focus on element before clicking, defaults to true.</param>
		public void Click(bool focus = true)
		{
			Logger.Instance.Trace("Clicking control '{0}'", this.TagName);
			this.browser.WaitForCondition(args => this.IsEnabled());
			if (focus)
			{
				this.ScrollToMiddle();
			}

			this.Browser.PerformClick(this);
		}

		/// <summary>The click method will wait for the control become enabled, scrolls the control to the middle of the browser view port, performs a click on the control, and then will wait until the passed condition is true.</summary>
		/// <param name="waitForCondition">The wait for condition.</param>
		public void Click(Func<Browser, bool> waitForCondition)
		{
			Logger.Instance.Trace("Clicking control '{0}'", this.TagName);
			this.browser.WaitForCondition(args => this.IsEnabled());
			this.ScrollToMiddle();
			this.Browser.PerformClick(this, waitForCondition);
		}

		/// <summary>The copy method will perform a deep copy of the control and return the copy.</summary>
		/// <returns>The <see cref="HtmlControl"/>.</returns>
		public HtmlControl Copy()
		{
			var type = this.GetType();
			var copy = (HtmlControl)Activator.CreateInstance(type);

			var properties = type.GetProperties();
			foreach (var propertyInfo in properties)
			{
				if (propertyInfo.PropertyType == typeof(string) && propertyInfo.CanWrite)
				{
					propertyInfo.SetValue(copy, propertyInfo.GetValue(this));
				}
			}

			foreach (var attribute in this.Attributes)
			{
				copy.AddAttribute(attribute.Key, attribute.Value);
			}

			return copy;
		}

		/// <summary>The double click.</summary>
		/// <param name="waitForCondition">The wait for condition.</param>
		public void DoubleClick(Func<Browser, bool> waitForCondition = null)
		{
			Logger.Instance.Trace("Double Clicking control '{0}'", this.TagName);
			this.browser.WaitForCondition(args => this.IsEnabled());
			this.ScrollToMiddle();
			this.Browser.PerformClick(this, ClickAction.DoubleLeftClick, waitForCondition);
		}

		/// <summary>Find single child of this control of type T with corresponding attributes.</summary>
		/// <param name="htmlControl">The html Control.</param>
		/// <typeparam name="T">The type.</typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public T Find<T>(T htmlControl) where T : HtmlControl, new()
		{
			return this.Browser.Find(htmlControl, this);
		}

		/// <summary>The find.</summary>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public T Find<T>() where T : HtmlControl, new()
		{
			return this.Browser.Find(new T(), this);
		}

		/// <summary>Find all children of this control of type T with corresponding attributes.</summary>
		/// <param name="htmlControl">The html Control.</param>
		/// <typeparam name="T">The type of HtmlControl</typeparam>
		/// <returns>The <see cref="IEnumerable{T}"/>.</returns>
		public IEnumerable<T> FindAll<T>(T htmlControl) where T : HtmlControl, new()
		{
			return this.Browser.FindAll(htmlControl, this);
		}

		/// <summary>The find all.</summary>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="IEnumerable"/>.</returns>
		public IEnumerable<T> FindAll<T>() where T : HtmlControl, new()
		{
			return this.Browser.FindAll(new T(), this);
		}

		/// <summary>The find all by class.</summary>
		/// <param name="cssClass">The css class.</param>
		/// <param name="additionalClasses">The additional classes.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="IEnumerable"/>.</returns>
		public IEnumerable<T> FindAllByClass<T>(string cssClass, params string[] additionalClasses) where T : HtmlControl, new()
		{
			return this.Browser.FindAllByClass<T>(cssClass, this, additionalClasses);
		}

		/// <summary>The find all by id.</summary>
		/// <param name="id">The id.</param>
		/// <param name="findOperator">The find operator.</param>
		/// <typeparam name="T">The type of HtmlControl.</typeparam>
		/// <returns>The <see cref="IEnumerable{T}"/>.</returns>
		public IEnumerable<T> FindAllById<T>(string id, FindOperator findOperator) where T : HtmlControl, new()
		{
			return this.Browser.FindAllById<T>(id, findOperator, this);
		}

		/// <summary>The find all by inner text.</summary>
		/// <param name="innerText">The inner text.</param>
		/// <param name="findOperator">The find operator.</param>
		/// <typeparam name="T">The type of HtmlControl.</typeparam>
		/// <returns>The <see cref="IEnumerable{T}"/>.</returns>
		public IEnumerable<T> FindAllByInnerText<T>(string innerText, FindOperator findOperator = FindOperator.Equals)
			where T : HtmlControl, new()
		{
			return this.Browser.FindAllByInnerText<T>(innerText, findOperator, this);
		}

		/// <summary>The find all by name.</summary>
		/// <param name="name">The name.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="IEnumerable"/>.</returns>
		public IEnumerable<T> FindAllByName<T>(string name) where T : HtmlControl, new()
		{
			return this.Browser.FindAllByName<T>(name, this);
		}

		/// <summary>The find by class.</summary>
		/// <param name="cssClass">The css class.</param>
		/// <param name="additionalClasses">The additional classes.</param>
		/// <typeparam name="T">The type of HtmlControl.</typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public T FindByClass<T>(string cssClass, params string[] additionalClasses) where T : HtmlControl, new()
		{
			return this.Browser.FindByClass<T>(cssClass, this, additionalClasses);
		}

		/// <summary>The find by id.</summary>
		/// <param name="id">The id.</param>
		/// <param name="findOperator">The find Operator.</param>
		/// <typeparam name="T">The type of HtmlControl.</typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public T FindById<T>(string id, FindOperator findOperator = FindOperator.Equals) where T : HtmlControl, new()
		{
			return this.Browser.FindById<T>(id, findOperator, this);
		}

		/// <summary>The find by inner text.</summary>
		/// <param name="innerText">The inner text.</param>
		/// <param name="findOperator">The find operator.</param>
		/// <typeparam name="T">The type of HtmlControl.</typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public T FindByInnerText<T>(string innerText, FindOperator findOperator = FindOperator.Equals) where T : HtmlControl, new()
		{
			return this.Browser.FindByInnerText<T>(innerText, findOperator, this);
		}

		/// <summary>The find by name.</summary>
		/// <param name="name">The name.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public T FindByName<T>(string name) where T : HtmlControl, new()
		{
			return this.Browser.FindByName<T>(name, this);
		}

		/// <summary>The find control.</summary>
		/// <param name="by">The by.</param>
		/// <returns>The <see cref="HtmlControl"/>.</returns>
		public HtmlControl FindControl(By @by)
		{
			return @by.FindControl(this);
		}

		/// <summary>The find control by class name.</summary>
		/// <param name="className">The class name.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="HtmlControl"/>.</returns>
		public HtmlControl FindControlByClassName(string className, HtmlControl parentControl = null)
		{
			return this.Browser.FindControlByClassName(className, this);
		}

		/// <summary>The find control by css selector.</summary>
		/// <param name="cssSelector">The css selector.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="HtmlControl"/>.</returns>
		public HtmlControl FindControlByCssSelector(string cssSelector, HtmlControl parentControl = null)
		{
			return this.Browser.FindControlByCssSelector(cssSelector, this);
		}

		/// <summary>The find control by id.</summary>
		/// <param name="id">The id.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="HtmlControl"/>.</returns>
		public HtmlControl FindControlById(string id, HtmlControl parentControl = null)
		{
			return this.Browser.FindControlById(id, this);
		}

		/// <summary>The find control by link text.</summary>
		/// <param name="linkText">The link text.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="HtmlControl"/>.</returns>
		public HtmlControl FindControlByLinkText(string linkText, HtmlControl parentControl = null)
		{
			return this.Browser.FindControlByLinkText(linkText, this);
		}

		/// <summary>The find control by name.</summary>
		/// <param name="name">The name.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="HtmlControl"/>.</returns>
		public HtmlControl FindControlByName(string name, HtmlControl parentControl = null)
		{
			return this.Browser.FindControlByName(name, this);
		}

		/// <summary>The find control by partial link text.</summary>
		/// <param name="partialLinkText">The partial link text.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="HtmlControl"/>.</returns>
		public HtmlControl FindControlByPartialLinkText(string partialLinkText, HtmlControl parentControl = null)
		{
			return this.Browser.FindControlByPartialLinkText(partialLinkText, this);
		}

		/// <summary>The find control by tag name.</summary>
		/// <param name="tagName">The tag name.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="HtmlControl"/>.</returns>
		public HtmlControl FindControlByTagName(string tagName, HtmlControl parentControl = null)
		{
			return this.Browser.FindControlByTagName(tagName, this);
		}

		/// <summary>The find controls.</summary>
		/// <param name="by">The by.</param>
		/// <returns>The <see cref="ReadOnlyCollection"/>.</returns>
		public ReadOnlyCollection<HtmlControl> FindControls(By @by)
		{
			return @by.FindControls(this);
		}

		/// <summary>The find controls by class name.</summary>
		/// <param name="className">The class name.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="ReadOnlyCollection"/>.</returns>
		public ReadOnlyCollection<HtmlControl> FindControlsByClassName(string className, HtmlControl parentControl = null)
		{
			return this.Browser.FindControlsByClassName(className, this);
		}

		/// <summary>The find controls by css selector.</summary>
		/// <param name="cssSelector">The css selector.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="ReadOnlyCollection"/>.</returns>
		public ReadOnlyCollection<HtmlControl> FindControlsByCssSelector(string cssSelector, HtmlControl parentControl = null)
		{
			return this.Browser.FindControlsByCssSelector(cssSelector, this);
		}

		/// <summary>The find controls by id.</summary>
		/// <param name="id">The id.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="ReadOnlyCollection"/>.</returns>
		public ReadOnlyCollection<HtmlControl> FindControlsById(string id, HtmlControl parentControl = null)
		{
			return this.Browser.FindControlsById(id, this);
		}

		/// <summary>The find controls by link text.</summary>
		/// <param name="linkText">The link text.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="ReadOnlyCollection"/>.</returns>
		public ReadOnlyCollection<HtmlControl> FindControlsByLinkText(string linkText, HtmlControl parentControl = null)
		{
			return this.Browser.FindControlsByLinkText(linkText, this);
		}

		/// <summary>The find controls by name.</summary>
		/// <param name="name">The name.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="ReadOnlyCollection"/>.</returns>
		public ReadOnlyCollection<HtmlControl> FindControlsByName(string name, HtmlControl parentControl = null)
		{
			return this.Browser.FindControlsByName(name, this);
		}

		/// <summary>The find controls by partial link text.</summary>
		/// <param name="partialLinkText">The partial link text.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="ReadOnlyCollection"/>.</returns>
		public ReadOnlyCollection<HtmlControl> FindControlsByPartialLinkText(string partialLinkText, HtmlControl parentControl = null)
		{
			return this.Browser.FindControlsByPartialLinkText(partialLinkText, this);
		}

		/// <summary>The find controls by tag name.</summary>
		/// <param name="tagName">The tag name.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="ReadOnlyCollection"/>.</returns>
		public ReadOnlyCollection<HtmlControl> FindControlsByTagName(string tagName, HtmlControl parentControl = null)
		{
			return this.Browser.FindControlsByTagName(tagName, this);
		}

		/// <summary>The find range method returns a specific amount of elements from a list.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <param name="count">The count.</param>
		/// <param name="startIndex">The start index.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="IEnumerable"/>.</returns>
		public IEnumerable<T> FindRange<T>(T htmlControl, int count, int startIndex = 0) where T : HtmlControl, new()
		{
			return this.Browser.FindRange(htmlControl, count, startIndex, this);
		}

		/// <summary>The find range method returns a specific amount of elements from a list.</summary>
		/// <param name="count">The count.</param>
		/// <param name="startIndex">The start index, defaults to 0.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="IEnumerable"/>.</returns>
		public IEnumerable<T> FindRange<T>(int count, int startIndex = 0) where T : HtmlControl, new()
		{
			return this.Browser.FindRange(new T(), count, startIndex, this);
		}

		/// <summary>The get attribute method gets the value of the requested attribute from the controls attribute store.</summary>
		/// <param name="attribute">The attribute.</param>
		/// <returns>The <see cref="string"/>.</returns>
		public string GetAttribute(string attribute)
		{
			if (this.attributes.ContainsKey(attribute))
			{
				return this.attributes[attribute];
			}

			return string.Empty;
		}

		/// <summary>The get label for method finds the label element in the dom that has the controls id in the for attribute.</summary>
		/// <returns>The <see cref="HtmlLabel"/>.</returns>
		public HtmlLabel GetLabelFor()
		{
			return this.Browser.Find(new HtmlLabel { For = this.Id });
		}

		/// <summary>The is visible method checks if the control is Enabled in the browser.</summary>
		/// <returns>The <see cref="bool"/>.</returns>
		public bool IsEnabled()
		{
			return this.Browser.CheckIsEnabled(this);
		}

		/// <summary>The is visible method checks the controls visibility in the browser.</summary>
		/// <returns>The <see cref="bool"/>.</returns>
		public bool IsVisible()
		{
			return this.Browser.CheckVisibility(this);
		}

		/// <summary>The parent method returns the parent element in the dom.</summary>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public T Parent<T>() where T : HtmlControl, new()
		{
			return this.Browser.FindParent<T>(this);
		}

		/// <summary>The refresh method tells the browser to refresh.</summary>
		/// <returns>The <see cref="bool"/>.</returns>
		public bool Refresh()
		{
			return this.Browser.PerformRefresh(this);
		}

		/// <summary>The right click.</summary>
		/// <param name="waitForCondition">The wait for condition.</param>
		public void RightClick(Func<Browser, bool> waitForCondition = null)
		{
			this.ScrollToMiddle();
			this.Browser.PerformClick(this, ClickAction.RightClick, waitForCondition);
		}

		/// <summary>The wait for condition.</summary>
		/// <param name="condition">The condition.</param>
		/// <returns>The <see cref="bool"/>.</returns>
		public bool WaitForCondition(Func<HtmlControl, bool> condition)
		{
			var testSettings = TestSettings.Instance;
			return this.WaitForCondition(condition, testSettings.Timeout, testSettings.Interval);
		}

		/// <summary>The wait for condition.</summary>
		/// <param name="condition">The condition.</param>
		/// <param name="timeout">The timeout.</param>
		/// <param name="interval">The interval.</param>
		/// <returns>The <see cref="bool"/>.</returns>
		public bool WaitForCondition(Func<HtmlControl, bool> condition, int timeout, int interval)
		{
			var logger = new Logger();
			var stopwatch = new Stopwatch();
			stopwatch.Start();

			try
			{
				if (TestSettings.Instance.Debug)
				{
					logger.Debug("WaitForCondition STARTED");
				}

				var timeoutWait = timeout;
				while (timeoutWait > 0 && !condition(this))
				{
					this.Browser.Wait(interval, timeout);
					this.Refresh();
					timeoutWait -= interval;
				}
			}
			finally
			{
				stopwatch.Stop();
				if (TestSettings.Instance.Debug)
				{
					logger.Debug("WaitForCondition COMPLETED - [RUNTIME: {0}]", stopwatch.Elapsed.TotalMilliseconds);
				}
			}

			return condition(this);
		}

		#endregion

		#region Methods

		/// <summary>The get framework attribute method gets the live attribute value from the browser.</summary>
		/// <param name="attribute">The attribute.</param>
		/// <returns>The <see cref="string"/>.</returns>
		public string GetFrameworkAttribute(string attribute)
		{
			return this.Browser.GetAttribute(this, attribute);
		}

		#endregion
	}
}