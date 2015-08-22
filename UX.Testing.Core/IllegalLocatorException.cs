using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UX.Testing.Core
{
	[Serializable]
	public class IllegalLocatorException : Exception
	{
		/// <summary>Initializes a new instance of the <see cref="CustomerNotFoundException"/> class.</summary>
		public IllegalLocatorException()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="CustomerNotFoundException"/> class.</summary>
		/// <param name="message">The message.</param>
		public IllegalLocatorException(string message)
			: base(message)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="CustomerNotFoundException"/> class.</summary>
		/// <param name="message">The message.</param>
		/// <param name="innerException">The inner exception.</param>
		public IllegalLocatorException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
