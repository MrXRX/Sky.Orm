using Sky.Model.Model.PaggingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Sky.Data.Realize
{
    /// <summary>
    /// 排序
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SortQuery<T>
    {
        /// <summary>
        /// 排序表达式拼接
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="sortList"></param>
        /// <returns></returns>
        public static IQueryable<T> SortQueryExpression(IQueryable<T> queryable, List<SortModel> sortList)
        {
            //创建表达式变量参数
            var parameter = Expression.Parameter(typeof(T), "p");
            if (sortList != null && sortList.Count > 0)
            {
                for (int i = 0; i < sortList.Count; i++)
                {
                    //根据属性名获取属性
                    var property = typeof(T).GetProperty(sortList[i].ColumnName);
                    //创建一个访问属性的表达式
                    var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                    var orderByExp = Expression.Lambda(propertyAccess, parameter);
                    string orderName = "";
                    if (i > 0)
                    {
                        orderName = sortList[i].IsDesc ? "ThenByDescending" : "ThenBy";
                    }
                    else
                    {
                        orderName = sortList[i].IsDesc ? "OrderByDescending" : "OrderBy";
                    }
                    MethodCallExpression resultExp = Expression.Call(typeof(Queryable), orderName, new Type[] { typeof(T), property.PropertyType }, queryable.Expression, Expression.Quote(orderByExp));
                    queryable = queryable.Provider.CreateQuery<T>(resultExp);
                }
            }
            else
            {
                var property = typeof(T).GetProperty("CreateDate");
                var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                var orderByExp = Expression.Lambda(propertyAccess, parameter);
                MethodCallExpression resultExp = Expression.Call(typeof(Queryable), "OrderByDescending", new Type[] { typeof(T), property.PropertyType }, queryable.Expression, Expression.Quote(orderByExp));
                queryable = queryable.Provider.CreateQuery<T>(resultExp);
            }
            return queryable;
        }
    }
}
