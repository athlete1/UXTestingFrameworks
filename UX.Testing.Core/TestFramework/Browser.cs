// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Browser.cs" company="">
//   
// </copyright>
// <summary>
//   The browser.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.TestFramework
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Diagnostics;
	using System.Linq;
	using System.Net;

	using UX.Testing.Core.Controls;
	using UX.Testing.Core.Enums;
	using UX.Testing.Core.Extensions;
	using UX.Testing.Core.Logging;

	/// <summary>The browser.</summary>
	public abstract class Browser : ISearchContext, 
		IFindsById, 
		IFindsByClassName, 
		IFindsByName, 
		IFindsByLinkText, 
		IFindsByPartialLinkText, 
		IFindsByTagName, 
		IFindsByCssSelector
	{
		#region Fields

		/// <summary>The type.</summary>
		private BrowserType type = BrowserType.InternetExplorer;

		#endregion

		#region Constructors and Destructors

		/// <summary>Initializes a new instance of the <see cref="Browser"/> class.</summary>
		public Browser()
		{
			this.TestSettings = TestSettings.Instance;
			ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
		}

		#endregion

		#region Enums

		/// <summary>The browser type.</summary>
		public enum BrowserType
		{
			/// <summary>The internet explorer.</summary>
			InternetExplorer, 

			/// <summary>The fire fox.</summary>
			FireFox, 

			/// <summary>The safari.</summary>
			Safari, 

			/// <summary>The chrome.</summary>
			Chrome, 

			/// <summary>The phantom js.</summary>
			PhantomJS, 

			/// <summary>The unit test.</summary>
			UnitTest, 
		}

		#endregion

		#region Public Properties

		/// <summary>Gets the native browser.</summary>
		public abstract object NativeBrowser { get; }

		/// <summary>Gets or sets the type.</summary>
		public BrowserType Type
		{
			get
			{
				return this.type;
			}

			set
			{
				this.type = value;
			}
		}

		/// <summary>Gets the url.</summary>
		public abstract string Url { get; }

		#endregion

		#region Properties

		/// <summary>Gets or sets the logger.</summary>
		protected abstract ILogger Logger { get; set; }

		/// <summary>Gets the test settings.</summary>
		protected TestSettings TestSettings { get; private set; }

		#endregion

		#region Public Methods and Operators

		/// <summary>The check is enabled.</summary>
		/// <param name="htmlControl">The html Control.</param>
		/// <returns>The <see cref="bool"/>.</returns>
		public abstract bool CheckIsEnabled(HtmlControl htmlControl);

		/// <summary>The check visibility.</summary>
		/// <param name="htmlControl">The html Control.</param>
		/// <returns>The <see cref="bool"/>.</returns>
		public abstract bool CheckVisibility(HtmlControl htmlControl);

		/// <summary>The close.</summary>
		public abstract void Close();

		/// <summary>The current window name.</summary>
		/// <returns>The <see cref="string"/>.</returns>
		public abstract string CurrentWindowName();

		/// <summary>Find single element of type T with corresponding attributes.  If element found, the returned instance should be the same as passed in.</summary>
		/// <param name="htmlControl">The html Control.</param>
		/// <param name="containingControl">The containing Control.</param>
		/// <typeparam name="T">The type of HtmlControl.</typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public abstract T Find<T>(T htmlControl, HtmlControl containingControl = null) where T : HtmlControl, new();

		/// <summary>Find all elements of type T with corresponding attributes.</summary>
		/// <param name="htmlControl">The html Control.</param>
		/// <param name="containingControl">The containing Control.</param>
		/// <typeparam name="T">The type of HtmlControl.</typeparam>
		/// <returns>The <see cref="IEnumerable{T}"/>.</returns>
		public abstract IEnumerable<T> FindAll<T>(T htmlControl, HtmlControl containingControl = null) where T : HtmlControl, new();

		/// <summary>The find all by class.</summary>
		/// <param name="cssClass">The css class.</param>
		/// <param name="containingControl">The containing Control.</param>
		/// <param name="additionalClasses">The additional Classes.</param>
		/// <typeparam name="T">The type of HtmlControl.</typeparam>
		/// <returns>The <see cref="IEnumerable{T}"/>.</returns>
		public abstract IEnumerable<T> FindAllByClass<T>(
			string cssClass, HtmlControl containingControl = null, params string[] additionalClasses) where T : HtmlControl, new();

		/// <summary>The find all by id.</summary>
		/// <param name="id">The id.</param>
		/// <param name="findOperator">The find operator.</param>
		/// <param name="containingControl">The containing Control.</param>
		/// <typeparam name="T">The type of HtmlControl.</typeparam>
		/// <returns>The <see cref="IEnumerable{T}"/>.</returns>
		public abstract IEnumerable<T> FindAllById<T>(
			string id, FindOperator findOperator = FindOperator.Equals, HtmlControl containingControl = null) where T : HtmlControl, new();

		/// <summary>The find all by inner text.</summary>
		/// <param name="innerText">The inner text.</param>
		/// <param name="findOperator">The find operator.</param>
		/// <param name="containingControl">The containing Control.</param>
		/// <typeparam name="T">The type of HtmlControl.</typeparam>
		/// <returns>The <see cref="IEnumerable{T}"/>.</returns>
		public abstract IEnumerable<T> FindAllByInnerText<T>(
			string innerText, FindOperator findOperator = FindOperator.Equals, HtmlControl containingControl = null)
			where T : HtmlControl, new();

		/// <summary>The find all by name.</summary>
		/// <param name="name">The name.</param>
		/// <param name="containingControl">The containing Control.</param>
		/// <typeparam name="T">The type of HtmlControl.</typeparam>
		/// <returns>The <see cref="IEnumerable{T}"/>.</returns>
		public abstract IEnumerable<T> FindAllByName<T>(string name, HtmlControl containingControl = null) where T : HtmlControl, new();

		/// <summary>The find ancestor.</summary>
		/// <param name="childControl">The child control.</param>
		/// <typeparam name="T">The type of HtmlControl.</typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public abstract T FindAncestor<T>(HtmlControl childControl) where T : HtmlControl, new();

		/// <summary>The find ancestor.</summary>
		/// <param name="childControl">The child control.</param>
		/// <param name="ancestorControl">The ancestor control.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public abstract T FindAncestor<T>(HtmlControl childControl, HtmlControl ancestorControl) where T : HtmlControl, new();

		/// <summary>The find by class.</summary>
		/// <param name="cssClass">The css class.</param>
		/// <param name="containingControl">The containing Control.</param>
		/// <param name="additionalClasses">The additional Classes.</param>
		/// <typeparam name="T">The type of HtmlControl.</typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public abstract T FindByClass<T>(string cssClass, HtmlControl containingControl = null, params string[] additionalClasses)
			where T : HtmlControl, new();

		/// <summary>The find by id.</summary>
		/// <param name="id">The id.</param>
		/// <param name="findOperator">The find Operator.</param>
		/// <param name="containingControl">The containing Control.</param>
		/// <typeparam name="T">The type of HtmlControl.</typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public abstract T FindById<T>(string id, FindOperator findOperator = FindOperator.Equals, HtmlControl containingControl = null)
			where T : HtmlControl, new();

		/// <summary>The find by inner text.</summary>
		/// <param name="innerText">The inner text.</param>
		/// <param name="findOperator">The find operator.</param>
		/// <param name="containingControl">The containing Control.</param>
		/// <typeparam name="T">The type of HtmlControl.</typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public abstract T FindByInnerText<T>(
			string innerText, FindOperator findOperator = FindOperator.Equals, HtmlControl containingControl = null)
			where T : HtmlControl, new();

		/// <summary>The find by name.</summary>
		/// <param name="name">The name.</param>
		/// <param name="containingControl">The containing Control.</param>
		/// <typeparam name="T">The type of HtmlControl.</typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public abstract T FindByName<T>(string name, HtmlControl containingControl = null) where T : HtmlControl, new();

		/// <summary>The find control.</summary>
		/// <param name="by">The by.</param>
		/// <returns>The <see cref="HtmlControl"/>.</returns>
		public abstract HtmlControl FindControl(By @by);

		/// <summary>The find control by class name.</summary>
		/// <param name="className">The class name.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="HtmlControl"/>.</returns>
		public abstract HtmlControl FindControlByClassName(string className, HtmlControl parentControl = null);

		/// <summary>The find control by css selector.</summary>
		/// <param name="cssSelecto">The css selecto.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="HtmlControl"/>.</returns>
		public abstract HtmlControl FindControlByCssSelector(string cssSelecto, HtmlControl parentControl = null);

		/// <summary>The find control by id.</summary>
		/// <param name="id">The id.</param>
		/// <param name="parentControl">The parent Control.</param>
		/// <returns>The <see cref="HtmlControl"/>.</returns>
		public abstract HtmlControl FindControlById(string id, HtmlControl parentControl = null);

		/// <summary>The find control by link text.</summary>
		/// <param name="linkText">The link text.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="HtmlControl"/>.</returns>
		public abstract HtmlControl FindControlByLinkText(string linkText, HtmlControl parentControl = null);

		/// <summary>The find control by name.</summary>
		/// <param name="name">The name.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="HtmlControl"/>.</returns>
		public abstract HtmlControl FindControlByName(string name, HtmlControl parentControl = null);

		/// <summary>The find control by partial link text.</summary>
		/// <param name="partialLinkText">The partial link text.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="HtmlControl"/>.</returns>
		public abstract HtmlControl FindControlByPartialLinkText(string partialLinkText, HtmlControl parentControl = null);

		/// <summary>The find control by tag name.</summary>
		/// <param name="tagName">The tag name.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="HtmlControl"/>.</returns>
		public abstract HtmlControl FindControlByTagName(string tagName, HtmlControl parentControl = null);

		/// <summary>The find controls.</summary>
		/// <param name="by">The by.</param>
		/// <returns>The <see cref="ReadOnlyCollection"/>.</returns>
		public abstract ReadOnlyCollection<HtmlControl> FindControls(By @by);

		/// <summary>The find controls by class name.</summary>
		/// <param name="className">The class name.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="ReadOnlyCollection"/>.</returns>
		public abstract ReadOnlyCollection<HtmlControl> FindControlsByClassName(string className, HtmlControl parentControl = null);

		/// <summary>The find controls by css selector.</summary>
		/// <param name="cssSelector">The css selector.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="ReadOnlyCollection"/>.</returns>
		public abstract ReadOnlyCollection<HtmlControl> FindControlsByCssSelector(string cssSelector, HtmlControl parentControl = null);

		/// <summary>The find controls by id.</summary>
		/// <param name="id">The id.</param>
		/// <param name="parentControl">The parent Control.</param>
		/// <returns>The <see cref="ReadOnlyCollection"/>.</returns>
		public abstract ReadOnlyCollection<HtmlControl> FindControlsById(string id, HtmlControl parentControl = null);

		/// <summary>The find controls by link text.</summary>
		/// <param name="linkText">The link text.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="ReadOnlyCollection"/>.</returns>
		public abstract ReadOnlyCollection<HtmlControl> FindControlsByLinkText(string linkText, HtmlControl parentControl = null);

		/// <summary>The find controls by name.</summary>
		/// <param name="name">The name.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="ReadOnlyCollection"/>.</returns>
		public abstract ReadOnlyCollection<HtmlControl> FindControlsByName(string name, HtmlControl parentControl = null);

		/// <summary>The find controls by partial link text.</summary>
		/// <param name="partialLinkText">The partial link text.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="ReadOnlyCollection"/>.</returns>
		public abstract ReadOnlyCollection<HtmlControl> FindControlsByPartialLinkText(
			string partialLinkText, HtmlControl parentControl = null);

		/// <summary>The find controls by tag name.</summary>
		/// <param name="tagName">The tag name.</param>
		/// <param name="parentControl">The parent control.</param>
		/// <returns>The <see cref="ReadOnlyCollection"/>.</returns>
		public abstract ReadOnlyCollection<HtmlControl> FindControlsByTagName(string tagName, HtmlControl parentControl = null);

		/// <summary>The find parent.</summary>
		/// <param name="childControl">The child control.</param>
		/// <typeparam name="T">The type of HtmlControl.</typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public abstract T FindParent<T>(HtmlControl childControl) where T : HtmlControl, new();

		/// <summary>The find range.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <param name="count">The count.</param>
		/// <param name="startIndex">The start index.</param>
		/// <param name="containingControl">The containing control.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="IEnumerable"/>.</returns>
		public abstract IEnumerable<T> FindRange<T>(T htmlControl, int count, int startIndex = 0, HtmlControl containingControl = null)
			where T : HtmlControl, new();

		/// <summary>The focus.</summary>
		/// <param name="htmlControl">The html Control.</param>
		public abstract void Focus(HtmlControl htmlControl);

		/// <summary>The get attribute.</summary>
		/// <param name="htmlControl">The html Control.</param>
		/// <param name="attribute">The attribute.</param>
		/// <returns>The <see cref="string"/>.</returns>
		public abstract string GetAttribute(HtmlControl htmlControl, string attribute);

		/// <summary>The go back.</summary>
		public abstract void GoBack();

		/// <summary>The go forward.</summary>
		public abstract void GoForward();

		/// <summary>The handle alert.</summary>
		/// <param name="action">The action.</param>
		/// <param name="waitForCondition">The wait for condition.</param>
		public abstract void HandleAlert(AlertAction action, Func<Browser, bool> waitForCondition = null);

		/// <summary>The handle alert.</summary>
		/// <param name="actionThatCausesAlert">The action that causes alert.</param>
		/// <param name="action">The action.</param>
		/// <param name="waitForCondition">The wait for condition.</param>
		public abstract void HandleAlert(Action actionThatCausesAlert, AlertAction action, Func<Browser, bool> waitForCondition = null);

		/// <summary>The mouse enter.</summary>
		/// <param name="htmlControl">The html control.</param>
		public abstract void MouseEnter(HtmlControl htmlControl);

		/// <summary>The mouse hover.</summary>
		/// <param name="htmlControl">The html control.</param>
		public abstract void MouseHover(HtmlControl htmlControl);

		/// <summary>The mouse leave.</summary>
		/// <param name="htmlControl">The html control.</param>
		public abstract void MouseLeave(HtmlControl htmlControl);

		/// <summary>The mouse out.</summary>
		/// <param name="htmlControl">The html control.</param>
		public abstract void MouseOut(HtmlControl htmlControl);

		/// <summary>The mouse over.</summary>
		/// <param name="htmlControl">The html Control.</param>
		public abstract void MouseOver(HtmlControl htmlControl);

		/// <summary>The navigate to.</summary>
		/// <param name="url">The url.</param>
		public abstract void NavigateTo(string url);

		/// <summary>The navigate to.</summary>
		/// <param name="uri">The uri.</param>
		public void NavigateTo(Uri uri)
		{
			this.NavigateTo(uri.ToString());
		}

		/// <summary>The perform click.</summary>
		/// <param name="htmlControl">The html Control.</param>
		/// <param name="waitForBehavior">The wait for behavior.</param>
		public abstract void PerformClick(HtmlControl htmlControl, Func<Browser, bool> waitForBehavior = null);

		/// <summary>The perform click.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <param name="clickAction">The click action.</param>
		/// <param name="waitForBehavior">The wait for behavior.</param>
		public abstract void PerformClick(HtmlControl htmlControl, ClickAction clickAction, Func<Browser, bool> waitForBehavior = null);

		/// <summary>The perform refresh.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <returns>The <see cref="bool"/>.</returns>
		public abstract bool PerformRefresh(HtmlControl htmlControl);

		/// <summary>The refresh.</summary>
		public abstract void Refresh();

		/// <summary>The scroll to middle.</summary>
		/// <param name="htmlControl">The html control.</param>
		public abstract void ScrollToMiddle(HtmlControl htmlControl);

		/// <summary>The set value.</summary>
		/// <param name="htmlControl"></param>
		/// <param name="value">The value.</param>
		public abstract void SetValue(HtmlControl htmlControl, string value);

		/// <summary>The set value.</summary>
		/// <param name="htmlControl">The html control.</param>
		/// <param name="value">The value.</param>
		/// <param name="clearFirst">The clear first.</param>
		public abstract void SetValue(HtmlControl htmlControl, string value, bool clearFirst);

		/// <summary>The switch window.</summary>
		/// <param name="windowName">The window name.</param>
		/// <param name="findOperator">The find operator.</param>
		public abstract void SwitchWindow(string windowName = "", FindOperator findOperator = FindOperator.Equals);

		/// <summary>The take screen shot.</summary>
		/// <returns>The <see cref="string"/>.</returns>
		public abstract string TakeScreenShot();

		/// <summary>The take screen shot.</summary>
		/// <param name="filename">The filename.</param>
		/// <returns>The <see cref="string"/>.</returns>
		public abstract string TakeScreenShot(string filename);

		/// <summary>The wait.</summary>
		/// <param name="interval">The interval.</param>
		/// <param name="ajaxTimeout">The ajax Timeout.</param>
		public abstract void Wait(int interval, int ajaxTimeout);

		/// <summary>The wait.</summary>
		public virtual void Wait()
		{
			this.Wait(this.TestSettings.Interval, this.TestSettings.Timeout);
		}

		/// <summary>The wait for condition.</summary>
		/// <param name="condition">The condition.</param>
		/// <returns>The <see cref="bool"/>.</returns>
		public virtual bool WaitForCondition(Func<Browser, bool> condition)
		{
			return this.WaitForCondition(condition, this.TestSettings.Timeout, this.TestSettings.Interval);
		}

		/// <summary>The wait for condition.</summary>
		/// <param name="condition">The condition.</param>
		/// <param name="timeout">The timeout.</param>
		/// <param name="interval">The interval.</param>
		/// <returns>The <see cref="bool"/>.</returns>
		public virtual bool WaitForCondition(Func<Browser, bool> condition, int timeout, int interval)
		{
			var logger = new Logger();
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			try
			{
				if (this.TestSettings.Debug)
				{
					logger.Debug("WaitForCondition STARTED");
				}

				var timeoutWait = timeout;
				while (timeoutWait > 0 && !condition(this))
				{
					this.Wait(interval, timeout);
					timeoutWait -= interval;
				}
			}
			finally
			{
				stopwatch.Stop();
				if (this.TestSettings.Debug)
				{
					logger.Debug("WaitForCondition COMPLETED - [RUNTIME: {0}]", stopwatch.Elapsed.TotalMilliseconds);
				}
			}

			return condition(this);
		}

		/// <summary>The window names.</summary>
		/// <returns>The <see cref="IReadOnlyCollection"/>.</returns>
		public abstract IReadOnlyCollection<string> WindowNames();

		#endregion

		#region Methods

		/// <summary>The create html control.</summary>
		/// <param name="tagName">The tag name.</param>
		/// <returns>The <see cref="HtmlControl"/>.</returns>
		protected HtmlControl CreateHtmlControl(string tagName)
		{
			return this.CreateHtmlControl(tagName, string.Empty);
		}

		/// <summary>The create html control.</summary>
		/// <param name="tagName">The tag name.</param>
		/// <param name="type">The type.</param>
		/// <returns>The <see cref="HtmlControl"/>.</returns>
		protected virtual HtmlControl CreateHtmlControl(string tagName, string type)
		{
			var enumValues = Enum.GetValues(typeof(HtmlTag)).Cast<HtmlTag>();
			var selectedEnum = enumValues.FirstOrDefault(p => p.GetHtmlTag() == tagName);

			switch (selectedEnum)
			{
				case HtmlTag.any:
					return new HtmlDynamic();
				case HtmlTag.a:
					return new HtmlAnchor();
				case HtmlTag.abbr:
					return new HtmlAbbreviation();
				case HtmlTag.address:
					return new HtmlAddress();
				case HtmlTag.area:
					return new HtmlArea();
				case HtmlTag.article:
					return new HtmlArticle();
				case HtmlTag.aside:
					return new HtmlAside();
				case HtmlTag.audio:
					return new HtmlAudio();
				case HtmlTag.b:
					return new HtmlBold();
				case HtmlTag.@base:
					return new HtmlBase();
				case HtmlTag.bdi:
					return new HtmlBiDirectionalIsolation();
				case HtmlTag.bdo:
					return new HtmlBiDirectionalOverride();
				case HtmlTag.blockquote:
					return new HtmlBlockQuote();
				case HtmlTag.body:
					return new HtmlBody();
				case HtmlTag.br:
					return new HtmlLineBreak();
				case HtmlTag.button:
					return new HtmlButton();
				case HtmlTag.canvas:
					return new HtmlCanvas();
				case HtmlTag.caption:
					return new HtmlCaption();
				case HtmlTag.cite:
					return new HtmlCite();
				case HtmlTag.code:
					return new HtmlCode();
				case HtmlTag.col:
					return new HtmlCol();
				case HtmlTag.colgroup:
					return new HtmlColGroup();
				case HtmlTag.command:
					return new HtmlCommand();
				case HtmlTag.datalist:
					return new HtmlDataList();
				case HtmlTag.dd:
					return new HtmlDescriptionDefinition();
				case HtmlTag.del:
					return new HtmlDeleted();
				case HtmlTag.details:
					return new HtmlDetails();
				case HtmlTag.dfn:
					return new HtmlDefinition();
				case HtmlTag.dialog:
					return new HtmlDialog();
				case HtmlTag.div:
					return new HtmlDiv();
				case HtmlTag.dl:
					return new HtmlDescriptionList();
				case HtmlTag.dt:
					return new HtmlDescriptionTerm();
				case HtmlTag.em:
					return new HtmlEmphasize();
				case HtmlTag.embed:
					return new HtmlEmbed();
				case HtmlTag.fieldset:
					return new HtmlFieldset();
				case HtmlTag.figcaption:
					return new HtmlFigureCaption();
				case HtmlTag.figure:
					return new HtmlFigure();
				case HtmlTag.footer:
					return new HtmlFooter();
				case HtmlTag.form:
					return new HtmlForm();
				case HtmlTag.h1:
					return new HtmlH1();
				case HtmlTag.h2:
					return new HtmlH2();
				case HtmlTag.h3:
					return new HtmlH3();
				case HtmlTag.h4:
					return new HtmlH4();
				case HtmlTag.h5:
					return new HtmlH5();
				case HtmlTag.h6:
					return new HtmlH6();
				case HtmlTag.head:
					return new HtmlHead();
				case HtmlTag.header:
					return new HtmlHeader();
				case HtmlTag.hr:
					return new HtmlHorizontalRule();
				case HtmlTag.html:
					return new HtmlHtml();
				case HtmlTag.i:
					return new HtmlItalic();
				case HtmlTag.iframe:
					return new HtmlIFrame();
				case HtmlTag.img:
					return new HtmlImage();
				case HtmlTag.input:
					if (string.IsNullOrEmpty(type))
					{
						return new HtmlInput(HtmlInput.InputType.Text);
					}

					var inputType = Enum.Parse(typeof(HtmlInput.InputType), type, true).CastTo<HtmlInput.InputType>();
					switch (inputType)
					{
						case HtmlInput.InputType.Text:
							return new HtmlInputText();
						case HtmlInput.InputType.Button:
							return new HtmlInputButton();
						case HtmlInput.InputType.CheckBox:
							return new HtmlInputCheckBox();
						case HtmlInput.InputType.Color:
							return new HtmlInputColor();
						case HtmlInput.InputType.Date:
							return new HtmlInputDate();
						case HtmlInput.InputType.DateTime:
							return new HtmlInputDateTime();
						case HtmlInput.InputType.Email:
							return new HtmlInputEmail();
						case HtmlInput.InputType.File:
							return new HtmlInputFile();
						case HtmlInput.InputType.Hidden:
							return new HtmlInputHidden();
						case HtmlInput.InputType.Image:
							return new HtmlInputImage();
						case HtmlInput.InputType.Month:
							return new HtmlInputMonth();
						case HtmlInput.InputType.Number:
							return new HtmlInputNumber();
						case HtmlInput.InputType.Password:
							return new HtmlInputPassword();
						case HtmlInput.InputType.Radio:
							return new HtmlInputRadioButton();
						case HtmlInput.InputType.Range:
							return new HtmlInputRange();
						case HtmlInput.InputType.Reset:
							return new HtmlInputReset();
						case HtmlInput.InputType.Search:
							return new HtmlInputSearch();
						case HtmlInput.InputType.Submit:
							return new HtmlInputSubmit();
						case HtmlInput.InputType.Time:
							return new HtmlInputTime();
						case HtmlInput.InputType.Url:
							return new HtmlInputUrl();
						case HtmlInput.InputType.Week:
							return new HtmlInputWeek();
					}

					return new HtmlInput(HtmlInput.InputType.Text);
				case HtmlTag.ins:
					return new HtmlInserted();
				case HtmlTag.kbd:
					return new HtmlKeyboard();
				case HtmlTag.keygen:
					return new HtmlKeygen();
				case HtmlTag.label:
					return new HtmlLabel();
				case HtmlTag.legend:
					return new HtmlLegend();
				case HtmlTag.li:
					return new HtmlListItem();
				case HtmlTag.link:
					return new HtmlLink();
				case HtmlTag.map:
					return new HtmlMap();
				case HtmlTag.mark:
					return new HtmlMark();
				case HtmlTag.menu:
					return new HtmlMenu();
				case HtmlTag.meta:
					return new HtmlMeta();
				case HtmlTag.meter:
					return new HtmlMeter();
				case HtmlTag.nav:
					return new HtmlNav();
				case HtmlTag.noscript:
					return new HtmlNoScript();
				case HtmlTag.ol:
					return new HtmlOrderedList();
				case HtmlTag.optgroup:
					return new HtmlOptionGroup();
				case HtmlTag.option:
					return new HtmlOption();
				case HtmlTag.output:
					return new HtmlOutput();
				case HtmlTag.p:
					return new HtmlParagraph();
				case HtmlTag.param:
					return new HtmlParameter();
				case HtmlTag.pre:
					return new HtmlPreformatted();
				case HtmlTag.progress:
					return new HtmlProgress();
				case HtmlTag.q:
					return new HtmlQuote();
				case HtmlTag.rp:
					return new HtmlDynamic();
				case HtmlTag.rt:
					return new HtmlDynamic();
				case HtmlTag.ruby:
					return new HtmlDynamic();
				case HtmlTag.s:
					return new HtmlDynamic();
				case HtmlTag.samp:
					return new HtmlSamp();
				case HtmlTag.script:
					return new HtmlScript();
				case HtmlTag.section:
					return new HtmlSection();
				case HtmlTag.select:
					return new HtmlSelect();
				case HtmlTag.small:
					return new HtmlSmall();
				case HtmlTag.source:
					return new HtmlSource();
				case HtmlTag.span:
					return new HtmlSpan();
				case HtmlTag.strong:
					return new HtmlStrong();
				case HtmlTag.style:
					return new HtmlStyle();
				case HtmlTag.sub:
					return new HtmlSubScript();
				case HtmlTag.summary:
					return new HtmlSummary();
				case HtmlTag.sup:
					return new HtmlSuperScript();
				case HtmlTag.table:
					return new HtmlTable();
				case HtmlTag.tbody:
					return new HtmlTableBody();
				case HtmlTag.td:
					return new HtmlTableCell();
				case HtmlTag.textarea:
					return new HtmlTextArea();
				case HtmlTag.tfoot:
					return new HtmlTableFooter();
				case HtmlTag.th:
					return new HtmlTableHeadCell();
				case HtmlTag.thead:
					return new HtmlTableHeader();
				case HtmlTag.time:
					return new HtmlTime();
				case HtmlTag.title:
					return new HtmlTitle();
				case HtmlTag.tr:
					return new HtmlTableRow();
				case HtmlTag.track:
					return new HtmlTrack();
				case HtmlTag.u:
					return new HtmlUnderline();
				case HtmlTag.ul:
					return new HtmlUnorderedList();
				case HtmlTag.var:
					return new HtmlVariable();
				case HtmlTag.video:
					return new HtmlVideo();
				case HtmlTag.wbr:
					return new HtmlWordBreakOpportunity();
			}

			return new HtmlDynamic();
		}

		#endregion
	}
}