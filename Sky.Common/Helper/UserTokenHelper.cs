using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Common.Helper
{
    public class UserTokenHelper
    {
        /// <summary>
        /// 根据用户Id生成登录令牌
        /// </summary>
        /// <returns></returns>
        public static string GetUserTokenHelper(string userId)
        {
            string token = userId + Guid.NewGuid().ToString("N");
            return token;
        }
    }
}
