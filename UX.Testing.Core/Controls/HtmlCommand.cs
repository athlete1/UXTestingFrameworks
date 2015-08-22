// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlCommand.cs" company="">
//   
// </copyright>
// <summary>
//   The html div.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	/// <summary>The html div.</summary>
	public class HtmlCommand : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets or sets the checked.</summary>
		public string Checked
		{
			get
			{
				return this.GetAttribute("checked");
			}

			set
			{
				this.AddAttribute("checked", value);
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

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.command;
			}
		}

		/// <summary>Gets or sets the icon.</summary>
		public string Icon
		{
			get
			{
				return this.GetAttribute("icon");
			}

			set
			{
				this.AddAttribute("icon", value);
			}
		}

		/// <summary>Gets or sets the label.</summary>
		public string Label
		{
			get
			{
				return this.GetAttribute("label");
			}

			set
			{
				this.AddAttribute("label", value);
			}
		}

		/// <summary>Gets or sets the radio group.</summary>
		public string RadioGroup
		{
			get
			{
				return this.GetAttribute("radiogroup");
			}

			set
			{
				this.AddAttribute("radiogroup", value);
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