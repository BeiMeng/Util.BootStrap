using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Util.BootStrap.Study.HtmlPackage.Builders.Tags;
using Util.BootStrap.Study.HtmlPackage.Extensions;

namespace Util.BootStrap.Study.HtmlPackage.Lesson2.BootStrapButton
{
    public class Button : IButton
    {
        //private string _htmltag = "<button class='{0}' type='button'>{1}</button>";
        //private string _strclass = string.Empty;
        //private string _name = string.Empty;
        public Button()
        {
            //_strclass = _strclass + " " + ButtonSize.Default.GetDescription();
            //_strclass = _strclass + " " + ButtonColor.Default.GetDescription();
        }
        private ButtonBuilder _builder;
        /// <summary>
        /// 标签生成器
        /// </summary>
        protected ButtonBuilder Builder
        {
            get { return _builder ?? (_builder = new ButtonBuilder()); }
        }

        /// <summary>
        /// 修改属性
        /// </summary>
        /// <param name="name">属性名,范例：class</param>
        /// <param name="value">属性值</param>
        public Button UpdateAttribute(string name, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return This();
            Builder.UpdateAttribute(name, value);
            return This();
        }
        /// <summary>
        /// 返回组件本身
        /// </summary>
        protected Button This()
        {
            return (Button)((object)this);
        }
        public string ToHtmlString()
        {
            return Builder.GetResult();
            //_htmltag = string.Format(_htmltag, _strclass,_name);
            // return _htmltag;
        }
        public IButton Name(string name = "")
        {
            //_name = name;
            UpdateAttribute("name", name);
            return this;
        }
        public IButton Size(ButtonSize size = ButtonSize.Default)
        {
            //_strclass = _strclass + " " + size.GetDescription();
            Builder.AddClass(size.GetDescription());
            return this;
        }

        public IButton Color(ButtonColor color = ButtonColor.Default)
        {
            //_strclass = _strclass + " " + color.GetDescription();
            Builder.AddClass(color.GetDescription());
            return this;
        }
    }
}