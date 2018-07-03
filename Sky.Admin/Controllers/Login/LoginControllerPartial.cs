using Sky.Common.Enum;
using Sky.Common.Helper;
using Sky.Data.Authority;
using Sky.IService;
using Sky.Model.Entity;
using Sky.Model.Model.BoolModel;
using Sky.Model.Model.LoginModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sky.Admin.Controllers
{
    [Authentication]
    public partial class LoginController : BaseController
    {
        private readonly ISysUserService _SysUserService;
        public LoginController(ISysUserService sysUserService)
        {
            _SysUserService = sysUserService;
        }


        /// <summary>
        /// 后台登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public JsonResult AdminLogin(LoginModel model)
        {
            BoolModel result = new BoolModel();
            if (string.IsNullOrWhiteSpace(model.UserName))
            {
                result.Message = "用户名必填";
                return Json(result);
            }
            if (string.IsNullOrWhiteSpace(model.Password))
            {
                result.Message = "密码必填";
                return Json(result);
            }
            result.Message = base.VerifyImgCode(model.VCode);
            if (!String.IsNullOrEmpty(result.Message))
            {
                return Json(result);
            }
            model.Password = EncryptionHelper.MD5Encrypt(model.Password);
            var user = _SysUserService.Select(a => a.Password.Equals(model.Password) && (a.Name.Equals(model.UserName) || a.Phone.Equals(model.UserName)));
            if (user != null)
            {
                LoginSetCookie(user);
                result.IsSuccess = true;
            }
            else
            {
                result.Message = "用户名或密码错误";
            }
            return Json(result);
        }


        /// <summary>
        /// 登录后设置cookie
        /// </summary>
        /// <param name="model"></param>
        private void LoginSetCookie(SysUserEntity model)
        {
            var userData = new UserData
            {
                Phone = model.Phone,
                Name = model.Name,
                UserID = model.FID,
                Token = UserTokenHelper.GetUserTokenHelper(model.FID),
            };
            FormsAuthenticationAuthority<UserData>.SetAuthenticationCookie(userData.UserID, userData);
        }
    }
}