using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Common.Logs
{
    public class Logger : ILogger
    {
        private Dictionary<Type, ILog> _loggers = new Dictionary<Type, ILog>();
        private bool _logInitialized = false;
        private object _lock = new object();

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="source">来源</param>
        /// <param name="message">消息体</param>
        public void Error(Type source, string message)
        {
            getLogger(source).Error(FormatException(message, null));
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="source">来源</param>
        /// <param name="message">消息体</param>
        /// <param name="ex">错误对象</param>
        public void Error(Type source, string message, Exception ex)
        {
            getLogger(source).Error(FormatException(message, ex));
        }

        /// <summary>
        /// 信息日志
        /// </summary>
        /// <param name="source">来源</param>
        /// <param name="message">消息体</param>
        public void Info(Type source, string message)
        {
            getLogger(source).Info(FormatException(message, null));
        }

        /// <summary>
        /// 信息日志
        /// </summary>
        /// <param name="source">来源</param>
        /// <param name="message">消息体</param>
        /// <param name="ex">错误对象</param>
        public void Info(Type source, string message, Exception ex)
        {
            getLogger(source).Info(FormatException(message, ex));
        }

        /// <summary>
        /// 初始化日志对象
        /// </summary>
        public void EnsureInitialized()
        {
            //避免重复初始化
            if (!_logInitialized)
            {
                initialize();
                _logInitialized = true;
            }
        }

        /// <summary>
        /// 查找日志记录器
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private ILog getLogger(Type source)
        {
            lock (_lock)
            {
                //如果已经存在，则不重复创建日志记录器
                if (_loggers.ContainsKey(source))
                {
                    return _loggers[source];
                }
                else
                {
                    ILog logger = LogManager.GetLogger(source);
                    _loggers.Add(source, logger);
                    return logger;
                }
            }
        }

        /// <summary>
        /// 往 AssemblyInfo类中注入日志相关的东西
        /// </summary>
        private void initialize()
        {
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"config\log4net.config");
            if (!File.Exists(logFilePath))
            {
                logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\log4net.config");
            }
            XmlConfigurator.ConfigureAndWatch(new FileInfo(logFilePath));
        }

        /// <summary>
        /// 格式化错误消息体
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private string FormatException(string message, Exception ex)
        {
            if (ex == null)
            {
                return message;
            }

            //拼接错误消息，
            message = string.Format("{0}{1}{2}\n{3}", message, message ?? "\n\n", ex.Message, ex.StackTrace);
            if (ex.InnerException != null)
            {
                message = FormatException(message, ex.InnerException);
            }
            return message;
        }

    }
}
