// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlTableCell.cs" company="">
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
	public abstract class HtmlTableCellBase : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets or sets the abbr.</summary>
		[Obsolete("Not supported in HTML5.")]
		public string Abbr
		{
			get
			{
				return this.GetAttribute("abbr");
			}

			set
			{
				this.AddAttribute("abbr", value);
			}
		}

		/// <summary>Gets or sets the align.</summary>
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

		/// <summary>Gets or sets the axis.</summary>
		[Obsolete("Not supported in HTML5.")]
		public string Axis
		{
			get
			{
				return this.GetAttribute("axis");
			}

			set
			{
				this.AddAttribute("axis", value);
			}
		}

		/// <summary>Gets or sets the bg color.</summary>
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

		/// <summary>Gets or sets the char.</summary>
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

		/// <summary>Gets or sets the char off.</summary>
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

		/// <summary>Gets or sets the col span.</summary>
		[Obsolete("Not supported in HTML5.")]
		public string ColSpan
		{
			get
			{
				return this.GetAttribute("colspan");
			}

			set
			{
				this.AddAttribute("colspan", value);
			}
		}

		/// <summary>Gets or sets the headers.</summary>
		[Obsolete("Not supported in HTML5.")]
		public string Headers
		{
			get
			{
				return this.GetAttribute("headers");
			}

			set
			{
				this.AddAttribute("headers", value);
			}
		}

		/// <summary>Gets or sets the height.</summary>
		[Obsolete("Not supported in HTML5. Deprecated in HTML 4.01.")]
		public string Height
		{
			get
			{
				return this.GetAttribute("height");
			}

			set
			{
				this.AddAttribute("height", value);
			}
		}

		/// <summary>Gets or sets the no wrap.</summary>
		[Obsolete("Not supported in HTML5. Deprecated in HTML 4.01.")]
		public string NoWrap
		{
			get
			{
				return this.GetAttribute("nowrap");
			}

			set
			{
				this.AddAttribute("nowrap", value);
			}
		}

		/// <summary>Gets or sets the row span.</summary>
		[Obsolete("Not supported in HTML5.")]
		public string RowSpan
		{
			get
			{
				return this.GetAttribute("rowspan");
			}

			set
			{
				this.AddAttribute("rowspan", value);
			}
		}

		/// <summary>Gets or sets the scope.</summary>
		[Obsolete("Not supported in HTML5.")]
		public string Scope
		{
			get
			{
				return this.GetAttribute("scope");
			}

			set
			{
				this.AddAttribute("scope", value);
			}
		}

		/// <summary>Gets or sets the v align.</summary>
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

		/// <summary>Gets or sets the width.</summary>
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