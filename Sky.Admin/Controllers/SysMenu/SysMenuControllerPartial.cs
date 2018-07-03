using Sky.Common.Enum;
using Sky.Common.Helper;
using Sky.IService;
using Sky.Model.Entity;
using Sky.Model.Model.HomeModel;
using Sky.Model.Model.PaggingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sky.Admin.Controllers
{
    public partial class SysMenuController : BaseController
    {
        private readonly ISysUserService _SysUserService;
        private readonly ISysMenuService _SysMenuService;
        public SysMenuController(ISysUserService sysUserService, ISysMenuService sysMenuService)
        {
            _SysUserService = sysUserService;
            _SysMenuService = sysMenuService;
        }


        [HttpGet]
        public string Pagging(int page, int rows, string name)
        {
            var model = new PageListModel<SysMenuEntity>();
            PaggingModel pagging = new PaggingModel() { Page = page, PageSize = rows };
            pagging.FilterList = new List<FilterModel>();
            if (!String.IsNullOrWhiteSpace(name))
            {
                pagging.FilterList.Add(new FilterModel { Key = "Name", Value = name });
            }
            model = _SysMenuService.PageList(pagging);
            dynamic aa = new { total = model.TotalRows, rows = model.DataList };
            return JsonHelper.SerializeObject(aa);
        }

    }
}