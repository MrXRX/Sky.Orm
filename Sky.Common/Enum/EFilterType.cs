using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Common.Enum
{
    /// <summary>
    /// 过滤类型
    /// </summary>
    public enum EFilterType
    {
        /// <summary>
        /// 等于
        /// </summary>
        Equal = 1,
        /// <summary>
        /// 不等于
        /// </summary>
        NotEqual = 2,
        /// <summary>
        /// 大于
        /// </summary>
        GreaterThan = 3,
        /// <summary>
        /// 大于等于
        /// </summary>
        GreaterThanOrEqual = 4,
        /// <summary>
        /// 小于
        /// </summary>
        LessThan = 5,
        /// <summary>
        /// 小于等于
        /// </summary>
        LessThanOrEqual = 6,
        LeftContains = 7,
        RightContains = 8,
        /// <summary>
        /// 模糊
        /// </summary>
        Contains = 9,
        /// <summary>
        /// 或者
        /// </summary>
        Or = 10,
    }
}
