using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Util.BootStrap.Study.HtmlPackage.Extensions
{
    /// <summary>
    /// 枚举扩展
    /// </summary>
    public static class EnumsExtensions
    {
        public static string GetDescription(this Enum instance)
        {
            return GetDescription(instance.GetType(), instance);
        }

        public static string GetDescription(Type type, object member)
        {
            string name = Enum.GetName(type, member);
            FieldInfo fieldInfo = type.GetField(name);

            DescriptionAttribute attriute =
                fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true).FirstOrDefault() as DescriptionAttribute;

            if (attriute == null)
            {
                return fieldInfo.Name;
            }

            return attriute.Description;
        }
    }
}