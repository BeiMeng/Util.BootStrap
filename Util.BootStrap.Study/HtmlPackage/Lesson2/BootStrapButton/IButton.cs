using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Util.BootStrap.Study.HtmlPackage.Lesson2.BootStrapButton
{
    public interface IButton:IHtmlString
    {
        IButton Size(ButtonSize size=ButtonSize.Default);
        IButton Color(ButtonColor color=ButtonColor.Default);
        IButton Name(string name = "");
    }
}