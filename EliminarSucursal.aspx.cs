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

        public void limpiarTextBox() { tbIDSucursal.Text = ""; }

        public void realizarConsulta()
        {
            Sucursal suc = new Sucursal()
            {
                id = int.Parse(tbIDSucursal.Text)
            };

            JobResponse jr = suc.Eliminar();
            if (jr.FilasAfectadas == 0)
            {
                MostrarMensaje("No es posible eliminar la sucursal de la Base de Datos.");
                limpiarTextBox();
            }
            else
            {
                MostrarMensaje("La sucursal se ha eliminado con éxito.");
                limpiarTextBox();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e) {
            // MostrarMensaje("¡Evento click del @btnEliminar activado!");

            // Validar que se ingresó un número positivo entero:
            try
            {
                int num = Convert.ToInt32(tbIDSucursal.Text);
                if (num > 0)
                {
                    // Realizar consulta y ejecutar transacción:
                    realizarConsulta();
                }
                else
                {
                    MostrarMensaje("Debe ingresar un número entero positivo.");
                    limpiarTextBox();
                }
            }
            catch (FormatException fe)
            {
                limpiarTextBox(); // Limpio el TextBox.
                MostrarMensaje(fe.ToString());
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}