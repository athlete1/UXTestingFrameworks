using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UX.Testing.Selenium
{
	internal enum FindBy
	{
		None,
		XPath,
		Id,
		Class,
		Name,
		CSSSelector,
		LinkText,
		PartialLinkText,
		TagName
	}
}
