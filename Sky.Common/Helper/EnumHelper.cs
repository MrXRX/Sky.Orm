using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Common.Helper
{
    public class EnumHelper
    {
        /// <summary>
        /// 根据枚举的值获取枚举描述
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetEnumDesc(Type type, int? value)
        {
            FieldInfo[] fields = type.GetFields();
            for (int i = 1; i < fields.Length; i++)
            {
                if ((int)System.Enum.Parse(type, fields[i].Name) == value)
                {
                    DescriptionAttribute[] EnumAttributes = (DescriptionAttribute[])fields[i].GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (EnumAttributes.Length > 0)
                    {
                        return EnumAttributes[0].Description;
                    }
                }
            }
            return "";
        }
    }
}
