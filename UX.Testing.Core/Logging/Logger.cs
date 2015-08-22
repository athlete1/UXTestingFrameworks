// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Logger.cs" company="">
//   
// </copyright>
// <summary>
//   The logger.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Logging
{
	using System;
	using System.Diagnostics;

	using NLog;

	/// <summary>The logger.</summary>
	public class Logger : ILogger
	{
		#region Fields

		/// <summary>The nlogger.</summary>
		private NLog.Logger nlogger;

		/// <summary>The instance.</summary>
		private static Logger instance;

		#endregion

		#region Constructors and Destructors

		/// <summary>Initializes a new instance of the <see cref="Logger"/> class.</summary>
		public Logger()
		{
			this.nlogger = LogManager.GetCurrentClassLogger();
		}

		#endregion

		/// <summary>Gets the instance.</summary>
		public static Logger Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new Logger();
				}

				return instance;
			}
		}

		#region Public Properties

		/// <summary>Gets or sets Logger.</summary>
		public NLog.Logger Nlogger
		{
			get
			{
				return this.nlogger;
			}

			set
			{
				this.nlogger = value;
			}
		}

		#endregion

		#region Public Methods and Operators

		/// <summary>The GetMethodInfo method that gathers DeclaringType.Name and Method.Name.</summary>
		private static string GetMethodInfo()
		{
			var method = new StackFrame(2, true).GetMethod();
			var callingProgram = string.Format(
				"{0}.{1}", method.DeclaringType.Name, method.Name);
			return callingProgram;
		}

		/// <summary>The debug.</summary>
		/// <param name="message">The message.</param>
		/// <param name="parameters">The parameters.</param>
		public void Debug(string message, params object[] parameters)
		{
			var callingProgram = GetMethodInfo();

			var msg = string.Format("DEBUG {0}: {1}", callingProgram, message);
			this.nlogger.Debug(msg, parameters);
			
			if (TestSettings.Instance.DisableDiagnosticLogging)
			{
				return;
			}

			try
			{
				System.Diagnostics.Trace.TraceInformation(msg, parameters);
			}
			catch
			{
			}
		}

		/// <summary>The error.</summary>
		/// <param name="message">The message.</param>
		/// <param name="parameters">The parameters.</param>
		public void Error(string message, params object[] parameters)
		{
			var callingProgram = GetMethodInfo();

			var msg = string.Format("ERROR {0}: {1}", callingProgram, message);
			this.nlogger.Error(msg, parameters);

			if (TestSettings.Instance.DisableDiagnosticLogging)
			{
				return;
			}

			try
			{
				System.Diagnostics.Trace.TraceError(msg, parameters);
			}
			catch 
			{
			}
		}

		/// <summary>The fatal.</summary>
		/// <param name="message">The message.</param>
		/// <param name="parameters">The parameters.</param>
		public void Fatal(string message, params object[] parameters)
		{
			var callingProgram = GetMethodInfo();

			var msg = string.Format("FATAL {0}: {1}", callingProgram, message);
			this.nlogger.Fatal(msg, parameters);

			if (TestSettings.Instance.DisableDiagnosticLogging)
			{
				return;
			}

			try
			{
				System.Diagnostics.Trace.TraceError(msg, parameters);
			}
			catch 
			{
			}
		}

		/// <summary>The info.</summary>
		/// <param name="message">The message.</param>
		/// <param name="parameters">The parameters.</param>
		public void Info(string message, params object[] parameters)
		{
			var callingProgram = GetMethodInfo();

			var msg = string.Format("INFO {0}: {1}", callingProgram, message);

			this.nlogger.Info(msg, parameters);

			if (TestSettings.Instance.DisableDiagnosticLogging)
			{
				return;
			}

			try
			{
				System.Diagnostics.Trace.TraceInformation(msg, parameters);
			}
			catch 
			{
			}
		}

		/// <summary>The trace.</summary>
		/// <param name="message">The message.</param>
		/// <param name="parameters">The parameters.</param>
		public void Trace(string message, params object[] parameters)
		{
			var callingProgram = GetMethodInfo();

			var msg = string.Format("TRACE {0}: {1}", callingProgram, message);
			this.nlogger.Trace(msg, parameters);

			if (TestSettings.Instance.DisableDiagnosticLogging)
			{
				return;
			}

			try
			{
				System.Diagnostics.Trace.TraceInformation(msg, parameters);
			}
			catch
			{
			}
		}

		/// <summary>The warn.</summary>
		/// <param name="message">The message.</param>
		/// <param name="parameters">The parameters.</param>
		public void Warn(string message, params object[] parameters)
		{
			var callingProgram = GetMethodInfo();

			var msg = string.Format("WARNING {0}: {1}", callingProgram, message);
			this.nlogger.Warn(msg, parameters);

			if (TestSettings.Instance.DisableDiagnosticLogging)
			{
				return;
			}

			try
			{
				System.Diagnostics.Trace.TraceWarning(msg, parameters);
			}
			catch 
			{
			}
		}

		#endregion
	}
}