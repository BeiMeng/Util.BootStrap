namespace Util.BootStrap.Study.HtmlPackage.Builders.Tags {
    /// <summary>
    /// Html字符串生成器
    /// </summary>
    public class HtmlStringBuilder : ITagBuilder {
        /// <summary>
        /// 初始化Html字符串生成器
        /// </summary>
        /// <param name="html">html字符串</param>
        public HtmlStringBuilder( string html ) {
            _html = html;
        }

        /// <summary>
        /// html字符串
        /// </summary>
        private readonly string _html;

        /// <summary>
        /// 获取Html结果
        /// </summary>
        public string GetResult() {
            return _html;
        }

        /// <summary>
        /// 获取起始Html
        /// </summary>
        public string GetBeginHtml() {
            return string.Empty;
        }

        /// <summary>
        /// 获取结束Html
        /// </summary>
        public string GetEndHtml() {
            return string.Empty;
        }
    }
}
