using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Util.BootStrap.Study.HtmlPackage.Lesson2.BootStrapTextBox
{
    public class TextBox : ITextBox
    {
        public string ToHtmlString()
        {
            return "<input type='text'/>";
        }
    }
}