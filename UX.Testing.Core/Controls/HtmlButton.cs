// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlButton.cs" company="">
//   
// </copyright>
// <summary>
//   The html div.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	/// <summary>The html div.</summary>
	public class HtmlButton : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets or sets the auto focus.</summary>
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

		/// <summary>Gets or sets the disabled.</summary>
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

		/// <summary>Gets or sets the form.</summary>
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

		/// <summary>Gets or sets the form action.</summary>
		public string FormAction
		{
			get
			{
				return this.GetAttribute("formaction");
			}

			set
			{
				this.AddAttribute("formaction", value);
			}
		}

		/// <summary>Gets or sets the form enc type.</summary>
		public string FormEncType
		{
			get
			{
				return this.GetAttribute("formenctype");
			}

			set
			{
				this.AddAttribute("formenctype", value);
			}
		}

		/// <summary>Gets or sets the form method.</summary>
		public string FormMethod
		{
			get
			{
				return this.GetAttribute("formmethod");
			}

			set
			{
				this.AddAttribute("formmethod", value);
			}
		}

		/// <summary>Gets or sets the form no validate.</summary>
		public string FormNoValidate
		{
			get
			{
				return this.GetAttribute("formnovalidate");
			}

			set
			{
				this.AddAttribute("formnovalidate", value);
			}
		}

		/// <summary>Gets or sets the form target.</summary>
		public string FormTarget
		{
			get
			{
				return this.GetAttribute("formtarget");
			}

			set
			{
				this.AddAttribute("formtarget", value);
			}
		}

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.button;
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

		/// <summary>Gets or sets the value.</summary>
		public string Value
		{
			get
			{
				return this.GetAttribute("value");
			}

			set
			{
				this.AddAttribute("value", value);
			}
		}

		#endregion
	}
}