using Sky.Data.Authority;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Sky.Admin.Controllers
{
    public class AuthenticationAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            base.AuthorizeCore(httpContext);
            bool isLogin = false;
            var formsIdentity = HttpContext.Current.User.Identity as FormsIdentity;
            if (formsIdentity != null && formsIdentity.IsAuthenticated && formsIdentity.AuthenticationType == "Forms")
            {
                FormsAuthenticationAuthority<UserData>.GetUserInfo(out isLogin);
            }
            else
            {
                //无权限状态码
                httpContext.Response.StatusCode = 401;
            }
            return isLogin;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
            else
            {
                string returnUrl = filterContext.HttpContext.Request.Url.AbsoluteUri;
                string redirectUrl = string.Format("?ReturnUrl={0}", returnUrl);
                string loginUrl = FormsAuthentication.LoginUrl + redirectUrl;
                filterContext.HttpContext.Response.Redirect(loginUrl, true);
            }
        }
    }
}