// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILogger.cs" company="">
//   
// </copyright>
// <summary>
//   The Logger interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UX.Testing.Core.Logging
{
	/// <summary>The Logger interface.</summary>
	public interface ILogger
	{
		#region Public Methods and Operators

		/// <summary>The debug.</summary>
		/// <param name="message">The message.</param>
		/// <param name="parameters">The parameters.</param>
		void Debug(string message, params object[] parameters);

		/// <summary>The error.</summary>
		/// <param name="message">The message.</param>
		/// <param name="parameters">The parameters.</param>
		void Error(string message, params object[] parameters);

		/// <summary>The fatal.</summary>
		/// <param name="message">The message.</param>
		/// <param name="parameters">The parameters.</param>
		void Fatal(string message, params object[] parameters);

		/// <param name="message">The message.</param>
		/// <param name="parameters">The parameters.</param>
		void Info(string message, params object[] parameters);

		/// <summary>The trace.</summary>
		/// <param name="message">The message.</param>
		/// <param name="parameters">The parameters.</param>
		void Trace(string message, params object[] parameters);

		/// <summary>The warn.</summary>
		/// <param name="message">The message.</param>
		/// <param name="parameters">The parameters.</param>
		void Warn(string message, params object[] parameters);

		#endregion
	}
}