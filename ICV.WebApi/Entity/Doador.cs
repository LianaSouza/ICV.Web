using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebApi.Entity
{
    public class Doador
    {
        public int IdDoador { get; set; }

        public string NomeDoador { get; set; }

        public string DocumentoDoador { get; set; }

        public string TelefoneDoador { get; set; }

        public string EmailDoador { get; set; }

        public int StatusDoador { get; set; }

        public int AnonimoDoador { get; set; }

        public string ObservacaoDoador { get; set; }

        public DateTime DataCadastroDoador { get; set; }

        public int FkIdColaborador { get; set; }

        public virtual Colaborador Colaborador { get; set; }
    }
}
