using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Model.Model.HomeModel
{
    public class SysHomeModel
    {
        /// <summary>
        /// 管理员信息
        /// </summary>
        public UserModel UserInfo { get; set; }
        /// <summary>
        /// 菜单栏
        /// </summary>
        public List<MenuModel> MenuList { get; set; }
    }



    public class UserModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 用户头像
        /// </summary>
        public string HeadPicUrl { get; set; }
    }

    public class MenuModel
    {

        public string FID { get; set; }

        public string Url { get; set; }

        public string Name { get; set; }

        public string ParentID { get; set; }

        public int MenuLevel { get; set; }
    }
}
