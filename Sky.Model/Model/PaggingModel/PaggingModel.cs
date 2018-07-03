using Sky.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Model.Model.PaggingModel
{
    /// <summary>
    /// 分页实体
    /// </summary>
    public class PaggingModel
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// 页大小
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 查询指定字段
        /// </summary>
        public string SpecifieField { get; set; }

        public List<SortModel> SortList { get; set; }

        public List<FilterModel> FilterList { get; set; }
    }

    /// <summary>
    /// 排序实体
    /// </summary>
    public class SortModel
    {
        /// <summary>
        /// 列名
        /// </summary>
        public string ColumnName { get; set; }
        /// <summary>
        /// 是否降序
        /// </summary>
        public bool IsDesc { get; set; }
    }
    /// <summary>
    /// 过滤实体
    /// </summary>
    public class FilterModel
    {
        /// <summary>
        /// 字段名
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 过滤类型
        /// </summary>
        public EFilterType FilterType { get; set; }
        /// <summary>
        /// “或”过滤列表
        /// </summary>
        public List<FilterModel> OrFilterList { get; set; }
    }
}
