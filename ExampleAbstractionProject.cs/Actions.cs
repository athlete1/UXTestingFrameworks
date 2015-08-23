using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleAbstractionProject
{
    using UX.Testing.Core.Enums;
    using UX.Testing.Core.Extensions;
    using UX.Testing.Core.TestFramework;

    public class Actions
    {
        private readonly Browser browser;

        private BingSite bing;

        public Actions(BingSite bing, Browser browser)
        {
            this.browser = browser;
            this.bing = bing;
        }
    }
}
