using Sky.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Data.Realize
{
    public class UnitOfWork : IUnitOfWork
    {
        protected DbContext dbContext;

        public UnitOfWork(DbContext context)
        {
            dbContext = context;
            this.OriginalTransaction = dbContext.Database.BeginTransaction();

        }

        /// <summary>  
        /// 获取当前单元操作是否已被提交  
        /// </summary>  
        public bool IsCommitted { get; set; }

        /// <summary>
        /// 提交一个事务
        /// </summary>
        /// <returns></returns>
        public int Commit()
        {
            if (IsCommitted || originalTransaction == null)
            {
                return 0;
            }
            int result = dbContext.SaveChanges();
            IsCommitted = true;
            originalTransaction.Commit();
            return result;
        }

        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            dbContext = null;
            GC.SuppressFinalize(this);
        }

        /// <summary>  
        ///     把当前单元操作回滚成未提交状态  
        /// </summary>  
        public void Rollback()
        {
            IsCommitted = false;
            originalTransaction.Rollback();
            originalTransaction.Dispose();
        }


        #region 属性


        private DbContextTransaction originalTransaction;
        public DbContextTransaction OriginalTransaction
        {
            get { return originalTransaction; }
            set { originalTransaction = value; }
        }

        #endregion

    }
}
