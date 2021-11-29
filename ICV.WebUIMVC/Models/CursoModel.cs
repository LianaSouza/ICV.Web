using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebUIMVC.Models
{
    public class CursoModel: ICrud<CursoModel>
    {
        // Revisado 19/11 - De acordo com o Banco

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

            if (dr.Read())
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

        public void Cadastrar(CursoModel objeto)
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = "Insert Into TblCurso Values ('"+objeto.NomeCurso+"','"+objeto.DescricaoCurso+"','"+(int)objeto.StatusCurso+"','"+objeto.DataCadastroCurso+ "')";

            SqlCommand cmd = new SqlCommand(sql,conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Editar(CursoModel objeto, int id)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();
           
            string sql = "Update TblCurso Set NomeCurso='"+objeto.NomeCurso+"', DescricaoCurso='"+objeto.DataCadastroCurso+"', StatusTurma='"+ (int)objeto.StatusCurso+"', where IdCurso="+ id;
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
