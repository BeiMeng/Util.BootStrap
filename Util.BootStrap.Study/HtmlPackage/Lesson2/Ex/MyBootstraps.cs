
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LearnUtils.Commons
{
    public static class MyHtmls
    {
        public static BootStrapButton BootStrapButton(this HtmlHelper html, string text)
        {
            return new BootStrapButton(text);
        }

        public static BootStrapInput BootStrapInput(this HtmlHelper html, string text)
        {
            return new BootStrapInput(text);
        }

        public static T StyleEx<T>(this T btn, ButtonStyles style) where T : class, IBootstrapButon
        {
            btn.SetAttiValue("class", "ButtonStyles", style);
            return btn;
        }

        public static T SizeEx<T>(this T btn, ButtonSizes size) where T : class, IBootstrapButon
        {
            btn.SetAttiValue("class", "ButtonSizes", size);
            return btn;
        }

    }

    public enum ButtonStyles
    {
        /// <summary>
        /// 默认/标准按钮
        /// </summary>
        [Description("btn-default")] Default,

        /// <summary>
        /// 原始按钮样式（未被操作）
        /// </summary>
        [Description("btn-primary")] Primary,

        /// <summary>
        /// 表示成功的动作
        /// </summary>
        [Description("btn-sucess")] Sucess,

        /// <summary>
        /// 该样式可用于要弹出信息的按钮
        /// </summary>
        [Description("btn-info")] Info,


        /// <summary>
        /// 表示需要谨慎操作的按钮
        /// </summary>
        [Description("btn-warning")] Warning,

        /// <summary>
        /// 表示一个危险动作的按钮操作
        /// </summary>
        [Description("btn-danger")] Danger,

        /// <summary>
        /// 让按钮看起来像个链接 (仍然保留按钮行为)
        /// </summary>
        [Description("btn-link")] Link,
    }

    public enum ButtonSizes
    {
        [Description("btn-lg")] Lg,

        [Description("btn-sm")] Sm,

        [Description("btn-xs")] Xs,

        [Description("btn-block")] Block,
    }

    public interface IBootstrapButon : IHtmlTag
    {

    }

    public class BootStrapButton : HtmlTag, IBootstrapButon
    {

        public BootStrapButton(string text)
        {
            base.Value = text;
            base.Name = "button";
            base.NewOrSetAtti("type", "button");
            base.NewOrSetAtti("class", "btn");
        }


        public BootStrapButton Style(ButtonStyles style)
        {
            base.SetAttiValue("class", "ButtonStyles", style);
            return this;
        }

        public BootStrapButton Size(ButtonSizes size)
        {
            base.SetAttiValue("class", "ButtonSizes", size);

            return this;
        }

    }

    public class BootStrapInput : HtmlTag, IBootstrapButon
    {
        public BootStrapInput(string text)
        {
            base.Value = text;
            base.Name = "input";
            base.NewOrSetAtti("type", "textbox");
            base.NewOrSetAtti("class", "btn");
        }
    }
}
