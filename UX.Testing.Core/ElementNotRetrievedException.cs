using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UX.Testing.Core
{
	public class ElementNotRetrievedException : Exception
	{
		public ElementNotRetrievedException()
			: this("Element not retrieved from DOM.")
		{
		}

		public ElementNotRetrievedException(string message)
			: base(message)
		{
		}
	}
}
