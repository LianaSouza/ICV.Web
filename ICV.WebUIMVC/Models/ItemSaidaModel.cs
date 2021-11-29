using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebUIMVC.Models
{
    public class ItemSaidaModel : ItemAbstract <ItemSaidaModel>
    {
        // Revisado 18/11 - De acordo com o Banco
        string dataAtual = DateTime.Now.ToString();

        public override ItemSaidaModel Buscar(int id)
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = @"Select * From TblSaidaItem where IdSaidaItem =" + id;

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            ItemSaidaModel Item = new ItemSaidaModel();

            if (dr.Read())
            {
                Item.IdItem = Convert.ToInt32(dr["IdSaidaItem"]);
                Item.QuantidadeItem = dr["QuantidadeSaidaItem"].ToString();
                Item.DataCadastroItem = dr["DataCadastroSaidaItem"].ToString();
                Item.FKIdProduto = dr["FkIdProduto"].ToString();
                Item.FKIdDoacao = dr["FkIdSaidaDoacao"].ToString(); 
            }

            return Item;
        }

        public override List<ItemSaidaModel> Buscar()
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = "Select * from TblSaidaItem";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            List<ItemSaidaModel> listaObj = new List<ItemSaidaModel>();

            while (dr.Read())
            {
                ItemSaidaModel Item = new ItemSaidaModel();

                Item.IdItem = Convert.ToInt32(dr["IdSaidaItem"]);
                Item.QuantidadeItem = dr["QuantidadeSaidaItem"].ToString();
                Item.DataCadastroItem = dr["DataCadastroSaidaItem"].ToString();
                Item.FKIdProduto = dr["FkIdProduto"].ToString();
                Item.FKIdDoacao = dr["FkIdSaidaDoacao"].ToString();

                listaObj.Add(Item);
            }

            return listaObj;
        }

        public override void Cadastrar(ItemSaidaModel objeto)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Insert Into TblSaidaItem Values ('" + objeto.QuantidadeItem + "','" + dataAtual + "','" + objeto.FKIdProduto + "','" + objeto.FKIdDoacao + "')";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public override void Editar(ItemSaidaModel objeto, int id)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Update TblSaidaItem Set  QuantidadeSaidaItem='" + objeto.QuantidadeItem + "',   where IdSaidaItem=" + objeto.IdItem;
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public override void Remover(int id)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Delete From TblSaidaItem Where IdSaidaItem=" + id + "";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}
