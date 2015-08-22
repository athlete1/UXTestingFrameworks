// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlOrderedList.cs" company="">
//   
// </copyright>
// <summary>
//   The html div.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	using System;
	using System.Collections.Generic;

	/// <summary>The html div.</summary>
	public class HtmlOrderedList : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets or sets Compact.</summary>
		[Obsolete("Not supported in HTML5. Deprecated in HTML 4.01.")]
		public string Compact
		{
			get
			{
				return this.GetAttribute("compact");
			}

			set
			{
				this.AddAttribute("compact", value);
			}
		}

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.ol;
			}
		}

		/// <summary>Gets or sets Reversed.</summary>
		public string Reversed
		{
			get
			{
				return this.GetAttribute("reversed");
			}

			set
			{
				this.AddAttribute("reversed", value);
			}
		}

		/// <summary>Gets or sets Start.</summary>
		public string Start
		{
			get
			{
				return this.GetAttribute("start");
			}

			set
			{
				this.AddAttribute("start", value);
			}
		}

		/// <summary>Gets or sets Type.</summary>
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

		public IEnumerable<HtmlListItem> ListItems
		{
			get
			{
				return this.FindAll<HtmlListItem>(); 
			}
		}

		#endregion
	}
}