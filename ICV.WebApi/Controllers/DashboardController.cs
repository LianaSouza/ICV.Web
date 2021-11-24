using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICV.WebApi.Controllers
{
    [Route("ICV.API/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        // GET: api/Dashboard
        [HttpGet]
        public Models.Dashboard Get()
        {
            var lista = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                lista.Add(i+22);
            }

            var dashboard = new Models.Dashboard()
            {
                DataInicio = "22/01/2022",
                DataFim = "23/01/2022",
                QtdEntradaDoacao = lista,
                QtdSaidaDoacao = lista
            };

            return dashboard;
        }

    }
}
