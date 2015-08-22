// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestStep.cs" company="">
//   
// </copyright>
// <summary>
//   TODO: Update summary.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Attributes
{
	using System;

	/// <summary>Custom Property to set which methods on a class can be used as a cleanup step per test.</summary>
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
	public sealed class CleanupStep : Attribute
	{
		#region Fields

		/// <summary>The test name.</summary>
		private string name;

		/// <summary>The step number.</summary>
		private int stepNumber;

		#endregion

		#region Constructors and Destructors

		/// <summary>Initializes a new instance of the <see cref="TestStep"/> class.</summary>
		/// <param name="name">The name of the test.</param>
		/// <param name="stepNumber">The step number.</param>
		public CleanupStep(string name, int stepNumber)
		{
			this.name = name;
			this.stepNumber = stepNumber;
		}

		/// <summary>Initializes a new instance of the <see cref="TestStep"/> class.</summary>
		/// <param name="name">The name of the test.</param>
		public CleanupStep(string name)
			: this(name, int.MaxValue)
		{
		}

		#endregion

		#region Public Properties

		/// <summary>Gets the step number.</summary>
		public int StepNumber
		{
			get
			{
				return this.stepNumber;
			}
		}

		/// <summary>Gets the test Name.</summary>
		/// <value>The test Name.</value>
		public string TestName
		{
			get
			{
				return this.name;
			}
		}

		#endregion
	}
}