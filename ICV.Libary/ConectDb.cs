using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ICV.Libary
{
    public class ConnectDb
    {
        public static string Connect()
        {
            //adicionar seu banco de dados do curso.
            return @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ICV;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
    }
}
