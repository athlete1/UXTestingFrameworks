// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockHttpResponseExtensions.cs" company="">
//   
// </copyright>
// <summary>
//   TODO: Update summary.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UX.Testing.HtmlAgilityPack
{
	using System.Text;
	using System.Web;

	using Moq;

	/// <summary>TODO: Update summary.</summary>
	public static class MockHttpResponseExtensions
	{
		#region Public Methods and Operators

		/// <summary>The set content encoding.</summary>
		/// <param name="mockResponse">The mock response.</param>
		/// <param name="encoding">The encoding.</param>
		public static void SetContentEncoding(this Mock<HttpResponseBase> mockResponse, Encoding encoding)
		{
			mockResponse.SetupGet(m => m.ContentEncoding).Returns(encoding);
		}

		/// <summary>The set content type.</summary>
		/// <param name="mockResponse">The mock response.</param>
		/// <param name="contentType">The content type.</param>
		public static void SetContentType(this Mock<HttpResponseBase> mockResponse, string contentType)
		{
			mockResponse.SetupGet(m => m.ContentType).Returns(contentType);
		}

		#endregion
	}
}