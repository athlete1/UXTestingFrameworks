// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlTime.cs" company="">
//   
// </copyright>
// <summary>
//   The html div.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	/// <summary>The html div.</summary>
	public class HtmlTime : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets or sets DateTime.</summary>
		public string DateTime
		{
			get
			{
				return this.GetAttribute("datetime");
			}

			set
			{
				this.AddAttribute("datetime", value);
			}
		}

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.time;
			}
		}

		#endregion
	}
}