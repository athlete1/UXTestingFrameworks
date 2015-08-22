// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlKeygen.cs" company="">
//   
// </copyright>
// <summary>
//   The html div.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	/// <summary>The html div.</summary>
	public class HtmlKeygen : HtmlControl
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

		/// <summary>Gets or sets Challenge.</summary>
		public string Challenge
		{
			get
			{
				return this.GetAttribute("challenge");
			}

			set
			{
				this.AddAttribute("challenge", value);
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
				return HtmlTag.keygen;
			}
		}

		/// <summary>Gets or sets KeyType.</summary>
		public string KeyType
		{
			get
			{
				return this.GetAttribute("keytype");
			}

			set
			{
				this.AddAttribute("keytype", value);
			}
		}

		#endregion
	}
}