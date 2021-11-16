using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebUIMVC.Models
{
    public class DoacaoSaidaModel : DoacaoAbstract<DoacaoSaidaModel>
    {
        string dataAtual = DateTime.Now.ToString();

        public override DoacaoSaidaModel Buscar(int id)
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = @"Select * From TblSaidaDoacao where IdSaidaDoacao =" + id;

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DoacaoSaidaModel Doacao = new DoacaoSaidaModel();

            if (dr.Read())
            {
                Doacao.IdDoacao = Convert.ToInt32(dr["IdSaidaDoacao"]);
                Doacao.CategoriaDoacao= (CategoriaProduto) Convert.ToInt32(dr["TipoSaidaDoacao"]);
                Doacao.DataCadastroDoacao = dr["DataCadastroSaidaDoacao"].ToString();
                Doacao.FKIdBeneficiado = Convert.ToInt32(dr["FKIdBeneficiado"]);
            }
            return Doacao;
        }

        public override List<DoacaoSaidaModel> Buscar()
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = @"Select * From TblSaidaDoacao";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
           
            List<DoacaoSaidaModel> listaObj = new List<DoacaoSaidaModel>();

            if (dr.Read())
            {
                DoacaoSaidaModel Doacao = new DoacaoSaidaModel();

                Doacao.IdDoacao = Convert.ToInt32(dr["IdSaidaDoacao"]);
                Doacao.CategoriaDoacao = (CategoriaProduto)Convert.ToInt32(dr["TipoSaidaDoacao"]);
                Doacao.DataCadastroDoacao = dr["DataCadastroSaidaDoacao"].ToString();
                Doacao.FKIdBeneficiado = Convert.ToInt32(dr["FKIdBeneficiado"]);

                listaObj.Add(Doacao);
            }
            return listaObj;
        }

        public override void Cadastrar(DoacaoSaidaModel objeto)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Insert Into TblSaidaDoacao Values ('" + objeto.CategoriaDoacao + "','" + dataAtual + "','" + objeto.FKIdBeneficiado + "')";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public override void Editar(DoacaoSaidaModel objeto, int id)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Update TblSaidaDoacao Set  TipoSaidaDoacao='" + objeto.CategoriaDoacao + "', where IdSaidaDoacao=" + objeto.IdDoacao;
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public override void Remover(int id)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Delete From TblSaidaDoacao Where IdSaidaDoacao=" + id + "";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}
