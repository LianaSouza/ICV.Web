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
        public int FKIdDoador { get; set; }
        public int FKIdEntradaDoacao { get; set; }
        public string Colaborador { get; set; }
        public int QuantidadeProduto { get; set; }
        public List<DoadorModel> Doador { get; set; }
        public List<ProdutoModel> Produto { get; set; }
        public DoacaoEntradaModel ListBeneficiado { get; set; }
        

        public DoacaoEntradaModel BuscarId(int id)
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = @"SELECT TOP 1* FROM TblEntradaDoacao where FkIdColaborador = "+id+" ORDER BY DataCadastroEntradoDoacao DESC ";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DoacaoEntradaModel Doacao = new DoacaoEntradaModel();

            if (dr.Read())
            {
                Doacao.IdDoacao = Convert.ToInt32(dr["IdEntradaDoacao"]);
                Doacao.CategoriaDoacao = (CategoriaProduto)Convert.ToInt32(dr["TipoEntradoDoacao"]);
                Doacao.DataCadastroDoacao = dr["DataCadastroEntradoDoacao"].ToString();
                Doacao.FKIdDoador = Convert.ToInt32(dr["FKIdDoador"]);
                Doacao.FKIdColaborador = id;
            }
            return Doacao;
        }

        public override void Cadastrar(DoacaoEntradaModel objeto)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string date = DateTime.Now.ToString("yyyy-MM-dd");

            string sql = "Insert Into TblEntradaDoacao Values ('" + (int)objeto.CategoriaDoacao + "','" + date + "','" + objeto.FKIdDoador + "','" + objeto.FKIdColaborador + "')";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }


        // Não utilizados
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

            while (dr.Read())
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
        public override void Editar(DoacaoEntradaModel objeto, int id)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Update TblEntradaDoacao Set  TipoEntradaDoacao=" + (int)objeto.CategoriaDoacao + " where IdEntradaDoacao=" + objeto.IdDoacao;
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
