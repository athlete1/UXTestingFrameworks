using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UX.Testing.Core
{
	using System.Collections.ObjectModel;

	using UX.Testing.Core.Controls;

	public interface IFindsByCssSelector
	{
		HtmlControl FindControlByCssSelector(string cssSelector, HtmlControl parentControl = null);

		ReadOnlyCollection<HtmlControl> FindControlsByCssSelector(string cssSelector, HtmlControl parentControl = null);
	}
}
