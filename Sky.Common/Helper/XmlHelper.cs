using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sky.Common.Helper
{
    /// <summary>
    /// Xml帮助类
    /// </summary>
    public class XmlHelper
    {
        /// <summary>
        /// 加载Xml文档
        /// </summary>
        /// <param name="path">文件相对路径</param>
        /// <returns></returns>
        public static XElement XmlLoad(string path)
        {
            //获取当前指定目录下的文件
            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
            XElement xml = null;
            var cacheXml = HttpCacheHelper.GetCache(path);
            if (cacheXml == null)
            {
                xml = XElement.Load(path);
                HttpCacheHelper.SetCache(path, xml, new TimeSpan(1, 0, 0, 0));
            }
            else
            {
                xml = (XElement)cacheXml;
            }
            return xml;
        }

        /// <summary>
        /// 读取指定节点的值
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetValue(int key, string path)
        {
            string result = string.Empty;
            XElement xml = XmlLoad(path);
            if (xml != null)
            {
                var attribute = xml.Elements("MsgCodeKey").Where(a => (int)a.Attribute("Key") == key).FirstOrDefault();
                result = attribute?.Value;
            }
            return result;
        }
    }
}
