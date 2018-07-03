using Sky.Common.Enum;
using Sky.Model.Model.PaggingModel;
using System;
using System.Linq.Expressions;

namespace Sky.Data.Realize
{
    public class SearchQuery<T>
    {
        /// <summary>
        /// 获取过滤条件的表达式
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static Expression GetFilterExpression(FilterModel filter, ParameterExpression param)
        {
            Expression condition = null;
            ConstantExpression targetValue = null;
            MemberExpression memExp = null;
            if (filter.FilterType != EFilterType.Or && (filter.OrFilterList == null || filter.OrFilterList.Count <= 0))
            {
                memExp = Expression.Property(param, filter.Key);
                targetValue = Expression.Constant(filter.Value, memExp.Type);
            }
            switch (filter.FilterType)
            {
                case EFilterType.Equal:
                    if (filter.OrFilterList != null && filter.OrFilterList.Count > 0)
                    {
                        Expression tempEqualCondition = null;
                        foreach (var item in filter.OrFilterList)
                        {
                            tempEqualCondition = GetFilterExpression(item, param);
                            if (condition == null)
                            {
                                condition = tempEqualCondition;
                            }
                            else
                            {
                                condition = Expression.AndAlso(tempEqualCondition, condition);
                            }
                        }
                    }
                    else
                    {
                        condition = Expression.Equal(memExp, targetValue);
                    }
                    break;
                case EFilterType.NotEqual:
                    condition = Expression.NotEqual(memExp, targetValue);
                    break;
                case EFilterType.GreaterThan:
                    condition = Expression.GreaterThan(memExp, targetValue);
                    break;
                case EFilterType.GreaterThanOrEqual:
                    condition = Expression.GreaterThanOrEqual(memExp, targetValue);
                    break;
                case EFilterType.LessThan:
                    condition = Expression.LessThan(memExp, targetValue);
                    break;
                case EFilterType.LessThanOrEqual:
                    condition = Expression.LessThanOrEqual(memExp, targetValue);
                    break;
                //case EFilterType.LeftContains:
                //    condition = Expression.And(memExp, targetValue);
                //    condition = Expression.Equal(condition, targetValue);
                //    break;
                //case EFilterType.RightContains:
                //    condition = Expression.And(memExp, targetValue);
                //    condition = Expression.Equal(condition, targetValue);
                //    break;
                case EFilterType.Contains:
                    condition = Expression.Call(memExp, typeof(String).GetMethod("Contains"), targetValue);
                    break;
                case EFilterType.Or://当为OR查询时,把里面的OrFilterList拿出来组合
                    Expression tempCondition = null;
                    foreach (var item in filter.OrFilterList)
                    {
                        tempCondition = GetFilterExpression(item, param);
                        if (condition == null)
                        {
                            condition = tempCondition;
                        }
                        else
                        {
                            condition = Expression.OrElse(tempCondition, condition);
                        }
                    }
                    break;
                default:
                    condition = Expression.Equal(memExp, targetValue);
                    break;
            }

            return condition;
        }
    }
}
