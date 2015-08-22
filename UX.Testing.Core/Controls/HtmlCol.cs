// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlCol.cs" company="">
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
	public class HtmlCol : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets or sets the align.</summary>
		[Obsolete("Not supported in HTML5. Deprecated in HTML 4.01")]
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

		/// <summary>Gets or sets the char.</summary>
		[Obsolete("Not supported in HTML5. Deprecated in HTML 4.01")]
		public string Char
		{
			get
			{
				return this.GetAttribute("char");
			}

			set
			{
				this.AddAttribute("char", value);
			}
		}

		/// <summary>Gets or sets the char off.</summary>
		[Obsolete("Not supported in HTML5. Deprecated in HTML 4.01")]
		public string CharOff
		{
			get
			{
				return this.GetAttribute("charoff");
			}

			set
			{
				this.AddAttribute("charoff", value);
			}
		}

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.col;
			}
		}

		/// <summary>Gets or sets the span.</summary>
		public string Span
		{
			get
			{
				return this.GetAttribute("span");
			}

			set
			{
				this.AddAttribute("span", value);
			}
		}

		/// <summary>Gets or sets the v align.</summary>
		[Obsolete("Not supported in HTML5. Deprecated in HTML 4.01")]
		public string VAlign
		{
			get
			{
				return this.GetAttribute("valign");
			}

			set
			{
				this.AddAttribute("valign", value);
			}
		}

		/// <summary>Gets or sets the width.</summary>
		[Obsolete("Not supported in HTML5. Deprecated in HTML 4.01")]
		public string Width
		{
			get
			{
				return this.GetAttribute("width");
			}

			set
			{
				this.AddAttribute("width", value);
			}
		}

		#endregion
	}
}