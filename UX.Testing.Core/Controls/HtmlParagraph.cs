// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlParagraph.cs" company="">
//   
// </copyright>
// <summary>
//   The html paragraph.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	using System;

	/// <summary>The html paragraph.</summary>
	public class HtmlParagraph : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets or sets Align.</summary>
		[Obsolete("Not supported in HTML5. Deprecated in HTML 4.01.")]
		public string Align
		{
			get
			{
				return this.GetAttribute("align");
			}

			set
			{
				this.AddAttribute("align", value);
			}
		}

		/// <summary>Gets the tag name.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.p;
			}
		}

		#endregion
	}
}