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
        public int IdDoacao { get; set; }
        public int QuantidadeItem { get; set; }
        public CategoriaProduto CategoriaDoacao { get; set; }
        public string DataCadastroDoacao { get; set; }
        public int FKIdColaborador { get; set; }
        public int FKIdProduto { get; set; }



        public abstract T Buscar(int id);

        public abstract List<T> Buscar();

        public abstract void Cadastrar(T objeto);

        public abstract void Editar(T objeto, int id);

        public abstract void Remover(int id);
    }
}
