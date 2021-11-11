using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebUIMVC.Models
{
    public class ColaboradorModel : SuperPessoaAbstract, ICrud<ColaboradorModel>
    {
        [Required]
        public string CPF { get; set; }

        [Required]
        public string DataNascimento { get; set; }

        [Required]
        public TipoColaborador TipoColaborador { get; set; }

        [Required]
        public string Senha { get; set; }

        public ColaboradorModel Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public List<ColaboradorModel> Buscar()
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(ColaboradorModel objeto)
        {
            throw new NotImplementedException();
        }

        public void Editar(ColaboradorModel objeto, int id)
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
