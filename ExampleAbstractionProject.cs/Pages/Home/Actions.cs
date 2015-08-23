using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleAbstractionProject.Pages.Home
{
    using UX.Testing.Core;
    using UX.Testing.Core.Controls;
    using UX.Testing.Core.Extensions;
    using UX.Testing.Core.TestFramework;

    public class Actions : Component
    {
        private HomePage page;

        public Actions(HomePage page, Browser browser)
            : base(browser)
        {
            this.page = page;
        }
    }
}
