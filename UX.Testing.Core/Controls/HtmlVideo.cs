// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlVideo.cs" company="">
//   
// </copyright>
// <summary>
//   The html div.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	/// <summary>The html div.</summary>
	public class HtmlVideo : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets or sets AutoPlay.</summary>
		public string AutoPlay
		{
			get
			{
				return this.GetAttribute("autoplay");
			}

			set
			{
				this.AddAttribute("autoplay", value);
			}
		}

		/// <summary>Gets or sets Controls.</summary>
		public string Controls
		{
			get
			{
				return this.GetAttribute("controls");
			}

			set
			{
				this.AddAttribute("controls", value);
			}
		}

		/// <summary>Gets or sets height.</summary>
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
				return HtmlTag.video;
			}
		}

		/// <summary>Gets or sets Loop.</summary>
		public string Loop
		{
			get
			{
				return this.GetAttribute("loop");
			}

			set
			{
				this.AddAttribute("loop", value);
			}
		}

		/// <summary>Gets or sets Muted.</summary>
		public string Muted
		{
			get
			{
				return this.GetAttribute("muted");
			}

			set
			{
				this.AddAttribute("muted", value);
			}
		}

		/// <summary>Gets or sets Poster.</summary>
		public string Poster
		{
			get
			{
				return this.GetAttribute("poster");
			}

			set
			{
				this.AddAttribute("poster", value);
			}
		}

		/// <summary>Gets or sets PreLoad.</summary>
		public string PreLoad
		{
			get
			{
				return this.GetAttribute("preload");
			}

			set
			{
				this.AddAttribute("preload", value);
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

		/// <summary>Gets or sets Width.</summary>
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