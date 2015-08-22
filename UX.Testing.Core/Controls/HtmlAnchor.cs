// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlAnchor.cs" company="">
//   
// </copyright>
// <summary>
//   The html anchor.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	/// <summary>The html anchor.</summary>
	public class HtmlAnchor : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets or sets the charset.</summary>
		public string Charset
		{
			get
			{
				return this.GetAttribute("charset");
			}

			set
			{
				this.AddAttribute("charset", value);
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

		/// <summary>Gets the tag name.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.a;
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

		/// <summary>Gets or sets the name.</summary>
		public new string Name
		{
			get
			{
				return this.GetAttribute("name");
			}

			set
			{
				this.AddAttribute("name", value);
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

		/// <summary>Gets or sets the rev.</summary>
		public string Rev
		{
			get
			{
				return this.GetAttribute("rev");
			}

			set
			{
				this.AddAttribute("rev", value);
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