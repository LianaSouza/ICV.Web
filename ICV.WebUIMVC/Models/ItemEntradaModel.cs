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

        public override ItemEntradaModel Buscar(int id)
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = @"SELECT IdEntradaItem, QuantidadeItem, TipoEntradaItem, DataCadastroEntradoItem, FKIdProduto, NomeProduto, CategoriaProduto, FKIdEntradaDoacao, FKIdDoador  FROM TblEntradaItem
                            INNER JOIN TblProduto ON  TblEntradaItem.FkIdProduto = TblProduto.IdProduto
                            INNER JOIN TblEntradaDoacao ON TblEntradaItem.FKIdEntradaDoacao = TblEntradaDoacao.IdEntradaDoacao where IdEntradaItem =" + id;

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            ItemEntradaModel Item = new ItemEntradaModel();

            if (dr.Read())
            {
                Item.IdItem = Convert.ToInt32(dr["IdEntradaItem"]);
                Item.QuantidadeItem = Convert.ToInt32(dr["QuantidadeItem"]);
                Item.categoriaProduto = (CategoriaProduto)Convert.ToInt32(dr["TipoEntradaItem"]);
                Item.DataCadastroItem = dr["DataCadastroEntradoItem"].ToString();
                Item.FKIdDoacao = Convert.ToInt32(dr["FkIdEntradaDoacao"]);
                Item.FKIdProduto = Convert.ToInt32(dr["FkIdProduto"]);
                Item.NomeProduto = dr["NomeProduto"].ToString();
                Item.categoriaProduto = (CategoriaProduto)Convert.ToInt32(dr["CategoriaProduto"]);
                Item.FKIdDoador = Convert.ToInt32(dr["FkIdDoador"]);
            }

            return Item;
        }

        public override List<ItemEntradaModel> Buscar()
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = @"SELECT IdEntradaItem, QuantidadeItem, TipoEntradaItem, DataCadastroEntradoItem,FKIdDoador , FKIdProduto, NomeProduto, FKIdEntradaDoacao  FROM TblEntradaItem
                            INNER JOIN TblProduto ON  TblEntradaItem.FkIdProduto = TblProduto.IdProduto
                            INNER JOIN TblEntradaDoacao ON TblEntradaItem.FKIdEntradaDoacao = TblEntradaDoacao.IdEntradaDoacao";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            List<ItemEntradaModel> listaObj = new List<ItemEntradaModel>();

            while (dr.Read())
            {
                ItemEntradaModel Item = new ItemEntradaModel();

                Item.IdItem = Convert.ToInt32(dr["IdEntradaItem"]);
                Item.QuantidadeItem = Convert.ToInt32(dr["QuantidadeItem"]);
                Item.categoriaProduto = (CategoriaProduto)Convert.ToInt32(dr["TipoEntradaItem"]);
                Item.DataCadastroItem = dr["DataCadastroEntradoItem"].ToString();
                Item.FKIdProduto = Convert.ToInt32(dr["FkIdProduto"]);
                Item.NomeProduto = dr["NomeProduto"].ToString();
                Item.FKIdDoador = Convert.ToInt32(dr["FkIdDoador"]);
                Item.FKIdDoacao = Convert.ToInt32(dr["FkIdEntradaDoacao"]);
  
                listaObj.Add(Item);
            }

            return listaObj;
        }

        public override void Cadastrar(ItemEntradaModel objeto)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string date = DateTime.Now.ToString("yyyy-MM-dd");

            string sql = "Insert Into TblEntradaItem Values ('" + objeto.QuantidadeItem + "','" + (int)objeto.categoriaProduto + "','" + date + "','" + objeto.FKIdDoacao + "','" + objeto.FKIdProduto + "')";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public override void Editar(ItemEntradaModel objeto, int id)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Update TblEntradaItem Set  QuantidadeEntradaItem='" + objeto.QuantidadeItem + "', TipoEntradaItem='" + (int)objeto.categoriaProduto + "'   where IdEntradaItem=" + id;
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
