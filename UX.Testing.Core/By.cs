using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace UX.Testing.Core
{
	using UX.Testing.Core;
	using UX.Testing.Core.Controls;

	[Serializable]
	public class By
	{
		private string description = "UX.Testing.Core.By";
		private Func<ISearchContext, HtmlControl> findElementMethod;
		private Func<ISearchContext, ReadOnlyCollection<HtmlControl>> findElementsMethod;

		protected string Description
		{
			get
			{
				return this.description;
			}
			set
			{
				this.description = value;
			}
		}

		protected Func<ISearchContext, HtmlControl> FindElementMethod
		{
			get
			{
				return this.findElementMethod;
			}
			set
			{
				this.findElementMethod = value;
			}
		}

		protected Func<ISearchContext, ReadOnlyCollection<HtmlControl>> FindElementsMethod
		{
			get
			{
				return this.findElementsMethod;
			}
			set
			{
				this.findElementsMethod = value;
			}
		}

		protected By()
		{
		}

		protected By(Func<ISearchContext, HtmlControl> findElementMethod, Func<ISearchContext, ReadOnlyCollection<HtmlControl>> findElementsMethod)
		{
			this.findElementMethod = findElementMethod;
			this.findElementsMethod = findElementsMethod;
		}

		//public static bool operator ==(By one, By two)
		//{
		//	if (object.ReferenceEquals((object)one, (object)two))
		//		return true;
		//	if (one == null || two == null)
		//		return false;
		//	else
		//		return one.Equals((object)two);
		//}

		//public static bool operator !=(By one, By two)
		//{
		//	return !(one == two);
		//}

		public static By Id(string idToFind)
		{
			if (idToFind == null)
			{
				throw new ArgumentNullException("idToFind", "Cannot find elements with a null id attribute.");
			}

			return new By()
				   {
					   findElementMethod = context => ((IFindsById)context).FindControlById(idToFind),
					   findElementsMethod = context => ((IFindsById)context).FindControlsById(idToFind),
					   description = "By.Id: " + idToFind
				   };
		}

		public static By LinkText(string linkTextToFind)
		{
			if (linkTextToFind == null)
			{
				throw new ArgumentNullException("linkTextToFind", "Cannot find elements when link text is null.");
			}

			return new By()
				   {
					   findElementMethod = context => ((IFindsByLinkText)context).FindControlByLinkText(linkTextToFind),
					   findElementsMethod = context => ((IFindsByLinkText)context).FindControlsByLinkText(linkTextToFind),
					   description = "By.LinkText: " + linkTextToFind
				   };
		}

		public static By Name(string nameToFind)
		{
			if (nameToFind == null)
			{
				throw new ArgumentNullException("nameToFind", "Cannot find elements when name text is null.");
			}

			return new By()
				   {
					   findElementMethod = context => ((IFindsByName)context).FindControlByName(nameToFind),
					   findElementsMethod = context => ((IFindsByName)context).FindControlsByName(nameToFind),
					   description = "By.Name: " + nameToFind
				   };
		}

		//public static By XPath(string xpathToFind)
		//{
		//	if (xpathToFind == null)
		//		throw new ArgumentNullException("xpathToFind", "Cannot find elements when the XPath expression is null.");
		//	return new By()
		//	{
		//		findElementMethod = (Func<ISearchContext, HtmlControl>)(context => ((IFindsByXPath)context).FindElementByXPath(xpathToFind)),
		//		findElementsMethod = (Func<ISearchContext, ReadOnlyCollection<HtmlControl>>)(context => ((IFindsByXPath)context).FindElementsByXPath(xpathToFind)),
		//		description = "By.XPath: " + xpathToFind
		//	};
		//}

		public static By ClassName(string classNameToFind)
		{
			if (classNameToFind == null)
			{
				throw new ArgumentNullException("classNameToFind", "Cannot find elements when the class name expression is null.");
			}

			if (new Regex(".*\\s+.*").IsMatch(classNameToFind))
			{
				throw new IllegalLocatorException(
					"Compound class names are not supported. Consider searching for one class name and filtering the results.");
			}

			return new By()
				   {
				findElementMethod = context => ((IFindsByClassName)context).FindControlByClassName(classNameToFind),
				findElementsMethod = context => ((IFindsByClassName)context).FindControlsByClassName(classNameToFind),
				description = "By.ClassName[Contains]: " + classNameToFind
			};
		}

		public static By PartialLinkText(string partialLinkTextToFind)
		{
			return new By()
			{
				findElementMethod = context => ((IFindsByPartialLinkText)context).FindControlByPartialLinkText(partialLinkTextToFind),
				findElementsMethod = context => ((IFindsByPartialLinkText)context).FindControlsByPartialLinkText(partialLinkTextToFind),
				description = "By.PartialLinkText: " + partialLinkTextToFind
			};
		}

		public static By TagName(string tagNameToFind)
		{
			if (tagNameToFind == null)
			{
				throw new ArgumentNullException("tagNameToFind", "Cannot find elements when name tag name is null.");
			}

			return new By()
				   {
					   findElementMethod = context => ((IFindsByTagName)context).FindControlByTagName(tagNameToFind),
					   findElementsMethod = context => ((IFindsByTagName)context).FindControlsByTagName(tagNameToFind),
					   description = "By.TagName: " + tagNameToFind
				   };
		}

		public static By CssSelector(string cssSelectorToFind)
		{
			if (cssSelectorToFind == null)
			{
				throw new ArgumentNullException("cssSelectorToFind", "Cannot find elements when name CSS selector is null.");
			}

			return new By()
				   {
					   findElementMethod = context => ((IFindsByCssSelector)context).FindControlByCssSelector(cssSelectorToFind),
					   findElementsMethod = context => ((IFindsByCssSelector)context).FindControlsByCssSelector(cssSelectorToFind),
					   description = "By.CssSelector: " + cssSelectorToFind
				   };
		}

		public virtual HtmlControl FindControl(ISearchContext context)
		{
			return this.findElementMethod(context);
		}

		public virtual ReadOnlyCollection<HtmlControl> FindControls(ISearchContext context)
		{
			return this.findElementsMethod(context);
		}

		public override string ToString()
		{
			return this.description;
		}

		public override bool Equals(object obj)
		{
			By by = obj as By;
			if (by != (By)null)
				return this.description.Equals(by.description);
			else
				return false;
		}

		public override int GetHashCode()
		{
			return this.description.GetHashCode();
		}
	}
}
