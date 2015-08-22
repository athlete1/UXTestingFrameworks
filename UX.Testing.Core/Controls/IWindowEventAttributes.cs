using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UX.Testing.Core.Controls
{
	public interface IWindowEventAttributes
	{
		string OnAfterPrint { get; set; }

		string OnBeforePrint { get; set; }

		string OnBeforeUnload { get; set; }

		string OnError { get; set; }

		string OnHasChange { get; set; }

		string OnLoad { get; set; }

		string OnMessage { get; set; }

		string OnOffline { get; set; }

		string OnOnline { get; set; }

		string OnPageHide { get; set; }

		string OnPageShow { get; set; }

		string OnPopState { get; set; }

		string OnRedo { get; set; }

		string OnResize { get; set; }

		string OnStorage { get; set; }

		string OnUndo { get; set; }

		string OnUnload { get; set; }
		
	}
}
