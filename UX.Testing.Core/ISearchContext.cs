using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UX.Testing.Core
{
	using System.Collections.ObjectModel;

	using UX.Testing.Core.Controls;

	public interface ISearchContext
	{
		HtmlControl FindControl(By by);

		ReadOnlyCollection<HtmlControl> FindControls(By by);
	}
}
