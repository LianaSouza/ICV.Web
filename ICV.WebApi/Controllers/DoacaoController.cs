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
        public List<int?> Get()
        {
            return new RequestDoacao().Get();
        }

        [HttpPost]
        public List<int?> Get(RequestDoacao request)
        {
            if (string.IsNullOrEmpty(request.RequestDate))
                return null;

            return new RequestDoacao().GetYear(request.RequestDate);
        }

    }
}