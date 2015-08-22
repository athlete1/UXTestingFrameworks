// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlForm.cs" company="">
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
	public class HtmlForm : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets or sets Accept.</summary>
		[Obsolete("Not supported in HTML5.")]
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

		/// <summary>Gets or sets AcceptCharset.</summary>
		public string AcceptCharset
		{
			get
			{
				return this.GetAttribute("acceptcharset");
			}

			set
			{
				this.AddAttribute("acceptcharset", value);
			}
		}

		/// <summary>Gets or sets Action.</summary>
		public string Action
		{
			get
			{
				return this.GetAttribute("action");
			}

			set
			{
				this.AddAttribute("action", value);
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

		/// <summary>Gets or sets EncType.</summary>
		public string EncType
		{
			get
			{
				return this.GetAttribute("enctype");
			}

			set
			{
				this.AddAttribute("enctype", value);
			}
		}

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.form;
			}
		}

		/// <summary>Gets or sets Method.</summary>
		public string Method
		{
			get
			{
				return this.GetAttribute("method");
			}

			set
			{
				this.AddAttribute("method", value);
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

		/// <summary>Gets or sets NoValidate.</summary>
		public string NoValidate
		{
			get
			{
				return this.GetAttribute("novalidate");
			}

			set
			{
				this.AddAttribute("novalidate", value);
			}
		}

		/// <summary>Gets or sets Target.</summary>
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

		#endregion
	}
}