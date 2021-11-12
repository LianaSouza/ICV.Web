using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebUIMVC.Models
{
    public class ItemSaidaModel : ItemAbstract <ItemSaidaModel>
    {
        string dataAtual = DateTime.Now.ToString();

        public override ItemSaidaModel Buscar(int id)
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = @"Select * From ItemSaida where IdSaidaDoacao =" + id;

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            ItemSaidaModel Item = new ItemSaidaModel();

            if (dr.Read())
            {
                Item.IdItem = Convert.ToInt32(dr["IdSaidaDoacao"]);
                Item.QuantidadeItem = dr["QuantidadeItem"].ToString();
                Item.DataCadastroItem = dr["DataCadastroItem"].ToString();
                Item.IdProduto = dr["FkProduto"].ToString();
                Item.IdDoacao = dr["FkDoacao"].ToString();
            }

            return Item;
        }

        public override List<ItemSaidaModel> Buscar()
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = "Select * from ItemSaida";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            List<ItemSaidaModel> listaObj = new List<ItemSaidaModel>();

            if (dr.Read())
            {
                ItemSaidaModel Item = new ItemSaidaModel();

                Item.IdItem = Convert.ToInt32(dr["IdSaidaDoacao"]);
                Item.QuantidadeItem = dr["QuantidadeItem"].ToString();
                Item.DataCadastroItem = dr["DataCadastroItem"].ToString();
                Item.IdProduto = dr["FkProduto"].ToString();
                Item.IdDoacao = dr["FkDoacao"].ToString();

                listaObj.Add(Item);
            }

            return listaObj;
        }

        public override void Cadastrar(ItemSaidaModel objeto)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Insert Into ItemSaida Values ('" + objeto.IdItem + "','" + objeto.QuantidadeItem + "','" + dataAtual + "','" + objeto.IdProduto + "','" + objeto.IdDoacao + "')";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public override void Editar(ItemSaidaModel objeto, int id)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Update ItemSaida Set  QuantidadeItem='" + objeto.QuantidadeItem + "',   where IdSaidaDoacao=" + objeto.IdItem;
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public override void Remover(int id)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Delete From ItemSaida Where IdSaidaDoacao=" + id + "";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}
