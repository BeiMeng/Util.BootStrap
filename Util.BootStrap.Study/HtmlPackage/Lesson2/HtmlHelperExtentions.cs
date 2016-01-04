using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Util.BootStrap.Study.HtmlPackage.Lesson2.BootStrapButton;
using Util.BootStrap.Study.HtmlPackage.Lesson2.BootStrapTextBox;

namespace Util.BootStrap.Study.HtmlPackage.Lesson2
{
    public static class HtmlHelperExtentions
    {
        public static BootStrapFactory BootStrap(this HtmlHelper helper)
        {
            return new BootStrapFactory();
        }
    }

    public class BootStrapFactory
    {
        public IButton Button()
        {
            return new Button();
        }
        public ITextBox TextBox()
        {
            return new TextBox();
        }
    }
}