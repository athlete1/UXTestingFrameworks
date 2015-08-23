using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleTestProject
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using UX.Testing.Core.Extensions;

    [TestClass]
    public class FrameworkInit
    {
        private static UX.Testing.Core.TestFramework.ITestingFramework testingFramework;

        [AssemblyInitialize]
        public static void InitializeReferencedAssemblies(TestContext context)
        {
            testingFramework = new UX.Testing.Selenium.TestingFramework();
            testingFramework.ShouldNotBeNull();
        }

        [AssemblyCleanup]
        public static void CleanupAssembly()
        {
            testingFramework.Cleanup();
        }
    }
}
