﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlMark.cs" company="">
//   
// </copyright>
// <summary>
//   The html div.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	/// <summary>The html div.</summary>
	public class HtmlMark : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.mark;
			}
		}

		#endregion
	}
}