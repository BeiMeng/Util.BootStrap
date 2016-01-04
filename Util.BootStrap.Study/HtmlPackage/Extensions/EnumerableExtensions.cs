using System.Collections.Generic;
using Util.BootStrap.Study.HtmlPackage.Commom;

namespace Util.BootStrap.Study.HtmlPackage.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// 转换为用分隔符拼接的字符串
        /// </summary>
        /// <typeparam name="T">集合元素类型</typeparam>
        /// <param name="list">集合</param>
        /// <param name="quotes">引号，默认不带引号，范例：单引号 "'"</param>
        /// <param name="separator">分隔符，默认使用逗号分隔</param>
        public static string Splice<T>(this IEnumerable<T> list, string quotes = "", string separator = ",")
        {
            return CommomHelper.Splice(list, quotes, separator);
        }
    }
}