using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UX.Testing.Core.Controls
{
	public interface IMouseEventAttributes
	{
		string OnClick { get; set; }

		string OnDblClick { get; set; }

		string OnDrag { get; set; }

		string OnDragEnd { get; set; }

		string OnDragEnter { get; set; }

		string OnDragLeave { get; set; }

		string OnDragOver { get; set; }

		string OnDragStart { get; set; }

		string OnDrop { get; set; }

		string OnMouseDown { get; set; }

		string OnMouseMove { get; set; }

		string OnMouseOut { get; set; }

		string OnMouseOver { get; set; }

		string OnMouseUp { get; set; }

		string OnMouseWheel { get; set; }

		string OnScroll { get; set; }
	}
}
