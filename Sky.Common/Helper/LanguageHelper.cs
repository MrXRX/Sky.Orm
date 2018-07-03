using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Common.Helper
{
    public class LanguageHelper
    {
        /// <summary>
        /// 获取当前目录下语言包路径
        /// </summary>
        private static string path = "Language";

        /// <summary>
        /// 获取提示消息
        /// </summary>
        /// <param name="code">消息代码</param>
        /// <param name="language">语言类型</param>
        /// <returns></returns>
        public static string MsgContent(int code, string language)
        {
            if (code <= 0)
            {
                return string.Empty;
            }

            language = String.IsNullOrWhiteSpace(language) ? "zh-cn" : language.ToLower();
            string langPath = string.Empty;
            //选择语言包文件
            switch (language)
            {
                case "en":
                    langPath = path + "\\MsgCode\\en.xml";
                    break;
                case "zh-tw":
                    langPath = path + "\\MsgCode\\zh-tw.xml";
                    break;
                default:
                    langPath = path + "\\MsgCode\\zh-cn.xml";
                    break;
            }
            return XmlHelper.GetValue(code, langPath);
        }

    }
}
