using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebUIMVC.Models
{
    public class DoacaoEntradaModel : DoacaoAbstract<DoacaoEntradaModel>
    {
        // Revisado 19/11 - De acordo com o Banco

        [Required]
        public int FKIdDoador { get; set; }

        [Required]
        public int FKIdEntradaDoacao { get; set; }

        string dataAtual = DateTime.Now.ToString();


        public override DoacaoEntradaModel Buscar(int id)
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = @"Select * From TblEntradaDoacao where IdEntradaDoacao =" + id;

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DoacaoEntradaModel Doacao = new DoacaoEntradaModel();

            if (dr.Read())
            {
                Doacao.IdDoacao = Convert.ToInt32(dr["IdEntradaDoacao"]);
                Doacao.CategoriaDoacao = (CategoriaProduto)Convert.ToInt32(dr["TipoEntradaDoacao"]);
                Doacao.DataCadastroDoacao = dr["DataCadastroEntradaDoacao"].ToString();
                Doacao.FKIdDoador = Convert.ToInt32(dr["FKIdDoador"]);
                Doacao.FKIdColaborador = Convert.ToInt32(dr["FKIdColaborador"]);
            }
            return Doacao;
        }

        public override List<DoacaoEntradaModel> Buscar()
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = @"Select * From TblEntradaDoacao";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            List<DoacaoEntradaModel> listaObj = new List<DoacaoEntradaModel>();

            if (dr.Read())
            {
                DoacaoEntradaModel Doacao = new DoacaoEntradaModel();

                Doacao.IdDoacao = Convert.ToInt32(dr["IdEntradaDoacao"]);
                Doacao.CategoriaDoacao = (CategoriaProduto)Convert.ToInt32(dr["TipoEntradaDoacao"]);
                Doacao.DataCadastroDoacao = dr["DataCadastroEntradaDoacao"].ToString();
                Doacao.FKIdDoador = Convert.ToInt32(dr["FKIdDoador"]);
                Doacao.FKIdColaborador = Convert.ToInt32(dr["FKIdColaborador"]);

                listaObj.Add(Doacao);
            }

            return listaObj;
        }

        public override void Cadastrar(DoacaoEntradaModel objeto)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Insert Into TblEntradaDoacao Values ('" + objeto.CategoriaDoacao + "','" + dataAtual + "','" + objeto.FKIdDoador + "','" + objeto.FKIdColaborador + "')";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public override void Editar(DoacaoEntradaModel objeto, int id)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Update TblEntradaDoacao Set  TipoEntradaDoacao='" + objeto.CategoriaDoacao + "', where IdEntradaDoacao=" + objeto.IdDoacao;
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public override void Remover(int id)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Delete From TblEntradaDoacao Where IdEntradaDoacao=" + id + "";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}
