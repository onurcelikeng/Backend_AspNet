using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Taksimetrik.Service.Entities.Tables;
using Taksimetrik.Service.Repositories;

namespace Taksimetrik.Service.Controllers
{
    [RoutePrefix("api/car")]
    public class CarController : BaseController
    {
        private Repository<Car> CarRepo = new Repository<Car>();


        // GET: api/Car
        public IEnumerable<string> Get()
        {
            return null;
        }

        // GET: api/Car/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Car
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Car/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Car/5
        public void Delete(int id)
        {
        }
    }
}