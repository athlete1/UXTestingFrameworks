using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleAbstractionProject.Pages.Home
{
    using ExampleAbstractionProject.Pages;
    using ExampleAbstractionProject.Pages.Components.SearchWidget;
    using UX.Testing.Core;
    using UX.Testing.Core.Controls;
    using UX.Testing.Core.Extensions;
    using UX.Testing.Core.TestFramework;

    public class HomePage : Page
    {
        private Actions actions;

        private SearchWidget searchWidget;

        public HomePage(Browser browser)
            : base(browser, "/")
        {
            this.actions = new Actions(this, this.Browser);
            this.searchWidget = new SearchWidget(this.Browser);
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
    }
}
