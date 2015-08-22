// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlInputText.cs" company="">
//   
// </copyright>
// <summary>
//   The html input text.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	/// <summary>The html input text.</summary>
	public class HtmlInputRadioButton : HtmlInput
	{
		#region Constructors and Destructors

		/// <summary>Initializes a new instance of the <see cref="HtmlInputText"/> class.</summary>
		public HtmlInputRadioButton()
			: base(InputType.Radio)
		{
		}

		/// <summary>
		/// Gets whether the radio button is selected. Uses the provider control attribute 'selected' instead of 'checked'.
		/// </summary>
		public override bool Checked
		{
			get
			{
				var selectedAttr = (this.GetFrameworkAttribute("selected") ?? string.Empty).ToLower();
				return selectedAttr == "selected" || selectedAttr == "true";
			}
		}

		#endregion
	}
}