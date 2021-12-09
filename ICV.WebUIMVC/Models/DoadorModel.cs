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
        // Revisado 19/11 - De acordo com o Banco

        [Required]
        public string DocumentoDoador { get; set; }

        [Required]
        public int FKIdColaborador { get; set; }

        [Required]
        public AnonimoDoador AnonimoDoador { get; set; }

        public string ObservacaoDoador { get; set; }

        string dataAtual = DateTime.Now.ToString();


        public override DoadorModel Buscar(int id)
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = @"Select * From TblDoador where IdDoador =" + id;

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DoadorModel Doador = new DoadorModel();

            if (dr.Read())
            {
                Doador.id = Convert.ToInt32(dr["IdDoador"]);
                Doador.Nome = dr["NomeDoador"].ToString();
                Doador.DocumentoDoador = dr["DocumentoDoador"].ToString();
                Doador.Telefone = dr["TelefoneDoador"].ToString();
                Doador.Email = dr["EmailDoador"].ToString();
                Doador.Status = (Status)Convert.ToInt32(dr["StatusDoador"]); 
                Doador.AnonimoDoador = (AnonimoDoador) Convert.ToInt32(dr["AnonimoDoador"]);
                Doador.ObservacaoDoador =  dr["ObservacaoDoador"].ToString();
                Doador.DataCadastro = dr["DataCadastroDoador"].ToString();
                Doador.FKIdColaborador = Convert.ToInt32(dr["FKIdColaborador"]);
            }

            return Doador;
        }

        public override List<DoadorModel> Buscar()
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = @"Select * From TblDoador";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            List<DoadorModel> listaObj = new List<DoadorModel>();

            while (dr.Read())
            {
                DoadorModel Doador = new DoadorModel();

                Doador.id = Convert.ToInt32(dr["IdDoador"]);
                Doador.Nome = dr["NomeDoador"].ToString();
                Doador.DocumentoDoador = dr["DocumentoDoador"].ToString();
                Doador.Telefone = dr["TelefoneDoador"].ToString();
                Doador.Email = dr["EmailDoador"].ToString();
                Doador.Status = (Status)Convert.ToInt32(dr["StatusDoador"]);
                Doador.AnonimoDoador = (AnonimoDoador)Convert.ToInt32(dr["AnonimoDoador"]);
                Doador.ObservacaoDoador = dr["ObservacaoDoador"].ToString();
                Doador.DataCadastro = dr["DataCadastroDoador"].ToString();
                Doador.FKIdColaborador = Convert.ToInt32(dr["FKIdColaborador"]);

                listaObj.Add(Doador);
            }

            return listaObj;
        }

        public override void Cadastrar(DoadorModel objeto)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Insert Into TblDoador Values ('" + objeto.Nome + "','" + objeto.DocumentoDoador + "','" + objeto.Telefone + "','" + objeto.Email + "','" + (int)objeto.Status + "','" + (int)objeto.AnonimoDoador + "','" + objeto.ObservacaoDoador + "','" + dataAtual + "', '" + objeto.FKIdColaborador+ "')";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public override void Editar(DoadorModel objeto, int id)
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();
            string sql = $"Update TblDoador Set NomeDoador= '{objeto.Nome}', DocumentoDoador='{objeto.DocumentoDoador}', TelefoneDoador=' {objeto.Telefone} ', EmailDoador=' {objeto.Email}', StatusDoador={(int)objeto.Status}, AnonimoDoador={(int)objeto.AnonimoDoador}, ObservacaoDoador='{ objeto.ObservacaoDoador }' where IdDoador = {id}";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public override void Remover(int id)
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = "Delete From TblDoador Where IdDoador=" + id + "";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}
