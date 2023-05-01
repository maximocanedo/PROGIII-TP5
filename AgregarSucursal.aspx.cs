using System;
using System.Collections.Generic;
using System.Data;
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
            DataSet p = Provincia.ObtenerProvincias();
            ddlProvincias.DataSource = p.Tables["root"];
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
            string n = tbNombreSucursal.Text;
            string d = tbDescripcion.Text;
            int idProvincia = int.Parse(ddlProvincias.SelectedValue);
            string dir = tbDireccion.Text;
            Sucursal s = new Sucursal() {
                nombre = n,
                descripcion = d,
                provincia = new Provincia() { id = idProvincia },
                direccion = dir
            };
            JobResponse job = s.Escribir();
            if (job.Estado) {
                MostrarMensaje("El registro se subió correctamente.");
            } else {
                MostrarMensaje("Error. " + job.Mensaje);
                
            }
            LimpiarCampos();
        }
    }
}