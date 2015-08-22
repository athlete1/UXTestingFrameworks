// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlAudio.cs" company="">
//   
// </copyright>
// <summary>
//   The html div.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	/// <summary>The html div.</summary>
	public class HtmlAudio : HtmlControl , IMediaEventAttributes
	{
		#region Public Properties

		/// <summary>Gets or sets the auto play.</summary>
		public string AutoPlay
		{
			get
			{
				return this.GetAttribute("autoplay");
			}

			set
			{
				this.AddAttribute("autoplay", value);
			}
		}

		/// <summary>Gets or sets the controls.</summary>
		public string Controls
		{
			get
			{
				return this.GetAttribute("controls");
			}

			set
			{
				this.AddAttribute("controls", value);
			}
		}

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.audio;
			}
		}

		/// <summary>Gets or sets the loop.</summary>
		public string Loop
		{
			get
			{
				return this.GetAttribute("loop");
			}

			set
			{
				this.AddAttribute("loop", value);
			}
		}

		/// <summary>Gets or sets the muted.</summary>
		public string Muted
		{
			get
			{
				return this.GetAttribute("muted");
			}

			set
			{
				this.AddAttribute("muted", value);
			}
		}

		/// <summary>Gets or sets the pre load.</summary>
		public string PreLoad { get; set; }

		/// <summary>Gets or sets the src.</summary>
		public string Src { get; set; }

		#endregion

		public string OnAbort { get; set; }

		public string OnCanPlay { get; set; }

		public string OnCanPlayThrough { get; set; }

		public string OnDurationChange { get; set; }

		public string OnEmptied { get; set; }

		public string OnEnded { get; set; }

		public string OnError { get; set; }

		public string OnLoadedData { get; set; }

		public string OnLoadedMetaData { get; set; }

		public string OnLoadStart { get; set; }

		public string OnPause { get; set; }

		public string OnPlay { get; set; }

		public string OnPlaying { get; set; }

		public string OnProgress { get; set; }

		public string OnRateChange { get; set; }

		public string OnReadyStateChange { get; set; }

		public string OnSeeked { get; set; }

		public string OnSeeking { get; set; }

		public string OnStalled { get; set; }

		public string OnSuspend { get; set; }

		public string OnTimeUpdate { get; set; }

		public string OnWaiting { get; set; }
	}
}