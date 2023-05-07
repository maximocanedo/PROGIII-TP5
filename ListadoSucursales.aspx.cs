using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace TrabajoPractico5 {    
    public partial class ListadoSucursales : System.Web.UI.Page {
        private void MostrarMensaje(string mensaje) {
            string script = "MostrarMensaje('" + mensaje + "');";
            ScriptManager.RegisterStartupScript(this, GetType(), "MostrarMensaje", script, true);
        }
        /// <summary>
        /// Carga los registros de los sucursales en la tabla @gvSucursales.
        /// </summary>
        /// <param name="seFiltra">Indica si se debe filtrar por el ID especificado por el usuario.</param>
        protected void CargarDatos(bool seFiltra = false) {
            DataSet sucursales = seFiltra?
                Sucursal.FiltrarSucursalesPorID(int.Parse(tbBuscarPorID.Text)):
                Sucursal.ObtenerSucursales();
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