// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlIFrame.cs" company="">
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
	public class HtmlIFrame : HtmlControl
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

		/// <summary>Gets or sets FrameBorder.</summary>
		[Obsolete("Not supported in HTML5.")]
		public string FrameBorder
		{
			get
			{
				return this.GetAttribute("frameborder");
			}

			set
			{
				this.AddAttribute("frameborder", value);
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
				return HtmlTag.iframe;
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

		/// <summary>Gets or sets MarginHeight.</summary>
		[Obsolete("Not supported in HTML5.")]
		public string MarginHeight
		{
			get
			{
				return this.GetAttribute("marginheight");
			}

			set
			{
				this.AddAttribute("marginheight", value);
			}
		}

		/// <summary>Gets or sets MarginWidth.</summary>
		[Obsolete("Not supported in HTML5.")]
		public string MarginWidth
		{
			get
			{
				return this.GetAttribute("marginwidth");
			}

			set
			{
				this.AddAttribute("marginwidth", value);
			}
		}

		/// <summary>Gets or sets SandBox.</summary>
		public string SandBox
		{
			get
			{
				return this.GetAttribute("sandbox");
			}

			set
			{
				this.AddAttribute("sandbox", value);
			}
		}

		/// <summary>Gets or sets Scrolling.</summary>
		[Obsolete("Not supported in HTML5.")]
		public string Scrolling
		{
			get
			{
				return this.GetAttribute("scrolling");
			}

			set
			{
				this.AddAttribute("scrolling", value);
			}
		}

		/// <summary>Gets or sets Seamless.</summary>
		public string Seamless
		{
			get
			{
				return this.GetAttribute("seamless");
			}

			set
			{
				this.AddAttribute("seamless", value);
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

		/// <summary>Gets or sets SrcDoc.</summary>
		public string SrcDoc
		{
			get
			{
				return this.GetAttribute("srcdoc");
			}

			set
			{
				this.AddAttribute("srcdoc", value);
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