namespace UX.Testing.Core
{
	using System;
	using System.Configuration;
	using System.IO;
	using System.Linq;

	/// <summary>
	/// Loads App.config sections on .NET, including when tests run under testhost.
	/// </summary>
	public static class ConfigurationHelper
	{
		private static readonly object Sync = new object();
		private static Configuration mappedConfiguration;
		private static bool initialized;

		public static T GetSection<T>(string sectionName)
			where T : ConfigurationSection
		{
			EnsureMappedConfiguration();

			var section = ConfigurationManager.GetSection(sectionName) as T;
			if (section != null)
			{
				return section;
			}

			return mappedConfiguration?.GetSection(sectionName) as T;
		}

		public static string GetAppSetting(string key)
		{
			EnsureMappedConfiguration();

			var value = ConfigurationManager.AppSettings[key];
			if (!string.IsNullOrEmpty(value))
			{
				return value;
			}

			return mappedConfiguration?.AppSettings.Settings[key]?.Value;
		}

		private static void EnsureMappedConfiguration()
		{
			if (initialized)
			{
				return;
			}

			lock (Sync)
			{
				if (initialized)
				{
					return;
				}

				var configPath = FindConfigFile();
				if (configPath != null)
				{
					var map = new ExeConfigurationFileMap { ExeConfigFilename = configPath };
					mappedConfiguration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
				}

				initialized = true;
			}
		}

		private static string FindConfigFile()
		{
			var baseDir = AppContext.BaseDirectory;
			if (!Directory.Exists(baseDir))
			{
				return null;
			}

			var candidates = Directory.GetFiles(baseDir, "*.dll.config")
				.Concat(Directory.GetFiles(baseDir, "*.exe.config"));

			return candidates.FirstOrDefault(path =>
			{
				try
				{
					return File.ReadAllText(path).IndexOf("testSettings", StringComparison.OrdinalIgnoreCase) >= 0;
				}
				catch
				{
					return false;
				}
			});
		}
	}
}
