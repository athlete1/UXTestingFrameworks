// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidAttributeException.cs" company="">
//   
// </copyright>
// <summary>
//   The invalid attribute exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core
{
	using System;

	/// <summary>The invalid attribute exception.</summary>
	public class InvalidAttributeException : Exception
	{
		/// <summary>Initializes a new instance of the <see cref="InvalidAttributeException"/> class.</summary>
		public InvalidAttributeException()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="InvalidAttributeException"/> class.</summary>
		/// <param name="message">The message.</param>
		public InvalidAttributeException(string message)
			: base(message)
		{
		}
	}
}