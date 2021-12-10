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

        public int? Get()
        {
            try
            {
                using (var context = new ICVContext())
                {
                    var query = context.Doacao
                        .Count();

                    return query;
                }
            }
            catch
            {
                return null;
            }
        }

        public List<int> Get(RequestDoacao request)
        {
            try
            {
                var values = new List<int>();

                using (var context = new ICVContext())
                {
                    var query = context.Doacao
                        .Where(a => a.DataCadastroEntradaDoacao.Contains(request.RequestDate));

                    values.Add(query.Count(a => a.TipoEntradaDoacao == 1));
                    values.Add(query.Count(a => a.TipoEntradaDoacao == 2));
                    values.Add(query.Count(a => a.TipoEntradaDoacao == 3));
                }

                return values;
            }
            catch
            {
                return null;
            }
        }
    }
}
