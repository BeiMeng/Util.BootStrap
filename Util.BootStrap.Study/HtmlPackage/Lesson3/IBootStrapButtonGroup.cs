namespace Util.BootStrap.Study.HtmlPackage.Lesson3
{
    public interface IBootStrapButtonGroup
    {
        ButtonGroupWrapper Begin();
        void End();
        /// <summary>
        /// 设置为大尺寸
        /// </summary>
        IBootStrapButtonGroup Large();
    }
}