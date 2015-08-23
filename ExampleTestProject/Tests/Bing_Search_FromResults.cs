

namespace ExampleTestProject
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using UX.Testing.Core;
    using UX.Testing.Core.Attributes;
    using UX.Testing.Core.Extensions;

    [TestClass]
    public class Bing_Search_FromResults : SingleBrowserBaseTest
    {
        [TestMethod]
        public void Bing_Search_FromResults_Test()
        {
            Bing.Home.NavigateTo();
            Bing.Home.SearchWidget.TextBox.Text = "Test";
            Bing.Home.SearchWidget.Button.Click();

            Bing.Search.SearchWidget.TextBox.Text.ShouldEqual("Test");
            Bing.Search.SearchWidget.TextBox.Text = "Selenium";
            Bing.Home.SearchWidget.Button.Click();

            Bing.Search.SearchWidget.TextBox.Text.ShouldEqual("Selenium");
            Bing.Search.SearchWidget.TextBox.Text = "Test";
            Bing.Home.SearchWidget.Button.Click();

            Bing.Search.SearchWidget.TextBox.Text.ShouldEqual("Test");
        }

    }
}
