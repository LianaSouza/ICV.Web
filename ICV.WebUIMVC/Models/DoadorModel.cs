using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebUIMVC.Models
{
    public class DoadorModel : SuperPessoaAbstract <DoadorModel>
    {
        [Required]
        public string DocumentoDoador { get; set; }

        string dataAtual = DateTime.Now.ToString();

        public override DoadorModel Buscar(int id)
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = @"Select * From Doador where IdDoador =" + id;

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DoadorModel Doador = new DoadorModel();

            if (dr.Read())
            {
                Doador.id = Convert.ToInt32(dr["IdDoador"]);
                Doador.Nome = dr["NomeDoador"].ToString();
                Doador.DocumentoDoador = dr["DocumentoDoador"].ToString();
                Doador.Status = (Status)Convert.ToInt32(dr["StatusDoador"]);
                Doador.DataCadastro = dr["DataCadastroDoador"].ToString();
            }

            return Doador;
        }

        public override List<DoadorModel> Buscar()
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = @"Select * From Doador";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            List<DoadorModel> listaObj = new List<DoadorModel>();

            if (dr.Read())
            {
                DoadorModel Doador = new DoadorModel();

                Doador.id = Convert.ToInt32(dr["IdDoador"]);
                Doador.Nome = dr["NomeDoador"].ToString();
                Doador.DocumentoDoador = dr["DocumentoDoador"].ToString();
                Doador.Status = (Status)Convert.ToInt32(dr["StatusDoador"]);
                Doador.DataCadastro = dr["DataCadastroDoador"].ToString();

                listaObj.Add(Doador);
            }

            return listaObj;
        }

        public override void Cadastrar(DoadorModel objeto)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Insert Into Doador Values ('" + objeto.id + "','" + objeto.Nome + "','" + objeto.DocumentoDoador + "','" + objeto.Status + "','" + dataAtual + "',)";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public override void Editar(DoadorModel objeto, int id)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Update Doador Set  IdDoador='" + objeto.id + "', NomeDoador='" + objeto.Nome + "', DocumentoDoador='" + objeto.DocumentoDoador + "', StatusDoador='" + objeto.Status + "', where IdDoador=" + objeto.id;
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public override void Remover(int id)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Delete From Doador Where IdDoador=" + id + "";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}
