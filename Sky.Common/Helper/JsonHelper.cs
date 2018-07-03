using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Common.Helper
{
    public class JsonHelper
    {
        /// <summary>
        /// 实体对象转化json字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SerializeObject(object value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            return JsonConvert.SerializeObject(value);
        }

        /// <summary>
        /// json 字符串转化为实体对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T aa<T>(string value) where T : class
        {
            if (!String.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}
