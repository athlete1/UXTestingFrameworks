// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlMeter.cs" company="">
//   
// </copyright>
// <summary>
//   The html div.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UX.Testing.Core.Controls
{
	/// <summary>The html div.</summary>
	public class HtmlMeter : HtmlControl
	{
		#region Public Properties

		/// <summary>Gets or sets Form.</summary>
		public string Form
		{
			get
			{
				return this.GetAttribute("form");
			}

			set
			{
				this.AddAttribute("form", value);
			}
		}

		/// <summary>Gets or sets High.</summary>
		public string High
		{
			get
			{
				return this.GetAttribute("high");
			}

			set
			{
				this.AddAttribute("high", value);
			}
		}

		/// <summary>Gets the html tag.</summary>
		public override HtmlTag HtmlTag
		{
			get
			{
				return HtmlTag.meter;
			}
		}

		/// <summary>Gets or sets Low.</summary>
		public string Low
		{
			get
			{
				return this.GetAttribute("low");
			}

			set
			{
				this.AddAttribute("low", value);
			}
		}

		/// <summary>Gets or sets Max.</summary>
		public string Max
		{
			get
			{
				return this.GetAttribute("max");
			}

			set
			{
				this.AddAttribute("max", value);
			}
		}

		/// <summary>Gets or sets Min.</summary>
		public string Min
		{
			get
			{
				return this.GetAttribute("min");
			}

			set
			{
				this.AddAttribute("min", value);
			}
		}

		/// <summary>Gets or sets Optimum.</summary>
		public string Optimum
		{
			get
			{
				return this.GetAttribute("optimum");
			}

			set
			{
				this.AddAttribute("optimum", value);
			}
		}

		/// <summary>Gets or sets Value.</summary>
		public string Value
		{
			get
			{
				return this.GetAttribute("value");
			}

			set
			{
				this.AddAttribute("value", value);
			}
		}

		#endregion
	}
}