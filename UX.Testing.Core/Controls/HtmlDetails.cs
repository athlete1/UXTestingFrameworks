// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlDetails.cs" company="">
//   
// </copyright>
// <summary>
//   The html div.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	/// <summary>The html div.</summary>
	public class HtmlDetails : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.details;
			}
		}

		/// <summary>Gets or sets the open.</summary>
		public string Open
		{
			get
			{
				return this.GetAttribute("open");
			}

			set
			{
				this.AddAttribute("open", value);
			}
		}

		#endregion
	}
}