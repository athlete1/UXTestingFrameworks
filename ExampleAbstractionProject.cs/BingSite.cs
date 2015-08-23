using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleAbstractionProject
{
    using UX.Testing.Core.TestFramework;

    public class BingSite
    {
        private readonly Browser browser;

        public BingSite(Browser browser)
        {
            this.browser = browser;
            this.Actions = new Actions(this, this.browser);
            this.Home = new Pages.Home.HomePage(browser);
            this.Search = new Pages.Search.SearchPage(browser);
        }

        public Actions Actions { get; private set; }

        public Pages.Home.HomePage Home { get; private set; }

        public Pages.Search.SearchPage Search { get; private set; }
    }
}
