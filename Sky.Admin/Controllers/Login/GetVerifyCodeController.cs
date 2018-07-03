using Sky.Common.Enum;
using Sky.Common.Helper;
using Sky.Model.Model.BoolModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sky.Admin.Controllers
{
    public class GetVerifyCodeController : BaseController
    {
        /// <summary>
        /// 获取图形验证码
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult GetVerifyCode()
        {
            string code = string.Empty;
            byte[] bytes = ValidateCodeHelper.CreateValidateGraphic(out code, 5, 120, 40, 20);
            Session["ValidateCode"] = code;
            return File(bytes, @"image/jpeg");
        }

        /// <summary>
        /// 验证图形验证码
        /// </summary>
        /// <param name="code">输入验证码</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public JsonResult CheckVerifyCode(string code)
        {
            BoolModel result = new BoolModel();
            if (string.IsNullOrEmpty(code))
            {
                result.Message = "图形验证码必填";
                return Json(result);
            }
            if (Session["ValidateCode"] == null || !Session["ValidateCode"].ToString().Equals(code, StringComparison.InvariantCultureIgnoreCase))
            {
                result.Message = "图形验证码错误";
                return Json(result);
            }
            Session.Remove("ValidateCode");
            result.IsSuccess = true;
            return Json(result);
        }
    }
}