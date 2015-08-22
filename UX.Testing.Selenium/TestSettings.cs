// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Settings.cs" company="">
//   
// </copyright>
// <summary>
//   The settings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Selenium
{
	using System.Configuration;

	/// <summary>The settings.</summary>
	public class TestSettings : ConfigurationSection
	{
		public static TestSettings Instance
		{
			get
			{
				return (TestSettings)ConfigurationManager.GetSection("seleniumTestSettings");
			}
		}

		[ConfigurationProperty("commandTimeout", DefaultValue = 60000, IsRequired = false)]
		public int CommandTimeout
		{
			get
			{
				int timeout;
				var timeoutSetting = ConfigurationManager.AppSettings["CommandTimeout"];
				if (!string.IsNullOrEmpty(timeoutSetting) && int.TryParse(timeoutSetting, out timeout))
				{
					return timeout;
				}

				return (int)this["commandTimeout"];
			}

			set
			{
				this["commandTimeout"] = value;
			}
		}
	}
}