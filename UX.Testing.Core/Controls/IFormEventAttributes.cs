using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UX.Testing.Core.Controls
{
	public interface IFormEventAttributes
	{
		string OnBlur { get; set; }

		string OnChange { get; set; }

		string OnContextMenu { get; set; }

		string OnFocus { get; set; }

		string OnFormChange { get; set; }

		string OnFormInput { get; set; }

		string OnInput { get; set; }

		string OnInvalid { get; set; }

		string OnReset { get; set; }

		string OnSelect { get; set; }

		string OnSubmit { get; set; }
		
	}
}
