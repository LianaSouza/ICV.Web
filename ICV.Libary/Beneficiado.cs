using System;
using System.Collections.Generic;
using System.Text;

namespace ICV.Libary
{
    class Beneficiado:SuperPessoaAbstract
    {
        public string CpfBeneficiado { get; set; }
        public string DataNascimento { get; set; }
        public string QuantidadeDependentesBeneficiado { get; set; }
        public string RendaMensalBeneficiado { get; set; }
        
    }
}
