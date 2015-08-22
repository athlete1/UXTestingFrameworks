// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlHead.cs" company="">
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
	public class HtmlHead : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.head;
			}
		}

		/// <summary>Gets or sets the profile.</summary>
		[Obsolete("Not supported in HTML5.")]
		public string Profile
		{
			get
			{
				return this.GetAttribute("profile");
			}

			set
			{
				this.AddAttribute("profile", value);
			}
		}

		#endregion
	}
}