using BigEyesAppServices.Models;
using ChongGuanDotNetUtils.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BigEyesAppServices.Controllers
{
    //[RequestAuthorize]
    public class AdvertisingController : ApiController
    {
        [HttpPost]
        public async Task<IHttpActionResult> Add([FromBody]Advertising advertising)
        {
            advertising.ModifyTime = DateTime.Now;
            advertising.CreateTime = DateTime.Now;

            var data = ModelContext.DatabaseContext.Advertising.Add(advertising);
            await ModelContext.DatabaseContext.SaveChangesAsync();

            ResponseData<Advertising> result = new ResponseData<Advertising>
            {
                Data = data
            };

            return Json(result);
        }

        [HttpGet]
        public IHttpActionResult Query([FromUri]int id = 0)
        {
            var query = from a in ModelContext.DatabaseContext.Advertising
                        where (a.Id == id || id == 0) && (bool)a.IsDeleted == false
                        select a;

            var responseData = new ResponseData<IEnumerable<Advertising>>()
            {
                Message = "",
                Data = query
            };
            return this.Json(responseData);
        }

        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetAdvertisingList([FromUri]int type = 0)
        {
            var query = from a in ModelContext.DatabaseContext.Advertising
                        where (a.Type == type || type == 0) && (bool)a.IsDeleted == false
                        select a;

            //var t = query.ToList();

            var responseData = new ResponseData<string>()
            {
                Message = "",
                Data = query.Count() > 0 ? ChongGuanDotNetUtils.Helpers.CryptHelper.Encrypt(JsonConvert.SerializeObject(query.ToList())) : ""
            };
            return this.Json(responseData);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update([FromBody]Advertising advertising)
        {
            var query = from a in ModelContext.DatabaseContext.Advertising
                        where a.Id == advertising.Id
                        select a;

            var data = query.FirstOrDefault();

            var responseData = new ResponseData<Advertising>()
            {
                Message = data == null ? "未找到该条广告数据" : "",
                Data = data
            };

            if (data != null)
            {
                ReflectionHelper.CopyProperties(advertising, data, new string[] { "Id" });
                ModelContext.DatabaseContext.Entry(data).State = System.Data.Entity.EntityState.Modified;
                await ModelContext.DatabaseContext.SaveChangesAsync();
            }

            return Json(responseData);
        }

        [HttpGet]
        public async Task<IHttpActionResult> Delete([FromUri]int id)
        {
            var query = from a in ModelContext.DatabaseContext.Advertising
                        where a.Id == id
                        select a;

            var data = query.FirstOrDefault();

            var responseData = new ResponseData<Advertising>()
            {
                Message = data == null ? "未找到该条广告数据" : "",
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
    }
}
