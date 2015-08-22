// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlLabel.cs" company="">
//   
// </copyright>
// <summary>
//   The html div.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	/// <summary>The html div.</summary>
	public class HtmlLabel : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets or sets For.</summary>
		public string For
		{
			get
			{
				return this.GetAttribute("for");
			}

			set
			{
				this.AddAttribute("for", value);
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
				return HtmlTag.label;
			}
		}

		#endregion
	}
}