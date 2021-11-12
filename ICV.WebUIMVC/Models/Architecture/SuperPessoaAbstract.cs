using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebUIMVC.Models
{
    public abstract class SuperPessoaAbstract<T> : ICrud <T>
    {
        [Required]
        public int id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        public Status Status { get; set; }

        public string DataCadastro { get; set; }

        public abstract T Buscar(int id);

        public abstract List<T> Buscar();

        public abstract void Cadastrar(T objeto);

        public abstract void Editar(T objeto, int id);

        public abstract void Remover(int id);
    }
}
