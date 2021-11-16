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
        public string Cpf { get; set; }

        [Required]
        public string DataNascimento { get; set; }

        [Required]
        public int FKIdTurma { get; set; }

        [Required]
        public int FKIdColaborador { get; set; }


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
