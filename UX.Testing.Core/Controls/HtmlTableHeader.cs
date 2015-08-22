// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlTableHeader.cs" company="">
//   
// </copyright>
// <summary>
//   The html div.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	using System.Collections.Generic;

	/// <summary>The html div.</summary>
	public class HtmlTableHeader : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets or sets Align.</summary>
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

		/// <summary>Gets or sets Char.</summary>
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
				return HtmlTag.thead;
			}
		}

		/// <summary>Gets or sets VAlign.</summary>
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

		public IEnumerable<HtmlTableRow> Rows
		{
			get
			{
				return this.FindAll<HtmlTableRow>();
			}
		}

		#endregion
	}
}