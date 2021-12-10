using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICV.WebApi.EF.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
