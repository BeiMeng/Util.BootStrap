using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Util.BootStrap.Study.HtmlPackage.Lesson2.BootStrapButton;
using Util.BootStrap.Study.HtmlPackage.Lesson2.BootStrapTextBox;
using Util.BootStrap.Study.HtmlPackage.Lesson3;

namespace Util.BootStrap.Study.HtmlPackage.Lesson2
{
    public static class HtmlHelperExtentions
    {
        public static BootStrapFactory BootStrap(this HtmlHelper helper)
        {
            return new BootStrapFactory(helper.ViewContext.Writer);
        }
    }

    public class BootStrapFactory
    {
        private readonly TextWriter _writer;

        public BootStrapFactory(TextWriter writer)
        {
            _writer = writer;
        }

        public IButton Button()
        {
            return new Button();
        }
        public ITextBox TextBox()
        {
            return new TextBox();
        }

        public BootStrapButtonGroup ButtonGroup()
        {
            return new BootStrapButtonGroup(_writer);
        }
    }
}