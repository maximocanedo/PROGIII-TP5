using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace TrabajoPractico5 {
    public class Negocio {
        SQL conexion = new SQL();
        public DataTable ObtenerSucursales() {
            string consultaSQL = "SELECT Id_Sucursal AS [ID], NombreSucursal AS Nombre, DescripcionProvincia AS Provincia, DireccionSucursal AS [Dirección] FROM Sucursal INNER JOIN Provincia ON Id_Provincia=Id_ProvinciaSucursal";
            string nombreTabla = "Sucursales";
            return conexion.ObtenerTablas(consultaSQL, nombreTabla);
        }

        public DataTable ObtenerProvincias() {
            string consultaSQL = "SELECT * FROM Provincia";
            string nombreTabla = "Provincias";
            return conexion.ObtenerTablas(consultaSQL, nombreTabla);
        }

        public DataTable ObtenerHorarios() {
            string consultaSQL = "SELECT * FROM Horario";
            string nombreTabla = "Horarios";
            return conexion.ObtenerTablas(consultaSQL, nombreTabla);
        }

        public int AgregarSucursal(string nombre, string descripcion, string idProvincia, string direccion) {
            string consultaSQL = "INSERT INTO [sucursal] (NombreSucursal, DescripcionSucursal, Id_ProvinciaSucursal, DireccionSucursal) VALUES (@nombre, @descripcion, @idProvincia, @direccion)";

            using (SqlConnection connection = new SqlConnection(SQL.rutaConexion)) {
                SqlCommand command = new SqlCommand(consultaSQL, connection);

                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@descripcion", descripcion);
                command.Parameters.AddWithValue("@idProvincia", idProvincia);
                command.Parameters.AddWithValue("@direccion", direccion);

                connection.Open();
                int filasAfectadas = command.ExecuteNonQuery();
                return filasAfectadas;
            }
        }

        public int EliminarSucursal(string idSucursal) {
            string consultaSQL = "DELETE FROM [sucursal] WHERE Id_Sucursal = @idSucursal";

            using (SqlConnection connection = new SqlConnection(SQL.rutaConexion)) {
                SqlCommand command = new SqlCommand(consultaSQL, connection);

                command.Parameters.AddWithValue("@idSucursal", idSucursal);

                connection.Open();
                int filasAfectadas = command.ExecuteNonQuery();
                return filasAfectadas;
            }
        }

        public DataTable BuscarSucursal(string idSucursal) {
            string consultaSQL = "SELECT Id_Sucursal AS [ID], NombreSucursal AS Nombre, DescripcionProvincia AS Provincia, DireccionSucursal AS [Dirección] FROM Sucursal INNER JOIN Provincia ON Id_Provincia=Id_ProvinciaSucursal WHERE [Id_Sucursal] = '" + idSucursal + "'";
            string nombreTabla = "Sucursales";
            return conexion.ObtenerTablas(consultaSQL, nombreTabla);
        }
    }
}