using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UX.Testing.Core.Controls;

namespace UX.Testing.Core.Extensions
{
    public static class EnumExtensions
    {
        public static string GetHtmlTag(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            TagAttribute[] attributes =
                (TagAttribute[])fi.GetCustomAttributes(typeof(TagAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].HtmlTag;
            else
                return value.ToString();
        }
    }
}
