using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleAbstractionProject.Pages.Components.SearchWidget
{
    using UX.Testing.Core;
    using UX.Testing.Core.Controls;
    using UX.Testing.Core.Extensions;
    using UX.Testing.Core.TestFramework;

    public class SearchWidget : Component
    {
        public SearchWidget(Browser browser)
            : base(browser)
        {
            this.TextBox = new SearchInputModule(this.Browser);
            this.Button = new SearchButtonModule(this.Browser);
        }

        private HtmlForm form { get { return this.Browser.FindById<HtmlForm>("sb_form"); } }

        public SearchInputModule TextBox { get; private set; }

        public SearchButtonModule Button { get; private set; }

        public bool IsVisible()
        {
            return this.Exists() && this.form.IsVisible();
        }

        private bool Exists()
        {
            return this.form != null;
        }

        public class SearchInputModule : Component
        {
            public SearchInputModule(Browser browser)
                : base(browser)
            {
            }

            private HtmlInputSearch textbox { get { return this.Browser.FindById<HtmlInputSearch>("sb_form_q"); } }

            public string Text
            {
                get
                {
                    return this.textbox.Value;
                }
                set
                {
                    this.textbox.Value = value;
                }
            }

            public bool IsEnabled()
            {
                return this.textbox.IsEnabled();
            }

            public bool IsVisible()
            {
                return this.Exists() && this.textbox.IsVisible();
            }

            private bool Exists()
            {
                return this.textbox != null;
            }
        }

        public class SearchButtonModule : Component
        {
            private event EventHandler Clicked;

            public SearchButtonModule(Browser browser)
                : base(browser)
            {
            }

            private HtmlInputSubmit button { get { return this.Browser.FindById<HtmlInputSubmit>("sb_form_go"); } }

            public void Click()
            {
                this.button.Click();
                this.OnClicked(EventArgs.Empty);
            }

            public bool IsEnabled()
            {
                return this.button.IsEnabled();
            }

            public bool IsVisible()
            {
                return this.Exists() && this.button.IsVisible();
            }

            private bool Exists()
            {
                return this.button != null;
            }

            private void OnClicked(EventArgs e)
            {
                if(this.Clicked != null)
                {
                    this.Clicked(this, e);
                }
            }
        }
    }


}
