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
    [RequestAuthorize]
    public class VersionUpdateController : ApiController
    {
        [HttpPost]
        public async Task<IHttpActionResult> Add([FromBody]VersionUpdate versionUpdate)
        {
            versionUpdate.ModifyTime = DateTime.Now;
            versionUpdate.CreateTime = DateTime.Now;

            var data = ModelContext.DatabaseContext.VersionUpdate.Add(versionUpdate);
            await ModelContext.DatabaseContext.SaveChangesAsync();

            ResponseData<VersionUpdate> result = new ResponseData<VersionUpdate>
            {
                Data = data
            };

            return Json(result);
        }

        [HttpGet]
        public IHttpActionResult Query([FromUri]int id = 0)
        {
            var query = from a in ModelContext.DatabaseContext.VersionUpdate
                        where (a.Id == id || id == 0) && (bool)a.IsDeleted == false
                        select a;

            var responseData = new ResponseData<IEnumerable<VersionUpdate>>()
            {
                Message = "",
                Data = query
            };
            return this.Json(responseData);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update([FromBody]VersionUpdate versionUpdate)
        {
            var query = from a in ModelContext.DatabaseContext.VersionUpdate
                        where a.Id == versionUpdate.Id
                        select a;

            var data = query.FirstOrDefault();

            var responseData = new ResponseData<VersionUpdate>()
            {
                Message = data == null ? "未找到该更新信息" : "",
                Data = data
            };

            if (data != null)
            {
                ReflectionHelper.CopyProperties(versionUpdate, data, new string[] { "Id" });
                data.ModifyTime = DateTime.Now;
                ModelContext.DatabaseContext.Entry(data).State = System.Data.Entity.EntityState.Modified;
                await ModelContext.DatabaseContext.SaveChangesAsync();
            }

            return Json(responseData);
        }

        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetVersionUpdateInfo()
        {
            var query = from a in ModelContext.DatabaseContext.VersionUpdate
                        where (bool)a.IsDeleted == false
                        select a;

            //var t = query.ToList();

            var responseData = new ResponseData<string>()
            {
                Message = "",
                Data = query.Count() > 0 ? ChongGuanDotNetUtils.Helpers.CryptHelper.Encrypt(JsonConvert.SerializeObject(query.ToList())) : ""
            };

            return this.Json(responseData);
        }

        [HttpGet]
        public async Task<IHttpActionResult> Delete([FromUri]int id)
        {
            var query = from a in ModelContext.DatabaseContext.VersionUpdate
                        where a.Id == id
                        select a;

            var data = query.FirstOrDefault();

            var responseData = new ResponseData<VersionUpdate>()
            {
                Message = data == null ? "未找到该更新数据" : "",
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
