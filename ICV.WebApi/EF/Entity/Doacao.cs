using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebApi.EF.Entity
{
    public class Doacao
    {
        public int IdEntradaDoacao { get; set; }

        public int TipoEntradaDoacao { get; set; }

        public string DataCadastroEntradaDoacao { get; set; }
    }
}
