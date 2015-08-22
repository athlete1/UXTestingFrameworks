// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestRunnerEventArgs.cs" company="">
//   
// </copyright>
// <summary>
//   The test runner event args.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UX.Testing.Core.Events
{
	using System;

	/// <summary>The test runner event args.</summary>
	public class TestRunnerEventArgs : EventArgs
	{
		#region Constructors and Destructors

		/// <summary>Initializes a new instance of the <see cref="TestRunnerEventArgs"/> class.</summary>
		/// <param name="data">The data.</param>
		public TestRunnerEventArgs(string data)
		{
			this.Data = data;
		}

		#endregion

		#region Public Properties

		/// <summary>Gets or sets the data.</summary>
		public string Data { get; set; }

		#endregion
	}
}