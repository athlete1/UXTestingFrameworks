// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlTextArea.cs" company="">
//   
// </copyright>
// <summary>
//   The html div.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	/// <summary>The html div.</summary>
	public class HtmlTextArea : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets or sets AutoFocus.</summary>
		public string AutoFocus
		{
			get
			{
				return this.GetAttribute("autofocus");
			}

			set
			{
				this.AddAttribute("autofocus", value);
			}
		}

		/// <summary>Gets or sets Cols.</summary>
		public string Cols
		{
			get
			{
				return this.GetAttribute("cols");
			}

			set
			{
				this.AddAttribute("cols", value);
			}
		}

		/// <summary>Gets or sets Disabled.</summary>
		public string Disabled
		{
			get
			{
				return this.GetAttribute("disabled");
			}

			set
			{
				this.AddAttribute("disabled", value);
			}
		}

		/// <summary>Gets or sets Form.</summary>
		public string Form
		{
			get
			{
				return this.GetAttribute("form");
			}

			set
			{
				this.AddAttribute("form", value);
			}
		}

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.textarea;
			}
		}

		/// <summary>Gets or sets MaxLength.</summary>
		public string MaxLength
		{
			get
			{
				return this.GetAttribute("maxlength");
			}

			set
			{
				this.AddAttribute("maxlength", value);
			}
		}

		/// <summary>Gets or sets PlaceHolder.</summary>
		public string PlaceHolder
		{
			get
			{
				return this.GetAttribute("placeholder");
			}

			set
			{
				this.AddAttribute("placeholder", value);
			}
		}

		/// <summary>Gets or sets ReadOnly.</summary>
		public string ReadOnly
		{
			get
			{
				return this.GetAttribute("readonly");
			}

			set
			{
				this.AddAttribute("readonly", value);
			}
		}

		/// <summary>Gets or sets Required.</summary>
		public string Required
		{
			get
			{
				return this.GetAttribute("required");
			}

			set
			{
				this.AddAttribute("required", value);
			}
		}

		/// <summary>Gets or sets Rows.</summary>
		public string Rows
		{
			get
			{
				return this.GetAttribute("rows");
			}

			set
			{
				this.AddAttribute("rows", value);
			}
		}

		/// <summary>Gets or sets Wrap.</summary>
		public string Wrap
		{
			get
			{
				return this.GetAttribute("wrap");
			}

			set
			{
				this.AddAttribute("wrap", value);
			}
		}

		public string Value
		{
			get
			{
				return this.Browser.GetAttribute(this, "value");
			}

			set
			{
				this.Browser.SetValue(this, value);
			}
		}

		#endregion
	}
}