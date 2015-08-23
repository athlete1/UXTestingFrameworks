using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleAbstractionProject.Pages
{
    using UX.Testing.Core;
    using UX.Testing.Core.Controls;
    using UX.Testing.Core.Extensions;
    using UX.Testing.Core.TestFramework;

    public class Page : PageBase
    {
        public Page(Browser browser, string url) : base(browser, url)
        { }

        public Page(Browser browser, string url, bool retry) : base(browser, url, retry)
        { }

        public Page(Browser browser, string url, int timeout, int interval) : base(browser, url, timeout, interval)
        { }

        //public string Title { get { return this.Browser.NativeBrowser.CastTo<OpenQA.Selenium.IWebDriver>().Title; } }

        public virtual bool IsAtUrl()
        {
            return this.Browser.WaitForCondition(p => p.Url.Contains(this.Url), 3000, 250);
        }

        public virtual bool IsNotAtUrl()
        {
            return this.Browser.WaitForCondition(p => !p.Url.Contains(this.Url));
        }

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

        protected void VerifyIsAtUrl()
        {
            this.IsAtUrl().ShouldBeTrue("Not on the correct Page.  Expected: '{0}' Actual: '{1}'", this.Url, this.Browser);
        }

    }
}
