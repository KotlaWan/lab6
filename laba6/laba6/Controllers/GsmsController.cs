using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using laba6.Services;
using laba6.Models;
using Microsoft.AspNetCore.Mvc;

namespace laba6.Controllers
{
    [Route("api/[controller]")]
    public class GsmsController : Controller
    {
        private DbService _service;

        public GsmsController(DbService service)
        {
            _service = service;
        }
        // GET api/gsms
        [HttpGet]
        public IEnumerable<PrepareFuels> Get()
        {
            return _service.ListPriceClass();
        }

        // GET api/gsms/5
        [HttpGet("{id}")]
        public List<Class> Get(int id)
        {
            return _service.FindPriceClassById(id);
        }

        //POST api/gsms
        [HttpPost]
        public void Post([FromBody]PriceBody value)
        {
            _service.PostPriceClass(value);
        }

        // PUT api/gsms/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]UpdateModel value)
        {
            _service.UpdatePriceClass(id, value);
        }

        // DELETE api/gsms/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.DeletePriceClass(id);
        }
    }
}
