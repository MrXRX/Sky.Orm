using Sky.IRepository;
using Sky.IService;
using Sky.Model.Model.PaggingModel;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;

namespace Sky.Service
{
    public class BaseService<T, TDAL> : IBaseService<T>
        where T : class, new()
        where TDAL : IBaseRepository<T>
    {

        protected IBaseRepository<T> TargetDAL;
        public BaseService(IBaseRepository<T> _targetDAL)
        {
            TargetDAL = _targetDAL;
        }

        #region 添加
        /// <summary>
        /// 单个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Add(T entity)
        {
            return this.TargetDAL.Add(entity);
        }

        /// <summary>
        /// 多个实体
        /// </summary>
        /// <param name="entityList"></param>
        /// <returns></returns>
        public virtual bool AddList(List<T> entityList)
        {
            return this.TargetDAL.AddList(entityList);
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
            return this.TargetDAL.Update(entity);
        }

        /// <summary>
        /// 多个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateList(List<T> entityList)
        {
            return this.TargetDAL.UpdateList(entityList);
        }

        /// <summary>
        /// 扩展修改
        /// </summary>
        /// <param name="filterExpression">条件</param>
        /// <param name="updateExpression">需要更新的字段与值</param>
        /// <returns></returns>
        public bool UpdateExtend(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T>> updateExpression)
        {
            return this.TargetDAL.UpdateExtend(filterExpression, updateExpression);
        }
        #endregion

        #region 删除
        /// <summary>
        /// 单个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(T entity)
        {
            return this.TargetDAL.Add(entity);
        }

        /// <summary>
        /// 条件删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool Delete(Expression<Func<T, bool>> predicate)
        {
            return this.TargetDAL.Delete(predicate);
        }

        /// <summary>
        /// 扩展删除(根据条件删除)
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual bool DeleteExtend(Expression<Func<T, bool>> predicate)
        {
            return this.TargetDAL.DeleteExtend(predicate);
        }

        /// <summary>
        /// 多个实体
        /// </summary>
        /// <param name="entityList"></param>
        /// <returns></returns>
        public virtual bool DeleteList(List<T> entityList)
        {
            return this.TargetDAL.DeleteList(entityList);
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
            return this.TargetDAL.SelectAll(predicate);
        }

        /// <summary>
        /// Lambda查询单条记录
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public T Select(Expression<Func<T, bool>> predicate)
        {
            return this.TargetDAL.Select(predicate);
        }

        /// <summary>
        /// 主键ID查询单条记录
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        public T Select(string fid)
        {
            return this.TargetDAL.Select(fid);
        }

        /// <summary>
        /// 根据sql查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="dbParameter">动态参数</param>
        /// <returns></returns>
        public IQueryable<T> SelectSql(string sql, DbParameter[] dbParameter)
        {
            return this.TargetDAL.SelectSql(sql, dbParameter);
        }

        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public int SelectCount(Expression<Func<T, bool>> predicate)
        {
            return this.TargetDAL.SelectCount(predicate);
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public bool SelectIsExists(Expression<Func<T, bool>> predicate)
        {
            return this.TargetDAL.SelectIsExists(predicate);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        public PageListModel<T> PageList(PaggingModel model)
        {
            return this.TargetDAL.PageList(model);
        }

        /// <summary>
        /// 返回分页实体
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public PageListModel<T> ReturnPageModel(IQueryable<T> queryable, PageListModel<T> result, int page, int pageSize)
        {
            return this.TargetDAL.ReturnPageModel(queryable, result, page, pageSize);
        }

        #endregion



    }
}
