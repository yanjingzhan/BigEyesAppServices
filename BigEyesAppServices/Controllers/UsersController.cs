using BigEyesAppServices.Models;
using ChongGuanDotNetUtils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace BigEyesAppServices.Controllers
{
    public class UsersController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Login([FromBody]Users user)
        {
            var query = from a in ModelContext.DatabaseContext.Users
                        where a.UserName == user.UserName
                        select a;
            var data = query.FirstOrDefault();

            if (data != null)
            {
                var saltedPass = user.Password + data.PasswordSalt;

                if (saltedPass.Md5() == data.Password && !(bool)data.IsDeleted && !(bool)data.IsDisable)
                {
                    ChongGuanDotNetUtils.Helpers.ReflectionHelper.CopyProperties(data, user, new string[] { "password", "passwordsalt" });// keep pwd and salt secret
                }
            }

            var resp = new ResponseData<Users>()
            {
                Message = data == null ? "用户名或密码错误" : "",
                Data = null
            };

            if (data != null)
            {
                if ((bool)data.IsDeleted || (bool)data.IsDisable)
                {
                    resp.Message = "用户已经被禁用或删除";
                }
                else
                {
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(0, user.UserName, DateTime.Now,
                            DateTime.Now.AddHours(1), true, string.Format("{0}&{1}", user.UserName, user.Password),
                            FormsAuthentication.FormsCookiePath);

                    user.Ticket = FormsAuthentication.Encrypt(ticket);
                    resp.Data = user;
                    //将身份信息保存在session中，验证当前请求是否是有效请求
                    HttpContext.Current.Session[user.UserName] = user;
                }
            }
            return Json(resp);
        }
    }
}
