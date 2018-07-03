using Sky.Data.Interface;
using Sky.IRepository;
using Sky.Repository.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Repository.ContextRepository
{
    public class DbContextFactory : IDbContextFactory
    {
        /// <summary>
        /// 创建EF上下文对象,已存在就直接取,不存在就创建,保证线程内是唯一。
        /// </summary>
        public DbContext GetCurrentThreadInstance()
        {
            return db;
        }

        private DbContext db
        {
            get
            {
                DbContext dbContext = (DbContext)CallContext.GetData("SkyDbContext");
                if (dbContext == null)
                {
                    dbContext = new SkyDbContext();
                    CallContext.SetData("SkyDbContext", dbContext);
                }
                return dbContext;
            }

        }
    }
}
