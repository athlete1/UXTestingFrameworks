// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlMap.cs" company="">
//   
// </copyright>
// <summary>
//   The html div.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	/// <summary>The html div.</summary>
	public class HtmlMap : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.map;
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

		#endregion
	}
}