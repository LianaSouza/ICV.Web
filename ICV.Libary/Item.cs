using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ICV.Libary
{
    class Item : ICrud <Item>
    {
        public int IdItem { get; set; }
        public string QuantidadeItem { get; set; }
        public string DataCadastroItem { get; set; }
        public string IdProduto { get; set; }
        public string IdDoacao { get; set; }
        public TipoItem TipoItem { get; set; }

        string dataAtual = DateTime.Now.ToString();

        // CRUD -> Item Entrada

        public void Cadastrar(Item objeto)
        {
            SqlConnection con = new SqlConnection(ConnectDb.Connect());
            con.Open();

            string sql = "Insert Into ItemEntrada Values ('" + objeto.IdItem + "','" + objeto.QuantidadeItem + "','" + dataAtual + "','" + objeto.IdProduto + "','" + objeto.IdDoacao + "')";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }
        public void Remover(int id)
        {
            SqlConnection con = new SqlConnection(ConnectDb.Connect());
            con.Open();

            string sql = "Delete From ItemEntrad Where IdPost=" + id + "";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }
        public Item Buscar(int id)
        {
            throw new NotImplementedException();
            /*SqlConnection conn = new SqlConnection(ConnectDb.Connect());
            conn.Open();

            string sql = @"Select * From TblPost where IdPost =" + id;

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            List<Item> listaObj = new List<Item>();

            if (dr.Read())
            {
                Item Item = new Item();

                Item.IdItem = Convert.ToInt32(dr["IdItem"]);
                Item.QuantidadeItem = dr["QuantidadeItem"].ToString();
                Item.DataCadastroItem = dr["DataCadastroItem"].ToString();
                Item.IdProduto = dr["FkProduto"].ToString();
                Item.IdDoacao = dr["FkDoacao"].ToString();

                listaObj.Add(Item);
            }

            //return listaObj;*/

        }

        public List<Item> Buscar()
        {
            throw new NotImplementedException();

        }

        public void Editar(Item objeto, int id)
        {
            throw new NotImplementedException();
        }

        

        // CRUD -> Item Saida

        public void CadastrarItemSaida(Item  objeto)
        {
            SqlConnection con = new SqlConnection(ConnectDb.Connect());
            con.Open();

            string sql = "Insert Into ItemSaida Values ('" + objeto.IdItem + "','" + objeto.QuantidadeItem + "','" + dataAtual + "','" + objeto.IdProduto + "','" + objeto.IdDoacao + "')";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            
            con.Close();
        }


    }
}
