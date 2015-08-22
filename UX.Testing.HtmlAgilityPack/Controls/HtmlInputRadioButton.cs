﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlInputRadioButton.cs" company="EBSCO Industries, Inc.">
//   Copyright (c) 2015, Ebsco Information Services.  All Rights Reserved.
// </copyright>
// <summary>
//   The html input text.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.HtmlAgilityPack.Controls
{
	/// <summary>The html input text.</summary>
	public class HtmlInputRadioButton : UX.Testing.Core.Controls.HtmlInputRadioButton
	{
		#region Constructors and Destructors

		/// <summary>
		/// The presence of the attribute checked is sufficient in HTML (although not XHTML) to select a radio button.
		/// </summary>
		public override bool Checked
		{
			get
			{
				return this.GetFrameworkAttribute("checked") != null;
			}
		}

		#endregion
	}
}