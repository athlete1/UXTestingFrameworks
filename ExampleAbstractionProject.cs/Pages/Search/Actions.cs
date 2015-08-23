using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleAbstractionProject.Pages.Search
{
    using UX.Testing.Core;
    using UX.Testing.Core.Controls;
    using UX.Testing.Core.Extensions;
    using UX.Testing.Core.TestFramework;

    public class Actions : Component
    {
        private SearchPage page;

        public Actions(SearchPage page, Browser browser)
            : base(browser)
        {
            this.page = page;
        }
    }
}
