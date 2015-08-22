// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlBody.cs" company="">
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
	public class HtmlBody : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets or sets the a link.</summary>
		[Obsolete("Not supported in HTML5. Deprecated in HTML 4.01")]
		public string ALink
		{
			get
			{
				return this.GetAttribute("alink");
			}

			set
			{
				this.AddAttribute("alink", value);
			}
		}

		/// <summary>Gets or sets the bg color.</summary>
		[Obsolete("Not supported in HTML5. Deprecated in HTML 4.01")]
		public string BGColor
		{
			get
			{
				return this.GetAttribute("bgcolor");
			}

			set
			{
				this.AddAttribute("bgcolor", value);
			}
		}

		/// <summary>Gets or sets the background.</summary>
		[Obsolete("Not supported in HTML5. Deprecated in HTML 4.01")]
		public string Background
		{
			get
			{
				return this.GetAttribute("background");
			}

			set
			{
				this.AddAttribute("background", value);
			}
		}

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.body;
			}
		}

		/// <summary>Gets or sets the link.</summary>
		[Obsolete("Not supported in HTML5. Deprecated in HTML 4.01")]
		public string Link
		{
			get
			{
				return this.GetAttribute("link");
			}

			set
			{
				this.AddAttribute("link", value);
			}
		}

		/// <summary>Gets or sets the text.</summary>
		[Obsolete("Not supported in HTML5. Deprecated in HTML 4.01")]
		public string Text
		{
			get
			{
				return this.GetAttribute("text");
			}

			set
			{
				this.AddAttribute("text", value);
			}
		}

		/// <summary>Gets or sets the v link.</summary>
		[Obsolete("Not supported in HTML5. Deprecated in HTML 4.01")]
		public string VLink
		{
			get
			{
				return this.GetAttribute("vlink");
			}

			set
			{
				this.AddAttribute("vlink", value);
			}
		}

		#endregion
	}
}