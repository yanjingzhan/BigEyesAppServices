using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BigEyesAppServices.Models
{
    public class ResponseData<T>
    {
        public string Message { get; set; }
        public T Data { get; set; }
    }
}