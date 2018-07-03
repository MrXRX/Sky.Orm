using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Sky.Data.Authority
{
    /// <summary>
    /// 登录后用户数据
    /// </summary>
    public class UserData : IPrincipal
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 用户头像
        /// </summary>
        public string HeadPicUrl { get; set; }
        /// <summary>
        /// 权限
        /// </summary>
        public string RoleIDList { get; set; }
        /// <summary>
        /// 用户登录令牌
        /// </summary>
        public string Token { get; set; }

        [ScriptIgnore] //在序列化的时候忽略该属性
        public IIdentity Identity { get; set; }

        //当使用Authorize特性时，会调用改方法验证角色 
        public bool IsInRole(string role)
        {
            //找出用户所有所属角色
            return true;
        }

        //验证用户信息
        public bool IsInUser(string user)
        {
            //找出用户所有所属角色
            return true;
        }
    }
}
