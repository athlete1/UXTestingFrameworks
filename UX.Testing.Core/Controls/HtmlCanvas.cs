// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlCanvas.cs" company="">
//   
// </copyright>
// <summary>
//   The html div.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	/// <summary>The html div.</summary>
	public class HtmlCanvas : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets or sets the height.</summary>
		public string Height
		{
			get
			{
				return this.GetAttribute("height");
			}

			set
			{
				this.AddAttribute("height", value);
			}
		}

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.canvas;
			}
		}

		/// <summary>Gets or sets the width.</summary>
		public string Width
		{
			get
			{
				return this.GetAttribute("width");
			}

			set
			{
				this.AddAttribute("width", value);
			}
		}

		#endregion
	}
}