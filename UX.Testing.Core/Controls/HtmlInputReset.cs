﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlInputSubmit.cs" company="">
//   
// </copyright>
// <summary>
//   The html input submit.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	/// <summary>The html input submit.</summary>
	public class HtmlInputReset : HtmlInput
	{
		#region Constructors and Destructors

		/// <summary>Initializes a new instance of the <see cref="HtmlInputSubmit"/> class.</summary>
		public HtmlInputReset()
			: base(InputType.Reset)
		{
		}

		#endregion
	}
}