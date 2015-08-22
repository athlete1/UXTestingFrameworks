// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlProgress.cs" company="">
//   
// </copyright>
// <summary>
//   The html div.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	/// <summary>The html div.</summary>
	public class HtmlProgress : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.progress;
			}
		}

		/// <summary>Gets or sets Max.</summary>
		public string Max
		{
			get
			{
				return this.GetAttribute("max");
			}

			set
			{
				this.AddAttribute("max", value);
			}
		}

		/// <summary>Gets or sets Value.</summary>
		public string Value
		{
			get
			{
				return this.GetAttribute("value");
			}

			set
			{
				this.AddAttribute("value", value);
			}
		}

		#endregion
	}
}