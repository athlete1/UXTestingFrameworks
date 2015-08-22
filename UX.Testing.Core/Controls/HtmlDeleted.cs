// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlDeleted.cs" company="">
//   
// </copyright>
// <summary>
//   The html div.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	/// <summary>The html div.</summary>
	public class HtmlDeleted : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets or sets the cite.</summary>
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

		/// <summary>Gets or sets the date time.</summary>
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
				return HtmlTag.del;
			}
		}

		#endregion
	}
}