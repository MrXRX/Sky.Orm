using Sky.Common.Enum;
using Sky.Data.Authority;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sky.Admin.Controllers
{
    public class BaseController : Controller
    {
        public UserData UserData
        {
            get
            {
                var user = HttpContext.User as FormsAuthenticationPrincipal<UserData>;
                if (user == null || user.UserData == null)
                {
                    this.FormSignOut();
                    return null;
                }
                return user.UserData;
            }
        }

        /// <summary>
        /// 清空登录信息
        /// </summary>
        public void FormSignOut()
        {
            FormsAuthenticationAuthority<UserData>.FormSignOut();
        }

        /// <summary>
        /// 验证图形验证码
        /// </summary>
        /// <param name="vCode"></param>
        public string VerifyImgCode(string vCode)
        {
            if (string.IsNullOrWhiteSpace(vCode))
            {
                return "图形验证码必填";
            }
            if (Session["ValidateCode"] == null || !vCode.Equals(Session["ValidateCode"].ToString(), StringComparison.CurrentCultureIgnoreCase))
            {
                return "图形验证码错误";
            }
            Session.Remove("ValidateCode");
            return "";
        }

        /// <summary>
        /// 获取语言类型
        /// </summary>
        /// <returns></returns>
        public string LanguageType
        {
            get
            {
                var cookie = HttpContext.Request.Cookies["language"];
                if (cookie == null || string.IsNullOrEmpty(cookie.Value))
                {
                    return "zh-cn";
                }
                return cookie.Value;
            }
        }
    }
}