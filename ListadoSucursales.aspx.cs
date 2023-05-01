using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrabajoPractico5 {
 
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
                // sucursales.Add(new Sucursal { Nombre = "Sucursal A", Descripcion = "Esta sucursal se especializa en productos orgánicos.", Direccion = "Calle 1, Colonia Centro, Ciudad de México." });
                
                // Enlazar la lista al GridView
                GridView1.DataSource = sucursales;
                GridView1.DataBind();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e) {
            MostrarMensaje("¡Evento click del @btnBuscar activado!");
        }
    }
}