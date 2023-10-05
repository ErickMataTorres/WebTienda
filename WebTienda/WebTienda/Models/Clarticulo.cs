using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using WebTienda.Models;

namespace WebTienda.Models
{
    public class Clarticulo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }

        public string Guardar()
        {

            string respuesta = "Ok";
            SqlConnection con = Models.Conexion.Conectar();
            SqlCommand comando = new SqlCommand("spGuardarArticulo", con);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", Id);
            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@Precio", Precio);
            comando.Parameters.AddWithValue("@Descripcion", Descripcion);
            comando.Parameters.AddWithValue("@Imagen", Imagen);

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
        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }
        public static List<Clarticulo> ListaArticulo(string idNombre)
        {
            SqlConnection con = Models.Conexion.Conectar();
            SqlCommand comando = new SqlCommand("spListaArticulo", con);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdNombre", idNombre);
            SqlDataReader dr;
            List<Clarticulo> lista = new List<Clarticulo>();
            Clarticulo c;
            con.Open();
            dr = comando.ExecuteReader();
            while (dr.Read())
            {
                c = new Clarticulo();
                c.Id = dr.GetInt32(0);
                c.Nombre = dr.GetString(1);
                c.Precio = dr.GetDecimal(2);
                c.Descripcion = dr.GetString(3);
                c.Imagen = dr.GetString(4);
                lista.Add(c);
            }

            dr.Close();
            con.Close();
            return lista;
        }

        //editar articulo
        public string Editar()
        {

            string respuesta = "Ok";
            SqlConnection con = Models.Conexion.Conectar();
            SqlCommand comando = new SqlCommand("spEditarArticulo", con);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", Id);
            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@Precio", Precio);
            comando.Parameters.AddWithValue("@Descripcion", Descripcion);
            comando.Parameters.AddWithValue("@Imagen", Imagen);


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

        //borrar articulo
        public string Borrar()
        {
            string respuesta = "Ok";
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spBorrarArticulo", conx);
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
        public static List<Clarticulo> Cargar(int id)
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spCargarArticulo", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", id);
            SqlDataReader dr;
            List<Clarticulo> lista = new List<Clarticulo>();
            Clarticulo c;
            conx.Open();
            dr = command.ExecuteReader();
            if (dr.Read())
            {
                c = new Clarticulo();
                c.Id = dr.GetInt32(0);
                c.Nombre = dr.GetString(1);
                c.Precio = dr.GetDecimal(2);
                c.Descripcion = dr.GetString(3);
                c.Imagen = dr.GetString(4);
                lista.Add(c);
            }
            dr.Close();
            conx.Close();
            return lista;
        }

        public string Post()
        {
            byte[] buffer;
            var request = HttpContext.Current.Request;
            if (request.Files.Count > 0)
            {
                foreach (string file in request.Files)
                {
                    var postedFile = request.Files[file];
                    int length = postedFile.ContentLength;
                    buffer = new byte[length];
                    postedFile.InputStream.Read(buffer, 0, length);

                    return Convert.ToBase64String(buffer);
                }
            }
            return "";
        }


    }
}