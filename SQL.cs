using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace TrabajoPractico5 {
    public class SQL {
        public static string rutaConexion = @"Data Source=localhost\sqlexpress;Initial Catalog=BDSucursales;Integrated Security=True";
        public DataTable ObtenerTablas(string consultaSQL, string nombreTabla) {
            SqlConnection conexion = new SqlConnection(rutaConexion);
            conexion.Open();
            SqlDataAdapter adap = new SqlDataAdapter(consultaSQL, conexion);
            DataSet ds = new DataSet();
            adap.Fill(ds, nombreTabla);
            conexion.Close();
            return ds.Tables[nombreTabla];
        }

        public int EjecutarConsulta(string consultaSQL) {
            SqlConnection conexion = new SqlConnection(rutaConexion);
            conexion.Open();
            SqlCommand cmd = new SqlCommand(consultaSQL, conexion);
            int filas = (int)cmd.ExecuteNonQuery(); // PARA INSERT-UPDATE-DELETE
            conexion.Close();
            return filas;
        }
    }
}