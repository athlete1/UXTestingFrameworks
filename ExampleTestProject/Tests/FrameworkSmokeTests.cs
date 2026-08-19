namespace ExampleTestProject.Tests
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using UX.Testing.Core;
	using UX.Testing.Core.Extensions;

	[TestClass]
	public class FrameworkSmokeTests
	{
		[TestMethod]
		public void TestSettings_LoadFromAppConfig()
		{
			var settings = TestSettings.Instance;
			Assert.IsNotNull(settings);
			Assert.IsFalse(string.IsNullOrEmpty(settings.BaseUrl));
			Assert.AreEqual("UX.Testing.Selenium", settings.Provider.Assembly);
			Assert.AreEqual("UX.Testing.Selenium.TestingFramework", settings.Provider.Type);
		}

		[TestMethod]
		public void StringExtensions_HtmlDecode()
		{
			"&lt;div&gt;".ToHtmlDecodedString().ShouldEqual("<div>");
		}

		[TestMethod]
		public void SeleniumTestingFramework_CanBeConstructed()
		{
			var framework = new UX.Testing.Selenium.TestingFramework();
			Assert.IsNotNull(framework);
			Assert.IsNotNull(framework.Logger);
		}
	}
}
