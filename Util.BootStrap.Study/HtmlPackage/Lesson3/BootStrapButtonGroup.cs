using System;
using System.IO;

namespace Util.BootStrap.Study.HtmlPackage.Lesson3
{
    public class BootStrapButtonGroup:IBootStrapButtonGroup
    {
        private readonly TextWriter _writer;

        public BootStrapButtonGroup(TextWriter writer)
        {
            _writer = writer;
        }

        public ButtonGroupWrapper Begin()
        {
            string beginHtml = "<div style='background:green'>";
            _writer.Write(beginHtml);
            return new ButtonGroupWrapper(this);
        }

        public void End()
        {
            string endHtml = "</div>";
            _writer.Write(endHtml);
        }

        public IBootStrapButtonGroup Large()
        {
            throw new NotImplementedException();
        }
    }
}