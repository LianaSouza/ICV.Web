using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebUIMVC.Models
{
    public abstract class ItemAbstract<T> : ICrud<T>
    {
        // Revisado 18/11 - De acordo com o Banco
        [Required]
        public int IdItem { get; set; }

        [Required]
        public int QuantidadeItem { get; set; }

        public string DataCadastroItem { get; set; }

        
        public int FKIdProduto { get; set; }

        public string NomeProduto { get; set; }

        public CategoriaProduto categoriaProduto { get; set; }

        public List<ProdutoModel> Produto { get; set; }


        public List<BeneficiadoModel> Beneficiado { get; set; }

        public int FKIdBeneficiado { get; set; }

        public string NomeBeneficiado { get; set; }


        [Required]
        public int FKIdDoacao { get; set; }

        public abstract T Buscar(int id);

        public abstract List<T> Buscar();

        public abstract void Cadastrar(T objeto);

        public abstract void Editar(T objeto, int id);

        public abstract void Remover(int id);
    }
}
