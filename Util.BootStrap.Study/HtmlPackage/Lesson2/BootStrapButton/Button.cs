using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Util.BootStrap.Study.HtmlPackage.Extensions;

namespace Util.BootStrap.Study.HtmlPackage.Lesson2.BootStrapButton
{
    public class Button : IButton
    {
        private string _htmltag = "<button class='{0}' type='button'>{1}</button>";
        private string _strclass = string.Empty;
        private string _name = string.Empty;

        public Button()
        {
            _strclass = _strclass + " " + ButtonSize.Default.GetDescription();
            //_strclass = _strclass + " " + ButtonColor.Default.GetDescription();
        }
        public string ToHtmlString()
        {
            _htmltag = string.Format(_htmltag, _strclass,_name);
            return _htmltag;
        }
        public IButton Name(string name = "")
        {
            _name = name;
            return this;
        }
        public IButton Size(ButtonSize size = ButtonSize.Default)
        {
            _strclass = _strclass + " " + size.GetDescription();
            return this;
        }

        public IButton Color(ButtonColor color = ButtonColor.Default)
        {
            _strclass = _strclass + " " + color.GetDescription();
            return this;
        }
    }
}