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

            string sql = @"Select * From SaidaDoacao where IdSaidaDoacao =" + id;

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DoacaoSaidaModel Doacao = new DoacaoSaidaModel();

            if (dr.Read())
            {
                Doacao.id = Convert.ToInt32(dr["IdTurma"]);
                Doacao.TipoSaida = dr["NomeTurma"].ToString();
                Doacao.FKBeneficiado = dr["DescricaoTurma"].ToString();
                Doacao.DataCadastro = dr["DataCadastroTurma"].ToString();

            }
            return Turma;
        }

        public override List<DoacaoSaidaModel> Buscar()
        {
            throw new NotImplementedException();
        }

        public override void Cadastrar(DoacaoSaidaModel objeto)
        {
            throw new NotImplementedException();
        }

        public override void Editar(DoacaoSaidaModel objeto, int id)
        {
            throw new NotImplementedException();
        }

        public override void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
