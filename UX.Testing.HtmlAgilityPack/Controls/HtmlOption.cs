// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlOption.cs" company="EBSCO Industries, Inc.">
//   Copyright (c) 2015, Ebsco Information Services.  All Rights Reserved.
// </copyright>
// <summary>
//   The html div.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.HtmlAgilityPack.Controls
{
	using System;

	using UX.Testing.Core.Controls;

	/// <summary>The html div.</summary>
	public class HtmlOption : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets or sets Disabled.</summary>
		public string Disabled
		{
			get
			{
				return this.GetAttribute("disabled");
			}

			set
			{
				this.AddAttribute("disabled", value);
			}
		}

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.option;
			}
		}

		public int Index
		{
			get
			{
				return Convert.ToInt32(this.GetFrameworkAttribute("index"));
			}
		}

		/// <summary>Gets or sets Label.</summary>
		public string Label
		{
			get
			{
				return this.GetAttribute("label");
			}

			set
			{
				this.AddAttribute("label", value);
			}
		}

		public bool Selected
		{
			get
			{
				return this.GetFrameworkAttribute("selected") != null; // the presence of the selected attribute is sufficient to make option selected (HTML, not valid XHTML)
			}
		}

		/// <summary>Gets or sets Value.</summary>
		public string Value
		{
			get
			{
				return this.GetAttribute("value");
			}

			set
			{
				this.AddAttribute("value", value);
			}
		}

		#endregion
	}
}