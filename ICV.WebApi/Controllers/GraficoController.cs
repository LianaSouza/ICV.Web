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
    public class GraficoController : ControllerBase
    {
        // GET: api/Grafico
        [HttpGet]
        public List<int?> Get()
        {
            var values = new List<int?>();

            using (var context = new ICVContext())
            
            {
                var value1 = context.Colaborador
                    .Count(a => a.TipoColaborador == 0 && a.StatusColaborador == 1);

                var value2 = context.Doador
                    .Count(a => a.StatusDoador == 1);

                var value3 = context.TblBeneficiado
                    .Count(a => a.StatusBeneficiado == 1);

                values.Add(value1);

                values.Add(value2);

                values.Add(value3);

                return values;
            }
        }
    }
}