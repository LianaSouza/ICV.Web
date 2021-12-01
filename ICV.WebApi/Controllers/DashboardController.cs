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
        [HttpGet]
        public IEnumerable<EntradaDoacao> Get()
        {
            var listaEntradaDoacoes = new List<EntradaDoacao>();

            using (var context = new ICVContext())
            {
                var query = context.EntradaDoacao
                    .Where(a => a.DataCadastroEntradoDoacao.Contains("2021-11-26"));
            }
            //using (var context = new ICVContext())
            //{
            //    foreach (var item in context.EntradaDoacao)
            //    {
            //        var doacao = new EntradaDoacao
            //        {
            //            IdEntradaDoacao = item.IdEntradaDoacao,
            //            DataCadastroEntradoDoacao = item.DataCadastroEntradoDoacao
            //        };

            //        listaEntradaDoacoes.Add(doacao);
            //    }
            //}
            return listaEntradaDoacoes;
        }


        [HttpGet]
        public IEnumerable<EntradaDoacao> GetEntrada()
        {
            var listaEntradaDoacoes = new List<EntradaDoacao>();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM [Blogs]";
                    var result = await command.ExecuteNonQueryAsync();
                }
            
        }
    }
}

