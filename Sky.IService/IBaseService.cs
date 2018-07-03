using Sky.Data.Interface;
using Sky.Model.Model.PaggingModel;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;

namespace Sky.IService
{
    public interface IBaseService<T> : IDependency where T : class, new()
    {
        #region 添加
        /// <summary>
        /// 新增一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Add(T entity);

        /// <summary>
        /// 多个实体
        /// </summary>
        /// <param name="entityList"></param>
        /// <returns></returns>
        bool AddList(List<T> entityList);
        #endregion

        #region 修改
        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Update(T entity);

        /// <summary>
        /// 多个实体
        /// </summary>
        /// <param name="entityList"></param>
        /// <returns></returns>
        bool UpdateList(List<T> entityList);

        /// <summary>
        /// 扩展修改
        /// </summary>
        /// <param name="filterExpression">条件</param>
        /// <param name="updateExpression">需要更新的字段与值</param>
        /// <returns></returns>
        bool UpdateExtend(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T>> updateExpression);
        #endregion

        #region 删除
        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Delete(T entity);

        /// <summary>
        /// 条件删除
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        bool Delete(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 扩展删除(根据条件删除)
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        bool DeleteExtend(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 多个实体
        /// </summary>
        /// <param name="entityList"></param>
        /// <returns></returns>
        bool DeleteList(List<T> entityList);
        #endregion

        #region 查询
        /// <summary>
        /// 根据条件返回对应的所有数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<T> SelectAll(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 表达式查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        T Select(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 主键查询
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        T Select(string fid);

        /// <summary>
        /// 根据sql查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="dbParameter">动态参数</param>
        /// <returns></returns>
        IQueryable<T> SelectSql(string sql, DbParameter[] dbParameter);

        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int SelectCount(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        bool SelectIsExists(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        PageListModel<T> PageList(PaggingModel model);

        /// <summary>
        /// 返回分页实体
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        PageListModel<T> ReturnPageModel(IQueryable<T> queryable, PageListModel<T> result, int page, int pageSize);
        #endregion
    }
}
