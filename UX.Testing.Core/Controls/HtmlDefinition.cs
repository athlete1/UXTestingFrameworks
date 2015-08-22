// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlDefinition.cs" company="">
//   
// </copyright>
// <summary>
//   The html div.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	/// <summary>The html div.</summary>
	public class HtmlDefinition : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.dfn;
			}
		}

		#endregion
	}
}