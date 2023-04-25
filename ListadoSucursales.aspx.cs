using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace TrabajoPractico5 {
    // Definir la clase Sucursal
    public class Sucursal {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Provincia { get; set; }
        public string Direccion { get; set; }
    }
    public partial class ListadoSucursales : System.Web.UI.Page {
        private void MostrarMensaje(string mensaje) {
            string script = "MostrarMensaje('" + mensaje + "');";
            ScriptManager.RegisterStartupScript(this, GetType(), "MostrarMensaje", script, true);
        }
        protected void CargarDatos(bool checkID = false) {
            Negocio sucursal = new Negocio();
            if (checkID) {
                gvSucursales.DataSource = sucursal.BuscarSucursal(tbBuscarPorID.Text);
            } else {
                gvSucursales.DataSource = sucursal.ObtenerSucursales();
            }
            gvSucursales.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                CargarDatos();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e) {
            MostrarMensaje("Recargando los resultados...");
            CargarDatos(true);
        }
    }
}