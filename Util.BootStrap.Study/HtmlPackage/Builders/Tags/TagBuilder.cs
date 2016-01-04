using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util.BootStrap.Study.HtmlPackage.Extensions;

namespace Util.BootStrap.Study.HtmlPackage.Builders.Tags {
    /// <summary>
    /// 标签生成器
    /// </summary>
    public class TagBuilder : ITagBuilder {
        /// <summary>
        /// 初始化标签生成器
        /// </summary>
        /// <param name="tagName">标签名称，范例：div</param>
        /// <param name="hasEnd">是否有结束标签</param>
        public TagBuilder( string tagName, bool hasEnd = true ) {
            TagName = tagName;
            _childBuilders = new List<ITagBuilder>();
            HasEnd = hasEnd;
        }

        /// <summary>
        /// 子标签生成器列表
        /// </summary>
        private readonly List<ITagBuilder> _childBuilders;
        /// <summary>
        /// 父标签生成器
        /// </summary>
        private ITagBuilder _parentBuilder;

        private AttributeBuilder _attributeBuilder;
        /// <summary>
        /// 属性生成器
        /// </summary>
        private AttributeBuilder AttributeBuilder {
            get { return _attributeBuilder ?? ( _attributeBuilder = new AttributeBuilder() ); }
        }

        /// <summary>
        /// 标签名称
        /// </summary>
        protected string TagName { get; set; }

        /// <summary>
        /// 是否有结束标签
        /// </summary>
        protected bool HasEnd { get; set; }

        /// <summary>
        /// 标签前Html
        /// </summary>
        private string BeforeHtml { get; set; }

        /// <summary>
        /// 标签后Html
        /// </summary>
        private string AfterHtml { get; set; }

        /// <summary>
        /// 添加属性
        /// </summary>
        /// <param name="name">属性名,范例：class</param>
        /// <param name="value">属性值</param>
        public void AddAttribute( string name, string value ) {
            AttributeBuilder.Add( name, value );
        }

        /// <summary>
        /// 更新属性
        /// </summary>
        /// <param name="name">属性名,范例：class</param>
        /// <param name="value">属性值</param>
        public void UpdateAttribute( string name, string value ) {
            AttributeBuilder.Update( name, value );
        }

        /// <summary>
        /// 移除属性
        /// </summary>
        /// <param name="name">属性名,范例：class</param>
        public void RemoveAttribute( string name ) {
            AttributeBuilder.Remove( name );
        }

        /// <summary>
        /// 添加style属性
        /// </summary>
        /// <param name="name">style属性名</param>
        /// <param name="value">style属性值</param>
        public void AddStyle( string name, string value ) {
            AttributeBuilder.AddStyle( name, value );
        }

        /// <summary>
        /// 添加class属性
        /// </summary>
        /// <param name="class">class属性值</param>
        public void AddClass( string @class ) {
            AttributeBuilder.AddClass( @class );
        }

        /// <summary>
        /// 更新class属性
        /// </summary>
        /// <param name="class">class属性</param>
        public void UpdateClass( string @class ) {
            AttributeBuilder.UpdateClass( @class );
        }

        /// <summary>
        /// 移除指定class
        /// </summary>
        /// <param name="class">class值</param>
        public void RemoveClass( string @class ) {
            AttributeBuilder.RemoveClass( @class );
        }

        /// <summary>
        /// 添加data-属性
        /// </summary>
        /// <param name="name">data属性名，范例toggle,结果为data-toggle</param>
        /// <param name="value">属性值</param>
        public void AddDataAttribute( string name, string value ) {
            AttributeBuilder.AddDataAttribute( name, value );
        }

        /// <summary>
        /// 添加data-options属性
        /// </summary>
        /// <param name="name">option属性名</param>
        /// <param name="value">option属性值</param>
        /// <param name="isAddQuote">是否为值添加单引号</param>
        public void AddDataOption( string name, string value, bool isAddQuote = false ) {
            AttributeBuilder.AddDataOption( name, value, isAddQuote );
        }

        /// <summary>
        /// 添加data-options属性
        /// </summary>
        /// <param name="name">option属性名</param>
        /// <param name="value">option属性值</param>
        public void AddDataOption( string name, bool value ) {
            AttributeBuilder.AddDataOption( name, value );
        }

        /// <summary>
        /// 添加data-options属性
        /// </summary>
        /// <param name="name">option属性名</param>
        /// <param name="value">option属性值</param>
        public void AddDataOption( string name, bool? value ) {
            AttributeBuilder.AddDataOption( name, value );
        }

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="name">属性名</param>
        public string Get( string name ) {
            return AttributeBuilder.Get( name );
        }

        /// <summary>
        /// 在标签前添加组件
        /// </summary>
        /// <param name="tagBuilder">标签生成器</param>
        public void AddBefore( ITagBuilder tagBuilder ) {
            BeforeHtml += tagBuilder.GetResult();
        }

        /// <summary>
        /// 更新标签前组件
        /// </summary>
        /// <param name="tagBuilder">标签生成器</param>
        public void UpdateBefore( ITagBuilder tagBuilder ) {
            BeforeHtml = tagBuilder.GetResult();
        }

        /// <summary>
        /// 在标签后添加组件
        /// </summary>
        /// <param name="tagBuilder">标签生成器</param>
        public void AddAfter( ITagBuilder tagBuilder ) {
            AfterHtml += tagBuilder.GetResult();
        }

        /// <summary>
        /// 更新标签后组件
        /// </summary>
        /// <param name="tagBuilder">标签生成器</param>
        public void UpdateAfter( ITagBuilder tagBuilder ) {
            AfterHtml = tagBuilder.GetResult();
        }

        /// <summary>
        /// 添加标签内部Html
        /// </summary>
        /// <param name="html">Html</param>
        public void AddInnerHtml( string html ) {
            AddChild( new HtmlStringBuilder( html ) );
        }

        /// <summary>
        /// 添加子标签生成器
        /// </summary>
        /// <param name="childBuilder">子标签生成器</param>
        public void AddChild( ITagBuilder childBuilder ) {
            if ( childBuilder == null )
                return;
            _childBuilders.Add( childBuilder );
        }

        /// <summary>
        /// 设置父标签生成器
        /// </summary>
        /// <param name="parentBuilder">父标签生成器</param>
        public void SetParent( ITagBuilder parentBuilder ) {
            _parentBuilder = parentBuilder;
        }

        /// <summary>
        /// 清除外围html
        /// </summary>
        public void ClearOuterHtml() {
            _parentBuilder = null;
            BeforeHtml = string.Empty;
            AfterHtml = string.Empty;
        }

        /// <summary>
        /// 是否为空标签
        /// </summary>
        public bool IsEmpty {
            get { return GetResult() == GetDefaultTag(); }
        }

        /// <summary>
        /// 获取默认标签
        /// </summary>
        private string GetDefaultTag() {
            if ( HasEnd )
                return string.Format( "<{0}></{0}>", TagName );
            return string.Format( "<{0}/>", TagName );
        }

        /// <summary>
        /// 获取Html结果
        /// </summary>
        public override string ToString() {
            return GetResult();
        }

        /// <summary>
        /// 获取Html结果
        /// </summary>
        public virtual string GetResult() {
            GetResultBefore();
            var html = new StringBuilder();
            html.AppendFormat( "{0}{1}{2}", GetBeginHtml(), GetInnerHtml(), GetEndHtml() );
            return html.ToString();
        }

        /// <summary>
        /// 获取结果前操作
        /// </summary>
        protected virtual void GetResultBefore() {
        }

        /// <summary>
        /// 获取起始Html
        /// </summary>
        public string GetBeginHtml() {
            StringBuilder result = new StringBuilder();
            result.Append( GetParentBeginTag() );
            result.Append( BeforeHtml );
            result.Append( GetBeginTag() );
            return result.ToString();
        }

        /// <summary>
        /// 获取父组件的开始标签
        /// </summary>
        protected string GetParentBeginTag() {
            if ( _parentBuilder == null )
                return string.Empty;
            return _parentBuilder.GetBeginHtml();
        }

        /// <summary>
        /// 获取起始标签
        /// </summary>
        public string GetBeginTag() {
            if ( HasEnd )
                return string.Format( "<{0}>", GetBeginTagOptions() );
            return string.Format( "<{0}/>", GetBeginTagOptions() );
        }

        /// <summary>
        /// 获取开始标签及配置项
        /// </summary>
        protected string GetBeginTagOptions() {
            var options = GetOptions();
            return string.Format( "{0}{1}", TagName, string.IsNullOrWhiteSpace(options) ? "" : " " + options );
        }

        /// <summary>
        /// 获取配置项
        /// </summary>
        public virtual string GetOptions() {
            return AttributeBuilder.ToString();
        }

        /// <summary>
        /// 获取标签内部Html
        /// </summary>
        public virtual string GetInnerHtml() {
            if ( _childBuilders.Count == 0 )
                return string.Empty;
            return _childBuilders.Select( t => t.GetResult() ).Splice( "", "" );
        }

        /// <summary>
        /// 获取结束Html
        /// </summary>
        public string GetEndHtml() {
            StringBuilder result = new StringBuilder();
            result.AppendFormat( GetEndTag() );
            result.Append( AfterHtml );
            result.Append( GetParentEndTag() );
            return result.ToString();
        }

        /// <summary>
        /// 获取结束标签
        /// </summary>
        public string GetEndTag() {
            return HasEnd ? string.Format( "</{0}>", TagName ) : string.Empty;
        }

        /// <summary>
        /// 获取父组件的结束标签
        /// </summary>
        protected string GetParentEndTag() {
            return _parentBuilder == null ? string.Empty : _parentBuilder.GetEndHtml();
        }
    }
}
