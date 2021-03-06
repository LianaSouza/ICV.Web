using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace ICV.WebUIMVC.Models
{
    public class CursoModel : ICrud<CursoModel>
    {
        [Required]
        public int IdCurso { get; set; }

        [Required]
        public string NomeCurso { get; set; }

        [Required]
        public string DescricaoCurso { get; set; }

        [Required]
        public Status StatusCurso { get; set; }


        public string DataCadastroCurso { get; set; }


        public CursoModel Buscar(int id)
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = @"Select * From TblCurso where IdCurso =" + id;

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            CursoModel Curso = new CursoModel();

            if (dr.Read())
            {
                Curso.IdCurso = Convert.ToInt32(dr["IdCurso"]);
                Curso.NomeCurso = dr["NomeCurso"].ToString();
                Curso.DescricaoCurso = dr["DescricaoCurso"].ToString();
                Curso.StatusCurso = (Status)Convert.ToInt32(dr["StatusCurso"]);
                Curso.DataCadastroCurso = dr["DataCadastroCurso"].ToString();
            }
            return Curso;
        }

       

        public List<CursoModel> Buscar()
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = @"Select * From TblCurso";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            List<CursoModel> listObj = new List<CursoModel>();

            while (dr.Read())
            {
                CursoModel Curso = new CursoModel();

                Curso.IdCurso = Convert.ToInt32(dr["IdCurso"]);
                Curso.NomeCurso = dr["NomeCurso"].ToString();
                Curso.DescricaoCurso = dr["DescricaoCurso"].ToString();
                Curso.StatusCurso = (Status)Convert.ToInt32(dr["StatusCurso"]);
                Curso.DataCadastroCurso = dr["DataCadastroCurso"].ToString();

                listObj.Add(Curso);
            }

            return listObj;
        }

       
        public List<CursoModel> BuscarCursoSelect(int id)
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = "Select * from TblCurso where IdCurso =" +id;

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader dr = cmd.ExecuteReader();

            List<CursoModel> lista = new List<CursoModel>();

            while (dr.Read())
            {
                CursoModel Curso = new CursoModel();

                Curso.IdCurso = id;
                Curso.NomeCurso = dr["NomeCurso"].ToString();

                lista.Add(Curso);
            }

            return lista;


        }

        public List<CursoModel> BuscarCursoSelect()
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = "Select * from TblCurso";

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader dr = cmd.ExecuteReader();

            List<CursoModel> lista = new List<CursoModel>();

            while (dr.Read())
            {
                CursoModel Curso = new CursoModel();

                Curso.IdCurso = Convert.ToInt32(dr["IdCurso"]);
                Curso.NomeCurso = dr["NomeCurso"].ToString();

                lista.Add(Curso);
            }

            return lista;


        }

        public void Cadastrar(CursoModel objeto)
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            var date = DateTime.Now.ToString("yyyy-MM-dd");

            string sql = $"Insert Into TblCurso Values ('{objeto.NomeCurso}','{objeto.DescricaoCurso}',{(int)objeto.StatusCurso},'{date}')";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Editar(CursoModel curso, int id)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = $"Update TblCurso Set NomeCurso= '{curso.NomeCurso}', DescricaoCurso='{curso.DescricaoCurso}', StatusCurso={(int)curso.StatusCurso} where IdCurso = {id}";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Remover(int id)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Delete From TblCurso Where IdCurso=" + id + "";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}