using ky.Common.Helper;
using Sky.IService;
using Sky.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sky.Admin.Controllers
{
    [Authentication]
    public partial class SysMenuController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public ActionResult Index(string menuId = "")
        {
            return View();
        }
    }
}