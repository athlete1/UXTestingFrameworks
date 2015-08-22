// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlTag.cs" company="">
//   
// </copyright>
// <summary>
//   The html tag.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UX.Testing.Core.Controls
{
	using System;
	using System.ComponentModel;

	/// <summary>The html tag.</summary>
	public enum HtmlTag
	{
		/// <summary>The a.</summary>
		[Description("any html tag")]
		[Tag("*")]
		any, 

		/// <summary>The a.</summary>
		[Description("a")]
		[Tag("a")]
		a, 

		/// <summary>The abbr.</summary>
		[Description("abbr")]
		[Tag("abbr")]
		abbr, 

		/// <summary>The address.</summary>
		[Description("address")]
		[Tag("address")]
		address, 

		/// <summary>The area.</summary>
		[Description("area")]
		[Tag("area")]
		area, 

		/// <summary>The article.</summary>
		[Description("article")]
		[Tag("article")]
		article, 

		/// <summary>The aside.</summary>
		[Description("aside")]
		[Tag("aside")]
		aside, 

		/// <summary>The audio.</summary>
		[Description("audio")]
		[Tag("audio")]
		audio, 

		/// <summary>The b.</summary>
		[Description("b")]
		[Tag("b")]
		b, 

		/// <summary>The base.</summary>
		[Description("base")]
		[Tag("base")]
		@base, 

		/// <summary>The bdi.</summary>
		[Description("bdi")]
		[Tag("bdi")]
		bdi, 

		/// <summary>The bdo.</summary>
		[Description("bdo")]
		[Tag("bdo")]
		bdo, 

		/// <summary>The blockquote.</summary>
		[Description("blockquote")]
		[Tag("blockquote")]
		blockquote, 

		/// <summary>The body.</summary>
		[Description("body")]
		[Tag("body")]
		body, 

		/// <summary>The br.</summary>
		[Description("br")]
		[Tag("br")]
		br, 

		/// <summary>The button.</summary>
		[Description("button")]
		[Tag("button")]
		button, 

		/// <summary>The canvas.</summary>
		[Description("canvas")]
		[Tag("canvas")]
		canvas, 

		/// <summary>The caption.</summary>
		[Description("caption")]
		[Tag("caption")]
		caption, 

		/// <summary>The cite.</summary>
		[Description("cite")]
		[Tag("cite")]
		cite, 

		/// <summary>The code.</summary>
		[Description("code")]
		[Tag("code")]
		code, 

		/// <summary>The col.</summary>
		[Description("col")]
		[Tag("col")]
		col, 

		/// <summary>The colgroup.</summary>
		[Description("colgroup")]
		[Tag("colgroup")]
		colgroup, 

		/// <summary>The command.</summary>
		[Description("command")]
		[Tag("command")]
		command, 

		/// <summary>The datalist.</summary>
		[Description("datalist")]
		[Tag("datalist")]
		datalist, 

		/// <summary>The dd.</summary>
		[Description("dd")]
		[Tag("dd")]
		dd, 

		/// <summary>The del.</summary>
		[Description("del")]
		[Tag("del")]
		del, 

		/// <summary>The details.</summary>
		[Description("details")]
		[Tag("details")]
		details, 

		/// <summary>The dfn.</summary>
		[Description("dfn")]
		[Tag("dfn")]
		dfn, 

		/// <summary>The dialog.</summary>
		[Description("dialog")]
		[Tag("dialog")]
		dialog, 

		/// <summary>The div.</summary>
		[Description("div")]
		[Tag("div")]
		div, 

		/// <summary>The dl.</summary>
		[Description("dl")]
		[Tag("dl")]
		dl, 

		/// <summary>The dt.</summary>
		[Description("dt")]
		[Tag("dt")]
		dt, 

		/// <summary>The em.</summary>
		[Description("em")]
		[Tag("em")]
		em, 

		/// <summary>The embed.</summary>
		[Description("embed")]
		[Tag("embed")]
		embed, 

		/// <summary>The fieldset.</summary>
		[Description("fieldset")]
		[Tag("fieldset")]
		fieldset, 

		/// <summary>The figcaption.</summary>
		[Description("figcaption")]
		[Tag("figcaption")]
		figcaption, 

		/// <summary>The figure.</summary>
		[Description("figure")]
		[Tag("figure")]
		figure, 

		/// <summary>The footer.</summary>
		[Description("footer")]
		[Tag("footer")]
		footer, 

		/// <summary>The form.</summary>
		[Description("form")]
		[Tag("form")]
		form, 

		/// <summary>The h 1.</summary>
		[Description("h1")]
		[Tag("h1")]
		h1, 

		/// <summary>The h 2.</summary>
		[Description("h2")]
		[Tag("h2")]
		h2, 

		/// <summary>The h 3.</summary>
		[Description("h3")]
		[Tag("h3")]
		h3, 

		/// <summary>The h 4.</summary>
		[Description("h4")]
		[Tag("h4")]
		h4, 

		/// <summary>The h 5.</summary>
		[Description("h5")]
		[Tag("h5")]
		h5, 

		/// <summary>The h 6.</summary>
		[Description("h6")]
		[Tag("h6")]
		h6, 

		/// <summary>The head.</summary>
		[Description("head")]
		[Tag("head")]
		head, 

		/// <summary>The header.</summary>
		[Description("header")]
		[Tag("header")]
		header, 

		/// <summary>The hr.</summary>
		[Description("hr")]
		[Tag("hr")]
		hr, 

		/// <summary>The html.</summary>
		[Description("html")]
		[Tag("html")]
		html, 

		/// <summary>The i.</summary>
		[Description("i")]
		[Tag("i")]
		i, 

		/// <summary>The iframe.</summary>
		[Description("iframe")]
		[Tag("iframe")]
		iframe, 

		/// <summary>The img.</summary>
		[Description("img")]
		[Tag("img")]
		img, 

		/// <summary>The input.</summary>
		[Description("input")]
		[Tag("input")]
		input, 

		/// <summary>The ins.</summary>
		[Description("ins")]
		[Tag("ins")]
		ins, 

		/// <summary>The kbd.</summary>
		[Description("kbd")]
		[Tag("kbd")]
		kbd, 

		/// <summary>The keygen.</summary>
		[Description("keygen")]
		[Tag("keygen")]
		keygen, 

		/// <summary>The label.</summary>
		[Description("label")]
		[Tag("label")]
		label, 

		/// <summary>The legend.</summary>
		[Description("legend")]
		[Tag("legend")]
		legend, 

		/// <summary>The li.</summary>
		[Description("li")]
		[Tag("li")]
		li, 

		/// <summary>The link.</summary>
		[Description("link")]
		[Tag("link")]
		link, 

		/// <summary>The map.</summary>
		[Description("map")]
		[Tag("map")]
		map, 

		/// <summary>The mark.</summary>
		[Description("mark")]
		[Tag("mark")]
		mark, 

		/// <summary>The menu.</summary>
		[Description("menu")]
		[Tag("menu")]
		menu, 

		/// <summary>The meta.</summary>
		[Description("meta")]
		[Tag("meta")]
		meta, 

		/// <summary>The meter.</summary>
		[Description("meter")]
		[Tag("meter")]
		meter, 

		/// <summary>The nav.</summary>
		[Description("nav")]
		[Tag("nav")]
		nav, 

		/// <summary>The noscript.</summary>
		[Description("noscript")]
		[Tag("noscript")]
		noscript, 

		/// <summary>The ol.</summary>
		[Description("ol")]
		[Tag("ol")]
		ol, 

		/// <summary>The optgroup.</summary>
		[Description("optgroup")]
		[Tag("optgroup")]
		optgroup, 

		/// <summary>The option.</summary>
		[Description("option")]
		[Tag("option")]
		option, 

		/// <summary>The output.</summary>
		[Description("output")]
		[Tag("output")]
		output, 

		/// <summary>The p.</summary>
		[Description("p")]
		[Tag("p")]
		p, 

		/// <summary>The param.</summary>
		[Description("param")]
		[Tag("param")]
		param, 

		/// <summary>The pre.</summary>
		[Description("pre")]
		[Tag("pre")]
		pre, 

		/// <summary>The progress.</summary>
		[Description("progress")]
		[Tag("progress")]
		progress, 

		/// <summary>The q.</summary>
		[Description("q")]
		[Tag("q")]
		q, 

		/// <summary>The rp.</summary>
		[Description("rp")]
		[Tag("rp")]
		rp, 

		/// <summary>The rt.</summary>
		[Description("rt")]
		[Tag("rt")]
		rt, 

		/// <summary>The ruby.</summary>
		[Description("ruby")]
		[Tag("ruby")]
		ruby, 

		/// <summary>The s.</summary>
		[Description("s")]
		[Tag("s")]
		s, 

		/// <summary>The samp.</summary>
		[Description("samp")]
		[Tag("samp")]
		samp, 

		/// <summary>The script.</summary>
		[Description("script")]
		[Tag("script")]
		script, 

		/// <summary>The section.</summary>
		[Description("section")]
		[Tag("section")]
		section, 

		/// <summary>The select.</summary>
		[Description("select")]
		[Tag("select")]
		select, 

		/// <summary>The small.</summary>
		[Description("small")]
		[Tag("small")]
		small, 

		/// <summary>The source.</summary>
		[Description("source")]
		[Tag("source")]
		source, 

		/// <summary>The span.</summary>
		[Description("span")]
		[Tag("span")]
		span, 

		/// <summary>The strong.</summary>
		[Description("strong")]
		[Tag("strong")]
		strong, 

		/// <summary>The style.</summary>
		[Description("style")]
		[Tag("style")]
		style, 

		/// <summary>The sub.</summary>
		[Description("sub")]
		[Tag("sub")]
		sub, 

		/// <summary>The summary.</summary>
		[Description("summary")]
		[Tag("summary")]
		summary, 

		/// <summary>The sup.</summary>
		[Description("sup")]
		[Tag("sup")]
		sup, 

		/// <summary>The table.</summary>
		[Description("table")]
		[Tag("table")]
		table, 

		/// <summary>The tbody.</summary>
		[Description("tbody")]
		[Tag("tbody")]
		tbody, 

		/// <summary>The td.</summary>
		[Description("td")]
		[Tag("td")]
		td, 

		/// <summary>The textarea.</summary>
		[Description("textarea")]
		[Tag("textarea")]
		textarea, 

		/// <summary>The tfoot.</summary>
		[Description("tfoot")]
		[Tag("tfoot")]
		tfoot, 

		/// <summary>The th.</summary>
		[Description("th")]
		[Tag("th")]
		th, 

		/// <summary>The thead.</summary>
		[Description("thead")]
		[Tag("thead")]
		thead, 

		/// <summary>The time.</summary>
		[Description("time")]
		[Tag("time")]
		time, 

		/// <summary>The title.</summary>
		[Description("title")]
		[Tag("title")]
		title, 

		/// <summary>The tr.</summary>
		[Description("tr")]
		[Tag("tr")]
		tr, 

		/// <summary>The track.</summary>
		[Description("track")]
		[Tag("track")]
		track, 

		/// <summary>The u.</summary>
		[Description("u")]
		[Tag("u")]
		u, 

		/// <summary>The ul.</summary>
		[Description("ul")]
		[Tag("ul")]
		ul, 

		/// <summary>The var.</summary>
		[Description("var")]
		[Tag("var")]
		var, 

		/// <summary>The video.</summary>
		[Description("video")]
		[Tag("video")]
		video, 

		/// <summary>The wbr.</summary>
		[Description("wbr")]
		[Tag("wbr")]
		wbr
	}

	/// <summary>The tag attribute.</summary>
	public class TagAttribute : Attribute
	{
		#region Fields

		/// <summary>The html tag.</summary>
		private string htmlTag;

		#endregion

		#region Constructors and Destructors

		/// <summary>Initializes a new instance of the <see cref="TagAttribute"/> class.</summary>
		/// <param name="htmlTag">The html tag.</param>
		public TagAttribute(string htmlTag)
		{
			this.htmlTag = htmlTag;
		}

		#endregion

		#region Public Properties

		/// <summary>Gets the html tag.</summary>
		public virtual string HtmlTag
		{
			get
			{
				return this.htmlTag;
			}
		}

		#endregion
	}
}