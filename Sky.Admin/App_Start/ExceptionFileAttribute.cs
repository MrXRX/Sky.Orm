using Sky.Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sky.Admin.App_Start
{
    public class ExceptionFileAttribute : HandleErrorAttribute
    {
        /// <summary>
        /// 重写全局错误过滤器
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            //处理错误消息  
            LogHelper.Error(filterContext.Controller, filterContext.Exception.Message, filterContext.Exception);
        }
    }
}