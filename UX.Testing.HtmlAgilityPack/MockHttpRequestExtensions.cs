// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockHttpRequestExtensions.cs" company="">
//   
// </copyright>
// <summary>
//   TODO: Update summary.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UX.Testing.HtmlAgilityPack
{
	using System;
	using System.Web;

	using Moq;

	/// <summary>TODO: Update summary.</summary>
	public static class MockHttpRequestExtensions
	{
		#region Public Methods and Operators

		/// <summary>The set http method.</summary>
		/// <param name="mock">The mock.</param>
		/// <param name="method">The method.</param>
		public static void SetHttpMethod(this Mock<HttpRequestBase> mock, string method)
		{
			mock.SetupGet(m => m.HttpMethod).Returns(method);
		}

		/// <summary>The set is secure.</summary>
		/// <param name="mock">The mock.</param>
		/// <param name="isSecure">The is secure.</param>
		public static void SetIsSecure(this Mock<HttpRequestBase> mock, bool isSecure)
		{
			mock.SetupGet(m => m.IsSecureConnection).Returns(isSecure);
		}

		/// <summary>The set referrer url.</summary>
		/// <param name="mock">The mock.</param>
		/// <param name="referrer">The referrer.</param>
		public static void SetReferrerUrl(this Mock<HttpRequestBase> mock, Uri referrer)
		{
			mock.SetupGet(m => m.UrlReferrer).Returns(referrer);
		}

		/// <summary>The set request length.</summary>
		/// <param name="mock">The mock.</param>
		/// <param name="length">The length.</param>
		public static void SetRequestLength(this Mock<HttpRequestBase> mock, int length)
		{
			mock.SetupGet(m => m.ContentLength).Returns(length);
		}

		/// <summary>The set server variable.</summary>
		/// <param name="request">The request.</param>
		/// <param name="name">The name.</param>
		/// <param name="value">The value.</param>
		public static void SetServerVariable(this Mock<HttpRequestBase> request, string name, string value)
		{
			request.Object.ServerVariables.Set(name, value);
		}

		/// <summary>The set url.</summary>
		/// <param name="mock">The mock.</param>
		/// <param name="url">The url.</param>
		public static void SetUrl(this Mock<HttpRequestBase> mock, Uri url)
		{
			mock.SetupGet(m => m.Url).Returns(url);
		}

		/// <summary>The set user agent.</summary>
		/// <param name="request">The request.</param>
		/// <param name="ua">The ua.</param>
		public static void SetUserAgent(this Mock<HttpRequestBase> request, string ua)
		{
			request.SetupGet(m => m.UserAgent).Returns(ua);
		}

		/// <summary>The set user languages.</summary>
		/// <param name="mock">The mock.</param>
		/// <param name="languages">The languages.</param>
		public static void SetUserLanguages(this Mock<HttpRequestBase> mock, string[] languages)
		{
			mock.SetupGet(m => m.UserLanguages).Returns(languages);
		}

		#endregion
	}
}