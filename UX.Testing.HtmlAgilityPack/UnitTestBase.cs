// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitTestBase.cs" company="">
//   
// </copyright>
// <summary>
//   The unit test base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UX.Testing.HtmlAgilityPack
{
	using System;
	using System.Collections.Generic;
	using System.Collections.Specialized;
	using System.Diagnostics;
	using System.IO;
	using System.Text;
	using System.Web;

	using global::HtmlAgilityPack;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using Moq;

	using UX.Testing.Core;
	using UX.Testing.Core.Logging;
	using UX.Testing.Core.TestFramework;

	/// <summary>The unit test base.</summary>
	public abstract class UnitTestBase
	{
		#region Static Fields

		/// <summary>The browser.</summary>
		private static Core.TestFramework.Browser browser;

		#endregion

		#region Fields

		/// <summary>The logger.</summary>
		private ILogger logger;

		/// <summary>The stopwatch.</summary>
		private Stopwatch stopwatch = new Stopwatch();

		/// <summary>The test context.</summary>
		private TestContext testContext;

		#endregion

		#region Constructors and Destructors

		/// <summary>Initializes a new instance of the <see cref="UnitTestBase"/> class. Initializes a new instance of the <see cref="BaseTests"/> class.</summary>
		/// <param name="newBrowserPerIteration">The run Browser Per Iteration.</param>
		protected UnitTestBase()
		{
			var testSettings = TestSettings.Instance;
			var remoteagentnlog = new RemoteNlogHelper();
			remoteagentnlog.EnableRemoteUDPLogger();
			this.logger = new Logger();
		}

		#endregion

		#region Public Properties

		/// <summary>Gets or sets Logger.</summary>
		public ILogger Logger
		{
			get
			{
				return this.logger;
			}

			set
			{
				this.logger = value;
			}
		}

		/// <summary>Gets or sets TestContext.</summary>
		public TestContext TestContext
		{
			get
			{
				return this.testContext;
			}

			set
			{
				this.testContext = value;
			}
		}

		/// <summary>Gets the testing framework.</summary>
		public ITestingFramework TestingFramework { get; private set; }

		#endregion

		#region Properties

		/// <summary>Gets or sets Browser.</summary>
		protected Core.TestFramework.Browser Browser
		{
			get
			{
				return browser;
			}

			set
			{
				browser = value;
			}
		}

		/// <summary>Gets the http context base mock.</summary>
		/// <value>The http context base mock.</value>
		protected Mock<HttpContextBase> MockHttpContext { get; private set; }

		/// <summary>Gets the http request base mock.</summary>
		/// <value>The http request base mock.</value>
		protected Mock<HttpRequestBase> MockHttpRequest { get; private set; }

		/// <summary>Gets the mock http response.</summary>
		/// <value>The mock http response.</value>
		protected Mock<HttpResponseBase> MockHttpResponse { get; private set; }

		/// <summary>Gets the mock http session.</summary>
		protected Mock<HttpSessionStateBase> MockHttpSession { get; private set; }

		#endregion

		#region Public Methods and Operators

		/// <summary>The close browser.</summary>
		public void CloseBrowser()
		{
			this.Logger.Trace("Browser Cleanup");
			this.TestingFramework.Cleanup();
		}

		/// <summary>The open browser.</summary>
		/// <param name="html">The html.</param>
		public void OpenBrowser(string html)
		{
			this.Logger.Trace("Browser Setup");
			var testSettings = TestSettings.Instance;
			this.TestingFramework = FrameworkLoader.GetInitializedFrameworkInstance();
			this.TestingFramework.Initialize(TestSettings.Instance.Browser, string.Empty);
			this.Browser = this.TestingFramework.Browser;
			((HtmlDocument)this.Browser.NativeBrowser).LoadHtml(html);
		}

		/// <summary>The test initialize.</summary>
		[TestInitialize]
		public void TestInitialize()
		{
			HtmlNode.ElementsFlags.Remove("option"); // workaround for HtmlAgilityPack known issue
			this.MockHttpContext = new Mock<HttpContextBase>();
			this.MockHttpResponse = new Mock<HttpResponseBase>();
			this.MockHttpRequest = new Mock<HttpRequestBase>();
			this.MockHttpSession = new Mock<HttpSessionStateBase>();
			HttpContext.Current = new HttpContext(new HttpRequest(string.Empty, "http://tempuri.org", string.Empty), new HttpResponse(new StringWriter()));
			this.Initialize();
		}

		#endregion

		#region Methods

		/// <summary>The initialize.</summary>
		protected virtual void Initialize()
		{
			this.SetupHttpContext();
			this.SetupRequest();
			this.SetupResponse();
			this.SetupSession();
		}

		/// <summary>The initialize response.</summary>
		protected void SetupResponse()
		{
			this.MockHttpResponse.SetupAllProperties();
			this.MockHttpResponse.SetContentEncoding(Encoding.Default);
			this.MockHttpResponse.Setup(m => m.ApplyAppPathModifier(It.IsAny<string>())).Returns((string virtualPath) => virtualPath);
			this.MockHttpResponse.Setup(m => m.Cookies).Returns(new HttpCookieCollection());
			this.MockHttpContext.SetupGet(m => m.Response).Returns(this.MockHttpResponse.Object);
		}

		/// <summary>The setup http context.</summary>
		private void SetupHttpContext()
		{
			this.MockHttpContext.SetupAllProperties();
			this.MockHttpContext.SetupGet(m => m.Items).Returns(new Dictionary<object, object>());
		}

		/// <summary>Initialiae the MockHttpRequest object and add it to the MockHttpContext and the AutoMockContainer.</summary>
		private void SetupRequest()
		{
			this.MockHttpRequest.SetupGet(m => m.ServerVariables).Returns(new NameValueCollection());
			this.MockHttpRequest.SetServerVariable("SERVER_PORT", "80");
			this.MockHttpRequest.SetupGet(m => m.Headers).Returns(new NameValueCollection());
			this.MockHttpRequest.Setup(m => m.UserHostAddress).Returns("127.0.0.1");
			this.MockHttpRequest.Setup(m => m.ApplicationPath).Returns(@"/");
			this.MockHttpRequest.Setup(m => m.AppRelativeCurrentExecutionFilePath).Returns(@"/");
			this.MockHttpRequest.Setup(m => m.PathInfo).Returns(string.Empty);
			this.MockHttpRequest.Setup(m => m.Cookies).Returns(new HttpCookieCollection());
			this.MockHttpRequest.Setup(m => m.QueryString).Returns(new NameValueCollection());
			this.MockHttpRequest.Setup(m => m.Form).Returns(new NameValueCollection());
			this.MockHttpRequest.Setup(m => m.Url).Returns(new Uri("http://localhost"));
			this.MockHttpContext.SetupGet(m => m.Request).Returns(this.MockHttpRequest.Object);
		}

		/// <summary>The setup session.</summary>
		private void SetupSession()
		{
			this.MockHttpSession.SetupAllProperties();
			this.MockHttpContext.SetupGet(m => m.Session).Returns(this.MockHttpSession.Object);
		}

		#endregion
	}
}