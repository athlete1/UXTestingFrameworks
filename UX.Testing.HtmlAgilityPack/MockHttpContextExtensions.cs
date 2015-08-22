// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockHttpContextExtensions.cs" company="">
//   
// </copyright>
// <summary>
//   TODO: Update summary.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UX.Testing.HtmlAgilityPack
{
	using System.Web;

	using Moq;

	/// <summary>TODO: Update summary.</summary>
	public static class MockHttpContextExtensions
	{
		#region Public Methods and Operators

		/// <summary>The set item.</summary>
		/// <param name="httpContext">The http context.</param>
		/// <param name="name">The name.</param>
		/// <param name="value">The value.</param>
		public static void SetItem(this Mock<HttpContextBase> httpContext, string name, object value)
		{
			httpContext.Object.Items[name] = value;
		}

		#endregion
	}
}