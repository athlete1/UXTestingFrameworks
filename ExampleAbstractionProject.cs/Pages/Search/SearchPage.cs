using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleAbstractionProject.Pages.Search
{
    using ExampleAbstractionProject.Pages;
    using ExampleAbstractionProject.Pages.Components.SearchWidget;
    using UX.Testing.Core;
    using UX.Testing.Core.Controls;
    using UX.Testing.Core.Extensions;
    using UX.Testing.Core.TestFramework;

    public class SearchPage : Page
    {
        private Actions actions;

        private SearchWidget searchWidget;

        private SummaryModule summary;

        public SearchPage(Browser browser)
            : base(browser, "/search")
        {
            this.actions = new Actions(this, this.Browser);
            this.searchWidget = new SearchWidget(this.Browser);
            this.summary = new SummaryModule(this.Browser);
        }

        public Actions Actions
        {
            get
            {
                this.VerifyIsAtUrl();
                return this.actions;
            }
        }

        public SearchWidget SearchWidget
        {
            get
            {
                this.VerifyIsAtUrl();
                return this.searchWidget;
            }
        }

        public SummaryModule Summary
        {
            get
            {
                this.VerifyIsAtUrl();
                return this.summary;
            }
        }

        public class SummaryModule : Component
        {
            public SummaryModule(Browser browser)
                : base(browser)
            {
            }

            private HtmlDiv container { get { return this.Browser.FindById<HtmlDiv>("b_tween"); } }

            private HtmlSpan span { get { return this.container.FindByClass<HtmlSpan>("sb_count"); } }

            public string Text { get { return this.span.InnerText; } }

            public int Count { get { return Convert.ToInt32(this.Text); } }

            public bool IsVisible()
            {
                return this.Exists() && this.container.IsVisible() && this.span.IsVisible();
            }

            private bool Exists()
            {
                return this.container != null && this.span != null;
            }
        }
    }
}
