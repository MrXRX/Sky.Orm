using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Common.Logs
{
    public interface ILogger
    {
        void EnsureInitialized();

        void Error(Type source, string message);
        void Error(Type source, string message, Exception ex);

        void Info(Type source, string message);
        void Info(Type source, string message, Exception ex);

    }
}
