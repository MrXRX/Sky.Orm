using Sky.Model.Entity;
using Sky.Model.Model.BoolModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.IService
{
    public interface ISysUserService : IBaseService<SysUserEntity>
    {
        /// <summary>
        /// 后台管理员登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        //BoolModel SysLogin(string userName, string password);
    }
}