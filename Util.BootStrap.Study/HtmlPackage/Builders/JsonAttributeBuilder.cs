using System.Text;
using Util.BootStrap.Study.HtmlPackage.Extensions;

namespace Util.BootStrap.Study.HtmlPackage.Builders {
    /// <summary>
    /// Json属性生成器
    /// </summary>
    public class JsonAttributeBuilder {
        /// <summary>
        /// Json属性生成器
        /// </summary>
        public JsonAttributeBuilder(){
            _builder = new AttributeBuilder( ":","," );
        }

        /// <summary>
        /// 属性生成器
        /// </summary>
        private readonly AttributeBuilder _builder;

        /// <summary>
        /// 是否包含指定项
        /// </summary>
        /// <param name="name">属性名</param>
        public bool Contains( string name ) {
            return _builder.Contains( name );
        }

        /// <summary>
        /// 参数是否为空
        /// </summary>
        public bool IsEmpty {
            get { return _builder.Count == 0; }
        }

        /// <summary>
        /// 添加属性
        /// </summary>
        /// <param name="name">属性名,范例：class</param>
        /// <param name="value">属性值</param>
        public void Add( string name, bool value ) {
            Add( name, value.ToString().ToLower() );
        }

        /// <summary>
        /// 添加属性
        /// </summary>
        /// <param name="name">属性名,范例：class</param>
        /// <param name="value">属性值</param>
        public void Add( string name, bool? value ) {
            if ( value == null )
                return;
            Add( name, value.SafeValue() );
        }

        /// <summary>
        /// 添加属性
        /// </summary>
        /// <param name="name">属性名,范例：class</param>
        /// <param name="value">属性值</param>
        /// <param name="quotes">属性值引号</param>
        public void Add( string name, string value,string quotes = "" ) {
            if ( string.IsNullOrWhiteSpace(value) )
                return;
            _builder.Update( name, value, ",", quotes );
        }

        /// <summary>
        /// 添加属性
        /// </summary>
        /// <param name="name">属性名,范例：class</param>
        /// <param name="value">属性值</param>
        /// <param name="isAddQuote">是否给值添加单引号</param>
        public void Add( string name, string value, bool isAddQuote ) {
            Add( name, value, GetQuotes( isAddQuote ) );
        }

        /// <summary>
        /// 获取值
        /// </summary>
        private string GetQuotes( bool isAddQuote ) {
            return isAddQuote ? "'" : "";
        }

        /// <summary>
        /// 添加属性列表
        /// </summary>
        /// <param name="values">属性列表</param>
        public void Add( string values ) {
            if (string.IsNullOrWhiteSpace(values))
                return;
            _builder.Add( values );
        }

        /// <summary>
        /// 更新属性,不存在则添加
        /// </summary>
        /// <param name="name">属性名</param>
        /// <param name="value">属性值</param>
        /// <param name="isAddQuote">是否给值添加引号</param>
        public void Update( string name, string value, bool isAddQuote = false ) {
            _builder.Update( name,value, "", GetQuotes( isAddQuote ) );
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        public string GetResult() {
            return _builder.GetResult();
        }

        /// <summary>
        /// 获取Json
        /// </summary>
        public string GetJson() {
            var param = GetResult();
            if (string.IsNullOrWhiteSpace(param))
                return string.Empty;
            StringBuilder result = new StringBuilder();
            result.Append( "{" );
            result.Append( param );
            result.Append( "}" );
            return result.ToString();
        }
    }
}
