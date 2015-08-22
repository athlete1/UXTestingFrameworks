// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITestingFramework.cs" company="">
//   
// </copyright>
// <summary>
//   The TestingFramework interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.TestFramework
{
	/// <summary>The TestingFramework interface.</summary>
	public interface ITestingFramework
	{
		/// <summary>Gets the browser.</summary>
		Browser Browser { get; }

		/// <summary>The initialize.</summary>
		void Initialize(Browser.BrowserType browserType, string baseUrl);

		/// <summary>The cleanup.</summary>
		void Cleanup();
	}
}