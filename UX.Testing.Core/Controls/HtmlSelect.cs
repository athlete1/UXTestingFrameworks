// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlSelect.cs" company="">
//   
// </copyright>
// <summary>
//   The html div.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using System.Threading;

	using UX.Testing.Core.Enums;
	using UX.Testing.Core.Extensions;
	using UX.Testing.Core.TestFramework;

	/// <summary>The html div.</summary>
	public class HtmlSelect : HtmlControl
	{
		#region Public Properties

		#endregion

		#region Public Properties

		/// <summary>
		///     Gets all of the selected options within the select element.
		/// </summary>
		public IList<HtmlOption> AllSelectedOptions
		{
			get
			{
				return this.Options.Where(webElement => Convert.ToBoolean(webElement.Selected)).ToList();
			}
		}

		/// <summary>Gets or sets AutoFocus.</summary>
		public string AutoFocus
		{
			get
			{
				return this.GetAttribute("autofocus");
			}

			set
			{
				this.AddAttribute("autofocus", value);
			}
		}

		/// <summary>Gets or sets Disabled.</summary>
		public string Disabled
		{
			get
			{
				return this.GetAttribute("disabled");
			}

			set
			{
				this.AddAttribute("disabled", value);
			}
		}

		/// <summary>Gets or sets Form.</summary>
		public string Form
		{
			get
			{
				return this.GetAttribute("form");
			}

			set
			{
				this.AddAttribute("form", value);
			}
		}

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.select;
			}
		}

		/// <summary>Gets or sets Multiple.</summary>
		public string Multiple
		{
			get
			{
				return this.GetAttribute("multiple");
			}

			set
			{
				this.AddAttribute("multiple", value);
			}
		}

		/// <summary>Gets or sets Name.</summary>
		public new string Name
		{
			get
			{
				return this.GetAttribute("name");
			}

			set
			{
				this.AddAttribute("name", value);
			}
		}

		/// <summary>Gets the options.</summary>
		public IEnumerable<HtmlOption> Options
		{
			get
			{
				return this.FindAll<HtmlOption>();
			}
		}

		/// <summary>Gets or sets Required.</summary>
		public string Required
		{
			get
			{
				return this.GetAttribute("required");
			}

			set
			{
				this.AddAttribute("required", value);
			}
		}

		/// <summary>
		///     Gets the selected item within the select element.
		/// </summary>
		/// <remarks>
		///     If more than one item is selected this will return the first item.
		/// </remarks>
		public HtmlOption SelectedOption
		{
			get
			{
				return this.Options.FirstOrDefault(webElement => webElement.Selected);

				// throw new NoSuchElementException("No option is selected");
			}
		}

		public int SelectedIndex
		{
			get
			{
				return Convert.ToInt32(this.Options.FirstOrDefault(webElement => webElement.Selected).GetFrameworkAttribute("index"));
			}
		}

		/// <summary>Gets or sets Size.</summary>
		public string Size
		{
			get
			{
				return this.GetAttribute("size");
			}

			set
			{
				this.AddAttribute("size", value);
			}
		}

		#endregion

		#region Public Methods and Operators

		/// <summary>
		///     Clear all selected entries. This is only valid when the SELECT supports multiple selections.
		/// </summary>
		/// <exception cref="T:OpenQA.Selenium.WebDriverException">
		///     Thrown when attempting to deselect all options from a SELECT
		///     that does not support multiple selections.
		/// </exception>
		public void DeselectAll()
		{
			if (!Convert.ToBoolean(this.Multiple))
			{
				throw new InvalidOperationException("You may only deselect all options if multi-select is supported");
			}

			foreach (var webElement in this.Options.Where(webElement => Convert.ToBoolean(webElement.Selected)))
			{
				webElement.Click();
			}
		}

		/// <summary>Deselect the option by the index, as determined by the "index" attribute of the element.</summary>
		/// <param name="index">The value of the index attribute of the option to deselect.</param>
		public void DeselectByIndex(int index)
		{
			string str = index.ToString(CultureInfo.InvariantCulture);
			foreach (
				var webElement in
					this.Options.ToList().Where(webElement => str == webElement.GetFrameworkAttribute("index") && Convert.ToBoolean(webElement.Selected)))
			{
				webElement.Click();
			}
		}

		/// <summary>Deselect the option by the text displayed.</summary>
		/// <param name="text">The text of the option to be deselected.</param>
		/// <remarks>When given "Bar" this method would deselect an option like:
		/// <para>
		///         &lt;option value="foo"&gt;Bar&lt;/option&gt;</para>
		/// </remarks>
		public void DeselectByText(string text)
		{
			foreach (var webElement in this.Options.ToList().Where(webElement => Convert.ToBoolean(webElement.Selected)))
			{
				webElement.Click();
			}
		}

		/// <summary>Deselect the option having value matching the specified text.</summary>
		/// <param name="value">The value of the option to deselect.</param>
		/// <remarks>When given "foo" this method will deselect an option like:
		/// <para>
		///         &lt;option value="foo"&gt;Bar&lt;/option&gt;</para>
		/// </remarks>
		public void DeselectByValue(string value)
		{
			foreach (var webElement in this.Options.ToList())
			{
				if (Convert.ToBoolean(webElement.Selected))
				{
					webElement.Click();
				}
			}
		}

		/// <summary>Select the option by the index, as determined by the "index" attribute of the element.</summary>
		/// <param name="index">The value of the index attribute of the option to be selected.</param>
		public void SelectByIndex(int index)
		{
			string str = index.ToString(CultureInfo.InvariantCulture);

			if (TestSettings.Instance.Browser != TestFramework.Browser.BrowserType.FireFox)
			{
				this.Click();
			}

			foreach (HtmlOption option in this.Options.Where(option => option.GetFrameworkAttribute("index") == str))
			{
				if (!option.Selected)
				{
					option.Click();
				}

				if (this.Multiple != null && this.Multiple != "true")
				{
					return;
				}
			}
		}

		/// <summary>Select all options by the text displayed.</summary>
		/// <param name="text">The text of the option to be selected. If an exact match is not found,
		///     this method will perform a substring match.</param>
		/// <remarks>When given "Bar" this method would select an option like:
		/// <para>
		///         &lt;option value="foo"&gt;Bar&lt;/option&gt;</para>
		/// </remarks>
		public void SelectByText(string text, FindOperator oOperator)
		{
			if (text == null)
			{
				throw new ArgumentNullException("text", "text must not be null");
			}

			if (TestSettings.Instance.Browser != TestFramework.Browser.BrowserType.FireFox)
			{
				this.Click();
			}

			if (oOperator == FindOperator.Equals)
			{
				foreach (HtmlOption option in this.Options.Where(option => option.InnerText == text))
				{
					if (!option.Selected)
					{
						option.Click();
					}

					if (this.Multiple != null && this.Multiple != "true")
					{
						return;
					}
				}
			}

			if (oOperator == FindOperator.Contains)
			{
				foreach (HtmlOption option in this.Options.Where(option => option.InnerText.Contains(text)))
				{
					if (!option.Selected)
					{
						option.Click();
					}

					if (this.Multiple != null && this.Multiple != "true")
					{
						return;
					}
				}
			}

			if (oOperator == FindOperator.StartsWith)
			{
				foreach (HtmlOption option in this.Options.Where(option => option.InnerText.StartsWith(text)))
				{
					if (!option.Selected)
					{
						option.Click();
					}

					if (this.Multiple != null && this.Multiple != "true")
					{
						return;
					}
				}
			}
		}

		public void SelectByText(string text)
		{
			this.SelectByText(text, FindOperator.Equals);
		}

		/// <summary>Select an option by the value.</summary>
		/// <param name="value">The value of the option to be selected.</param>
		/// <remarks>When given "foo" this method will select an option like:
		/// <para>
		///         &lt;option value="foo"&gt;Bar&lt;/option&gt;</para>
		/// </remarks>
		/// <exception cref="T:OpenQA.Selenium.NoSuchElementException">Thrown when no element with the specified value is found.</exception>
		public void SelectByValue(string value)
		{
			if (TestSettings.Instance.Browser != TestFramework.Browser.BrowserType.FireFox)
			{
				this.Click();
			}

			foreach (HtmlOption option in this.Options.Where(option => option.Value == value))
			{
				if (!option.Selected)
				{
					option.Click();
				}

				if (this.Multiple != null && this.Multiple != "true")
				{
					return;
				}
			}
		}

		#endregion

		#region Methods

		/// <summary>The escape quotes.</summary>
		/// <param name="toEscape">The to escape.</param>
		/// <returns>The <see cref="string"/>.</returns>
		private static string EscapeQuotes(string toEscape)
		{
			if (toEscape.IndexOf("\"", StringComparison.OrdinalIgnoreCase) > -1
				&& toEscape.IndexOf("'", StringComparison.OrdinalIgnoreCase) > -1)
			{
				bool flag = false || toEscape.LastIndexOf("\"", StringComparison.OrdinalIgnoreCase) == toEscape.Length - 1;

				var list = new List<string>(toEscape.Split(new[] { '"' }));
				if (flag && string.IsNullOrEmpty(list[list.Count - 1]))
				{
					list.RemoveAt(list.Count - 1);
				}

				var stringBuilder = new StringBuilder("concat(");
				for (int index = 0; index < list.Count; ++index)
				{
					stringBuilder.Append("\"").Append(list[index]).Append("\"");
					if (index == list.Count - 1)
					{
						if (flag)
						{
							stringBuilder.Append(", '\"')");
						}
						else
						{
							stringBuilder.Append(")");
						}
					}
					else
					{
						stringBuilder.Append(", '\"', ");
					}
				}

				return stringBuilder.ToString();
			}

			if (toEscape.IndexOf("\"", StringComparison.OrdinalIgnoreCase) > -1)
			{
				return string.Format(CultureInfo.InvariantCulture, "'{0}'", new object[1] { toEscape });
			}
			
			return string.Format(CultureInfo.InvariantCulture, "\"{0}\"", new object[1] { toEscape });
		}

		/// <summary>The get longest substring without space.</summary>
		/// <param name="s">The s.</param>
		/// <returns>The <see cref="string"/>.</returns>
		private static string GetLongestSubstringWithoutSpace(string s)
		{
			var str1 = string.Empty;
			var str2 = s;
			var charArray = new[] { ' ' };
			foreach (string str3 in str2.Split(charArray).Where(str3 => str3.Length > str1.Length))
			{
				str1 = str3;
			}

			return str1;
		}

		/// <summary>The set selected.</summary>
		/// <param name="option">The option.</param>
		private static void SetSelected(HtmlOption option)
		{
			if (option.Selected)
			{
				return;
			}

			option.Click();
		}

		#endregion
	}
}