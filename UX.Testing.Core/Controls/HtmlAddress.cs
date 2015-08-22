// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlAddress.cs" company="">
//   
// </copyright>
// <summary>
//   The html div.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	/// <summary>The html address.</summary>
	public class HtmlAddress : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets or sets the alt.</summary>
		public string Alt
		{
			get
			{
				return this.GetAttribute("alt");
			}

			set
			{
				this.AddAttribute("alt", value);
			}
		}

		/// <summary>Gets or sets the coords.</summary>
		public string Coords
		{
			get
			{
				return this.GetAttribute("coords");
			}

			set
			{
				this.AddAttribute("coords", value);
			}
		}

		/// <summary>Gets or sets the download.</summary>
		public string Download
		{
			get
			{
				return this.GetAttribute("download");
			}

			set
			{
				this.AddAttribute("download", value);
			}
		}

		/// <summary>Gets or sets the href.</summary>
		public string Href
		{
			get
			{
				return this.GetAttribute("href");
			}

			set
			{
				this.AddAttribute("href", value);
			}
		}

		/// <summary>Gets or sets the href lang.</summary>
		public string HrefLang
		{
			get
			{
				return this.GetAttribute("hreflang");
			}

			set
			{
				this.AddAttribute("hreflang", value);
			}
		}

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.address;
			}
		}

		/// <summary>Gets or sets the media.</summary>
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

		/// <summary>Gets or sets the no href.</summary>
		public string NoHref
		{
			get
			{
				return this.GetAttribute("nohref");
			}

			set
			{
				this.AddAttribute("nohref", value);
			}
		}

		/// <summary>Gets or sets the rel.</summary>
		public string Rel
		{
			get
			{
				return this.GetAttribute("rel");
			}

			set
			{
				this.AddAttribute("rel", value);
			}
		}

		/// <summary>Gets or sets the shape.</summary>
		public string Shape
		{
			get
			{
				return this.GetAttribute("shape");
			}

			set
			{
				this.AddAttribute("shape", value);
			}
		}

		/// <summary>Gets or sets the target.</summary>
		public string Target
		{
			get
			{
				return this.GetAttribute("target");
			}

			set
			{
				this.AddAttribute("target", value);
			}
		}

		/// <summary>Gets or sets the type.</summary>
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