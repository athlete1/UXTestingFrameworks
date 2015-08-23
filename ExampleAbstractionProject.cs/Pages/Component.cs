using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleAbstractionProject.Pages
{
    using UX.Testing.Core;
    using UX.Testing.Core.Controls;
    using UX.Testing.Core.TestFramework;

    public class Component : ViewBase
    {
        public Component(Browser browser) : base(browser)
        { }

        public Component(Browser browser, bool retry) : base(browser, retry)
        { }

        public Component(Browser browser, int timeout, int interval) : base(browser, timeout, interval)
        { }

        public T FindByATAttribut<T>(T htmlControl, string attributeValue) where T : HtmlControl, new()
        {
            htmlControl.AddAttribute("data-at", attributeValue);
            return this.Find(htmlControl);
        }

        public HtmlDynamic FindByATAttribute(string attributeValue)
        {
            var htmlControl = new HtmlDynamic();
            htmlControl.AddAttribute("data-at", attributeValue);
            return this.Find(htmlControl);
        }

        public IEnumerable<T> FindAllByATAttribut<T>(T htmlControl, string attributeValue) where T : HtmlControl, new()
        {
            htmlControl.AddAttribute("data-at", attributeValue);
            return this.FindAll(htmlControl);
        }

        public IEnumerable<HtmlDynamic> FindAllByATAttribute(string attributeValue)
        {
            var htmlControl = new HtmlDynamic();
            htmlControl.AddAttribute("data-at", attributeValue);
            return this.FindAll(htmlControl);
        }
    }
}
