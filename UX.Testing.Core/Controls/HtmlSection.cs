// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlSection.cs" company="">
//   
// </copyright>
// <summary>
//   The html section.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	/// <summary>The html section.</summary>
	public class HtmlSection : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets the tag name.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.section;
			}
		}

		#endregion
	}
}