// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlListItem.cs" company="">
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
	public class HtmlListItem : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.li;
			}
		}

		/// <summary>Gets or sets Type.</summary>
		[Obsolete("Not supported in HTML5. Deprecated in HTML 4.01.")]
		public string Type
		{
			get
			{
				return this.GetAttribute("type");
			}

			set
			{
				this.AddAttribute("type", value);
			}
		}

		/// <summary>Gets or sets Value.</summary>
		public string Value
		{
			get
			{
				return this.GetAttribute("value");
			}

			set
			{
				this.AddAttribute("value", value);
			}
		}

		#endregion
	}
}