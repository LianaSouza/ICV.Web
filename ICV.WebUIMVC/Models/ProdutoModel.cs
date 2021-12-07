using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebUIMVC.Models
{
    // Revisado 18/11 - De acordo com o Banco
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

        string dataAtual = DateTime.Now.ToString();

        public List<ProdutoModel> BuscarProdutoSelect()
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = "Select * from TblProduto";

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader dr = cmd.ExecuteReader();

            List<ProdutoModel> lista = new List<ProdutoModel>();

            while (dr.Read())
            {
                ProdutoModel produto = new ProdutoModel();

                produto.IdProduto = Convert.ToInt32(dr["IdProduto"]);
                produto.NomeProduto = dr["NomeProduto"].ToString();

                lista.Add(produto);
            }

            return lista;
        }

        public ProdutoModel Buscar(int id)
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = @"Select * From TblProduto where IdProduto =" + id;

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
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = "Select * from TblProduto";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            List<ProdutoModel> listaObj = new List<ProdutoModel>();

            while (dr.Read())
            {
                ProdutoModel Produto = new ProdutoModel();

                Produto.IdProduto = Convert.ToInt32(dr["IdProduto"]);
                Produto.NomeProduto = dr["NomeProduto"].ToString();
                Produto.CategoriaProduto = (CategoriaProduto)Convert.ToInt32(dr["CategoriaProduto"]);
                Produto.QuantidadeProduto = Convert.ToInt32(dr["QuantidadeProduto"]);
                Produto.DataCadastroProduto = dr["DataCadastroProduto"].ToString();

                listaObj.Add(Produto);
            }
            return listaObj;
        }

        public void Cadastrar(ProdutoModel objeto)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Insert Into TblProduto Values ('" + objeto.NomeProduto + "','" + (int)objeto.CategoriaProduto + "','" + objeto.QuantidadeProduto + "','" + dataAtual + "')";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void Editar(ProdutoModel objeto, int id)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();
            
            string sql = $"Update TblProduto set NomeProduto='{objeto.NomeProduto}', CategoriaProduto={(int)objeto.CategoriaProduto}, QuantidadeProduto={objeto.QuantidadeProduto} where IdProduto = {id}";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Remover(int id)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Delete From TblProduto Where IdProduto=" + id + "";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}
