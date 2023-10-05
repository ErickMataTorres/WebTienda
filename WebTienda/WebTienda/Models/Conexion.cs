using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebTienda.Models
{
    public class Conexion
    {
        public static SqlConnection Conectar()
        {
            string cs = "Data Source=A;Initial Catalog=webtienda;Integrated Security=True";
            SqlConnection conx = new SqlConnection(cs);
            return conx;
        }
    }
}