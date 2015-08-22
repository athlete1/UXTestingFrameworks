// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlTable.cs" company="">
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
	public class HtmlTable : HtmlControl
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

		/// <summary>Gets or sets Border.</summary>
		public string Border
		{
			get
			{
				return this.GetAttribute("border");
			}

			set
			{
				this.AddAttribute("border", value);
			}
		}

		/// <summary>Gets or sets CellPadding.</summary>
		[Obsolete("Not supported in HTML5.")]
		public string CellPadding
		{
			get
			{
				return this.GetAttribute("cellpadding");
			}

			set
			{
				this.AddAttribute("cellpadding", value);
			}
		}

		/// <summary>Gets or sets CellSpacing.</summary>
		[Obsolete("Not supported in HTML5.")]
		public string CellSpacing
		{
			get
			{
				return this.GetAttribute("cellspacing");
			}

			set
			{
				this.AddAttribute("cellspacing", value);
			}
		}

		/// <summary>Gets or sets Frame.</summary>
		[Obsolete("Not supported in HTML5.")]
		public string Frame
		{
			get
			{
				return this.GetAttribute("frame");
			}

			set
			{
				this.AddAttribute("frame", value);
			}
		}

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.table;
			}
		}

		/// <summary>Gets or sets Rules.</summary>
		[Obsolete("Not supported in HTML5.")]
		public string Rules
		{
			get
			{
				return this.GetAttribute("rules");
			}

			set
			{
				this.AddAttribute("rules", value);
			}
		}

		/// <summary>Gets or sets Summary.</summary>
		[Obsolete("Not supported in HTML5.")]
		public string Summary
		{
			get
			{
				return this.GetAttribute("summary");
			}

			set
			{
				this.AddAttribute("summary", value);
			}
		}

		/// <summary>Gets or sets Width.</summary>
		[Obsolete("Not supported in HTML5.")]
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

		public IEnumerable<HtmlTableRow> Rows
		{
			get
			{
				return this.FindAll<HtmlTableRow>();
			}
		}

		public HtmlTableHeader Header
		{
			get
			{
				return this.Find<HtmlTableHeader>();
			}
		}

		public HtmlTableBody Body
		{
			get
			{
				return this.Find<HtmlTableBody>();
			}
		}

		public HtmlTableFooter Footer
		{
			get
			{
				return this.Find<HtmlTableFooter>();
			}
		}
	}
}