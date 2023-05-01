using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace TrabajoPractico5
{
    public class Conexion
    {
        string Ruta = "Data Source=PCOK\\SQLEXPRESS;Initial Catalog=BDSucursales;Integrated Security=True";

        public SqlDataReader ObtenerDatos(String consulta)
        {
            SqlConnection conexion = new SqlConnection(Ruta);
            SqlCommand command = new SqlCommand(consulta, conexion);
            conexion.Open();
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        public void cerrar(SqlDataReader cn)
        {
            cn.Close();
        }
        public int ejecutaTransaccion(String consulta)
        {
            SqlConnection conexion = new SqlConnection(Ruta);
            conexion.Open();
            SqlCommand comando = new SqlCommand(consulta, conexion);
            int filasAfectadas = comando.ExecuteNonQuery();
            return filasAfectadas;
        }
    }
}