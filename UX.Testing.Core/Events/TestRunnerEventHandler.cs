using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UX.Testing.Core.Events
{
	public static class TestRunnerEventHandler
	{
		public static EventHandler<TestRunnerEventArgs> TestRunnerExceptionOccured;
	}
}
