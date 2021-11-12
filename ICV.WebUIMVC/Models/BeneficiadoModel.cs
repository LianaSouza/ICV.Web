using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebUIMVC.Models
{
    public class BeneficiadoModel : SuperPessoaAbstract <BeneficiadoModel>
    {
        [Required]
        public string CpfBeneficiado { get; set; }

        [Required]
        public string DataNascimento { get; set; }

        [Required]
        [Display(Name = "Digite a quantidade de pessoas na casa")]
        public string QuantidadeDependentes { get; set; }

        [Required]
        [Display(Name = "Digite a renda mensal da familia cadastrada")]
        public string RendaMensalBeneficiado { get; set; }

        public override BeneficiadoModel Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public override List<BeneficiadoModel> Buscar()
        {
            throw new NotImplementedException();
        }

        public override void Cadastrar(BeneficiadoModel objeto)
        {
            throw new NotImplementedException();
        }

        public override void Editar(BeneficiadoModel objeto, int id)
        {
            throw new NotImplementedException();
        }

        public override void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
