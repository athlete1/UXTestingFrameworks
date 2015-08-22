// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlFieldset.cs" company="">
//   
// </copyright>
// <summary>
//   The html div.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	/// <summary>The html div.</summary>
	public class HtmlFieldset : HtmlControl
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

		/// <summary>Gets or sets Form.</summary>
		public string Form
		{
			get
			{
				return this.GetAttribute("form");
			}

			set
			{
				this.AddAttribute("form", value);
			}
		}

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.fieldset;
			}
		}

		#endregion
	}
}