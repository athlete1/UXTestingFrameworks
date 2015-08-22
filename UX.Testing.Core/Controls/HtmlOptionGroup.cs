// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlOptionGroup.cs" company="">
//   
// </copyright>
// <summary>
//   The html div.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	/// <summary>The html div.</summary>
	public class HtmlOptionGroup : HtmlControl
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
				return HtmlTag.optgroup;
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

		#endregion
	}
}