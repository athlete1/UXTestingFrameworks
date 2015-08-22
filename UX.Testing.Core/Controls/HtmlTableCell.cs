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
	public class HtmlTableCell : HtmlTableCellBase
	{
		#region Public Properties

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.td;
			}
		}

		#endregion
	}
}