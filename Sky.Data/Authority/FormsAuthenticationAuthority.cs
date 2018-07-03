using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace Sky.Data.Authority
{
    public class FormsAuthenticationAuthority<T> where T : class, new()
    {
        /// <summary>
        /// 设置登录cookie
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userData"></param>
        public static void SetAuthenticationCookie(string userName, UserData userData)
        {

            //保存在cookie中的信息
            string userJson = JsonConvert.SerializeObject(userData);

            //创建用户票据
            var ticket = new FormsAuthenticationTicket(2, userName, DateTime.Now, DateTime.Now.AddMinutes(FormsAuthenticationConfig.ExpirationTime), false, userJson, FormsAuthentication.FormsCookiePath);

            //FormsAuthentication提供web forms身份验证服务
            //加密
            string encryptValue = FormsAuthentication.Encrypt(ticket);

            //创建cookie
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptValue)
            {
                HttpOnly = true,
                Domain = FormsAuthentication.CookieDomain,
                Expires = ticket.Expiration,
                Secure = FormsAuthentication.RequireSSL,
                Path = FormsAuthentication.FormsCookiePath
            };

            HttpContext.Current.Response.Cookies.Remove(cookie.Name);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 获取登录信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="isLogin"></param>
        /// <returns></returns>
        public static void GetUserInfo(out bool isLogin)
        {
            isLogin = false;
            HttpCookie cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null || string.IsNullOrEmpty(cookie.Value))
            {
                return;
            }
            //解密cookie值
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
            if (ticket == null || string.IsNullOrEmpty(ticket.UserData))
            {
                return;
            }
            UserData userData = JsonConvert.DeserializeObject<UserData>(ticket.UserData);
            HttpContext.Current.User = new FormsAuthenticationPrincipal<UserData>(ticket, userData);
            isLogin = true;
        }

        /// <summary>
        /// 清空登录信息
        /// </summary>
        public static void FormSignOut()
        {
            FormsAuthentication.SignOut();
        }

    }
}
