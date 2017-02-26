using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Taksimetrik.Service.Models;

namespace Taksimetrik.Service.Controllers
{
    public class BaseController : ApiController
    {

        public IHttpActionResult Result(bool isSuccess, string message)
        {
            return Ok(new ResultModel()
            {
                IsSuccess = isSuccess,
                Message = message
            });
        }
    }
}