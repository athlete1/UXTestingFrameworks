// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlTableRow.cs" company="">
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
	using System.Linq;

	/// <summary>The html div.</summary>
	public class HtmlTableRow : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets or sets Align.</summary>
		[Obsolete("Not supported in HTML5.")]
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

		/// <summary>Gets or sets BGColor.</summary>
		[Obsolete("Not supported in HTML5. Deprecated in HTML 4.01.")]
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

		/// <summary>Gets or sets Char.</summary>
		[Obsolete("Not supported in HTML5.")]
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

		/// <summary>Gets or sets CharOff.</summary>
		[Obsolete("Not supported in HTML5.")]
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
				return HtmlTag.tr;
			}
		}

		/// <summary>Gets or sets VAlign.</summary>
		[Obsolete("Not supported in HTML5.")]
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

		public IEnumerable<HtmlTableCellBase> Cells
		{
			get
			{
				var collection = new List<HtmlTableCellBase>();
				collection.AddRange(this.FindAll<HtmlTableCell>());
				collection.AddRange(this.FindAll<HtmlTableHeadCell>());
				return collection;
			}
		}

		#endregion
	}
}