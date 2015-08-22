// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlTableBody.cs" company="">
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
	public class HtmlTableBody : HtmlControl
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
				return HtmlTag.tbody;
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