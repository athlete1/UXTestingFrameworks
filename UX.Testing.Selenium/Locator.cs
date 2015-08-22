using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UX.Testing.Selenium
{
	internal struct Locator
	{
		public FindBy FindBy { get; set; }

		public string Term { get; set; }
	}
}
