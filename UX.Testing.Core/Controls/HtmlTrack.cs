// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlTrack.cs" company="">
//   
// </copyright>
// <summary>
//   The html div.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	/// <summary>The html div.</summary>
	public class HtmlTrack : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets or sets Default.</summary>
		public string Default
		{
			get
			{
				return this.GetAttribute("default");
			}

			set
			{
				this.AddAttribute("default", value);
			}
		}

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.track;
			}
		}

		/// <summary>Gets or sets Kind.</summary>
		public string Kind
		{
			get
			{
				return this.GetAttribute("kind");
			}

			set
			{
				this.AddAttribute("kind", value);
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

		/// <summary>Gets or sets Src.</summary>
		public string Src
		{
			get
			{
				return this.GetAttribute("src");
			}

			set
			{
				this.AddAttribute("src", value);
			}
		}

		/// <summary>Gets or sets SrcLang.</summary>
		public string SrcLang
		{
			get
			{
				return this.GetAttribute("srclang");
			}

			set
			{
				this.AddAttribute("srclang", value);
			}
		}

		#endregion
	}
}