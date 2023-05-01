using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrabajoPractico5 {
    
    public partial class EliminarSucursal : System.Web.UI.Page {
        private void MostrarMensaje(string mensaje) {
            string script = "MostrarMensaje('" + mensaje + "');";
            ScriptManager.RegisterStartupScript(this, GetType(), "MostrarMensaje", script, true);
        }
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnEliminar_Click(object sender, EventArgs e) {
            Sucursal obj = new Sucursal() {
                id = int.Parse(tbIDSucursal.Text)
            };
            if (obj.Eliminar().FilasAfectadas == 1) {
                MostrarMensaje("Registro eliminado con éxito.");
            } else {
                MostrarMensaje("Hubo un problema al intentar eliminar el registro.");
            }
        }
    }
}