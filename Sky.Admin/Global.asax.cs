using Sky.Admin.App_Start;
using Sky.Data.Authority;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Sky.Admin
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //使用指定的用户定义信息在 ASP.NET MVC 应用程序内注册所有区域。
            AreaRegistration.RegisterAllAreas();
            //注册路由
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //注册全局过滤器
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //注册使用css和js的捆绑包
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //其他应用初始化
            AppConfig.Init();
        }

    }
}
