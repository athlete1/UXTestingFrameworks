// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewBase.cs" company="">
//   
// </copyright>
// <summary>
//   The view base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core
{
	using System.Collections.Generic;

	using UX.Testing.Core.Controls;
	using UX.Testing.Core.Enums;
	using UX.Testing.Core.Logging;
	using UX.Testing.Core.TestFramework;

	/// <summary>The view base.</summary>
	public abstract class ViewBase
	{
		#region Fields

		/// <summary>The logger.</summary>
		private readonly ILogger logger;

		/// <summary>The interval.</summary>
		private int interval;

		/// <summary>The retry.</summary>
		private bool retry;

		/// <summary>The testing framework.</summary>
		private Browser browser;

		/// <summary>The timeout.</summary>
		private int timeout;

		#endregion

		#region Constructors and Destructors

		/// <summary>Initializes a new instance of the <see cref="ViewBase"/> class.</summary>
		/// <param name="browser">The testing Framework.</param>
		/// <param name="timeout">The timeout.</param>
		/// <param name="interval">The interval.</param>
		protected ViewBase(Browser browser, int timeout, int interval)
		{
			this.logger = new Logger();
			this.browser = browser;
			this.timeout = timeout;
			this.interval = interval;
			this.retry = false;
		}

		/// <summary>Initializes a new instance of the <see cref="ViewBase"/> class.</summary>
		/// <param name="browser">The testing Framework.</param>
		protected ViewBase(Browser browser)
		{
			var testSettings = TestSettings.Instance;
			this.logger = new Logger();
			this.browser = browser;
			this.timeout = testSettings.Timeout;
			this.interval = testSettings.Interval;
			this.retry = false;
		}

		/// <summary>Initializes a new instance of the <see cref="ViewBase"/> class.</summary>
		/// <param name="browser">The testing Framework.</param>
		/// <param name="retry">The retry.</param>
		protected ViewBase(Browser browser, bool retry)
			: this(browser)
		{
			this.retry = retry;
		}

		#endregion

		#region Public Properties

		/// <summary>Gets or sets the num retries.</summary>
		public virtual int Interval
		{
			get
			{
				return this.interval;
			}

			set
			{
				this.interval = value;
			}
		}

		/// <summary>Gets or sets a value indicating whether retry.</summary>
		public virtual bool Retry
		{
			get
			{
				return this.retry;
			}

			set
			{
				this.retry = value;
			}
		}

		/// <summary>Gets or sets the timeout.</summary>
		public virtual int Timeout
		{
			get
			{
				return this.timeout;
			}

			set
			{
				this.timeout = value;
			}
		}

		#endregion

		#region Properties

		/// <summary>Gets the logger.</summary>
		protected ILogger Logger
		{
			get
			{
				return this.logger;
			}
		}

		/// <summary>Gets Manager.</summary>
		protected Browser Browser
		{
			get
			{
				return this.browser;
			}
		}

		#endregion

		#region Public Methods and Operators

		/// <summary>The find all.</summary>
		/// <typeparam name="T">The type of HtmlControl.</typeparam>
		/// <returns>The <see cref="IEnumerable{T}"/>.</returns>
		public IEnumerable<T> FindAll<T>() where T : HtmlControl, new()
		{
			return this.Browser.FindAll(new T());
		}

		/// <summary>The find.</summary>
		/// <typeparam name="T">The type of HtmlControl.</typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public T Find<T>() where T : HtmlControl, new()
		{
			return this.Browser.Find(new T());
		}

		/// <summary>The find.</summary>
		/// <param name="htmlControl">The html Control.</param>
		/// <typeparam name="T">The type of HtmlControl.</typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public T Find<T>(T htmlControl) where T : HtmlControl, new()
		{
			return this.Browser.Find(htmlControl);
		}

		/// <summary>The find all.</summary>
		/// <param name="htmlControl">The html Control.</param>
		/// <typeparam name="T">The type of HtmlControl.</typeparam>
		/// <returns>The <see cref="IEnumerable{T}"/>.</returns>
		public IEnumerable<T> FindAll<T>(T htmlControl) where T : HtmlControl, new()
		{
			return this.Browser.FindAll(htmlControl);
		}

		/// <summary>The find by id.</summary>
		/// <param name="id">The id.</param>
		/// <param name="findOperator">The find Operator.</param>
		/// <typeparam name="T">The type of HtmlControl.</typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public T FindById<T>(string id, FindOperator findOperator = FindOperator.Equals) where T : HtmlControl, new()
		{
			return this.Browser.FindById<T>(id, findOperator);
		}

		public IEnumerable<T> FindAllByInnerText<T>(string innerText, FindOperator findOperator = FindOperator.Equals) where T : HtmlControl, new()
		{
			return this.Browser.FindAllByInnerText<T>(innerText, findOperator);
		}

		public T FindByInnerText<T>(string innerText, FindOperator findOperator = FindOperator.Equals) where T : HtmlControl, new()
		{
			return this.Browser.FindByInnerText<T>(innerText, findOperator);
		}

		/// <summary>The find all by id.</summary>
		/// <param name="id">The id.</param>
		/// <param name="findOperator">The find operator.</param>
		/// <typeparam name="T">The type of HtmlControl.</typeparam>
		/// <returns>The <see cref="IEnumerable{T}"/>.</returns>
		public IEnumerable<T> FindAllById<T>(string id, FindOperator findOperator) where T : HtmlControl, new()
		{
			return this.Browser.FindAllById<T>(id, findOperator);
		}

		/// <summary>The find by class.</summary>
		/// <param name="cssClass">The css class.</param>
		/// <param name="additionalClasses">The additional classes.</param>
		/// <typeparam name="T">The type of HtmlControl.</typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public T FindByClass<T>(string cssClass, params string[] additionalClasses) where T : HtmlControl, new()
		{
			return this.Browser.FindByClass<T>(cssClass, null, additionalClasses);
		}

		/// <summary>The find by name.</summary>
		/// <param name="name">The name.</param>
		/// <typeparam name="T">The type of HtmlControl.</typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public T FindByName<T>(string name) where T : HtmlControl, new()
		{
			return this.Browser.FindByName<T>(name);
		}

		/// <summary>The find all by class.</summary>
		/// <param name="cssClass">The css class.</param>
		/// <param name="additionalClasses">The additional Classes.</param>
		/// <typeparam name="T">The type of HtmlControl.</typeparam>
		/// <returns>The <see cref="IEnumerable{T}"/>.</returns>
		public IEnumerable<T> FindAllByClass<T>(string cssClass, params string[] additionalClasses) where T : HtmlControl, new()
		{
			return this.Browser.FindAllByClass<T>(cssClass, null, additionalClasses);
		}

		/// <summary>The find all by name.</summary>
		/// <param name="name">The name.</param>
		/// <typeparam name="T">The type of HtmlControl.</typeparam>
		/// <returns>The <see cref="IEnumerable{T}"/>.</returns>
		public IEnumerable<T> FindAllByName<T>(string name) where T : HtmlControl, new()
		{
			return this.Browser.FindAllByName<T>(name);
		}

		/// <summary>The wait.</summary>
		public void Wait()
		{
			this.Wait(this.Timeout, this.Interval);
		}

		/// <summary>The wait.</summary>
		/// <param name="interval">The interval.</param>
		/// <param name="ajaxTimeout">The ajax timeout.</param>
		public void Wait(int interval, int ajaxTimeout)
		{
			this.Browser.Wait(interval, ajaxTimeout);
		}
		
		#endregion
	}
}