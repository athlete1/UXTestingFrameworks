// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlQuote.cs" company="">
//   
// </copyright>
// <summary>
//   The html div.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	/// <summary>The html div.</summary>
	public class HtmlQuote : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets or sets Cite.</summary>
		public string Cite
		{
			get
			{
				return this.GetAttribute("cite");
			}

			set
			{
				this.AddAttribute("cite", value);
			}
		}

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.q;
			}
		}

		#endregion
	}
}