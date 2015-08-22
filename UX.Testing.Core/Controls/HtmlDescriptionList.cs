// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlDescriptionList.cs" company="">
//   
// </copyright>
// <summary>
//   The html div.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	using System.Collections.Generic;

	/// <summary>The html div.</summary>
	public class HtmlDescriptionList : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.dl;
			}
		}

		public IEnumerable<HtmlDescriptionTerm> Terms
		{
			get
			{
				return this.FindAll<HtmlDescriptionTerm>();
			}
		}

		#endregion
	}
}