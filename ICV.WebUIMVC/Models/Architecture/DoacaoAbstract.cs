using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebUIMVC.Models
{
    public abstract class DoacaoAbstract <T> : ICrud<T>
    {
        // Revisado 19/11 - De acordo com o Banco

        [Required]
        public int IdDoacao { get; set; }

        [Required]
        public int QuantidadeItem { get; set; }

        [Required]
        [Display(Name = "Digite o  tipo de produto")]
        public CategoriaProduto CategoriaDoacao { get; set; }

        public string DataCadastroDoacao { get; set; }

        [Required]
        public int FKIdColaborador { get; set; }


        public abstract T Buscar(int id);

        public abstract List<T> Buscar();

        public abstract void Cadastrar(T objeto);

        public abstract void Editar(T objeto, int id);

        public abstract void Remover(int id);
    }
}
