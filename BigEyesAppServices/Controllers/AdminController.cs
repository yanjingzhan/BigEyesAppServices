using BigEyesAppServices.Models;
using ChongGuanDotNetUtils.Extensions;
using ChongGuanDotNetUtils.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BigEyesAppServices.Controllers
{
    [RequestAuthorize]
    public class AdminController : ApiController
    {
        [HttpPost]
        public async Task<IHttpActionResult> Add([FromBody]Users user)
        {
            var query = from a in ModelContext.DatabaseContext.Users
                        where a.UserName == user.UserName
                        select a;

            var data_t = query.FirstOrDefault();

            ResponseData<Users> result = new ResponseData<Users>
            {
                Message = "该用户已经存在！"
            };

            if (data_t == null)
            {

                user.ModifyTime = DateTime.Now;
                user.CreateTime = DateTime.Now;

                user.PasswordSalt = Guid.NewGuid().ToString("N");
                user.Password = (user.Password + user.PasswordSalt).Md5();

                var data = ModelContext.DatabaseContext.Users.Add(user);
                await ModelContext.DatabaseContext.SaveChangesAsync();

                Users user_t = new Users();
                ReflectionHelper.CopyProperties(data, user_t, new string[] { "Password", "PasswordSalt" });

                result.Data = user_t;
                result.Message = "";
            }

            return Json(result);
        }

        [HttpGet]
        public IHttpActionResult Query([FromUri]int id = 0)
        {
            var query = from a in ModelContext.DatabaseContext.Users
                        where (a.Id == id || id == 0) && (bool)a.IsDeleted == false
                        select a;

            var responseData = new ResponseData<IEnumerable<Users>>()
            {
                Message = "",
                Data = query
            };
            return this.Json(responseData);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update([FromBody]Users user)
        {
            var query = from a in ModelContext.DatabaseContext.Users
                        where a.Id == user.Id
                        select a;

            var data = query.FirstOrDefault();

            var responseData = new ResponseData<Users>()
            {
                Message = data == null ? "未找到该用户数据" : "",
                Data = data
            };

            if (data != null)
            {
                ReflectionHelper.CopyProperties(user, data, new string[] { "Id", "Password", "PasswordSalt" });

                data.ModifyTime = DateTime.Now;
                ModelContext.DatabaseContext.Entry(data).State = System.Data.Entity.EntityState.Modified;
                await ModelContext.DatabaseContext.SaveChangesAsync();
            }

            return Json(responseData);
        }

        [HttpGet]
        public async Task<IHttpActionResult> Delete([FromUri]int id)
        {
            var query = from a in ModelContext.DatabaseContext.Users
                        where a.Id == id
                        select a;

            var data = query.FirstOrDefault();

            var responseData = new ResponseData<Users>()
            {
                Message = data == null ? "未找到该用户数据" : "",
                Data = data
            };

            if (data != null)
            {
                data.IsDeleted = true;

                ModelContext.DatabaseContext.Entry(data).State = System.Data.Entity.EntityState.Modified;
                await ModelContext.DatabaseContext.SaveChangesAsync();
            }

            return Json(responseData);
        }

        [HttpPost]
        public async Task<IHttpActionResult> ModifyPassword([FromBody]Users user,string oldPassword,string newPassword)
        {
            string message = "密码修改失败！";

            var query = from a in ModelContext.DatabaseContext.Users
                        where a.UserName == user.UserName || a.Id == user.Id
                        select a;

            var data = query.FirstOrDefault();

            if (data != null && data.Password == (oldPassword + data.PasswordSalt).Md5())
            {
                //ReflectionHelper.CopyProperties<Users>(user, data, new String[] { "Id", "Password" });

                data.ModifyTime = DateTime.Now;

                data.PasswordSalt = Guid.NewGuid().ToString("N");
                data.Password = (newPassword + data.PasswordSalt).Md5();
                ModelContext.DatabaseContext.Entry(data).State = System.Data.Entity.EntityState.Modified;
                await ModelContext.DatabaseContext.SaveChangesAsync();

                user.Password = newPassword;
                message = string.Empty;
            }

            var responseData = new ResponseData<Users>()
            {
                Message = message,
                Data = string.IsNullOrWhiteSpace(message) ? data : null
            };


            return Json(responseData);
        }
    }
}
