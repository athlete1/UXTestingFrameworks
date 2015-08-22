// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlHorizontalRule.cs" company="">
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
	public class HtmlHorizontalRule : HtmlControl
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

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.hr;
			}
		}

		/// <summary>Gets or sets NoShade.</summary>
		[Obsolete("Not supported in HTML5. Deprecated in HTML 4.01.")]
		public string NoShade
		{
			get
			{
				return this.GetAttribute("noshade");
			}

			set
			{
				this.AddAttribute("noshade", value);
			}
		}

		/// <summary>Gets or sets Size.</summary>
		[Obsolete("Not supported in HTML5. Deprecated in HTML 4.01.")]
		public string Size
		{
			get
			{
				return this.GetAttribute("size");
			}

			set
			{
				this.AddAttribute("size", value);
			}
		}

		/// <summary>Gets or sets Width.</summary>
		[Obsolete("Not supported in HTML5. Deprecated in HTML 4.01.")]
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