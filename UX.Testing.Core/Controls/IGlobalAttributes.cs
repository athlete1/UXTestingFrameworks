using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UX.Testing.Core.Controls
{
	public interface IGlobalAttributes
	{
		string AccessKey { get; set; }

		string Class { get; set; }

		string ContentEditable { get; set; }

		string ContextMenu { get; set; }

		string Dir { get; set; }

		string Draggable { get; set; }

		string Dropzone { get; set; }

		string Hidden { get; set; }

		string Id { get; set; }

		string Lang { get; set; }

		string Spellcheck { get; set; }

		string Style { get; set; }

		string TabIndex { get; set; }

		string Title { get; set; }

		string Translate { get; set; }

	}
}
