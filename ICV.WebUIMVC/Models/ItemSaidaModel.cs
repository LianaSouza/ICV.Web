using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebUIMVC.Models
{
    public class ItemSaidaModel : ItemAbstract <ItemSaidaModel>
    {

        public override ItemSaidaModel Buscar(int id)
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = @"SELECT IdSaidaItem, QuantidadeSaidaItem, DataCadastroSaidaItem, FKIdProduto, NomeProduto, CategoriaProduto, FKIdSaidaDoacao, FKIdBeneficiado  FROM TblSaidaItem
                            INNER JOIN TblProduto ON  TblSaidaItem.FkIdProduto = TblProduto.IdProduto
                            INNER JOIN TblSaidaDoacao ON TblSaidaItem.FKIdSaidaDoacao = TblSaidaDoacao.IdSaidaDoacao where TblSaidaItem .IdSaidaItem = " + id;

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            ItemSaidaModel Item = new ItemSaidaModel();

            if (dr.Read())
            {
                Item.IdItem = Convert.ToInt32(dr["IdSaidaItem"]);
                Item.QuantidadeItem = Convert.ToInt32(dr["QuantidadeSaidaItem"]);
                Item.DataCadastroItem = dr["DataCadastroSaidaItem"].ToString();
                Item.FKIdProduto = Convert.ToInt32(dr["FkIdProduto"]);
                Item.FKIdDoacao = Convert.ToInt32(dr["FkIdSaidaDoacao"]);
                Item.NomeProduto = dr["NomeProduto"].ToString();
                Item.categoriaProduto = (CategoriaProduto)Convert.ToInt32(dr["CategoriaProduto"]);
                Item.FKIdBeneficiado = Convert.ToInt32(dr["FkIdBeneficiado"]);
            }

            return Item;
        }

        public override List<ItemSaidaModel> Buscar()
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = @"SELECT IdSaidaItem, QuantidadeSaidaItem, DataCadastroSaidaItem, FKIdProduto, NomeProduto, CategoriaProduto, FKIdSaidaDoacao, FKIdBeneficiado  FROM TblSaidaItem
                            INNER JOIN TblProduto ON  TblSaidaItem.FkIdProduto = TblProduto.IdProduto
                            INNER JOIN TblSaidaDoacao ON TblSaidaItem.FKIdSaidaDoacao = TblSaidaDoacao.IdSaidaDoacao";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            List<ItemSaidaModel> listaObj = new List<ItemSaidaModel>();

            while (dr.Read())
            {
                ItemSaidaModel Item = new ItemSaidaModel();

                Item.IdItem = Convert.ToInt32(dr["IdSaidaItem"]);
                Item.QuantidadeItem = Convert.ToInt32(dr["QuantidadeSaidaItem"]);
                Item.DataCadastroItem = dr["DataCadastroSaidaItem"].ToString();
                Item.FKIdProduto = Convert.ToInt32(dr["FKIdProduto"]);
                Item.FKIdDoacao = Convert.ToInt32(dr["FKIdSaidaDoacao"]);
                Item.NomeProduto = dr["NomeProduto"].ToString();
                Item.categoriaProduto = (CategoriaProduto)Convert.ToInt32(dr["CategoriaProduto"]);
                Item.FKIdBeneficiado = Convert.ToInt32(dr["FkIdBeneficiado"]);

                listaObj.Add(Item);
            }

            return listaObj;
        }

        public override void Cadastrar(ItemSaidaModel objeto)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string date = DateTime.Now.ToString("yyyy-MM-dd");

            string sql = "Insert Into TblSaidaItem Values ('" + objeto.QuantidadeItem + "','" + date + "','" + objeto.FKIdProduto + "','" + objeto.FKIdDoacao + "')";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public override void Editar(ItemSaidaModel objeto, int id)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Update TblSaidaItem Set  QuantidadeSaidaItem='" + objeto.QuantidadeItem + "'   where IdSaidaItem=" + id;
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }


        // Não utilizados
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
