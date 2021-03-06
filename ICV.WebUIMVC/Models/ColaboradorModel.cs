using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebUIMVC.Models
{
    public class ColaboradorModel : SuperPessoaAbstract<ColaboradorModel>
    {
        //Revisado e de acordo com o banco - 26/11

        [Required]
        public string DocumentoColaborador { get; set; }

        [Required]
        public string DataNascimentoColaborador { get; set; }

        [Required]
        public TipoColaborador TipoColaborador { get; set; }

        [Required]
        public string SenhaColaborador { get; set; }

        string dataAtual = DateTime.Now.ToString("yyyy-mm-dd");



        public override ColaboradorModel Buscar(int id)
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = @"Select * From TblColaborador where IdColaborador =" + id;

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            ColaboradorModel Colaborador = new ColaboradorModel();

            if (dr.Read())
            {
                Colaborador.id = Convert.ToInt32(dr["IdColaborador"]);
                Colaborador.Nome = dr["NomeColaborador"].ToString();
                Colaborador.DocumentoColaborador = dr["DocumentoColaborador"].ToString();
                Colaborador.DataNascimentoColaborador = dr["DataNascimentoColaborador"].ToString();
                Colaborador.Email = dr["EmailColaborador"].ToString();
                Colaborador.SenhaColaborador = dr["SenhaColaborador"].ToString();
                Colaborador.Telefone = dr["TelefoneColaborador"].ToString();
                Colaborador.Status = (Status)Convert.ToInt32(dr["StatusColaborador"]);
                Colaborador.TipoColaborador = (TipoColaborador)Convert.ToInt32(dr["TipoColaborador"]);
                Colaborador.DataCadastro = dr["DataCadastroColaborador"].ToString();

            }

            return Colaborador;

        }

        public override List<ColaboradorModel> Buscar()
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = @"Select * From TblColaborador";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            List<ColaboradorModel> listaObj = new List<ColaboradorModel>();

            while (dr.Read())
            {
                ColaboradorModel Colaborador = new ColaboradorModel();

                Colaborador.id = Convert.ToInt32(dr["IdColaborador"]);
                Colaborador.Nome = dr["NomeColaborador"].ToString();
                Colaborador.DocumentoColaborador = dr["DocumentoColaborador"].ToString();
                Colaborador.DataNascimentoColaborador = dr["DataNascimentoColaborador"].ToString();
                Colaborador.Email = dr["EmailColaborador"].ToString();
                Colaborador.SenhaColaborador = dr["SenhaColaborador"].ToString();
                Colaborador.Telefone = dr["TelefoneColaborador"].ToString();
                Colaborador.Status = (Status)Convert.ToInt32(dr["StatusColaborador"]);
                Colaborador.TipoColaborador = (TipoColaborador)Convert.ToInt32(dr["TipoColaborador"]);
                Colaborador.DataCadastro = dr["DataCadastroColaborador"].ToString();

                listaObj.Add(Colaborador);

            }

            return listaObj;
        }

        public override void Cadastrar(ColaboradorModel objeto)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string dataNascimento = Convert.ToString( objeto.DataNascimentoColaborador);
            string dataAtual = DateTime.Now.ToString("yyyy-MM-dd");
            
                
            string sql = $"Insert Into TblColaborador Values('{objeto.Nome}','" + objeto.DocumentoColaborador + "','" +  dataNascimento + "', '" + objeto.Email + "','" + objeto.SenhaColaborador + "','" + objeto.Telefone + "','" + (int) objeto.TipoColaborador + "','" + (int)objeto.Status + "','" + dataAtual + "')";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public override void Editar(ColaboradorModel objeto, int id)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();
            //Update TblColaborador set NomeColaborador='1', DocumentoColaborador='2', DataNascimentoColaborador='2002-01-02', EmailColaborador='"+objeto.Email+"', TelefoneColaborador='"+objfone+"', TipoColaborador=0, StatusColaborador=1
            string sql = $"Update TblColaborador set NomeColaborador='{objeto.Nome}', DocumentoColaborador='{objeto.DocumentoColaborador}', EmailColaborador='{objeto.Email}', TelefoneColaborador='{objeto.Telefone}', TipoColaborador={(int)objeto.TipoColaborador}, StatusColaborador={(int)objeto.Status} where IdColaborador = {id}";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public override void Remover(int id)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Delete From TblColaborador Where IdColaborador=" + id + "";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }

    }
}