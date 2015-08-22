using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UX.Testing.Core
{
	using System.Collections.ObjectModel;

	using UX.Testing.Core.Controls;

	public interface IFindsByPartialLinkText
	{
		HtmlControl FindControlByPartialLinkText(string partialLinkText, HtmlControl parentControl = null);

		ReadOnlyCollection<HtmlControl> FindControlsByPartialLinkText(string partialLinkText, HtmlControl parentControl = null);
	}
}
