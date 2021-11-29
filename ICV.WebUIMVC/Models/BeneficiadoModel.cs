using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebUIMVC.Models
{
    public class BeneficiadoModel : SuperPessoaAbstract <BeneficiadoModel>
    {
        // Revisado e de acordo com o banco - 26/11
        [Required]
        public string CpfBeneficiado { get; set; }

        [Required]
        public string DataNascimentoBeneficiado { get; set; }

        [Required]
        [Display(Name = "Digite a quantidade de pessoas na casa")]
        public int QuantidadeDependentes { get; set; }

        [Required]
        [Display(Name = "Digite a renda mensal da familia cadastrada")]
        public string RendaMensalBeneficiado { get; set; }

        [Required]
        public int FKIdColaborador { get; set; }

        string dataAtual = DateTime.Now.ToString();


        public override BeneficiadoModel Buscar(int id)
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = @"Select * From TblBeneficiado where IdBeneficiario =" + id;

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            BeneficiadoModel Beneficiado = new BeneficiadoModel();

            if (dr.Read())
            {
                Beneficiado.id = Convert.ToInt32(dr["IdBeneficiado"]);
                Beneficiado.Nome = dr["NomeBeneficiado "].ToString();
                Beneficiado.CpfBeneficiado = dr["CpfBeneficiado "].ToString();
                Beneficiado.DataNascimentoBeneficiado = dr["DataNascimentoBeneficiado "].ToString();
                Beneficiado.Telefone = dr["TelefoneBeneficiado"].ToString();
                Beneficiado.Email = dr["EmailBeneficiado"].ToString();
                Beneficiado.Status = (Status)Convert.ToInt32(dr["StatusBeneficiado"]);
                Beneficiado.QuantidadeDependentes = Convert.ToInt32(dr["QuantidadeDependentesBeneficiado"]);
                Beneficiado.RendaMensalBeneficiado = dr["RendaMensalBeneficiado"].ToString();
                Beneficiado.DataCadastro = dr["DataCadastroBeneficiado"].ToString();
                Beneficiado.FKIdColaborador = Convert.ToInt32(dr["FKIdColaborador"]);
            }

            return Beneficiado;
        }

        public override List<BeneficiadoModel> Buscar()
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = @"Select * From TblBeneficiado";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            List<BeneficiadoModel> listObj = new List<BeneficiadoModel>();

            while (dr.Read())
            {
                BeneficiadoModel Beneficiado = new BeneficiadoModel();

                Beneficiado.id = Convert.ToInt32(dr["IdBeneficiado"]);
                Beneficiado.Nome = dr["NomeBeneficiado "].ToString();
                Beneficiado.CpfBeneficiado = dr["CpfBeneficiado "].ToString();
                Beneficiado.DataNascimentoBeneficiado = dr["DataNascimentoBeneficiado "].ToString();
                Beneficiado.Telefone = dr["TelefoneBeneficiado"].ToString();
                Beneficiado.Email = dr["EmailBeneficiado"].ToString();
                Beneficiado.Status = (Status)Convert.ToInt32(dr["StatusBeneficiado"]);
                Beneficiado.QuantidadeDependentes = Convert.ToInt32(dr["QuantidadeDependentesBeneficiado"]);
                Beneficiado.RendaMensalBeneficiado = dr["RendaMensalBeneficiado"].ToString();
                Beneficiado.DataCadastro = dr["DataCadastroBeneficiado"].ToString();
                Beneficiado.FKIdColaborador = Convert.ToInt32(dr["FKIdColaborador"]);

                listObj.Add(Beneficiado);
            }

            return listObj;
        }

        public override void Cadastrar(BeneficiadoModel objeto)
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = "Insert Into TblBeneficiado Values('" + objeto.Nome + "','" + objeto.CpfBeneficiado + "','" +Convert.ToDateTime(objeto.DataNascimentoBeneficiado) + "', '" + objeto.Telefone + "','" + objeto.Email  + "','" +(int) objeto.Status + "','" + objeto.QuantidadeDependentes + "','" + objeto.RendaMensalBeneficiado + "','" + dataAtual + "','" + FKIdColaborador + "')";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public override void Editar(BeneficiadoModel objeto, int id)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Update TblBeneficiado Set NomeBeneficiado='" + objeto.Nome + "', CpfBeneficiado='" + objeto.CpfBeneficiado + "', DataNascimentoBeneficiado='" + Convert.ToDateTime(objeto.DataNascimentoBeneficiado) + "', TelefoneBeneficiado='" + objeto.Telefone + "', EmailBeneficiado='" + objeto.Email + "', StatusBeneficiado='" + (int)objeto.Status + "', QuantidadeDependentesBeneficiado='" + objeto.QuantidadeDependentes + "', RendaMensalBeneficiado='" + objeto.RendaMensalBeneficiado + "', where IdBeneficiado=" + objeto.id;
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public override void Remover(int id)
        {
            SqlConnection con = new SqlConnection(ConecteDb.Connect());
            con.Open();

            string sql = "Delete From TblBeneficiado Where IdBeneficiado=" + id + "";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}
