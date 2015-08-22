// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoteNlogHelper.cs" company="">
//   
// </copyright>
// <summary>
//   The remote nlog helper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UX.Testing.Core.Logging
{
	using System.Configuration;

	using NLog;
	using NLog.Config;
	using NLog.Targets;

	/// <summary>The remote nlog helper.</summary>
	public class RemoteNlogHelper
	{
		/// <summary>The target ip.</summary>
		private string targetIP;

		/// <summary>Initializes a new instance of the <see cref="RemoteNlogHelper"/> class.</summary>
		public RemoteNlogHelper()
		{
			this.targetIP = ConfigurationManager.AppSettings["RemoteAgentLoggingIP"];
		}

		/// <summary>The enable remote udp logger.</summary>
		public void EnableRemoteUDPLogger()
		{
			if (string.IsNullOrWhiteSpace(this.targetIP))
			{
				return;
			}

			var config = LogManager.Configuration;

			var consoleTarget = new NLogViewerTarget
									{
										Name = "RemoteLog2Console", 
										Address = string.Format("udp://{0}:7071", this.targetIP), 
										Layout = "${event-context:item=messageType} ${longdate} | ${level:uppercase=true} | ${stacktrace} | ${message}"
									};

			config.AddTarget("RemoteLog2Console", consoleTarget);

			// <logger name="*" minlevel="Trace" writeTo="JRLog2Console" />
			config.LoggingRules.Add(new LoggingRule("*", LogLevel.Trace, consoleTarget));

			LogManager.Configuration = config;
		}
	}
}