using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebUIMVC.Models
{
    public class TurmaModel : CursoModel
    {
        public int IdTurma { get; set; }
        public string NomeTurma { get; set; }
        public string DescricaoTurma { get; set; }
        public PeriodoTurma PeriodoTurma { get; set; }
        public Status StatusTurma { get; set; }
        public string DataCadastroTurma { get; set; }

        public TurmaModel BuscarTurma(int id)
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = @"Select * From Turma where IdTurma =" + id;

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            TurmaModel Turma = new TurmaModel();

            if (dr.Read())
            {
                Turma.IdTurma = Convert.ToInt32(dr["IdTurma"]);
                Turma.NomeTurma = dr["NomeTurma"].ToString();
                Turma.DescricaoTurma = dr["DescricaoTurma"].ToString();
                Turma.PeriodoTurma = (PeriodoTurma)Convert.ToInt32(dr["PeriodoTurma"]);
                Turma.StatusTurma = (Status)Convert.ToInt32(dr["StatusTurma"]);
                Turma.DataCadastroTurma = dr["DataCadastroTurma"].ToString();

            }
            return Turma;
        }

        public List<TurmaModel> BuscarTurma()
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = "Select * from Turma";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            List<TurmaModel> listaObj = new List<TurmaModel>();

            if (dr.Read())
            {
                TurmaModel Turma = new TurmaModel();

                Turma.IdTurma = Convert.ToInt32(dr["IdTurma"]);
                Turma.NomeTurma = dr["NomeTurma"].ToString();
                Turma.DescricaoTurma = dr["DescricaoTurma"].ToString();
                Turma.PeriodoTurma = (PeriodoTurma) Convert.ToInt32(dr["PeriodoTurma"]);
                Turma.StatusTurma = (Status) Convert.ToInt32(dr["StatusTurma"]);
                Turma.DataCadastroTurma = dr["DataCadastroTurma"].ToString();

                listaObj.Add(Turma);
            }
            return listaObj;
        }

        public void CadastrarTurma(TurmaModel objeto)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Insert Into Turma Values ('" + objeto.NomeTurma + "','" + objeto.DescricaoTurma + "','" + objeto.PeriodoTurma + "','" + objeto.StatusTurma + "')";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void EditarTurma(TurmaModel objeto, int id)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Update Turma Set  NomeTurma='" + objeto.NomeTurma + "', DescricaoTurma='" + objeto.DescricaoTurma + "',StatusTurma='" + objeto.StatusTurma + "', PeriodoTurma='" + objeto.PeriodoTurma + "', where IdTurma=" + id;
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void RemoverTurma(int id)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Delete From Turma Where IdPost=" + id + "";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}
