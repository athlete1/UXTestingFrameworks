
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.HtmlAgilityPack.Controls
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using UX.Testing.Core.Controls;

	/// <summary>The html div.</summary>
	public class HtmlSelect : HtmlControl
	{
		#region Public Properties

		#endregion

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
				return HtmlTag.select;
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

		/// <summary>Gets the options.</summary>
		public IEnumerable<HtmlOption> Options
		{
			get
			{
				return this.FindAll<HtmlOption>();
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

		/// <summary>
		///     Gets the selected item within the select element.
		/// </summary>
		/// <remarks>
		///     If more than one item is selected this will return the first item.
		/// </remarks>
		public HtmlOption SelectedOption
		{
			get
			{
				return this.Options.FirstOrDefault(option => option.Selected) ?? this.Options.FirstOrDefault();
			}
		}

		public int SelectedIndex
		{
			get
			{
				return Convert.ToInt32(this.Options.FirstOrDefault(option => option.Selected).GetFrameworkAttribute("index"));
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

		#endregion
	}
}