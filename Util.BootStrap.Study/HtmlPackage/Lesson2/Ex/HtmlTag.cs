using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace LearnUtils.Commons
{
    public interface IHtmlTag
    {
        void SetAttiValue(string attiName, string vaName, Enum inst);
    }

    /// <summary>
    /// HTML标签
    /// </summary>
    public class HtmlTag : IHtmlString
    {
        public HtmlTag()
        {
            Name = "";
            Value = "";
            IsSelfClosed = false;
            Attis = new List<HtmlAtti>();
            Childs = new List<HtmlTag>();
        }

        /// <summary>
        /// 标签名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 标签值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 是否自关闭
        /// </summary>
        public bool IsSelfClosed { get; set; }

        /// <summary>
        /// 节点属性
        /// </summary>

        public List<HtmlAtti> Attis { get; set; }

        /// <summary>
        /// 子节点
        /// </summary>

        public List<HtmlTag> Childs { get; set; }

        public string ToHtmlString()
        {
            return ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            ToString(sb);
            return sb.ToString();
        }

        public string ToString(StringBuilder sb)
        {
            sb.Append("<");
            sb.Append(Name);

            if (Attis != null)
            {
                foreach (var atti in Attis)
                {
                    sb.Append(" ");
                    atti.ToString(sb);
                }
            }

            if (IsSelfClosed) sb.Append("/>");
            else
            {
                sb.Append(">");
                sb.Append(Value);
                if (Childs != null)
                {
                    foreach (var child in Childs)
                    {
                        sb.AppendLine();
                        child.ToString(sb);
                    }
                }
                sb.Append("</");
                sb.Append(Name);
                sb.Append(">");
            }
            return sb.ToString();
        }

        /// <summary>
        /// 获取属性
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public HtmlAtti GetAtti(string name)
        {
            foreach (var atti in Attis)
            {
                if (atti.Name == name) { return atti; }
            }
            return null;
        }

        public HtmlAtti NewOrGetAtti(string name)
        {
            HtmlAtti atti = GetAtti(name);
            if (atti == null)
            {
                atti = new HtmlAtti();
                atti.Name = name;
                this.Attis.Add(atti);
            }
            return atti;
        }

        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public HtmlAtti NewOrSetAtti(string name, string value)
        {
            HtmlAtti atti = NewOrGetAtti(name);
            atti.Values.Clear();
            atti.NewOrGetAttiValue(name).Value = value;
            return atti;
        }

        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <param name="attiName"></param>
        /// <param name="vaName"></param>
        /// <param name="inst"></param>
        public void SetAttiValue(string attiName, string vaName, Enum inst)
        {
            string desp = inst.GetDescription();
            HtmlAtti atti = this.NewOrGetAtti(attiName);
            atti.SetValue(vaName, desp);
        }
    }



    public class HtmlAtti
    {
        public HtmlAtti()
        {
            Name = "";
            Values = new List<HtmlAttiValue>();
        }

        public string Name { get; set; }
        public List<HtmlAttiValue> Values { get; set; }

        public void ToString(StringBuilder sb)
        {
            sb.Append(Name);
            sb.Append("=\"");
            int idx = 0;
            foreach (var value in Values)
            {
                if(idx > 0) sb.Append(" ");
                value.ToString(sb);
                idx++;
            }
            sb.Append("\"");
        }

        public HtmlAttiValue GetAttiValue(string name)
        {
            foreach (var item in Values)
            {
                if (item.Name == name) return item;
            }
            return null;
        }
        public HtmlAttiValue NewOrGetAttiValue(string name)
        {
            HtmlAttiValue va = GetAttiValue(name);
            if (va != null) return va;
            va = new HtmlAttiValue();
            va.Name = name;
            Values.Add(va);
            return va;
        }

        public void SetValue(string name, string value)
        {
            HtmlAttiValue va = NewOrGetAttiValue(name);
            va.Value = value;
        }
    }

    public class HtmlAttiValue
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 是否有分号
        /// </summary>
        public bool ShowSemicolon { get; set; }

        public bool ShowName { get; set; }

        public HtmlAttiValue()
        {
            Name = "";
            Value = "";
            ShowSemicolon = false;
            ShowName = false;
        }

        public void ToString(StringBuilder sb)
        {
            if (ShowName)
            {
                sb.Append(Name);
                sb.Append(":");
            }
            sb.Append(Value);
            if (ShowSemicolon) sb.Append(";");
        }
    }
}