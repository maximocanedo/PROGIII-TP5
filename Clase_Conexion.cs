using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace TrabajoPractico5
{
    public class Conexion
    {
        public static string ruta = "Data Source = localhost\\sqlexpress; Initial Catalog = BDSucursales ; Integrated Security = True";


        public static SqlConnection Open()
        {
            SqlConnection Conex = new SqlConnection(ruta);
            Conex.Open();
            return Conex;
        }

        public static void Close(SqlConnection Conex)
        {
            Conex.Close();
        }



        public static int ejecutaTransaccion(String consulta)// insertar,eliminar o modificar
        {
            SqlConnection conexion = new SqlConnection(ruta);
            conexion.Open();

            //El sql commnd me sirve para realizar instrucciones de tipo insert, delete y update
            SqlCommand comando = new SqlCommand(consulta, conexion);

            //ejecutar el comando
            //executeNonQuery hace la transaccion y devuelve el numero de filas afectadas
            int filasAfectadas = comando.ExecuteNonQuery();
            //if (filasAfectadas == 0)
            //{
            //No se pudo agregar en la base de datos
            //}
            //else
            //{
            //Se agrego correctamente
            //}

            return filasAfectadas;
        }
    }
}