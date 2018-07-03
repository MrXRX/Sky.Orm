using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Model.Model.PaggingModel
{
    /// <summary>
    /// 分页实体类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageListModel<T>
    {
        /// <summary>
        /// 数据集
        /// </summary>
        public List<T> DataList { get; set; }
        /// <summary>
        /// 是否有下一页
        /// </summary>
        public bool HasNext { get; set; }
        /// <summary>
        /// 是否有上一页
        /// </summary>
        public bool HasPrevious { get; set; }
        /// <summary>
        /// 总行数
        /// </summary>
        public int TotalRows { get; set; }
        /// <summary>
        /// 状态码
        /// </summary>
        public int Code { get; set; }
    }
}
