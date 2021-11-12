using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebUIMVC.Models
{
    public abstract class DoacaoAbstract <T> : ICrud<T>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public CategoriaProduto CategoriaDoacao { get; set; }

        public string DataCadastro { get; set; }

        [Required]
        public int FKIdDoador { get; set; }

        [Required]
        public int FKIdBeneficiado { get; set; }

        public abstract T Buscar(int id);

        public abstract List<T> Buscar();

        public abstract void Cadastrar(T objeto);

        public abstract void Editar(T objeto, int id);

        public abstract void Remover(int id);
    }
}
