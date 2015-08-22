using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UX.Testing.Selenium.Controls
{
    public class SelectControl
    {
        private readonly IWebElement element;

        /// <summary>
        ///     Initializes a new instance of the SelectElement class.
        /// </summary>
        /// <param name="element">The element to be wrapped</param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     Thrown when the <see cref="T:OpenQA.Selenium.IWebElement" /> object is <see langword="null" />
        /// </exception>
        /// <exception cref="T:OpenQA.Selenium.Support.UI.UnexpectedTagNameException">Thrown when the element wrapped is not a &lt;select&gt; element.</exception>
        public SelectControl(IWebElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element", "element cannot be null");
            if (string.IsNullOrEmpty(element.TagName) ||
                string.Compare(element.TagName, "select", StringComparison.OrdinalIgnoreCase) != 0)
                throw new UnexpectedTagNameException("select", element.TagName);
            this.element = element;
            string attribute = element.GetAttribute("multiple");
            IsMultiple = attribute != null && attribute.ToLowerInvariant() != "false";
        }

        /// <summary>
        ///     Gets a value indicating whether the parent element supports multiple selections.
        /// </summary>
        public bool IsMultiple { get; private set; }

        /// <summary>
        ///     Gets the list of options for the select element.
        /// </summary>
        public IList<IWebElement> Options
        {
            get { return element.FindElements(OpenQA.Selenium.By.TagName("option")); }
        }

        /// <summary>
        ///     Gets the selected item within the select element.
        /// </summary>
        /// <remarks>
        ///     If more than one item is selected this will return the first item.
        /// </remarks>
        /// <exception cref="T:OpenQA.Selenium.NoSuchElementException">Thrown if no option is selected.</exception>
        public IWebElement SelectedOption
        {
            get
            {
                foreach (IWebElement webElement in Options)
                {
                    if (webElement.Selected)
                        return webElement;
                }
                throw new NoSuchElementException("No option is selected");
            }
        }

        /// <summary>
        ///     Gets all of the selected options within the select element.
        /// </summary>
        public IList<IWebElement> AllSelectedOptions
        {
            get
            {
                var list = new List<IWebElement>();
                foreach (IWebElement webElement in Options)
                {
                    if (webElement.Selected)
                        list.Add(webElement);
                }
                return list;
            }
        }

        /// <summary>
        ///     Select all options by the text displayed.
        /// </summary>
        /// <param name="text">
        ///     The text of the option to be selected. If an exact match is not found,
        ///     this method will perform a substring match.
        /// </param>
        /// <remarks>
        ///     When given "Bar" this method would select an option like:
        ///     <para>
        ///         &lt;option value="foo"&gt;Bar&lt;/option&gt;
        ///     </para>
        /// </remarks>
        /// <exception cref="T:OpenQA.Selenium.NoSuchElementException">Thrown if there is no element with the given text present.</exception>
        public void SelectByText(string text)
        {
            if (text == null)
                throw new ArgumentNullException("text", "text must not be null");
            IList<IWebElement> list =
                element.FindElements(
                    OpenQA.Selenium.By.XPath(".//option[normalize-space(.) = " + EscapeQuotes(text) + "]"));
            bool flag = false;
            foreach (IWebElement option in list)
            {
                SetSelected(option);
                if (!IsMultiple)
                    return;
                flag = true;
            }
            if (list.Count == 0 && text.Contains(" "))
            {
                string substringWithoutSpace = GetLongestSubstringWithoutSpace(text);
                foreach (
                    IWebElement option in
                        !string.IsNullOrEmpty(substringWithoutSpace)
                            ? (IEnumerable<IWebElement>)
                              element.FindElements(
                                  OpenQA.Selenium.By.XPath(".//option[contains(., " +
                                                           EscapeQuotes(substringWithoutSpace) + ")]"))
                            : (IEnumerable<IWebElement>) element.FindElements(OpenQA.Selenium.By.TagName("option")))
                {
                    if (text == option.Text)
                    {
                        SetSelected(option);
                        if (!IsMultiple)
                            return;
                        flag = true;
                    }
                }
            }
            if (!flag)
                throw new NoSuchElementException("Cannot locate element with text: " + text);
        }

        /// <summary>
        ///     Select an option by the value.
        /// </summary>
        /// <param name="value">The value of the option to be selected.</param>
        /// <remarks>
        ///     When given "foo" this method will select an option like:
        ///     <para>
        ///         &lt;option value="foo"&gt;Bar&lt;/option&gt;
        ///     </para>
        /// </remarks>
        /// <exception cref="T:OpenQA.Selenium.NoSuchElementException">Thrown when no element with the specified value is found.</exception>
        public void SelectByValue(string value)
        {
            var stringBuilder = new StringBuilder(".//option[@value = ");
            stringBuilder.Append(EscapeQuotes(value));
            stringBuilder.Append("]");
            IList<IWebElement> list = element.FindElements(OpenQA.Selenium.By.XPath((stringBuilder).ToString()));
            bool flag = false;
            foreach (IWebElement option in list)
            {
                SetSelected(option);
                if (!IsMultiple)
                    return;
                flag = true;
            }
            if (!flag)
                throw new NoSuchElementException("Cannot locate option with value: " + value);
        }

        /// <summary>
        ///     Select the option by the index, as determined by the "index" attribute of the element.
        /// </summary>
        /// <param name="index">The value of the index attribute of the option to be selected.</param>
        /// <exception cref="T:OpenQA.Selenium.NoSuchElementException">Thrown when no element exists with the specified index attribute.</exception>
        public void SelectByIndex(int index)
        {
            string str = index.ToString(CultureInfo.InvariantCulture);
            bool flag = false;
            foreach (IWebElement option in Options)
            {
                if (option.GetAttribute("index") == str)
                {
                    SetSelected(option);
                    if (!IsMultiple)
                        return;
                    flag = true;
                }
            }
            if (!flag)
                throw new NoSuchElementException("Cannot locate option with index: " + index);
        }

        /// <summary>
        ///     Clear all selected entries. This is only valid when the SELECT supports multiple selections.
        /// </summary>
        /// <exception cref="T:OpenQA.Selenium.WebDriverException">
        ///     Thrown when attempting to deselect all options from a SELECT
        ///     that does not support multiple selections.
        /// </exception>
        public void DeselectAll()
        {
            if (!IsMultiple)
                throw new InvalidOperationException("You may only deselect all options if multi-select is supported");
            foreach (IWebElement webElement in Options)
            {
                if (webElement.Selected)
                    webElement.Click();
            }
        }

        /// <summary>
        ///     Deselect the option by the text displayed.
        /// </summary>
        /// <param name="text">The text of the option to be deselected.</param>
        /// <remarks>
        ///     When given "Bar" this method would deselect an option like:
        ///     <para>
        ///         &lt;option value="foo"&gt;Bar&lt;/option&gt;
        ///     </para>
        /// </remarks>
        public void DeselectByText(string text)
        {
            var stringBuilder = new StringBuilder(".//option[normalize-space(.) = ");
            stringBuilder.Append(EscapeQuotes(text));
            stringBuilder.Append("]");
            foreach (
                IWebElement webElement in
                    (IEnumerable<IWebElement>)
                    element.FindElements(OpenQA.Selenium.By.XPath((stringBuilder).ToString())))
            {
                if (webElement.Selected)
                    webElement.Click();
            }
        }

        /// <summary>
        ///     Deselect the option having value matching the specified text.
        /// </summary>
        /// <param name="value">The value of the option to deselect.</param>
        /// <remarks>
        ///     When given "foo" this method will deselect an option like:
        ///     <para>
        ///         &lt;option value="foo"&gt;Bar&lt;/option&gt;
        ///     </para>
        /// </remarks>
        public void DeselectByValue(string value)
        {
            var stringBuilder = new StringBuilder(".//option[@value = ");
            stringBuilder.Append(EscapeQuotes(value));
            stringBuilder.Append("]");
            foreach (
                IWebElement webElement in
                    (IEnumerable<IWebElement>)
                    element.FindElements(OpenQA.Selenium.By.XPath((stringBuilder).ToString())))
            {
                if (webElement.Selected)
                    webElement.Click();
            }
        }

        /// <summary>
        ///     Deselect the option by the index, as determined by the "index" attribute of the element.
        /// </summary>
        /// <param name="index">The value of the index attribute of the option to deselect.</param>
        public void DeselectByIndex(int index)
        {
            string str = index.ToString(CultureInfo.InvariantCulture);
            foreach (IWebElement webElement in Options)
            {
                if (str == webElement.GetAttribute("index") && webElement.Selected)
                    webElement.Click();
            }
        }

        private static string EscapeQuotes(string toEscape)
        {
            if (toEscape.IndexOf("\"", StringComparison.OrdinalIgnoreCase) > -1 &&
                toEscape.IndexOf("'", StringComparison.OrdinalIgnoreCase) > -1)
            {
                bool flag = false;
                if (toEscape.LastIndexOf("\"", StringComparison.OrdinalIgnoreCase) == toEscape.Length - 1)
                    flag = true;
                var list = new List<string>(toEscape.Split(new char[1]
                    {
                        '"'
                    }));
                if (flag && string.IsNullOrEmpty(list[list.Count - 1]))
                    list.RemoveAt(list.Count - 1);
                var stringBuilder = new StringBuilder("concat(");
                for (int index = 0; index < list.Count; ++index)
                {
                    stringBuilder.Append("\"").Append(list[index]).Append("\"");
                    if (index == list.Count - 1)
                    {
                        if (flag)
                            stringBuilder.Append(", '\"')");
                        else
                            stringBuilder.Append(")");
                    }
                    else
                        stringBuilder.Append(", '\"', ");
                }
                return (stringBuilder).ToString();
            }
            else if (toEscape.IndexOf("\"", StringComparison.OrdinalIgnoreCase) > -1)
                return string.Format(CultureInfo.InvariantCulture, "'{0}'", new object[1]
                    {
                        toEscape
                    });
            else
                return string.Format(CultureInfo.InvariantCulture, "\"{0}\"", new object[1]
                    {
                        toEscape
                    });
        }

        private static string GetLongestSubstringWithoutSpace(string s)
        {
            string str1 = string.Empty;
            string str2 = s;
            var chArray = new char[1]
                {
                    ' '
                };
            foreach (string str3 in str2.Split(chArray))
            {
                if (str3.Length > str1.Length)
                    str1 = str3;
            }
            return str1;
        }

        private static void SetSelected(IWebElement option)
        {
            if (option.Selected)
                return;
            option.Click();
        }
    }
}