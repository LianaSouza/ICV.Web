using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebApi.Entity
{
    public class EntradaDoacao
    {
        public int IdEntradaDoacao { get; set; }

        public int TipoEntradoDoacao { get; set; }

        public string DataCadastroEntradoDoacao { get; set; }

        public int FKIdDoador { get; set; }

        public int FkIdColaborador { get; set; }

    }
}
