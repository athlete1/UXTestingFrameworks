// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlInput.cs" company="">
//   
// </copyright>
// <summary>
//   The html input.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	using System;

	/// <summary>The html input.</summary>
	public class HtmlInput : HtmlControl
	{
		#region Fields

		/// <summary>The type.</summary>
		private InputType type;

		#endregion

		#region Constructors and Destructors

		/// <summary>Initializes a new instance of the <see cref="HtmlInput"/> class.</summary>
		/// <param name="type">The type.</param>
		public HtmlInput(InputType type)
		{
			this.type = type;
		}

		#endregion

		#region Enums

		/// <summary>The input type.</summary>
		public enum InputType
		{
			/// <summary>The button.</summary>
			Button, 

			/// <summary>The check box.</summary>
			CheckBox, 

			/// <summary>The color.</summary>
			Color, 

			/// <summary>The date.</summary>
			Date, 

			/// <summary>The date time.</summary>
			DateTime, 

			/// <summary>The date time local.</summary>
			DateTimeLocal, 

			/// <summary>The file.</summary>
			File, 

			/// <summary>The hidden.</summary>
			Hidden, 

			/// <summary>The image.</summary>
			Image, 

			/// <summary>The month.</summary>
			Month, 

			/// <summary>The password.</summary>
			Password, 

			/// <summary>The radio.</summary>
			Radio, 

			/// <summary>The reset.</summary>
			Reset, 

			/// <summary>The submit.</summary>
			Submit, 

			/// <summary>The tel.</summary>
			Tel, 

			/// <summary>The text.</summary>
			Text, 

			/// <summary>The time.</summary>
			Time, 

			/// <summary>The email.</summary>
			Email, 

			/// <summary>The url.</summary>
			Url, 

			/// <summary>The number.</summary>
			Number, 

			/// <summary>The range.</summary>
			Range, 

			/// <summary>The search.</summary>
			Search, 

			/// <summary>The week.</summary>
			Week
		}

		#endregion

		#region Public Properties

		/// <summary>Gets or sets Accept.</summary>
		public string Accept
		{
			get
			{
				return this.GetAttribute("accept");
			}

			set
			{
				this.AddAttribute("accept", value);
			}
		}

		/// <summary>Gets or sets Align.</summary>
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

		/// <summary>Gets or sets AutoComplete.</summary>
		public string AutoComplete
		{
			get
			{
				return this.GetAttribute("autocomplete");
			}

			set
			{
				this.AddAttribute("autocomplete", value);
			}
		}

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

		/// <summary>Gets or sets Checked.</summary>
		public virtual bool Checked
		{
			get
			{
				var checkedAttr = (this.GetFrameworkAttribute("checked") ?? string.Empty).ToLower();
				return checkedAttr == "checked" || checkedAttr == "true";
			}
		}

		/// <summary>Gets or sets Disabled.</summary>
		public string Disabled
		{
			get
			{
				return this.Browser.GetAttribute(this, "disabled");
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

		/// <summary>Gets or sets FormAction.</summary>
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

		/// <summary>Gets or sets FormEncType.</summary>
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

		/// <summary>Gets or sets FormMethod.</summary>
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

		/// <summary>Gets or sets FormNoValidate.</summary>
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

		/// <summary>Gets or sets FormTarget.</summary>
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

		/// <summary>Gets the tag name.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.input;
			}
		}

		/// <summary>Gets or sets List.</summary>
		public string List
		{
			get
			{
				return this.GetAttribute("list");
			}

			set
			{
				this.AddAttribute("list", value);
			}
		}

		/// <summary>Gets or sets Max.</summary>
		public string Max
		{
			get
			{
				return this.GetAttribute("max");
			}

			set
			{
				this.AddAttribute("max", value);
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

		/// <summary>Gets or sets Min.</summary>
		public string Min
		{
			get
			{
				return this.GetAttribute("min");
			}

			set
			{
				this.AddAttribute("min", value);
			}
		}

		/// <summary>Gets or sets Multiple.</summary>
		public string Multiple
		{
			get
			{
				return this.GetAttribute("multiple");
			}

			set
			{
				this.AddAttribute("multiple", value);
			}
		}

		/// <summary>Gets or sets Name.</summary>
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

		/// <summary>Gets or sets Pattern.</summary>
		public string Pattern
		{
			get
			{
				return this.GetAttribute("pattern");
			}

			set
			{
				this.AddAttribute("pattern", value);
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

		/// <summary>Gets or sets Size.</summary>
		public string Size
		{
			get
			{
				return this.GetAttribute("size");
			}

			set
			{
				this.AddAttribute("size", value);
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

		/// <summary>Gets or sets Step.</summary>
		public string Step
		{
			get
			{
				return this.GetAttribute("step");
			}

			set
			{
				this.AddAttribute("step", value);
			}
		}

		/// <summary>Gets or sets the value.</summary>
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

		/// <summary>Gets the type.</summary>
		public InputType Type
		{
			get
			{
				return this.type;
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