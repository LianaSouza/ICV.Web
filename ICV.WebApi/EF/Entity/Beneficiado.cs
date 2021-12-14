using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebApi.EF.Entity
{
    public class TblBeneficiado
    {
        [Key]
        public int IdBeneficiado { get; set; }

        public string NomeBeneficiado { get; set; }

        public string CpfBeneficiado { get; set; }

        public DateTime DataNascimentoBeneficiado { get; set; }

        public string TelefoneBeneficiado { get; set; }

        public string EmailBeneficiado { get; set; }

        public int StatusBeneficiado { get; set; }

        public int QuantidadesDependentesBeneficiado { get; set; }

        public string RendaMensalBeneficiado { get; set; }

        public DateTime DataCadastroBeneficiado { get; set; }

        public int FKIdColaborador { get; set; }
    }
}
