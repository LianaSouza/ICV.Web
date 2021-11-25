using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ICV.WebApi.Context;
using ICV.WebApi.Entity;

namespace ICV.WebApi.Controllers
{
    [Route("ICV/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        // GET: ICV/Dashboard
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var listColaborador = new List<Colaborador>();



            using (var context = new ICVContext())
            {
                foreach (var item in context.Colaborador)
                {

                }
                
            }





                return new string[] { "value1", "value2" };
        }

        // GET: api/Dashboard/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Dashboard
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Dashboard/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
