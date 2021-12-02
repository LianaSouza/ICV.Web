using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebApi.Entity
{
    public class SaidaDoacao
    {
        public int IdEntradaDoacao { get; set; }

        public int TipoSaidaDoacao { get; set; }

        public string DataCadastroSaidaDoacao { get; set; }

        public int FKIdDoador { get; set; }

        public int FkIdColaborador { get; set; }
    }
}
