using ICV.WebApi.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebApi.Request
{
    public class RequestDoacao
    {
        public int RequestType { get; set; }
        public string RequestDate { get; set; }

        public List<int?> Get()
        
        {
            try
            {
                var values = new List<int?>();

                using (var context = new ICVContext())
                {
                    var query = context.Doacao
                        .Where(a => a.DataCadastroEntradaDoacao.Contains("2021"));

                    values.Add(query.Count(a => a.TipoEntradaDoacao == 1));
                    values.Add(query.Count(a => a.TipoEntradaDoacao == 2));
                    values.Add(query.Count(a => a.TipoEntradaDoacao == 3));
                }

                return values;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public List<int?> GetYear(string year)
        {
            var doacoesList = new List<int?>();

            using (var context = new ICVContext())
            {
                var query = context.Doacao
                    .Where(a => a.DataCadastroEntradaDoacao.Contains("01/01/2021"));

                doacoesList.Add(query.Count());
            }

            return doacoesList;
        }
    }
}
