namespace Util.BootStrap.Study.HtmlPackage.Builders.Tags {
    /// <summary>
    /// 标签生成器
    /// </summary>
    public interface ITagBuilder {
        /// <summary>
        /// 获取结果
        /// </summary>
        string GetResult();
        /// <summary>
        /// 获取起始Html
        /// </summary>
        string GetBeginHtml();
        /// <summary>
        /// 获取结束Html
        /// </summary>
        string GetEndHtml();
    }
}
