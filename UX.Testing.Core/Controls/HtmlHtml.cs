// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlHtml.cs" company="">
//   
// </copyright>
// <summary>
//   The html div.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	using System;

	/// <summary>The html div.</summary>
	public class HtmlHtml : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.html;
			}
		}

		/// <summary>Gets or sets Manifest.</summary>
		public string Manifest
		{
			get
			{
				return this.GetAttribute("manifest");
			}

			set
			{
				this.AddAttribute("manifest", value);
			}
		}

		/// <summary>Gets or sets xmlns.</summary>
		[Obsolete("Not supported in HTML.  ONLY for XHTML.")]
		public string Xmlns
		{
			get
			{
				return this.GetAttribute("xmlns");
			}

			set
			{
				this.AddAttribute("xmlns", value);
			}
		}

		#endregion
	}
}