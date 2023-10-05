using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebTienda.Models;

namespace WebTienda.Models
{
    public class Clcliente
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Colonia { get; set; }
        public string Ciudad { get; set; }
        public string Telefono { get; set; }
        public string Contraseña { get; set; }
        public string Activo { get; set; }

        public string Guardar()
        {

            string respuesta = "Ok";
            SqlConnection con = Models.Conexion.Conectar();
            SqlCommand comando = new SqlCommand("spGuardarCliente", con);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", Id);
            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@Email", Email);
            comando.Parameters.AddWithValue("@Direccion", Direccion);
            comando.Parameters.AddWithValue("@Colonia", Colonia);
            comando.Parameters.AddWithValue("@Ciudad", Ciudad);
            comando.Parameters.AddWithValue("@Telefono", Telefono);
            comando.Parameters.AddWithValue("@Contraseña", Contraseña);
            comando.Parameters.AddWithValue("@Activo", Activo);
            //comando.Parameters.AddWithValue("@FechaNacimiento", Convert.ToDateTime(FechaNacimiento.Trim()));

            try
            {
                con.Open();
                comando.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception error)
            {

                respuesta = error.Message;
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return respuesta;

        }

        //llenar  tabla
        public static List<Clcliente> ListaClientes(string idNombre)
        {
            SqlConnection con = Models.Conexion.Conectar();
            SqlCommand comando = new SqlCommand("spListaClientes", con);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdNombre", idNombre);
            SqlDataReader dr;
            List<Clcliente> lista = new List<Clcliente>();
            Clcliente c;
            con.Open();
            dr = comando.ExecuteReader();
            while (dr.Read())
            {
                c = new Clcliente();
                c.Id = dr.GetInt32(0);
                c.Nombre = dr.GetString(1);
                c.Email = dr.GetString(2);
                c.Direccion = dr.GetString(3);
                c.Colonia = dr.GetString(4);
                c.Ciudad = dr.GetString(5);
                c.Telefono = dr.GetString(6);
                c.Contraseña = dr.GetString(7);
                c.Activo = dr.GetString(8);
                //c.FechaNacimiento = dr.GetDateTime(3).ToShortDateString();
                lista.Add(c);
            }

            dr.Close();
            con.Close();
            return lista;
        }

        //editar cliente
        public string Editar()
        {

            string respuesta = "Ok";
            SqlConnection con = Models.Conexion.Conectar();
            SqlCommand comando = new SqlCommand("spEditarCliente", con);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", Id);
            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@Email", Email);
            comando.Parameters.AddWithValue("@Direccion", Direccion);
            comando.Parameters.AddWithValue("@Colonia", Colonia);
            comando.Parameters.AddWithValue("@Ciudad", Ciudad);
            comando.Parameters.AddWithValue("@Telefono", Telefono);
            comando.Parameters.AddWithValue("@Contraseña", Contraseña);
            comando.Parameters.AddWithValue("@Activo", Activo);
            //comando.Parameters.AddWithValue("@FechaNacimiento", Convert.ToDateTime(FechaNacimiento.Trim()));

            try
            {
                con.Open();
                comando.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception error)
            {

                respuesta = error.Message;
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return respuesta;

        }

        //borrar cliente
        public string Borrar()
        {
            string respuesta = "Ok";
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spBorrarCliente", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", Id);
            try
            {
                conx.Open();
                command.ExecuteNonQuery();
                conx.Close();
            }
            catch (Exception error)
            {
                respuesta = error.Message;
                if (conx.State == ConnectionState.Open)
                {
                    conx.Close();
                }
            }
            return respuesta;
        }

        //cargar en el formulario cuando sea editado
        public static List<Clcliente> Cargar(int id)
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spCargarCliente", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", id);
            SqlDataReader dr;
            List<Clcliente> lista = new List<Clcliente>();
            Clcliente c;
            conx.Open();
            dr = command.ExecuteReader();
            if (dr.Read())
            {
                c = new Clcliente();
                c.Id = dr.GetInt32(0);
                c.Nombre = dr.GetString(1);
                c.Email = dr.GetString(2);
                c.Direccion = dr.GetString(3);
                c.Colonia = dr.GetString(4);
                c.Ciudad = dr.GetString(5);
                c.Telefono = dr.GetString(6);
                c.Contraseña = dr.GetString(7);
                c.Activo = dr.GetString(8);
                //c.FechaNacimiento = dr.GetDateTime(3).ToString("dd/MMMM/yyyy");
                lista.Add(c);
            }
            dr.Close();
            conx.Close();
            return lista;
        }
    }
}