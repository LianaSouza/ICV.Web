using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebApi.Entity
{
    public class Doador
    {
        [Key]
        public int IdDoador { get; set; }
        public int NomeDoador { get; set; }
        public int DocumentoDoador { get; set; }
        public int TelefoneDoador { get; set; }
        public int EmailDoador { get; set; }
        public int StatusDoador { get; set; }
        public int AnonimoDoador { get; set; }
        public int ObservacaoDoador { get; set; }
        public int DataCadastroDoador { get; set; }
        public int FkIdColaborador { get; set; }
    }
}
