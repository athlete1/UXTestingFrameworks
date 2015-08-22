// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlAbbreviation.cs" company="">
//   
// </copyright>
// <summary>
//   The html div.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	/// <summary>The html div control.</summary>
	public class HtmlAbbreviation : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.abbr;
			}
		}

		#endregion
	}
}