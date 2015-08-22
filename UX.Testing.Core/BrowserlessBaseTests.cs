namespace UX.Testing.Core
{
	using System.Diagnostics;
	using System.Reflection;

	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using UX.Testing.Core.Events;
    using UX.Testing.Core;
	using UX.Testing.Core.Logging;
	using UX.Testing.Core.TestFramework;

	/// <summary>The base tests.</summary>
	[TestClass]
	public abstract class BrowserlessBaseTests
	{
		#region Constants

		/// <summary>The frame offset.</summary>
		private const int FrameOffset = 4;

		#endregion

		#region Fields

		/// <summary>The browser.</summary>
		private static Browser browser;

        /// <summary>The is browser opened.</summary>
        private static bool browserOpened;

		/// <summary>The logger.</summary>
		private ILogger logger;

		/// <summary>The test context.</summary>
		private TestContext testContext;

		/// <summary>The base url.</summary>
		private string baseUrl;

		/// <summary>The stopwatch.</summary>
		private Stopwatch stopwatch = new Stopwatch();

        private bool screenShotTaken = false;

		#endregion

		#region Constructors and Destructors

		/// <summary>Initializes a new instance of the <see cref="BaseTests"/> class.</summary>
		/// <param name="newBrowserPerIteration">The run Browser Per Iteration.</param>
		protected BrowserlessBaseTests()
		{
			var testSettings = TestSettings.Instance;
			var remoteagentnlog = new RemoteNlogHelper();
			remoteagentnlog.EnableRemoteUDPLogger();
			this.logger = new Logger();
            TestRunnerEventHandler.TestRunnerExceptionOccured += this.TestRunnerExceptionOccured;
        }

        private void TestRunnerExceptionOccured(object sender, TestRunnerEventArgs eventArgs)
        {
            if (string.IsNullOrWhiteSpace(eventArgs.Data))
            {
                this.TakeScreenShot();
            }
            else
            {
                this.TakeScreenShot(eventArgs.Data);
            }

            this.screenShotTaken = true;
        }

        #endregion

        #region Public Properties

        /// <summary>Gets the testing framework.</summary>
        public ITestingFramework TestingFramework { get; private set; }

		/// <summary>Gets or sets the base url.</summary>
		public string BaseUrl
		{
			get
			{
				return this.baseUrl;
			}

			set
			{
				this.baseUrl = value;
			}
		}

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

		#endregion

		#region Properties

		/// <summary>Gets or sets Browser.</summary>
		protected Browser Browser
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

        protected bool BrowserOpened
        {
            get
            {
                return browserOpened;
            }
        }

		#endregion

		public void OpenBrowser()
		{
			this.Logger.Trace("Browser Setup");
			var testSettings = TestSettings.Instance;
			this.TestingFramework = FrameworkLoader.GetInitializedFrameworkInstance();
			this.BaseUrl = testSettings.BaseUrl;
			//this.TestingFramework.Initialize(TestSettings.Instance.Browser, this.BaseUrl);
			this.Browser = this.TestingFramework.Browser;
            browserOpened = true;
		}

		public void CloseBrowser()
		{

			this.Logger.Trace("Browser Cleanup");
			this.TestingFramework.Cleanup();
            browserOpened = false;
		}

		/// <summary>The get test method name.</summary>
		/// <returns>The <see cref="string"/>.</returns>
		private string GetTestMethodName()
		{
			try
			{
				// for when it runs via TeamCity
				var testName = string.Format("{0}.{1}", this.testContext.FullyQualifiedTestClassName, this.TestContext.TestName);
				return testName;
			}
			catch
			{
				// for when it runs via Visual Studio locally
				var stackTrace = new StackTrace();
				foreach (var stackFrame in stackTrace.GetFrames() ?? new StackFrame[] { })
				{
					MethodBase methodBase = stackFrame.GetMethod();
					object[] attributes = methodBase.GetCustomAttributes(typeof(TestMethodAttribute), false);
					if (attributes.Length >= 1)
					{
						return methodBase.Name;
					}
				}

				return "Not called from a test method";
			}
		}

		/// <summary>The log test result.</summary>
		private void LogTestResult()
		{
			var currentTestOutcome = this.testContext.CurrentTestOutcome;
			var testName = string.Format("{0}.{1}", this.testContext.FullyQualifiedTestClassName, this.TestContext.TestName);
			var message = string.Format("STATUS: '{0}' TEST: '{1}' {0}", currentTestOutcome.ToString().ToUpperInvariant(), testName);
			switch (this.testContext.CurrentTestOutcome)
			{
				case UnitTestOutcome.Error:
				case UnitTestOutcome.Failed:
					this.logger.Error(message);
					Trace.TraceError(message);
					break;
				default:
					this.logger.Trace(message);
					Trace.TraceInformation(message);
					break;
			}
		}

		/// <summary>The clean up.</summary>
		[TestCleanup]
		public void TestCleanUp()
		{
			this.logger.Trace("Running Test Cleanup");
			this.Cleanup();
		}

		/// <summary>The initialize.</summary>
		[TestInitialize]
		public void TestInitialize()
		{
			this.stopwatch.Start();
			this.Logger.Trace("Running Test Initialize");
			this.Initialize();
		}

		#region Methods

		/// <summary>The clean up.</summary>
		protected virtual void Cleanup()
		{
            if(!this.screenShotTaken)
            {
                switch (this.testContext.CurrentTestOutcome)
                {
                    case UnitTestOutcome.Failed:
                    case UnitTestOutcome.Error:
                        this.TakeScreenShot();
                        break;
                }
            }

			this.LogTestResult();
			this.stopwatch.Stop();
			this.Logger.Info(
				"---------- Completed Test {0} - [RUNTIME: {1}]----------", this.GetTestMethodName(), this.stopwatch.Elapsed.TotalMilliseconds);
		}

        protected void TakeScreenShot()
        {
            this.TakeScreenShot(string.Empty);
        }

        protected void TakeScreenShot(string fileName)
        {
            if (!TestSettings.Instance.ScreenCapture)
            {
                return;
            }

            var image = string.Empty;
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                image = this.Browser.TakeScreenShot(fileName);
            }
            else
            {
                image = this.Browser.TakeScreenShot();
            }

            this.TestContext.AddResultFile(image);
        }

        /// <summary>The initialize.</summary>
        protected virtual void Initialize()
		{
			this.Logger.Info("---------- Starting Test {0} ----------", this.GetTestMethodName());
		}

		#endregion
	}
}
