using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebUIMVC.Models
{
    public class ItemEntradaModel : ItemAbstract <ItemEntradaModel>
    {
        //Revisado com o banco - 26/11
    
        string dataAtual = DateTime.Now.ToString();

        public override ItemEntradaModel Buscar(int id)
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = @"Select * From TblEntradaItem where IdEntradaItem =" + id;

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            ItemEntradaModel Item = new ItemEntradaModel();

            if (dr.Read())
            {
                Item.IdItem = Convert.ToInt32(dr["IdEntradaItem"]);
                Item.QuantidadeItem = dr["QuantidadeEntradaItem"].ToString();
                Item.categoriaProduto = (CategoriaProduto) Convert.ToInt32( dr["QuantidadeEntradaItem"]);
                Item.DataCadastroItem = dr["DataCadastroEntradaItem"].ToString();
                Item.FKIdDoacao = dr["FkIdEntradaDoacao"].ToString();
                Item.FKIdProduto = dr["FkIdProduto"].ToString(); 
            }

            return Item;
        }

        public override List<ItemEntradaModel> Buscar()
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = "Select * from TblEntradaItem";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            List<ItemEntradaModel> listaObj = new List<ItemEntradaModel>();

            if (dr.Read())
            {
                ItemEntradaModel Item = new ItemEntradaModel();

                Item.IdItem = Convert.ToInt32(dr["IdEntradaItem"]);
                Item.QuantidadeItem = dr["QuantidadeEntradaItem"].ToString();
                Item.categoriaProduto = (CategoriaProduto)Convert.ToInt32(dr["QuantidadeEntradaItem"]);
                Item.DataCadastroItem = dr["DataCadastroEntradaItem"].ToString();
                Item.FKIdDoacao = dr["FkIdEntradaDoacao"].ToString();
                Item.FKIdProduto = dr["FkIdProduto"].ToString();

                listaObj.Add(Item);
            }

            return listaObj;
        }

        public override void Cadastrar(ItemEntradaModel objeto)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Insert Into TblEntradaItem Values ('" + objeto.QuantidadeItem + "','" + objeto.categoriaProduto + "','" + dataAtual + "','" + objeto.FKIdDoacao + "','" + objeto.FKIdProduto + "')";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public override void Editar(ItemEntradaModel objeto, int id)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Update TblEntradaItem Set  QuantidadeEntradaItem='" + objeto.QuantidadeItem + "', TipoEntradaItem='" + objeto.categoriaProduto + "',   where IdEntradaItem=" + objeto.IdItem;
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public override void Remover(int id)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Delete From TblEntradaItem Where IdEntradaItem=" + id + "";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}
