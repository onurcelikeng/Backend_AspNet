using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Taksimetrik.Service.Entities.Tables;
using Taksimetrik.Service.Models;
using Taksimetrik.Service.Repositories;

namespace Taksimetrik.Service.Controllers
{
    [RoutePrefix("api/driver")]
    public class DriverController : BaseController
    {
        private Repository<Driver> DriverRepo = new Repository<Driver>();


        [HttpGet]
        [Route("list")]
        public IHttpActionResult GetDrivers()
        {
            List<Driver> drivers = DriverRepo.All();
            
            var list = drivers.Select(driver => new DriverModel()
            {
                Id = driver.Id,
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                Phone = driver.Phone,
                TCnumber = driver.TCnumber
            }).ToList();

            return Ok(list);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetDriverFindById(int id)
        {
            Driver driver = DriverRepo.Single(p => p.Id == id);

            if (driver == null)
                return NotFound();

            var model = new DriverModel()
            {
                Id = driver.Id,
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                Phone = driver.Phone,
                TCnumber = driver.TCnumber
            };

            return Ok(model);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IHttpActionResult> AddDriver()
        {
            string param = await Request.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<Driver>(param);

            var response = DriverRepo.Add(new Driver()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Phone = model.Phone,
                TCnumber = model.TCnumber
            });

            if (response == true)
                return Result(true, "Başarıyla eklendi.");
            else
                return Result(false, "Ekleme işlemi başarısız.");
        }

        [HttpPost]
        [Route("update")]
        public async Task<IHttpActionResult> UpdateDriver()
        {
            string param = await Request.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<Driver>(param);

            var driver = DriverRepo.Single(p => p.Id == model.Id);
            if(driver != null)
            {              
                var response = DriverRepo.Update(new Driver()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Phone = model.Phone,
                    TCnumber = model.TCnumber
                });

                if (response == true)
                    return Result(true, "Başarıyla güncellendi.");
                else
                    return Result(false, "Güncelleme işlemi başarısız.");
            }

            else
                return Result(false, "Böyle bir sürücü yok.");
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IHttpActionResult> DeleteDriver()
        {
            string param = await Request.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<Driver>(param);

            var response = DriverRepo.Delete(DriverRepo.Single(p => p.Id == model.Id));

            if (response == true)
                return Result(true, "Başarıyla silindi.");
            else
                return Result(false, "Silme işlemi başarısız.");
        }
    }
}