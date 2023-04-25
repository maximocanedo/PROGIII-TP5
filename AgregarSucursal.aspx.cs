using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrabajoPractico5 {
    public partial class AgregarSucursal : System.Web.UI.Page {
        public void MostrarMensaje(string mensaje) {
            string script = "MostrarMensaje('" + mensaje + "');";
            ScriptManager.RegisterStartupScript(this, GetType(), "MostrarMensaje", script, true);
        }
        protected void Page_Load(object sender, EventArgs e) {
            /* Controles de esta página:
             * tbNombreSucursal (TextBox)
             * tbDescripcion (TextBox)
             * ddlProvincias (DropDownList)
             * tbDireccion (TextBox)
             * btnAceptar (Button)
             */
            
        }
        protected void LimpiarCampos() {
            tbNombreSucursal.Text = "";
            tbDescripcion.Text = "";
            ddlProvincias.SelectedIndex = 0;
            tbDireccion.Text = "";

        }
        protected void btnAceptar_Click(object sender, EventArgs e) {
            MostrarMensaje("¡Evento click del @btnAceptar activado!"); // Ejemplo de cómo usar MostrarMensaje. (¡Probalo!)
            LimpiarCampos();
        }
    }
}