// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFindsById.cs" company="">
//   
// </copyright>
// <summary>
//   The FindsById interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UX.Testing.Core
{
	using System.Collections.ObjectModel;

	using UX.Testing.Core.Controls;

	/// <summary>The FindsById interface.</summary>
	public interface IFindsById
	{
		#region Public Methods and Operators

		/// <summary>The find element by id.</summary>
		/// <param name="id">The id.</param>
		/// <returns>The <see cref="HtmlControl"/>.</returns>
		HtmlControl FindControlById(string id, HtmlControl parentControl = null);

		/// <summary>The find elements by id.</summary>
		/// <param name="id">The id.</param>
		/// <returns>The <see cref="ReadOnlyCollection"/>.</returns>
		ReadOnlyCollection<HtmlControl> FindControlsById(string id, HtmlControl parentControl = null);

		#endregion
	}
}