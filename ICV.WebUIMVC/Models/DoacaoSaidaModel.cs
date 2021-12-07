using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebUIMVC.Models
{
    public class DoacaoSaidaModel : DoacaoAbstract<DoacaoSaidaModel>
    {
        // Revisado 19/11 - De acordo com o Banco

      
        public int FKIdBeneficiado { get; set; }

        
        public int FKIdSaidaDoacao { get; set; }

        public List<BeneficiadoModel> Beneficiado { get; set; }

        public DoacaoSaidaModel ListBeneficiado { get; set; }

        public List<ProdutoModel> Produto { get; set; }

        public int FKIdProduto { get; set; }

        public string Colaborador { get; set; }

        public int QuantidadeProduto { get; set; }

        

        public DoacaoSaidaModel BuscarId(int id)
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = @"SELECT TOP 1* FROM TblSaidaDoacao where FkIdColaborador = "+id+" ORDER BY FkIdColaborador DESC";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DoacaoSaidaModel Doacao = new DoacaoSaidaModel();

            if (dr.Read())
            {
                Doacao.IdDoacao = Convert.ToInt32(dr["IdSaidaDoacao"]);
                Doacao.CategoriaDoacao = (CategoriaProduto)Convert.ToInt32(dr["TipoSaidaDoacao"]);
                Doacao.DataCadastroDoacao = dr["DataCadastroSaidaDoacao"].ToString();
                Doacao.FKIdBeneficiado = Convert.ToInt32(dr["FKIdBeneficiado"]);
                Doacao.FKIdColaborador = id;
            }
            return Doacao;
        }

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
                Doacao.FKIdColaborador = Convert.ToInt32(dr["FKIdColaborador"]);
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

            while (dr.Read())
            {
                DoacaoSaidaModel Doacao = new DoacaoSaidaModel();

                Doacao.IdDoacao = Convert.ToInt32(dr["IdSaidaDoacao"]);
                Doacao.CategoriaDoacao = (CategoriaProduto)Convert.ToInt32(dr["TipoSaidaDoacao"]);
                Doacao.DataCadastroDoacao = dr["DataCadastroSaidaDoacao"].ToString();
                Doacao.FKIdBeneficiado = Convert.ToInt32(dr["FKIdBeneficiado"]);
                Doacao.FKIdColaborador = Convert.ToInt32(dr["FKIdColaborador"]);

                listaObj.Add(Doacao);
            }
            return listaObj;
        }

        public override void Cadastrar(DoacaoSaidaModel objeto)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string date = DateTime.Now.ToString("yyyy-MM-dd");

            string sql = "Insert Into TblSaidaDoacao Values (" + (int)objeto.CategoriaDoacao + ",'" + date + "'," + objeto.FKIdBeneficiado + "," + objeto.FKIdColaborador + ")";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public override void Editar(DoacaoSaidaModel objeto, int id)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Update TblSaidaDoacao Set  TipoSaidaDoacao='" + (int)objeto.CategoriaDoacao + "', where IdSaidaDoacao=" + objeto.IdDoacao;
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
