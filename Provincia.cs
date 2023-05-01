using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TrabajoPractico5 {
    public class Provincia {
        public int id { get; set; }
        public string descripcion { get; set; }
        public Provincia(int id, string descripcion) {
            this.id = id;
            this.descripcion = descripcion;
        }
        public Provincia(int id) {
            this.id = id;
        }
        public Provincia(SqlDataReader reader) {
            int id = Convert.ToInt32(reader["Id_Provincia"]);
            string descripcion = reader["DescripcionProvincia"].ToString();
        }
        public Provincia() {
            this.id = -1;
            this.descripcion = "";
        }
        public static List<Provincia> GetProvinces() {
            List<Provincia> provincias = new List<Provincia>();
            Conexion cn = new Conexion();
            string query = "SELECT [Id_Provincia], [DescripcionProvincia] FROM Provincias";
            SqlDataReader reader = cn.ObtenerDatos(query);
            while(reader.Read()) {
                provincias.Add(new Provincia(reader));
            }
            cn.Cerrar(reader);
            return provincias;
        }

        public bool GetFromID(int id) {
            bool seHalloProvincia = false;
            Conexion conexion = new Conexion();
            string consulta = "SELECT Id_Provincia, DescripcionProvincia FROM Provincias WHERE Id_Provincia = @id";
            Dictionary<string, object> parametros = new Dictionary<string, object> {
                { "@id", id }
            };
            SqlDataReader reader = conexion.ObtenerDatos(consulta, parametros);
            if (reader.HasRows) {
                reader.Read();
                this.id = Convert.ToInt32(reader["Id_Provincia"]);
                this.descripcion = reader["DescripcionProvincia"].ToString();
                seHalloProvincia = true;
            }
            conexion.Cerrar(reader);
            return seHalloProvincia;
        }

        public bool WriteInDatabase() {
            Conexion cn = new Conexion();
            string consulta = "INSERT INTO Provincias (DescripcionProvincia) VALUES (@descripcion)";
            Dictionary<String, object> parametros = new Dictionary<string, object> {
                { "@descripcion", this.descripcion }
            };
            int filasAfectadas = cn.EjecutarTransaccion(consulta, parametros);
            return (filasAfectadas > 0);
        }
        public bool DeleteFromDatabase() {
            Conexion cn = new Conexion();
            string consulta = "DELETE FROM Provincias WHERE [Id_Provincia] = @id";
            Dictionary<String, object> parametros = new Dictionary<string, object> {
                { "@id", this.id }
            };
            int filasAfectadas = cn.EjecutarTransaccion(consulta, parametros);
            return (filasAfectadas > 0);
        }


    }
}