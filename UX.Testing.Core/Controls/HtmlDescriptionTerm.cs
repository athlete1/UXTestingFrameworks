// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlDescriptionTerm.cs" company="">
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
	public class HtmlDescriptionTerm : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.dt;
			}
		}

		public IEnumerable<HtmlDescriptionDefinition> Definitions
		{
			get
			{
				return this.FindAll<HtmlDescriptionDefinition>();
			}
		}

		#endregion
	}
}