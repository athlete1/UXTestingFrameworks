// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicControl.cs" company="">
//   
// </copyright>
// <summary>
//   The dynamic control.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UX.Testing.Core.Controls
{
	/// <summary>The dynamic control is used if you are not worried about knowing the HtmlControl Type.</summary>
	public class HtmlDynamic : HtmlControl
	{
		#region Public Properties

		private HtmlTag htmlTag = HtmlTag.any;

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return this.htmlTag;
			}
		}

		public void SetHtmlTag(HtmlTag htmlTag)
		{
			this.htmlTag = htmlTag;
		}

		#endregion
	}
}