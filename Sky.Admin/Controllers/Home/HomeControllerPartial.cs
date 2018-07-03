using Sky.Common.Enum;
using Sky.IService;
using Sky.Model.Model.HomeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sky.Admin.Controllers
{
    public partial class HomeController : BaseController
    {
        private readonly ISysUserService _SysUserService;
        private readonly ISysMenuService _SysMenuService;
        public HomeController(ISysUserService sysUserService, ISysMenuService sysMenuService)
        {
            _SysUserService = sysUserService;
            _SysMenuService = sysMenuService;
        }

        /// <summary>
        /// 获取首页导航栏
        /// </summary>
        /// <returns></returns>
        private SysHomeModel SysHomeInfo(string menuId)
        {
            SysHomeModel model = new SysHomeModel();
            var userData = UserData;
            //查询用户信息
            model.UserInfo = new UserModel()
            {
                UserID = userData.UserID,
                UserName = userData.Name,
                HeadPicUrl = userData.HeadPicUrl
            };

            //查询菜单栏
            var menuList = _SysMenuService.SelectAll(a => true).Select(a => new MenuModel { FID = a.FID, Name = a.Name, Url = a.URL, ParentID = a.ParentID, MenuLevel = a.MenuLevel }).ToList();
            if (menuList != null && menuList.Count > 0)
            {
                model.MenuList = menuList;
            }
            return model;
        }
    }
}