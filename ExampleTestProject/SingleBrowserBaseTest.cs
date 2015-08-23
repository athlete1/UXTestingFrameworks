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
            Assert.IsNotNull((object)this.TestContext.DataRow, "The datasource is not configured properly.");
            Assert.IsTrue(this.TestContext.DataRow.Table.Columns.Contains(name), string.Format("The test parameter specified could not be found: {0}", (object)name));
            return this.TestContext.DataRow[name].ToString();
        }

    }
}
