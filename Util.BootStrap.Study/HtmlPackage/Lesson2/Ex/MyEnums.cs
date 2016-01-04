using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace LearnUtils.Commons
{
    public static class MyEnums
    {
        public static string GetDescription(this Enum inst)
        {
            Type type = inst.GetType();
            MemberInfo[] memInfo = type.GetMember(inst.ToString());

            if (null != memInfo && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (null != attrs && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return "";
        }
    }
}