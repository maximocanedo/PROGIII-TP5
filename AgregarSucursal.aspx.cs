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
            Negocio sucursal = new Negocio();
            ddlProvincias.DataSource = sucursal.ObtenerProvincias();
            ddlProvincias.DataTextField = "DescripcionProvincia";
            ddlProvincias.DataValueField = "Id_Provincia";
            ddlProvincias.DataBind();
        }
        protected void LimpiarCampos() {
            tbNombreSucursal.Text = "";
            tbDescripcion.Text = "";
            ddlProvincias.SelectedIndex = 0;
            tbDireccion.Text = "";

        }
        protected void btnAceptar_Click(object sender, EventArgs e) {
            Negocio sucursal = new Negocio();
            string nombre = tbNombreSucursal.Text;
            string descripcion = tbDescripcion.Text;
            string provincia = ddlProvincias.SelectedValue;
            string direccion = tbDireccion.Text;
            if(sucursal.AgregarSucursal(nombre, descripcion, provincia, direccion) != 0) {
                MostrarMensaje("El registro se subió correctamente.");
            } else {
                MostrarMensaje("Hubo un problema al intentar escribir en la base de datos. ");
            }
            LimpiarCampos();
        }
    }
}