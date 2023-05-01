using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TrabajoPractico5 {
    public class Sucursal {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int horario { get; set; }
        public Provincia provincia { get; set; }
        public string direccion { get; set; }
        public string imagen { get; set; }
        public Sucursal(int id, string nombre, string descripcion, int horario, Provincia provincia, string direccion, string imagen) {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.horario = horario;
            this.provincia = provincia;
            this.direccion = direccion;
            this.imagen = imagen;
        }
        public Sucursal() {
            this.id = -1;
            this.nombre = null;
            this.descripcion = null;
            this.horario = 0;
            this.provincia = null;
            this.direccion = null;
            this.imagen = null;
        }
        public void SetFromReader(SqlDataReader reader) {
            this.id = Convert.ToInt32(reader["Id_Sucursal"]);
            this.nombre = reader["NombreSucursal"].ToString();
            this.descripcion = reader["DescripcionSucursal"].ToString();
            this.horario = Convert.ToInt32(reader["Id_HorarioSucursal"]);
            Provincia p = new Provincia();
            int idProvincia = Convert.ToInt32(reader["Id_ProvinciaSucursal"]);
            p.GetFromID(idProvincia);
            this.provincia = p;
            this.direccion = reader["DireccionSucursal"].ToString();
            this.imagen = reader["URL_Imagen_Sucursal"].ToString();
        }
        public Sucursal(SqlDataReader reader) {
            SetFromReader(reader);
        }
        public static List<Sucursal> GetSucursales() {
            List<Sucursal> sucursales = new List<Sucursal>();
            Conexion cn = new Conexion();
            string query = "SELECT * FROM Sucursal";
            SqlDataReader reader = cn.ObtenerDatos(query);
            while(reader.Read()) {
                sucursales.Add(new Sucursal(reader));
            }
            return sucursales;
        }
        public bool GetFromID(int id) {
            bool seHalloProvincia = false;
            Conexion conexion = new Conexion();
            string consulta = "SELECT * FROM Sucursal WHERE [Id_Sucursal] = @id";
            Dictionary<string, object> parametros = new Dictionary<string, object> {
                { "@id", id }
            };
            SqlDataReader reader = conexion.ObtenerDatos(consulta, parametros);
            if (reader.HasRows) {
                reader.Read();
                SetFromReader(reader);
                seHalloProvincia = true;
            }
            conexion.Cerrar(reader);
            return seHalloProvincia;
        }
        public bool WriteInDatabase() {
            Conexion cn = new Conexion();
            string consulta = "INSERT INTO Sucursal ([NombreSucursal],[DescripcionSucursal],[Id_HorarioSucursal],[Id_ProvinciaSucursal],[DireccionSucursal],[URL_Imagen_Sucursal])" +
                                            "VALUES (@nombre, @descripcion, @horario, @provincia, @direccion, @imagen)";
            Dictionary<String, object> parametros = new Dictionary<string, object> {
                { "@nombre", this.nombre },
                { "@descripcion", this.descripcion },
                { "@horario", this.horario },
                { "@provincia", this.provincia.id },
                { "@direccion", this.direccion },
                { "@imagen", this.imagen }
            };
            int filasAfectadas = cn.EjecutarTransaccion(consulta, parametros);
            return (filasAfectadas > 0);
        }
        public bool DeleteFromDatabase() {
            Conexion cn = new Conexion();
            string consulta = "DELETE FROM Sucursal WHERE [Id_Provincia] = @id";
            Dictionary<String, object> parametros = new Dictionary<string, object> {
                { "@id", this.id }
            };
            int filasAfectadas = cn.EjecutarTransaccion(consulta, parametros);
            return (filasAfectadas > 0);
        }


    }
}