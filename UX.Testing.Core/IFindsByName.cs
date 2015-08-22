using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UX.Testing.Core
{
	using System.Collections.ObjectModel;

	using UX.Testing.Core.Controls;

	public interface IFindsByName
	{
		HtmlControl FindControlByName(string name, HtmlControl parentControl = null);

		ReadOnlyCollection<HtmlControl> FindControlsByName(string name, HtmlControl parentControl = null);
	}
}
