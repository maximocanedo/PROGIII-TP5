using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace TrabajoPractico5 {
    public class Conexion {
        string Ruta = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=BDSucursales;Integrated Security=True";
        public bool HuboError = false;
        public string MensajeDeError = "";
        public string DetalleError = "";

        public SqlDataReader ObtenerDatos(string consulta, Dictionary<string, object> parametros = null) {
            try {
                using (SqlConnection conexion = new SqlConnection(Ruta)) {
                    using (SqlCommand command = new SqlCommand(consulta, conexion)) {
                        if (parametros != null) {
                            foreach (KeyValuePair<string, object> parametro in parametros) {
                                command.Parameters.AddWithValue(parametro.Key, parametro.Value);
                            }
                        }
                        conexion.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        return reader;
                    }
                }
            }
            catch (Exception ex) {
                // Manejar la excepción aquí, por ejemplo:
                HuboError = true;
                MensajeDeError = ("Error al obtener datos de la base de datos.");
                DetalleError = ex.ToString();
                return null;
            }
        }


        public void Cerrar(SqlDataReader cn) {
            if(cn != null)
                cn.Close();
        }
        public int EjecutarTransaccion(string consulta, Dictionary<string, object> parametros = null) {
            try {
                using (SqlConnection conexion = new SqlConnection(Ruta)) {
                    using (SqlCommand comando = new SqlCommand(consulta, conexion)) {
                        if (parametros != null) {
                            foreach (KeyValuePair<string, object> parametro in parametros) {
                                comando.Parameters.AddWithValue(parametro.Key, parametro.Value);
                            }
                        }
                        conexion.Open();
                        int filasAfectadas = comando.ExecuteNonQuery();
                        return filasAfectadas;
                    }
                }
            }
            catch (Exception ex) {
                // Manejar la excepción aquí, por ejemplo:
                HuboError = true;
                MensajeDeError = ("Error al obtener datos de la base de datos.");
                DetalleError = ex.ToString();
                return 0;
            }
        }
    }
}