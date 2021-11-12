using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebUIMVC.Models
{
    public class AlunoModel : SuperPessoaAbstract<AlunoModel>
    {
        
        [Required]
        [Display(Name = "Digite o Cpf do Aluno")]
        public string Cpf { get; set; }

        [Required]
        [Display(Name = "Digite o Data de Nascimento Aluno")]
        public string DataNascimento { get; set; }

        public override AlunoModel Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public override List<AlunoModel> Buscar()
        {
            throw new NotImplementedException();
        }

        public override void Cadastrar(AlunoModel objeto)
        {
            throw new NotImplementedException();
        }

        public override void Editar(AlunoModel objeto, int id)
        {
            throw new NotImplementedException();
        }

        public override void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
