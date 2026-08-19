using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleTestProject
{
    using ExampleAbstractionProject;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using UX.Testing.Core;

    [TestClass]
    public class SingleBrowserBaseTest : BrowserlessBaseTests
    {
        private static BingSite bingPAL;

        protected static BingSite Bing
        {
            get
            {
                return bingPAL;
            }
        }

        protected override void Initialize()
        {
            base.Initialize();
            if (!this.BrowserOpened)
            {
                this.OpenBrowser();
            }

            bingPAL = new BingSite(this.Browser);
        }

        protected new void Cleanup()
        {
            this.CleanupTest();
            base.Cleanup();
        }

        protected virtual void CleanupTest()
        {

        }

        protected string GetTestParameter(string name)
        {
            return this.TestContext.GetDataValue(name);
        }

    }
}
