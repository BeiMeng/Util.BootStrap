using System.Web;
using System.Web.Mvc;

namespace Util.BootStrap.Study.HtmlPackage.Lesson1
{
    public static class HtmlHelperExtentions
    {
        public static MvcHtmlString TextBoxEx(this HtmlHelper helper)
        {
            return MvcHtmlString.Create("<input type='text'/>");
        }
        public static TextBox TextBoxExAa(this HtmlHelper helper)
        {
            return new TextBox();
        }
        public static HtmlString TextBoxExBb(this HtmlHelper helper)
        {
            return new HtmlString("<input type='text'/>");
        }
    }

    public interface ITextBox : IHtmlString
    {
        
    }

    public class TextBox : ITextBox
    {
        public string ToHtmlString()
        {
            return "<input type='text'/>";
        }
    }
}