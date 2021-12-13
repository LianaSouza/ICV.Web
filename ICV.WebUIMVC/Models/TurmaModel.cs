using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebUIMVC.Models
{
    // Revisado 18/11 - De acordo com o Banco
    public class TurmaModel : CursoModel
    {
        [Required]
        public int IdTurma { get; set; }

        [Required]
        public string NomeTurma { get; set; }

        [Required]
        public string DescricaoTurma { get; set; }

        [Required]
        public PeriodoTurma PeriodoTurma { get; set; }

        [Required]
        public Status StatusTurma { get; set; }

        [Required]
        public int FKIdColaborador { get; set; }

        [Required]
        public int FKIdCurso { get; set; }

        public string Curso { get; set; }

        public List<CursoModel> Cursos { set; get; }

        public List<LoginModel> LoginColaborador { get; set; }

        public string Colaborador { get; set; }

        public string DataCadastroTurma { get; set; }

   

        public List<TurmaModel> BuscarTurmaCurso()
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = @" SELECT * FROM TblTurma INNER JOIN TblCurso ON TblTurma.FkIdCurso = TblCurso.IdCurso ";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            List<TurmaModel> listaObj = new List<TurmaModel>();

            while (dr.Read())
            {
                TurmaModel Turma = new TurmaModel();

                Turma.IdTurma = Convert.ToInt32(dr["IdTurma"]);
                Turma.NomeTurma = dr["NomeTurma"].ToString();
                Turma.DescricaoTurma = dr["DescricaoTurma"].ToString();
                Turma.PeriodoTurma = (PeriodoTurma)Convert.ToInt32(dr["PeriodoTurma"]);
                Turma.StatusTurma = (Status)Convert.ToInt32(dr["StatusTurma"]);
                Turma.DataCadastroTurma = dr["DataCadastroTurma"].ToString(); 
                Turma.Curso = dr["NomeCurso"].ToString();

                listaObj.Add(Turma);
                
            }
            return listaObj;
        }

        public TurmaModel BuscarTurma(int id)
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = @"  SELECT  NomeTurma , DescricaoTurma , PeriodoTurma, StatusTurma , DataCadastroTurma , FkIdCurso ,FkIdColaborador , NomeCurso , NomeColaborador  FROM TblTurma 
                               INNER JOIN TblCurso ON TblTurma.FkIdCurso = TblCurso.IdCurso 
                               INNER JOIN TblColaborador  ON TblTurma.FkIdColaborador = TblColaborador.IdColaborador where TblTurma.IdTurma = "+ id;

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            TurmaModel Turma = new TurmaModel();

            if (dr.Read())
            {
                Turma.IdTurma = id;
                Turma.NomeTurma = dr["NomeTurma"].ToString();
                Turma.DescricaoTurma = dr["DescricaoTurma"].ToString();
                Turma.PeriodoTurma = (PeriodoTurma)Convert.ToInt32(dr["PeriodoTurma"]);
                Turma.StatusTurma = (Status)Convert.ToInt32(dr["StatusTurma"]);
                Turma.DataCadastroTurma = dr["DataCadastroTurma"].ToString();
                Turma.FKIdCurso = Convert.ToInt32(dr["FKIdCurso"]);
                Turma.Curso = dr["NomeCurso"].ToString();
                Turma.FKIdColaborador = Convert.ToInt32(dr["FkIdColaborador"]);
                Turma.Colaborador = dr["NomeColaborador"].ToString();

            }

            return Turma;
        }

        public List<TurmaModel> BuscarTurma()
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = "Select * from TblTurma";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            List<TurmaModel> listaObj = new List<TurmaModel>();

            while (dr.Read())
            {
                TurmaModel Turma = new TurmaModel();

                Turma.IdTurma = Convert.ToInt32(dr["IdTurma"]);
                Turma.NomeTurma = dr["NomeTurma"].ToString();
                Turma.DescricaoTurma = dr["DescricaoTurma"].ToString();
                Turma.PeriodoTurma = (PeriodoTurma)Convert.ToInt32(dr["PeriodoTurma"]);
                Turma.StatusTurma = (Status)Convert.ToInt32(dr["StatusTurma"]);
                Turma.DataCadastroTurma = dr["DataCadastroTurma"].ToString();
                Turma.FKIdCurso = Convert.ToInt32(dr["FKIdCurso"]);
                Turma.FKIdColaborador = Convert.ToInt32(dr["FKIdColaborador"]);

                listaObj.Add(Turma);
            }
            return listaObj;
        }

        public bool CadastrarTurma(TurmaModel objeto)
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();
            string dataAtual = DateTime.Now.ToString("yyyy-MM-dd");
            string sql = "Insert Into TblTurma Values ('" + objeto.NomeTurma + "','" + objeto.DescricaoTurma + "'," + (int)objeto.PeriodoTurma + "," + (int)objeto.StatusTurma + ",'" + dataAtual + "'," + objeto.FKIdCurso+ "," + objeto.FKIdColaborador + ")";

            SqlCommand cmd = new SqlCommand(sql, conn);

            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void EditarTurma(int id, TurmaModel objeto)
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = "Update TblTurma Set  NomeTurma='" + objeto.NomeTurma + "', DescricaoTurma='" + objeto.DescricaoTurma + "', PeriodoTurma=" + (int)objeto.PeriodoTurma + ", StatusTurma=" + (int)objeto.StatusTurma + "  where IdTurma=" + id;
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void RemoverTurma(int id)
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = "Delete From TblTurma Where IdTurma=" + id + "";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}
