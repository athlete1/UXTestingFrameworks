using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UX.Testing.Core
{
	using System.Collections.ObjectModel;

	using UX.Testing.Core.Controls;

	public interface IFindsByLinkText
	{
		HtmlControl FindControlByLinkText(string linkText, HtmlControl parentControl = null);

		ReadOnlyCollection<HtmlControl> FindControlsByLinkText(string linkText, HtmlControl parentControl = null);
	}
}
