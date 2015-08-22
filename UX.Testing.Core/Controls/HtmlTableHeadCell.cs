// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlTableHeadCell.cs" company="">
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
	public class HtmlTableHeadCell : HtmlTableCellBase
	{
		#region Public Properties

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.th;
			}
		}

		#endregion
	}
}