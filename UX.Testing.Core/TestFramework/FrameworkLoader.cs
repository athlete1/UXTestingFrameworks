// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FrameworkLoader.cs" company="">
//   
// </copyright>
// <summary>
//   The framework loader.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.TestFramework
{
	using System;
	using System.Reflection;

	/// <summary>The framework loader.</summary>
	public static class FrameworkLoader
	{
		#region Public Methods and Operators

		/// <summary>The get initialized framework instance.</summary>
		/// <returns>The <see cref="ITestingFramework"/>.</returns>
		public static ITestingFramework GetInitializedFrameworkInstance()
		{
			var testSettings = TestSettings.Instance;
			var frameworkInstance = LoadFrameworkInstance(testSettings.Provider.Assembly, testSettings.Provider.Type);
			frameworkInstance.Initialize(testSettings.Browser, testSettings.BaseUrl);
			return frameworkInstance;
		}

		#endregion

		#region Methods

		/// <summary>The load framework instance.</summary>
		/// <param name="assembly">The assembly.</param>
		/// <param name="type">The type.</param>
		/// <returns>The <see cref="ITestingFramework"/>.</returns>
		/// <exception cref="TypeLoadException"></exception>
		internal static ITestingFramework LoadFrameworkInstance(string assembly, string type)
		{
			var dll = Assembly.Load(assembly);
			var assemblyType = dll.GetType(type);
			if (assemblyType != null)
			{
				var argTypes = new Type[] { };

				ConstructorInfo constructorInfo = assemblyType.GetConstructor(argTypes);

				ITestingFramework service = null;
				if (constructorInfo != null)
				{
					service = constructorInfo.Invoke(null) as ITestingFramework;
				}

				return service;
			}

			throw new TypeLoadException("Type not found: " + type);
		}

		#endregion
	}
}