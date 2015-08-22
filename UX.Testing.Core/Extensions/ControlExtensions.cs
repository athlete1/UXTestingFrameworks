// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ControlExtensions.cs" company="">
//   
// </copyright>
// <summary>
//   The control extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UX.Testing.Core.Extensions
{
	using UX.Testing.Core.Controls;

	/// <summary>The control extensions.</summary>
	public static class ControlExtensions
	{
		#region Public Methods and Operators

		/// <summary>The focus.</summary>
		/// <param name="control">The control.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public static T Focus<T>(this T control) where T : HtmlControl
		{
			control.Browser.Focus(control);
			return control;
		}

		/// <summary>The mouse over.</summary>
		/// <param name="control">The control.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public static T MouseOver<T>(this T control) where T : HtmlControl
		{
			control.Browser.MouseOver(control);
			return control;
		}

		public static T MouseEnter<T>(this T control) where T : HtmlControl
		{
			control.Browser.MouseEnter(control);
			return control;
		}

		public static T MouseLeave<T>(this T control) where T : HtmlControl
		{
			control.Browser.MouseLeave(control);
			return control;
		}

		public static T MouseOut<T>(this T control) where T : HtmlControl
		{
			control.Browser.MouseOut(control);
			return control;
		}

		public static T MouseHover<T>(this T control) where T : HtmlControl
		{
			control.Browser.MouseHover(control);
			return control;
		}

		/// <summary>The scroll to middle.</summary>
		/// <param name="control">The control.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public static T ScrollToMiddle<T>(this T control) where T : HtmlControl
		{
			control.Browser.ScrollToMiddle(control);
			return control;
		}

		#endregion
	}
}