using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebUIMVC.Models
{
    public class AlunoModel : SuperPessoaAbstract, ICrud <AlunoModel>
    {
        [Required]
        [Display(Name = "Digite o Cpf do Aluno")]
        public string Cpf { get; set; }

        [Required]
        [Display(Name = "Digite o Data de Nascimento Aluno")]
        public string DataNascimento { get; set; }

        public AlunoModel Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public List<AlunoModel> Buscar()
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(AlunoModel objeto)
        {
            throw new NotImplementedException();
        }

        public void Editar(AlunoModel objeto, int id)
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
