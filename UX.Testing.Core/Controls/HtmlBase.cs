// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlBase.cs" company="">
//   
// </copyright>
// <summary>
//   The html div.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	/// <summary>The html div.</summary>
	public class HtmlBase : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets or sets the href.</summary>
		public string Href { get; set; }

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.@base;
			}
		}

		/// <summary>Gets or sets the target.</summary>
		public string Target { get; set; }

		#endregion
	}
}