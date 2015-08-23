

namespace ExampleTestProject.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using UX.Testing.Core;
    using UX.Testing.Core.Attributes;
    using UX.Testing.Core.Extensions;

    [TestClass]
    public class Bing_Home_Search : SingleBrowserBaseTest
    {
        [TestMethod]
        public void Bing_HomePage_Search()
        {
            var runner = new TestRunner<Bing_Home_Search>(this, "Test");
            runner.ExecuteSteps();
        }

        [TestStep("Test", 1)]
        public void Test()
        {
            Bing.Home.NavigateTo();
            Bing.Home.SearchWidget.IsVisible().ShouldBeTrue();
            Bing.Home.SearchWidget.TextBox.Text.ShouldEqual("");
            Bing.Home.SearchWidget.TextBox.Text = "Test";
            Bing.Home.SearchWidget.Button.Click();

            Bing.Search.SearchWidget.IsVisible().ShouldBeTrue();
            Bing.Search.SearchWidget.TextBox.Text.ShouldEqual("Test");
        }

        [CleanupStep("Test")]
        public void Cleanup()
        {
            
        }
    }
}
