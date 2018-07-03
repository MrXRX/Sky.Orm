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
    public partial class HomeController
    {
        public ActionResult Index(string menuId = "")
        {
            var model = SysHomeInfo(menuId);
            ViewBag.MenuID = menuId;
            return View(model);
        }

        public ActionResult IndexPartial()
        {
            return View();
        }

    }
}