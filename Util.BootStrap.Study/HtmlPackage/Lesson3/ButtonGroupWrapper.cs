using System;
using Util.BootStrap.Study.HtmlPackage.Lesson2.BootStrapButton;

namespace Util.BootStrap.Study.HtmlPackage.Lesson3
{
    public class ButtonGroupWrapper : IDisposable
    {
        private readonly IBootStrapButtonGroup _bootStrapButtonGroup;
        public ButtonGroupWrapper( IBootStrapButtonGroup bootStrapButtonGroup)
        {
            this._bootStrapButtonGroup = bootStrapButtonGroup;
        }

        public IButton Button()
        {
            return new Button();
        }

        public void Dispose()
        {
            _bootStrapButtonGroup.End();
        }
    }
}