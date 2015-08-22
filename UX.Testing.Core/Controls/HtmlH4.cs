// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlH4.cs" company="">
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
	public class HtmlH4 : HtmlControl
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
				return HtmlTag.h4;
			}
		}

		#endregion
	}
}