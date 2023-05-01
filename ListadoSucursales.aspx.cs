using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace TrabajoPractico5 {
    // Definir la clase Sucursal
    
    public partial class ListadoSucursales : System.Web.UI.Page {
        private void MostrarMensaje(string mensaje) {
            string script = "MostrarMensaje('" + mensaje + "');";
            ScriptManager.RegisterStartupScript(this, GetType(), "MostrarMensaje", script, true);
        }
        protected void CargarDatos(bool checkID = false) {
            DataSet sucursales = checkID ? Sucursal.FiltrarSucursalesPorID(int.Parse(tbBuscarPorID.Text)) : Sucursal.ObtenerSucursales();
            gvSucursales.DataSource = sucursales.Tables["root"];
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