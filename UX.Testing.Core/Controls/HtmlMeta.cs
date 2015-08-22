// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlMeta.cs" company="">
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
	public class HtmlMeta : HtmlControl
	{
		#region Public Properties

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

		/// <summary>Gets or sets Content.</summary>
		public string Content
		{
			get
			{
				return this.GetAttribute("content");
			}

			set
			{
				this.AddAttribute("content", value);
			}
		}

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.meta;
			}
		}

		/// <summary>Gets or sets HttpEquiv.</summary>
		public string HttpEquiv
		{
			get
			{
				return this.GetAttribute("httpequiv");
			}

			set
			{
				this.AddAttribute("httpequiv", value);
			}
		}

		/// <summary>Gets or sets Name.</summary>
		public string Name
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

		/// <summary>Gets or sets Scheme.</summary>
		[Obsolete("Not supported in HTML5")]
		public string Scheme
		{
			get
			{
				return this.GetAttribute("scheme");
			}

			set
			{
				this.AddAttribute("scheme", value);
			}
		}

		#endregion
	}
}