using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Data.Interface
{
    public interface IDbContextFactory :IDependency
    {
        //获取当前上下文的唯一实例
        DbContext GetCurrentThreadInstance();
    }
}
