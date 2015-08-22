// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlImage.cs" company="">
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
	public class HtmlImage : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets or sets Align.</summary>
		[Obsolete("Not supported in HTML5. Deprecated in HTML 4.01.")]
		public string Align
		{
			get
			{
				return this.GetAttribute("align");
			}

			set
			{
				this.AddAttribute("align", value);
			}
		}

		/// <summary>Gets or sets Alt.</summary>
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

		/// <summary>Gets or sets Border.</summary>
		[Obsolete("Not supported in HTML5. Deprecated in HTML 4.01.")]
		public string Border
		{
			get
			{
				return this.GetAttribute("border");
			}

			set
			{
				this.AddAttribute("border", value);
			}
		}

		/// <summary>Gets or sets CrossOrigin.</summary>
		public string CrossOrigin
		{
			get
			{
				return this.GetAttribute("crossorigin");
			}

			set
			{
				this.AddAttribute("crossorigin", value);
			}
		}

		/// <summary>Gets or sets HS.</summary>
		[Obsolete("Not supported in HTML5. Deprecated in HTML 4.01.")]
		public string HSpace
		{
			get
			{
				return this.GetAttribute("hspace");
			}

			set
			{
				this.AddAttribute("hspace", value);
			}
		}

		/// <summary>Gets or sets Height.</summary>
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
				return HtmlTag.img;
			}
		}

		/// <summary>Gets or sets IsMap.</summary>
		public string IsMap
		{
			get
			{
				return this.GetAttribute("ismap");
			}

			set
			{
				this.AddAttribute("ismap", value);
			}
		}

		/// <summary>Gets or sets LongDesc.</summary>
		[Obsolete("Not supported in HTML5.")]
		public string LongDesc
		{
			get
			{
				return this.GetAttribute("longdesc");
			}

			set
			{
				this.AddAttribute("longdesc", value);
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

		/// <summary>Gets or sets UseMap.</summary>
		public string UseMap
		{
			get
			{
				return this.GetAttribute("usemap");
			}

			set
			{
				this.AddAttribute("usemap", value);
			}
		}

		/// <summary>Gets or sets VSpace.</summary>
		public string VSpace
		{
			get
			{
				return this.GetAttribute("vspace");
			}

			set
			{
				this.AddAttribute("vspace", value);
			}
		}

		/// <summary>Gets or sets Width.</summary>
		[Obsolete("Not supported in HTML5. Deprecated in HTML 4.01.")]
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