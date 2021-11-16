﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebUIMVC.Models
{
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
        public int IdColaborador { get; set; }

        public string DataCadastroTurma { get; set; }

        string dataAtual = DateTime.Now.ToString();  
        

        public TurmaModel BuscarTurma(int id)
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = @"Select * From TblTurma where IdTurma =" + id;

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
                Turma.IdColaborador = Convert.ToInt32(dr["FKIdColaborador"]);

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

            if (dr.Read())
            {
                TurmaModel Turma = new TurmaModel();

                Turma.IdTurma = Convert.ToInt32(dr["IdTurma"]);
                Turma.NomeTurma = dr["NomeTurma"].ToString();
                Turma.DescricaoTurma = dr["DescricaoTurma"].ToString();
                Turma.PeriodoTurma = (PeriodoTurma) Convert.ToInt32(dr["PeriodoTurma"]);
                Turma.StatusTurma = (Status) Convert.ToInt32(dr["StatusTurma"]);
                Turma.DataCadastroTurma = dr["DataCadastroTurma"].ToString();
                Turma.IdColaborador = Convert.ToInt32(dr["FKIdColaborador"]);

                listaObj.Add(Turma);
            }
            return listaObj;
        }

        public void CadastrarTurma(TurmaModel objeto)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Insert Into TblTurma Values ('" + objeto.NomeTurma + "','" + objeto.DescricaoTurma + "','" + objeto.PeriodoTurma + "','" + objeto.StatusTurma + "','" + dataAtual + "','" + objeto.IdColaborador+ "')";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void EditarTurma(TurmaModel objeto, int id)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Update TblTurma Set  NomeTurma='" + objeto.NomeTurma + "', DescricaoTurma='" + objeto.DescricaoTurma + "', PeriodoTurma='" + objeto.PeriodoTurma + "', StatusTurma='" + objeto.StatusTurma + "',  where IdTurma=" + id;
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void RemoverTurma(int id)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Delete From TblTurma Where IdTurma=" + id + "";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}