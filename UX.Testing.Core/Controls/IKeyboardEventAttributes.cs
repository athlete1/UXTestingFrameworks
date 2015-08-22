using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UX.Testing.Core.Controls
{
	public interface IKeyboardEventAttributes
	{
		string OnKeyDown { get; set; }

		string OnKeyPress { get; set; }

		string OnKeyUp { get; set; }
	}
}
