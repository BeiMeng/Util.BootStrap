namespace Util.BootStrap.Study.HtmlPackage.Builders.Tags {
    /// <summary>
    /// 按钮生成器
    /// </summary>
    public class ButtonBuilder : TagBuilder {
        /// <summary>
        /// 初始化按钮生成器
        /// </summary>
        public ButtonBuilder() : base( "button" ) {
            AddAttribute( "type","button" );
        }
    }
}
