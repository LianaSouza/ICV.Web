using System;
using System.ComponentModel.DataAnnotations;

namespace ICV.WebApi.EF.Entity
{
    public class Colaborador
    {
        [Key]
        public int IdColaborador { get; set; }

        public string NomeColaborador { get; set; }

        public string DocumentoColaborador { get; set; }

        public DateTime DataNascimentoColaborador { get; set; }

        public string EmailColaborador { get; set; }

        public string SenhaColaborador { get; set; }

        public string TelefoneColaborador { get; set; }

        public int TipoColaborador { get; set; }

        public int StatusColaborador { get; set; }

        public DateTime DataCadastroColaborador { get; set; }
    }
}
