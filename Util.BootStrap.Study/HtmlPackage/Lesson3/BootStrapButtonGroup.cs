using System;
using System.IO;

namespace Util.BootStrap.Study.HtmlPackage.Lesson3
{
    public class BootStrapButtonGroup:IDisposable
    {
        private readonly TextWriter _writer;

        public BootStrapButtonGroup(TextWriter writer)
        {
            _writer = writer;
            string beginHtml = "<div style='background:green'>";
            _writer.Write(beginHtml);
        }

        public void Dispose()
        {
            string endHtml = "</div>";
            _writer.Write(endHtml);
        }
    }
}