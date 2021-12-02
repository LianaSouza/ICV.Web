﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebUIMVC.Models
{
    public class LoginModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }


        

        public bool Login(LoginModel objeto)
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();
            
            string sql = @"Select * From TblColaborador where EmailColaborador ='" + objeto.Email + "'and SenhaColaborador='" + objeto.Senha+"'";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<LoginModel> BuscarLoginColaborador(string email)
        {
            SqlConnection conn = new SqlConnection(ConecteDb.Connect());
            conn.Open();

            string sql = @"Select * From TblColaborador where EmailColaborador ='" + email+ "'";

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader dr = cmd.ExecuteReader();

            List<LoginModel> lista = new List<LoginModel>();

            while (dr.Read())
            {
                LoginModel Login = new LoginModel();

                Login.Id = Convert.ToInt32(dr["IdColaborador"]);
                Login.Nome = dr["NomeColaborador"].ToString();

                lista.Add(Login);
            }

            return lista;


        }

    }
}
