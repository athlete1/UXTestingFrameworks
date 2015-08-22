using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UX.Testing.Core.Controls
{
	public interface IMediaEventAttributes
	{
		string OnAbort { get; set; }

		string OnCanPlay { get; set; }

		string OnCanPlayThrough { get; set; }

		string OnDurationChange { get; set; }

		string OnEmptied { get; set; }

		string OnEnded { get; set; }

		string OnError { get; set; }

		string OnLoadedData { get; set; }

		string OnLoadedMetaData { get; set; }

		string OnLoadStart { get; set; }

		string OnPause { get; set; }

		string OnPlay { get; set; }

		string OnPlaying { get; set; }

		string OnProgress { get; set; }

		string OnRateChange { get; set; }

		string OnReadyStateChange { get; set; }

		string OnSeeked { get; set; }

		string OnSeeking { get; set; }

		string OnStalled { get; set; }

		string OnSuspend { get; set; }

		string OnTimeUpdate { get; set; }

		string OnWaiting { get; set; }
	}
}
