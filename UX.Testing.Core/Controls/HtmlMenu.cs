// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlMenu.cs" company="">
//   
// </copyright>
// <summary>
//   The html div.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	/// <summary>The html div.</summary>
	public class HtmlMenu : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.menu;
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

		/// <summary>Gets or sets Type.</summary>
		public string Type
		{
			get
			{
				return this.GetAttribute("type");
			}

			set
			{
				this.AddAttribute("type", value);
			}
		}

		#endregion
	}
}