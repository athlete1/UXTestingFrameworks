using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UX.Testing.Core.Extensions
{
	using System.Diagnostics;

	using UX.Testing.Core.Controls;
	using UX.Testing.Core.Logging;

	/// <summary>The view base extensions.</summary>
	public static class ViewBaseExtensions
	{
		/// <summary>The wait for condition.</summary>
		/// <param name="viewBase">The view base.</param>
		/// <param name="condition">The condition.</param>
		/// <typeparam name="T">The type.</typeparam>
		/// <returns>The <see cref="bool"/>.</returns>
		public static bool WaitForCondition<T>(this T viewBase, Func<T, bool> condition) where T : ViewBase
		{
			return viewBase.WaitForCondition(condition, viewBase.Timeout, viewBase.Interval);
		}

		/// <summary>The wait for null element.</summary>
		/// <param name="viewBase">The view base.</param>
		/// <param name="htmlControl">The html control.</param>
		/// <typeparam name="T">The type.</typeparam>
		/// <returns>The <see cref="bool"/>.</returns>
		public static bool WaitForNullElement<T>(this T viewBase, Func<T, HtmlControl> htmlControl) where T : ViewBase
		{
			var originalRetry = viewBase.Retry;
			viewBase.Retry = false;
			var returnValue = viewBase.WaitForCondition(vb => htmlControl(vb) == null, viewBase.Timeout, viewBase.Interval);
			viewBase.Retry = originalRetry;
			return returnValue;
		}

		/// <summary>The wait for condition.</summary>
		/// <param name="viewBase">The view base.</param>
		/// <param name="condition">The condition.</param>
		/// <param name="timeout">The timeout.</param>
		/// <param name="interval">The interval.</param>
		/// <typeparam name="T">The ViewBase.</typeparam>
		/// <returns>The <see cref="bool"/>.</returns>
		public static bool WaitForCondition<T>(this T viewBase, Func<T, bool> condition, int timeout, int interval) where T : ViewBase
		{
			var logger = new Logger();
			var stopwatch = new Stopwatch();
			stopwatch.Start();

			try
			{
				if (TestSettings.Instance.Debug)
				{
					logger.Debug("WaitForCondition STARTED");
				}

				var timeoutWait = timeout;
				while (timeoutWait > 0 && !condition(viewBase))
				{
					viewBase.Wait(interval, timeout);
					timeoutWait -= interval;
				}
			}
			finally
			{
				stopwatch.Stop();
				if (TestSettings.Instance.Debug)
				{
					logger.Debug("WaitForCondition COMPLETED - [RUNTIME: {0}]", stopwatch.Elapsed.TotalMilliseconds);
				}
			}

			return condition(viewBase);
		}
	}
}
