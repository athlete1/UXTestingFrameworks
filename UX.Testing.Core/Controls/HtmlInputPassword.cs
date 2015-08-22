// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlInputPassword.cs" company="">
//   
// </copyright>
// <summary>
//   The html input password.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	/// <summary>The html input password.</summary>
	public class HtmlInputPassword : HtmlInput
	{
		#region Constructors and Destructors

		/// <summary>Initializes a new instance of the <see cref="HtmlInputPassword"/> class.</summary>
		public HtmlInputPassword()
			: base(InputType.Password)
		{
		}

		#endregion
	}
}