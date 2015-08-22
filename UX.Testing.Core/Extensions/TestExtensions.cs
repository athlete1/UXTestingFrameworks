// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestExtensions.cs" company="">
//   
// </copyright>
// <summary>
//   The test extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Extensions
{
	using System;
	using System.Collections;
	using System.Diagnostics;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	/// <summary>The test extensions.</summary>
	[DebuggerStepThrough]
	public static class TestExtensions
	{
		#region Public Methods and Operators

		/// <summary>Asserts that two strings are equal, without regard to case. </summary>
		/// <param name="expected">The expected string.</param>
		/// <param name="actual">The actual string.</param>
		public static void AreEqualIgnoringCase(string expected, string actual)
		{
			AreEqualIgnoringCase(expected, actual, "Expected <{0}> but actual was <{1}>.", expected, actual);
		}

		/// <summary>Asserts that two strings are equal, without regard to case. </summary>
		/// <param name="expected">The expected string.</param>
		/// <param name="actual">The actual string.</param>
		/// <param name="message">A message to display. This message can be seen in the unit test results.</param>
		/// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
		public static void AreEqualIgnoringCase(string expected, string actual, string message, params object[] parameters)
		{
			Assert.IsTrue(string.Compare(expected, actual, StringComparison.CurrentCultureIgnoreCase) == 0, message, parameters);
		}

		/// <summary>The cast to.</summary>
		/// <param name="source">The source.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public static T CastTo<T>(this object source)
		{
			return (T)source;
		}

		/// <summary>Assert that an array, list or other collection is empty.</summary>
		/// <param name="collection">The value to be tested.</param>
		public static void IsEmpty(ICollection collection)
		{
			IsEmpty(collection, "Expected a collection containing <0> items but actual was <{0}> items.", 0, collection.Count);
		}

		/// <summary>Assert that an array, list or other collection is empty.</summary>
		/// <param name="collection">The value to be tested.</param>
		/// <param name="message">A message to display. This message can be seen in the unit test results.</param>
		public static void IsEmpty(ICollection collection, string message)
		{
			IsEmpty(collection, message, null);
		}

		/// <summary>Assert that an array, list or other collection is empty.</summary>
		/// <param name="collection">The value to be tested.</param>
		/// <param name="message">A message to display. This message can be seen in the unit test results.</param>
		/// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
		public static void IsEmpty(ICollection collection, string message, params object[] parameters)
		{
			Assert.IsTrue(collection.Count == 0, message, parameters);
		}

		/// <summary>Asserts that a string is empty.</summary>
		/// <param name="value">The value to be tested.</param>
		public static void IsEmpty(string value)
		{
			IsEmpty(value, "Expected <{0}> but actual was <{1}>.", string.Empty, value);
		}

		/// <summary>Asserts that a string is empty.</summary>
		/// <param name="value">The value to be tested.</param>
		/// <param name="message">A message to display. This message can be seen in the unit test results.</param>
		/// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
		public static void IsEmpty(string value, string message, params object[] parameters)
		{
			Assert.IsTrue(value.Length == 0, message, parameters);
		}

		/// <summary>Assert that an array, list or other collection is not empty.</summary>
		/// <param name="collection">The value to be tested.</param>
		public static void IsNotEmpty(ICollection collection)
		{
			IsNotEmpty(collection, "Expected a collection containing <0> items but actual was <{0}> items.", collection.Count, 0);
		}

		/// <summary>Assert that an array, list or other collection is not empty.</summary>
		/// <param name="collection">The value to be tested.</param>
		/// <param name="message">A message to display. This message can be seen in the unit test results.</param>
		/// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
		public static void IsNotEmpty(ICollection collection, string message, params object[] parameters)
		{
			Assert.IsFalse(collection.Count == 0, message, parameters);
		}

		/// <summary>Asserts that a string is not empty.</summary>
		/// <param name="value">The value to be tested.</param>
		public static void IsNotEmpty(string value)
		{
			IsNotEmpty(value, "Expected <{0}> but actual was <{1}>.", value, string.Empty);
		}

		/// <summary>Asserts that a string is not empty.</summary>
		/// <param name="value">The value to be tested.</param>
		/// <param name="message">A message to display. This message can be seen in the unit test results.</param>
		/// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
		public static void IsNotEmpty(string value, string message, params object[] parameters)
		{
			Assert.IsFalse(value.Length == 0, message, parameters);
		}

		/// <summary>The should be.</summary>
		/// <param name="actual">The actual.</param>
		/// <typeparam name="T"></typeparam>
		public static void ShouldBe<T>(this object actual)
		{
			Assert.IsInstanceOfType(actual, typeof(T));
		}

		/// <summary>The should be.</summary>
		/// <param name="actual">The actual.</param>
		/// <param name="message"></param>
		/// <param name="parameters"></param>
		/// <typeparam name="T"></typeparam>
		public static void ShouldBe<T>(this object actual, string message, params object[] parameters)
		{
			Assert.IsInstanceOfType(actual, typeof(T), message, parameters);
		}

		/// <summary>The should be false verifies that the specified condition is false.</summary>
		/// <param name="source">The source.</param>
		public static void ShouldBeFalse(this bool source)
		{
			Assert.IsFalse(source);
		}

		/// <summary>The should be false.</summary>
		/// <param name="source">The source.</param>
		/// <param name="message">The message.</param>
		/// <param name="parameters">The parameters.</param>
		public static void ShouldBeFalse(this bool source, string message, params object[] parameters)
		{
			Assert.IsFalse(source, message, parameters);
		}

		/// <summary>The should be null.</summary>
		/// <param name="actual">The actual.</param>
		public static void ShouldBeNull(this object actual)
		{
			Assert.IsNull(actual);
		}

		/// <summary>The should be null.</summary>
		/// <param name="actual">The actual.</param>
		/// <param name="message">The message.</param>
		/// <param name="parameters">The parameters.</param>
		public static void ShouldBeNull(this object actual, string message, params object[] parameters)
		{
			Assert.IsNull(actual, message, parameters);
		}

		/// <summary>Compares the two strings (case-insensitive).</summary>
		/// <param name="actual"></param>
		/// <param name="expected"></param>
		public static void ShouldBeSameStringAs(this string actual, string expected)
		{
			if (!string.Equals(actual, expected, StringComparison.InvariantCultureIgnoreCase))
			{
				var message = string.Format("Expected {0} but was {1}", expected, actual);
				throw new AssertFailedException(message);
			}
		}

		/// <summary>The should be same string as.</summary>
		/// <param name="actual">The actual.</param>
		/// <param name="expected">The expected.</param>
		/// <param name="message">The message.</param>
		/// <param name="parameters">The parameters.</param>
		/// <exception cref="Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException"></exception>
		public static void ShouldBeSameStringAs(this string actual, string expected, string message, params object[] parameters)
		{
			if (!string.Equals(actual, expected, StringComparison.InvariantCultureIgnoreCase))
			{
				var msg = string.Format(message, parameters);
				throw new AssertFailedException(msg);
			}
		}

		/// <summary>The should be the same as verifies that two specified objects refer to the same object.</summary>
		/// <param name="actual">The actual.</param>
		/// <param name="expected">The expected.</param>
		public static void ShouldBeTheSameAs(this object actual, object expected)
		{
			Assert.AreSame(expected, actual);
		}

		/// <summary>The should be the same as.</summary>
		/// <param name="actual">The actual.</param>
		/// <param name="expected">The expected.</param>
		/// <param name="message">The message.</param>
		/// <param name="parameters">The parameters.</param>
		public static void ShouldBeTheSameAs(this object actual, object expected, string message, params object[] parameters)
		{
			Assert.AreSame(expected, actual, message, parameters);
		}

		/// <summary>The should be true.</summary>
		/// <param name="source">The source.</param>
		public static void ShouldBeTrue(this bool source)
		{
			Assert.IsTrue(source);
		}

		/// <summary>The should be true.</summary>
		/// <param name="source">The source.</param>
		/// <param name="message">The message.</param>
		/// <param name="parameters">The parameters.</param>
		public static void ShouldBeTrue(this bool source, string message, params object[] parameters)
		{
			Assert.IsTrue(source, message, parameters);
		}

		/// <summary>The should equal.</summary>
		/// <param name="actual">The actual.</param>
		/// <param name="expected">The expected.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public static T ShouldEqual<T>(this T actual, object expected)
		{
			Assert.AreEqual(expected, actual);
			return actual;
		}

		/// <summary>Asserts that two objects are equal.</summary>
		/// <param name="actual"></param>
		/// <param name="expected"></param>
		/// <param name="message"></param>
		/// <param name="parameters"></param>
		/// <exception cref="AssertionException"></exception>
		public static void ShouldEqual(this object actual, object expected, string message, params object[] parameters)
		{
			Assert.AreEqual(expected, actual, message, parameters);
		}

		/// <summary>The should not be null.</summary>
		/// <param name="obj">The obj.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public static T ShouldNotBeNull<T>(this T obj)
		{
			Assert.IsNotNull(obj);
			return obj;
		}

		/// <summary>The should not be null.</summary>
		/// <param name="obj">The obj.</param>
		/// <param name="message">The message.</param>
		/// <param name="parameters"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The <see cref="T"/>.</returns>
		public static T ShouldNotBeNull<T>(this T obj, string message, params object[] parameters)
		{
			Assert.IsNotNull(obj, message, parameters);
			return obj;
		}

		/// <summary>The should be not be the same as verifies that two specified objects refer to different objects.</summary>
		/// <param name="actual">The actual.</param>
		/// <param name="expected">The expected.</param>
		public static void ShouldNotBeTheSameAs(this object actual, object expected)
		{
			Assert.AreNotSame(expected, actual);
		}

		/// <summary>The should not be the same as.</summary>
		/// <param name="actual">The actual.</param>
		/// <param name="expected">The expected.</param>
		/// <param name="message">The message.</param>
		/// <param name="parameters">The parameters.</param>
		public static void ShouldNotBeTheSameAs(this object actual, object expected, string message, params object[] parameters)
		{
			Assert.AreNotSame(expected, actual, message, parameters);
		}

		#endregion
	}
}