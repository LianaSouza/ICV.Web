using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebUIMVC.Models
{
    public class AlunoModel : SuperPessoaAbstract<AlunoModel>
    {
        // Revisado 19/11 - De acordo com o Banco

        [Required]
        public string CpfAluno { get; set; }

        [Required]
        public string DataNascimentoAluno { get; set; }

        [Required]
        public int FKIdTurma { get; set; }

        [Required]
        public int FKIdColaborador { get; set; }

        public string NomeTurma { get; set; }

        public string Colaborador { get; set; }

        public List<AlunoModel> Turmas { get; set; }

        public List<AlunoModel> BuscarAlunoTurma()
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());

            conn.Open();

            string sql = "Select IdTurma ,NomeTurma from TblTurma";
            //string sql = "Select * from tblAluno Inner Join TblTurma on TblAluno.FKIdTurma = TblTurma.IdTurma";

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader dr = cmd.ExecuteReader();

            var lista = new List<AlunoModel>();

            while (dr.Read())
            {
                var aluno = new AlunoModel
                {
                    //Nome = (string)dr["NomeAluno"],
                    //CpfAluno = (string)dr["CpfAluno"],
                    ////DataNascimentoAluno = (string)dr["DataNascimentoAluno"],
                    //Email = (string)dr["EmailAluno"],
                    //Telefone = (string)dr["TelefoneAluno"],
                    //Status = (Status)dr["StatusAluno"],
                    //DataCadastro = (string)dr["DataCadastroAluno"],
                    FKIdTurma = (int)dr["IdTurma"],
                    NomeTurma = (string)dr["NomeTurma"],
                    //FKIdColaborador = (int)dr["FkIdColaborador"],
                    
                };


                lista.Add(aluno);
            }

            return lista;
        }

        public override AlunoModel Buscar(int id)
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

           
            string sql = @" SELECT * FROM TblAluno INNER JOIN TblTurma ON TblAluno.FkIdColaborador = TblTurma.IdTurma where TblAluno.IdAluno= "+ id;

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            AlunoModel Aluno = new AlunoModel();

            if (dr.Read())
            {
                Aluno.id = Convert.ToInt32(dr["IdAluno"]);
                Aluno.Nome = dr["NomeAluno"].ToString();
                Aluno.CpfAluno = dr["CpfAluno"].ToString();
                Aluno.DataNascimentoAluno = dr["DataNascimentoAluno"].ToString();
                Aluno.Email = dr["EmailAluno"].ToString();
                Aluno.Telefone = dr["TelefoneAluno"].ToString();
                Aluno.Status = (Status) Convert.ToInt32(dr["StatusAluno"]);
                //Aluno.DataCadastro = dr["DataCadastroAluno"].ToString();
                Aluno.FKIdTurma = Convert.ToInt32(dr["FkIdTurma"]);
                Aluno.FKIdColaborador = Convert.ToInt32(dr["FkIdColaborador"]);
                Aluno.NomeTurma =  dr["NomeTurma"].ToString();
            }

            return Aluno;
        }

        public override List<AlunoModel> Buscar()
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = @"Select * From TblAluno";

            SqlCommand cmd = new SqlCommand( sql,conn);
            SqlDataReader dr = cmd.ExecuteReader();
            List<AlunoModel> listaObj = new List<AlunoModel>();

            while (dr.Read())
            {
                AlunoModel Aluno = new AlunoModel();

                Aluno.id = Convert.ToInt32(dr["IdAluno"]);
                Aluno.Nome = dr["NomeAluno"].ToString();
                Aluno.CpfAluno = dr["CpfAluno"].ToString();
                Aluno.DataNascimentoAluno = dr["DataNascimentoAluno"].ToString();
                Aluno.Email = dr["EmailAluno"].ToString();
                Aluno.Telefone = dr["TelefoneAluno"].ToString();
                Aluno.Status = (Status)Convert.ToInt32(dr["StatusAluno"]);
                Aluno.DataCadastro = dr["DataCadastroAluno"].ToString();
                Aluno.FKIdTurma = Convert.ToInt32(dr["FkIdTurma"]);
                Aluno.FKIdColaborador = Convert.ToInt32(dr["FkIdColaborador"]);

                listaObj.Add(Aluno);
            }

            return listaObj;
            
        }

        public override void Cadastrar(AlunoModel objeto)
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string dataNascimento = Convert.ToString(objeto.DataNascimentoAluno);
            string dataAtual = DateTime.Now.ToString("yyyy-MM-dd");
            string sql = @"Insert into TblAluno values('" + objeto.Nome + "','" + objeto.CpfAluno + "','" + dataNascimento + "','" + objeto.Email + "','" + objeto.Telefone + "'," + (int) objeto.Status + ",'" + dataAtual + "'," + objeto.FKIdTurma + "," + objeto.FKIdColaborador + ")";

            SqlCommand cmd = new SqlCommand(sql,conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public override void Editar(AlunoModel objeto, int id)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string dataNascimento = Convert.ToString(objeto.DataNascimentoAluno);
            string sql = "Update TblAluno Set NomeAluno='" + objeto.Nome + "', CpfAluno='" + objeto.CpfAluno + "', DataNascimentoAluno='" + dataNascimento + "', EmailAluno='" + objeto.Email + "', TelefoneAluno='" + objeto.Telefone + "',  StatusAluno=" + (int)objeto.Status + "  where IdAluno=" + objeto.id;
            
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public override void Remover(int id)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Delete From TblAluno Where IdAluno=" + id + "";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
