using System.Linq;
using ICV.WebApi.EF.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;

namespace ICV.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoadorController : ControllerBase
    {
        // GET: api/Doador
        [HttpGet]
        public int? Get()
        {
            try
            {
                using (var context = new ICVContext())
                {
                    var query = context.Doador
                        .Count(a => a.StatusDoador == 1);

                    return query;
                }
            }
            catch 
            {
                return null;
            }
        }
    }
}
