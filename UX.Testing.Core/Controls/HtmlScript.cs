// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlScript.cs" company="">
//   
// </copyright>
// <summary>
//   The html div.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	/// <summary>The html div.</summary>
	public class HtmlScript : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets or sets Async.</summary>
		public string Async
		{
			get
			{
				return this.GetAttribute("async");
			}

			set
			{
				this.AddAttribute("async", value);
			}
		}

		/// <summary>Gets or sets CharSet.</summary>
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

		/// <summary>Gets or sets Defer.</summary>
		public string Defer
		{
			get
			{
				return this.GetAttribute("defer");
			}

			set
			{
				this.AddAttribute("defer", value);
			}
		}

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.script;
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

		/// <summary>Gets or sets XmlSpace.</summary>
		public string XmlSpace
		{
			get
			{
				return this.GetAttribute("xmlspace");
			}

			set
			{
				this.AddAttribute("xmlspace", value);
			}
		}

		#endregion
	}
}