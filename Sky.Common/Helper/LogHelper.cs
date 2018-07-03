using Sky.Common.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Common.Helper
{
    public class LogHelper
    {
        private static ILogger logger = null;

        public static ILogger Logger
        {
            get
            {
                if (logger == null)
                {
                    logger = new Logger();
                    logger.EnsureInitialized();
                }
                return logger;
            }
        }


        public static void Error(object source, string message)
        {
            Error(source.GetType(), message);
        }

        public static void Error(object source, string message, Exception ex)
        {
            Error(source.GetType(), message, ex);
        }

        public static void Info(object source, string message)
        {
            Logger.Info(source.GetType(), message);
        }

        public static void Info(object source, string message, Exception ex)
        {
            Logger.Info(source.GetType(), message, ex);
        }
    }
}
