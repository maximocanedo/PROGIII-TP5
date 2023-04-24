using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrabajoPractico5 {
    // Definir la clase Sucursal
    public class Sucursal {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
    }
    public partial class ListadoSucursales : System.Web.UI.Page {
        private void MostrarMensaje(string mensaje) {
            string script = "MostrarMensaje('" + mensaje + "');";
            ScriptManager.RegisterStartupScript(this, GetType(), "MostrarMensaje", script, true);
        }
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                // Crear una lista de objetos de tipo Sucursal
                List<Sucursal> sucursales = new List<Sucursal>();

                // Agregar los registros a la lista
                sucursales.Add(new Sucursal { Nombre = "Sucursal A", Descripcion = "Esta sucursal se especializa en productos orgánicos.", Direccion = "Calle 1, Colonia Centro, Ciudad de México." });
                sucursales.Add(new Sucursal { Nombre = "Sucursal B", Descripcion = "Esta sucursal es la más grande de nuestra cadena y cuenta con una amplia variedad de productos.", Direccion = "Avenida Principal #100, Colonia San Miguel, Guadalajara." });
                sucursales.Add(new Sucursal { Nombre = "Sucursal C", Descripcion = "Esta sucursal se encuentra en un centro comercial y cuenta con un área de comidas rápidas.", Direccion = "Centro Comercial Plaza Las Américas, Piso 2, Cancún." });
                sucursales.Add(new Sucursal { Nombre = "Sucursal D", Descripcion = "Esta sucursal se encuentra en una zona residencial y ofrece servicio a domicilio.", Direccion = "Calle 5, Colonia Los Pinos, Monterrey." });
                sucursales.Add(new Sucursal { Nombre = "Sucursal E", Descripcion = "Esta sucursal es la más nueva de nuestra cadena y cuenta con tecnología de última generación para procesar pagos.", Direccion = "Calle 10, Colonia Polanco, Ciudad de México." });

                // Enlazar la lista al GridView
                GridView1.DataSource = sucursales;
                GridView1.DataBind();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e) {
            MostrarMensaje("¡Evento click del btnBuscar activado!");
        }
    }
}