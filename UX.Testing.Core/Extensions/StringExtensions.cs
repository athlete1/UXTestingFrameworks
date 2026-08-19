// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="">
//   
// </copyright>
// <summary>
//   The uri extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UX.Testing.Core.Extensions
{
	using System;
	using System.Net;

	/// <summary>The uri extensions.</summary>
	public static class StringExtensions
	{
		#region Public Methods and Operators

		/// <summary>The to html decoded string.</summary>
		/// <param name="encodedString">The encoded string.</param>
		/// <returns>The <see cref="string"/>.</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static string ToHtmlDecodedString(this string encodedString)
		{
			if (encodedString == null)
			{
				throw new ArgumentNullException("encodedString");
			}

			var decodedString = WebUtility.HtmlDecode(encodedString);
			while (decodedString != encodedString)
			{
				encodedString = decodedString;
				decodedString = WebUtility.HtmlDecode(encodedString);
			}

			return decodedString;
		}

		/// <summary>The to decoded string.</summary>
		/// <param name="encodedString">The encoded String.</param>
		/// <returns>The <see cref="string"/>.</returns>
		/// <exception cref="ArgumentNullException">The string cannot be null.</exception>
		public static string ToUrlDecodedString(this string encodedString)
		{
			if (encodedString == null)
			{
				throw new ArgumentNullException("encodedString");
			}

			var decodedString = WebUtility.UrlDecode(encodedString);
			while (decodedString != encodedString)
			{
				encodedString = decodedString;
				decodedString = WebUtility.UrlDecode(encodedString);
			}

			return decodedString;
		}

		#endregion
	}
}