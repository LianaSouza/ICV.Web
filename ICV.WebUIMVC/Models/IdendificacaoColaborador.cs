using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebUIMVC.Models
{
    public class IdendificacaoColaborador
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        public IdendificacaoColaborador Buscar(string email)
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = @"Select * From TblColaborador where EmailColaborador ='" + email + "'";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            IdendificacaoColaborador idendificacao = new IdendificacaoColaborador();

            if (dr.Read())
            {
                idendificacao.Id = Convert.ToInt32(dr["IdColaborador"]);
                idendificacao.Nome = dr["NomeColaborador"].ToString();
                idendificacao.Email = dr["EmailColaborador"].ToString();
            }

            return idendificacao;
        }
    }
}
