using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Common.Enum
{
    /// <summary>
    /// 错误消息
    /// </summary>
    public class EMsgCodeType
    {
        /// <summary>
        /// 操作成功
        /// </summary>
        public const int v200 = 200;
        /// <summary>
        /// 操作失败
        /// </summary>
        public const int v201 = 201;

        #region 数据不存在10000-30000
        /// <summary>
        /// 手机号不存在
        /// </summary>
        public const int v10000 = 10000;
        /// <summary>
        /// 用户不存在
        /// </summary>
        public const int v10001 = 10001;
        #endregion

        #region 参数必填30001-50000
        /// <summary>
        /// 图形验证码必填
        /// </summary>
        public const int v30001 = 30001;
        /// <summary>
        /// 手机号必填
        /// </summary>
        public const int v30002 = 30002;
        /// <summary>
        /// 密码必填
        /// </summary>
        public const int v30003 = 30003;
        /// <summary>
        /// 用户名必填
        /// </summary>
        public const int v30004 = 30004;
        #endregion

        #region 参数/数据错误50001-70000
        /// <summary>
        /// 密码错误
        /// </summary>
        public const int v50001 = 50001;
        /// <summary>
        /// 手机验证码错误
        /// </summary>
        public const int v50002 = 50002;
        /// <summary>
        /// 手机号格式错误
        /// </summary>
        public const int v50003 = 50003;
        /// <summary>
        /// 图形验证码错误
        /// </summary>
        public const int v50004 = 50004;
        /// <summary>
        /// 用户名或密码错误
        /// </summary>
        public const int v50005 = 50005;
        #endregion


    }
}
