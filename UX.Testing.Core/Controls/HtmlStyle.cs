// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlStyle.cs" company="">
//   
// </copyright>
// <summary>
//   The html div.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	/// <summary>The html div.</summary>
	public class HtmlStyle : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.style;
			}
		}

		/// <summary>Gets or sets Media.</summary>
		public string Media
		{
			get
			{
				return this.GetAttribute("media");
			}

			set
			{
				this.AddAttribute("media", value);
			}
		}

		/// <summary>Gets or sets Scoped.</summary>
		public string Scoped
		{
			get
			{
				return this.GetAttribute("scoped");
			}

			set
			{
				this.AddAttribute("scoped", value);
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