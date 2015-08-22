// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlDocumentExtensions.cs" company="">
//   
// </copyright>
// <summary>
//   The html document extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UX.Testing.HtmlAgilityPack
{
	using global::HtmlAgilityPack;

	/// <summary>The html document extensions.</summary>
	public static class HtmlDocumentExtensions
	{
		#region Public Methods and Operators

		/// <summary>The to html.</summary>
		/// <param name="document">The document.</param>
		/// <returns>The <see cref="string"/>.</returns>
		public static string ToHtmlString(this HtmlDocument document)
		{
			return document.DocumentNode.OuterHtml;
		}

		#endregion
	}
}