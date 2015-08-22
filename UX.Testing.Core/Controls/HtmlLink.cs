// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlLink.cs" company="">
//   
// </copyright>
// <summary>
//   The html div.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	using System;

	/// <summary>The html div.</summary>
	public class HtmlLink : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets or sets CharSetS.</summary>
		[Obsolete("Not supported in HTML5.")]
		public string CharSet
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

		/// <summary>Gets or sets Href.</summary>
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

		/// <summary>Gets or sets HrefLang.</summary>
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
				return HtmlTag.link;
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

		/// <summary>Gets or sets Rel.</summary>
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

		/// <summary>Gets or sets Rev.</summary>
		[Obsolete("Not supported in HTML5.")]
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

		/// <summary>Gets or sets Sizes.</summary>
		public string Sizes
		{
			get
			{
				return this.GetAttribute("sizes");
			}

			set
			{
				this.AddAttribute("sizes", value);
			}
		}

		/// <summary>Gets or sets Target.</summary>
		[Obsolete("Not supported in HTML5.")]
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