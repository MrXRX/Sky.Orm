using EntityFramework.Extensions;
using Sky.Data.Interface;
using Sky.Data.Realize;
using Sky.IRepository;
using Sky.Model.Model.PaggingModel;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Sky.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        #region 数据库上下文
        private DbContext BaseDBContext;
        private DbSet<T> BaseTable;
        private IUnitOfWork _unitOfWork;
        public BaseRepository(IDbContextFactory dbContextFactory)
        {
            BaseDBContext = dbContextFactory.GetCurrentThreadInstance();
            BaseTable = BaseDBContext.Set<T>();
        }

        /// <summary>
        /// Unit of Work
        /// 工作单元
        /// </summary>
        public IUnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
            set { _unitOfWork = value; }
        }
        #endregion


        #region 添加
        /// <summary>
        /// 单个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool Add(T entity)
        {
            if (entity == null)
            {
                return false;
            }
            BaseTable.Add(entity);
            if (UnitOfWork != null)
            {
                UnitOfWork.IsCommitted = false;
                return true;
            }
            return this.SavaChange();
        }

        /// <summary>
        /// 多个实体
        /// </summary>
        /// <param name="entityList"></param>
        /// <returns></returns>
        public virtual bool AddList(List<T> entityList)
        {
            if (entityList == null || entityList.Count <= 0)
            {
                return false;
            }
            BaseTable.AddRange(entityList);
            if (UnitOfWork != null)
            {
                UnitOfWork.IsCommitted = false;
                return true;
            }
            return this.SavaChange();
        }
        #endregion


        #region 修改
        /// <summary>
        /// 单个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(T entity)
        {
            if (entity == null)
            {
                return false;
            }
            BaseTable.Attach(entity);
            BaseDBContext.Entry(entity).State = EntityState.Modified;
            return this.SavaChange();
        }

        /// <summary>
        /// 多个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateList(List<T> entityList)
        {
            if (entityList == null || entityList.Count <= 0)
            {
                return false;
            }
            foreach (var item in entityList)
            {
                BaseDBContext.Entry(item).State = EntityState.Modified;
            }
            if (UnitOfWork != null)
            {
                UnitOfWork.IsCommitted = false;
                return true;
            }
            return this.SavaChange();
        }

        /// <summary>
        /// 扩展修改
        /// </summary>
        /// <param name="filterExpression">条件</param>
        /// <param name="updateExpression">需要更新的字段与值</param>
        /// <returns></returns>
        public bool UpdateExtend(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T>> updateExpression)
        {
            return BaseTable.Where(filterExpression).Update<T>(updateExpression) > 0;
        }
        #endregion

        #region 删除
        /// <summary>
        /// 单个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool Delete(T entity)
        {
            if (entity == null)
            {
                return false;
            }
            //实体放入EF容器中
            BaseTable.Attach(entity);
            BaseDBContext.Entry(entity).State = EntityState.Deleted;
            //BaseTable.Remove(entity);
            return this.SavaChange();
        }

        /// <summary>
        /// 条件删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool Delete(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> queryable = BaseTable.Where(predicate);
            if (queryable == null)
            {
                return false;
            }
            BaseTable.RemoveRange(queryable);
            if (UnitOfWork != null)
            {
                UnitOfWork.IsCommitted = false;
                return true;
            }
            return this.SavaChange();
        }

        /// <summary>
        /// 扩展删除(根据条件删除)
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual bool DeleteExtend(Expression<Func<T, bool>> predicate)
        {
            return BaseTable.Where(predicate).Delete() > 0;
        }

        /// <summary>
        /// 多个实体
        /// </summary>
        /// <param name="entityList"></param>
        /// <returns></returns>
        public virtual bool DeleteList(List<T> entityList)
        {
            if (entityList == null || entityList.Count <= 0)
            {
                return false;
            }
            //foreach (var item in entityList)
            //{
            //    //实体放入EF容器中
            //    BaseTable.Attach(item);
            //    BaseDBContext.Entry(item).State = EntityState.Deleted;
            //}
            BaseTable.RemoveRange(entityList);
            if (UnitOfWork != null)
            {
                UnitOfWork.IsCommitted = false;
                return true;
            }
            return this.SavaChange();
        }
        #endregion



        #region 查询

        /// <summary>
        /// 根据条件返回对应的所有数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IQueryable<T> SelectAll(Expression<Func<T, bool>> predicate)
        {
            return BaseTable.Where(predicate).AsNoTracking();
        }

        /// <summary>
        /// Lambda查询单条记录
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public T Select(Expression<Func<T, bool>> predicate)
        {
            return BaseTable.AsNoTracking().Where(predicate).FirstOrDefault();
        }

        /// <summary>
        /// 主键ID查询单条记录
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        public T Select(string fid)
        {
            return BaseTable.Find(fid);
        }

        /// <summary>
        /// 根据sql查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="dbParameter">动态参数</param>
        /// <returns></returns>
        public IQueryable<T> SelectSql(string sql, DbParameter[] dbParameter)
        {
            return BaseDBContext.Set<T>().SqlQuery(sql, dbParameter).AsNoTracking().AsQueryable();
        }

        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public int SelectCount(Expression<Func<T, bool>> predicate)
        {
            return this.SelectAll(predicate).Count();
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public bool SelectIsExists(Expression<Func<T, bool>> predicate)
        {
            return this.SelectCount(predicate) > 0;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        public PageListModel<T> PageList(PaggingModel model)
        {
            ParameterExpression param = Expression.Parameter(typeof(T));
            var queryable = SelectAll(a => true);
            if (model != null)
            {
                if (model.FilterList != null && model.FilterList.Count > 0)
                {
                    foreach (var item in model.FilterList)
                    {
                        Expression condition = SearchQuery<T>.GetFilterExpression(item, param);
                        var lambda = Expression.Lambda<Func<T, bool>>(condition, param);
                        queryable = queryable.Where(lambda);
                    }
                }

                queryable = SortQuery<T>.SortQueryExpression(queryable, model.SortList);
            }
            PageListModel<T> result = new PageListModel<T>();
            result = ReturnPageModel(queryable, result, model.Page, model.PageSize);
            return result;
        }

        /// <summary>
        /// 返回分页实体
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="result"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PageListModel<T> ReturnPageModel(IQueryable<T> queryable, PageListModel<T> result, int page, int pageSize)
        {
            var futureList = queryable.Skip((page - 1) * pageSize).Take(pageSize).Future();
            var futureCount = queryable.FutureCount();
            result.DataList = futureList.ToList();
            result.TotalRows = futureCount.Value;
            result.HasNext = result.TotalRows > page * pageSize;
            return result;
        }


        #endregion


        /// <summary>
        /// 统一保存
        /// </summary>
        /// <returns></returns>
        public bool SavaChange()
        {
            return BaseDBContext.SaveChanges() > 0;
        }
    }
}
