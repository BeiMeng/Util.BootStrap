using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Util.BootStrap.Study.HtmlPackage.Lesson2.BootStrapButton
{
    public enum ButtonColor
    {
        [Description("btn-default")]
        Default,

        [Description("btn-primary")]
        Primary,

        [Description("btn-danger")]
        Danger,

        [Description("btn-danger")]
        Warning,

        [Description("btn-success")]
        Success,

        [Description("btn-info")]
        Info,

        [Description("btn-inverse")]
        Inverse
    }
}