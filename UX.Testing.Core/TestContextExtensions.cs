namespace UX.Testing.Core
{
	using System.Reflection;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	/// <summary>
	/// Helpers for MSTest TestContext on .NET, where DataSource/TestContext.DataRow is not available.
	/// </summary>
	public static class TestContextExtensions
	{
		/// <summary>Returns true when this is the first data-driven iteration, or when the test is not data-driven.</summary>
		public static bool IsFirstIteration(this TestContext context)
		{
			var dataRow = GetLegacyDataRow(context);
			if (dataRow == null)
			{
				return true;
			}

			var first = GetRowAt(dataRow, 0);
			return ReferenceEquals(dataRow, first);
		}

		/// <summary>Returns true when this is the last data-driven iteration, or when the test is not data-driven.</summary>
		public static bool IsLastIteration(this TestContext context)
		{
			var dataRow = GetLegacyDataRow(context);
			if (dataRow == null)
			{
				return true;
			}

			var count = GetRowCount(dataRow);
			var last = GetRowAt(dataRow, count - 1);
			return ReferenceEquals(dataRow, last);
		}

		/// <summary>Reads a named test parameter from TestContext.Properties or a legacy DataRow when present.</summary>
		public static string GetDataValue(this TestContext context, string name)
		{
			if (context?.Properties != null && context.Properties.Contains(name))
			{
				return context.Properties[name]?.ToString();
			}

			var dataRow = GetLegacyDataRow(context);
			if (dataRow != null)
			{
				var indexer = dataRow.GetType().GetProperty("Item", new[] { typeof(string) });
				var value = indexer?.GetValue(dataRow, new object[] { name });
				if (value != null)
				{
					return value.ToString();
				}
			}

			throw new AssertFailedException(
				string.Format(
					"The test parameter '{0}' was not found. On .NET 10 use [DataRow] or [DynamicData] method parameters instead of TestContext.DataRow.",
					name));
		}

		private static object GetLegacyDataRow(TestContext context)
		{
			return context?.GetType().GetProperty("DataRow")?.GetValue(context);
		}

		private static int GetRowCount(object dataRow)
		{
			var table = dataRow.GetType().GetProperty("Table")?.GetValue(dataRow);
			var rows = table?.GetType().GetProperty("Rows")?.GetValue(table);
			var count = rows?.GetType().GetProperty("Count")?.GetValue(rows);
			return count is int value ? value : 1;
		}

		private static object GetRowAt(object dataRow, int index)
		{
			var table = dataRow.GetType().GetProperty("Table")?.GetValue(dataRow);
			var rows = table?.GetType().GetProperty("Rows")?.GetValue(table);
			return rows?.GetType().GetProperty("Item", new[] { typeof(int) })?.GetValue(rows, new object[] { index });
		}
	}
}
