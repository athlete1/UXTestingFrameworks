// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestRunner.cs" company="">
//   
// </copyright>
// <summary>
//   The feature test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Reflection;

	using UX.Testing.Core.Events;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using UX.Testing.Core.Attributes;
	using UX.Testing.Core.Logging;

	/// <summary>The feature test.</summary>
	/// <typeparam name="T">The test class.</typeparam>
	public class TestRunner<T>
		where T : class
	{
		#region Fields

		/// <summary>The on executing steps.</summary>
		public EventHandler OnExecutingSteps;

		/// <summary>The base instance.</summary>
		private readonly T baseInstance;

		/// <summary>The test name.</summary>
		private readonly string testName;

		/// <summary>The errors occured.</summary>
		private bool errorsOccured;

		/// <summary>The logger.</summary>
		private ILogger logger;

		/// <summary>The stop on error.</summary>
		private bool stopOnError;

		#endregion

		#region Constructors and Destructors

		/// <summary>Initializes a new instance of the <see cref="TestRunner{T}"/> class.</summary>
		/// <param name="baseInstance">The base instance.</param>
		/// <param name="testName">The test name.</param>
		public TestRunner(T baseInstance, string testName)
			: this(baseInstance, testName, true)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="TestRunner{T}"/> class.</summary>
		/// <param name="baseInstance">The base instance.</param>
		/// <param name="testName">The test name.</param>
		/// <param name="stopOnError">The stop on error.</param>
		public TestRunner(T baseInstance, string testName, bool stopOnError)
		{
			this.logger = new Logger();
			this.testName = testName;
			this.baseInstance = baseInstance;
			this.stopOnError = stopOnError;
		}

		#endregion

		#region Public Properties

		/// <summary>Gets a value indicating whether errors occured.</summary>
		public bool ErrorsOccured
		{
			get
			{
				return this.errorsOccured;
			}
		}

		/// <summary>Gets the logger.</summary>
		public ILogger Logger
		{
			get
			{
				return this.logger;
			}
		}

		#endregion

		#region Public Methods and Operators

		/// <summary>The execute steps.</summary>
		/// <param name="aobjParams">The aobj params.</param>
		/// <exception cref="AssertFailedException">Thrown at the end of execution if an error occurred.</exception>
		public void ExecuteSteps(params object[] aobjParams)
		{
			if (this.OnExecutingSteps != null)
			{
				this.OnExecutingSteps(null, null);
			}

			this.errorsOccured = false;
			var type = this.baseInstance.GetType();

			var methods = type.GetMethods();

			var attrMethodMap = new List<KeyValuePair<TestStep, MethodInfo>>();

			foreach (var method in methods)
			{
				foreach (var step in Attribute.GetCustomAttributes(method, typeof(TestStep), false).Where(p => ((TestStep)p).TestName == this.testName))
				{
					attrMethodMap.Add(new KeyValuePair<TestStep, MethodInfo>((TestStep)step, method));
				}
			}

			var currentStep = string.Empty;

			try
			{
				foreach (var kv in attrMethodMap.OrderBy(p => p.Key.StepNumber))
				{
					var stopwatch = new Stopwatch();
					stopwatch.Start();
					try
					{
						currentStep = kv.Key.StepNumber.ToString();
						this.logger.Info("Running STEP {0} - {1}.{2}", (int)kv.Key.StepNumber, this.testName, kv.Value.Name);
						this.RunInstanceMethod(type, (int)kv.Key.StepNumber, kv.Value.Name, this.baseInstance, aobjParams);
					}
					finally
					{
						stopwatch.Stop();
						this.logger.Info(
							"Completed STEP {0} - {1}.{2} - [RUNTIME: {3}]", 
							(int)kv.Key.StepNumber, 
							this.testName, 
							kv.Value.Name, 
							stopwatch.Elapsed.TotalMilliseconds);
					}
				}
			}
			catch (Exception)
			{
				// this.OnTestRunnerExceptionOccured("Step" + currentStep);
				this.ExecuteCleanUpSteps(aobjParams);
				throw;
			}
			
			this.ExecuteCleanUpSteps(aobjParams);

			if (this.ErrorsOccured)
			{
				// this.OnTestRunnerExceptionOccured(null);
				throw new AssertFailedException();
			}
		}

		#endregion

		#region Methods

		private void ExecuteCleanUpSteps(params object[] aobjParams)
		{
			if (this.OnExecutingSteps != null)
			{
				this.OnExecutingSteps(null, null);
			}

			var type = this.baseInstance.GetType();

			var methods = type.GetMethods();

			var attrMethodMap = new List<KeyValuePair<CleanupStep, MethodInfo>>();

			foreach (var method in methods)
			{
				foreach (var step in Attribute.GetCustomAttributes(method, typeof(CleanupStep), false).Where(p => ((CleanupStep)p).TestName == this.testName))
				{
					attrMethodMap.Add(new KeyValuePair<CleanupStep, MethodInfo>((CleanupStep)step, method));
				}
			}

			foreach (var kv in attrMethodMap.OrderBy(p => p.Key.StepNumber))
			{
				var stopwatch = new Stopwatch();
				stopwatch.Start();
				try
				{
					this.logger.Info("Running CLEANUP STEP {0} - {1}.{2}", (int)kv.Key.StepNumber, this.testName, kv.Value.Name);
					this.RunInstanceMethod(type, (int)kv.Key.StepNumber, kv.Value.Name, this.baseInstance, aobjParams);
				}
				finally
				{
					stopwatch.Stop();
					this.logger.Info(
						"Completed CLEANUP STEP {0} - {1}.{2} - [RUNTIME: {3}]",
						(int)kv.Key.StepNumber,
						this.testName,
						kv.Value.Name,
						stopwatch.Elapsed.TotalMilliseconds);
				}
			}
		}

		/// <summary>The run instance method.</summary>
		/// <param name="t">The t.</param>
		/// <param name="strMethod">The str method.</param>
		/// <param name="objInstance">The obj instance.</param>
		/// <param name="aobjParams">The aobj params.</param>
		/// <returns>The <see cref="object"/>.</returns>
		private object RunInstanceMethod(Type t, int currentStep, string strMethod, object objInstance, object[] aobjParams)
		{
			return this.RunMethod(
				t, currentStep, strMethod, objInstance, aobjParams, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		}

		/// <summary>The run method.</summary>
		/// <param name="t">The t.</param>
		/// <param name="strMethod">The str method.</param>
		/// <param name="objInstance">The obj instance.</param>
		/// <param name="aobjParams">The aobj params.</param>
		/// <param name="flags">The flags.</param>
		/// <returns>The <see cref="object"/>.</returns>
		/// <exception cref="ArgumentException">Thrown if method not found in type.</exception>
		private object RunMethod(Type t, int currentStep, string strMethod, object objInstance, object[] aobjParams, BindingFlags flags)
		{
			MethodInfo method = t.GetMethod(strMethod, flags);
			if (method == null)
			{
				throw new ArgumentException("There is no method '" + strMethod + "' for type '" + t + "'.");
			}

			bool handledParams = false;
			var parameters = method.GetParameters();
			object[] methodParams = null;

			if (parameters.Length == 1 && parameters[0].ParameterType == typeof(object[]))
			{
				methodParams = new object[] { aobjParams };
				handledParams = true;
			}
			else if (parameters.Length > 0)
			{
				methodParams = aobjParams;
			}

			try
			{
				if (methodParams != null && !handledParams)
				{
					if (parameters.Length != methodParams.Length)
					{
						throw new TargetParameterCountException(
							string.Format("Expected {0} parameters, got {1} parameters.", parameters.Length, methodParams.Length));
					}

					for (int i = 0; i < parameters.Length; i++)
					{
						if (parameters[i].ParameterType != methodParams[i].GetType())
						{
							throw new ArgumentException(
								string.Format("Expected type {0}, got type {1}.", parameters[i].ParameterType, methodParams[i].GetType()));
						}
					}
				}

				object objRet = method.Invoke(objInstance, methodParams);
				return objRet;
			}
			catch (TargetInvocationException ex)
			{
				if (ex.InnerException != null)
				{
					this.logger.Error(ex.InnerException.Message + "\r\n" + ex.InnerException.StackTrace);
					this.OnTestRunnerExceptionOccured("Step" + currentStep);
					if (this.stopOnError)
					{
						throw ex.InnerException;
					}
				}

				this.errorsOccured = true;
			}
			catch (Exception ex)
			{
				this.logger.Error(ex.Message + "\r\n" + ex.StackTrace);
				throw;
			}

			return null;
		}

		#endregion

		private void OnTestRunnerExceptionOccured(string data)
		{
			if (TestRunnerEventHandler.TestRunnerExceptionOccured != null)
			{
				TestRunnerEventHandler.TestRunnerExceptionOccured(null, new TestRunnerEventArgs(data));
			}
		}

	}
}