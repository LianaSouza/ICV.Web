using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebUIMVC.Models
{
    public class ProdutoModel : ICrud <ProdutoModel>
    {
        [Required]
        public int IdProduto { get; set; }

        [Required]
        public string NomeProduto { get; set; }

        [Required]
        public CategoriaProduto CategoriaProduto { get; set; }

        [Required]
        public int QuantidadeProduto { get; set; }

        public string DataCadastroProduto { get; set; }


        public ProdutoModel Buscar(int id)
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = @"Select * From Produto where IdProduto =" + id;

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            ProdutoModel produto = new ProdutoModel();

            if (dr.Read())
            {
                produto.IdProduto = Convert.ToInt32(dr["IdProduto"]);
                produto.NomeProduto = dr["NomeProduto"].ToString();
                produto.CategoriaProduto = (CategoriaProduto)Convert.ToInt32(dr["CategoriaProduto"]);
                produto.QuantidadeProduto = Convert.ToInt32(dr["QuantidadeProduto"]);
                produto.DataCadastroProduto = dr["DataCadastroProduto "].ToString();

            }
            return produto;
        }

        public List<ProdutoModel> Buscar()
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(ProdutoModel objeto)
        {
            throw new NotImplementedException();
        }

        public void Editar(ProdutoModel objeto, int id)
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
