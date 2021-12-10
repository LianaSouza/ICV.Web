using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICV.WebApi.EF.Context;
using ICV.WebApi.EF.Entity;
using ICV.WebApi.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICV.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoacaoController : ControllerBase
    {
        // GET: api/Doacao
        [HttpGet]
        public int? Get()
        {
            return new RequestDoacao().Get();
        }

        [HttpPost]
        public List<int> Get(RequestDoacao request)
        {
            if (request.RequestDate == null)
                return null;

            if (request.RequestType != 1)
                return null;

            return new RequestDoacao().Get(request);
        }
    }
}