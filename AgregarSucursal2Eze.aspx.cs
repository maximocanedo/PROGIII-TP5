using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace TrabajoPractico5
{
    public partial class AgregarSucursalEze : System.Web.UI.Page
    {

        public void CargarProvincias()
        {
            SqlConnection conex = Conexion.Open();
            SqlCommand cmd = new SqlCommand("Select DescripcionProvincia,Id_Provincia from Provincia order by Id_Provincia", conex);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListItem item = new ListItem();
                item.Text = reader["DescripcionProvincia"].ToString();
                item.Value = reader["Id_Provincia"].ToString();
                ddlProvincias.Items.Add(item);
            }
            
            reader.Close();
            Conexion.Close(conex);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProvincias();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            String consulta = "insert into Sucursal (NombreSucursal,DescripcionSucursal,Id_ProvinciaSucursal,DireccionSucursal) values ('" + txtNombreSucursal.Text + "','" + txtDescripcion.Text + "'," + ddlProvincias.SelectedValue + ",'" + txtDireccion.Text + "')";
            int filas = Conexion.ejecutaTransaccion(consulta);
            if (filas == 0)
            {
                Label1.Text = "No se pudo agregar la sucursal"; //no se agrego a la base de datos
            }
            else
            {
                Label1.Text = "La sucursal se ha agregado con exito"; //se agrego exitosamente
            }




            LimpiarCampos();

        }

        public void LimpiarCampos()
        {
            txtNombreSucursal.Text = "";
            txtDescripcion.Text = "";
           // ddlProvincias.SelectedValue = ;
            txtDireccion.Text = "";
        }
    }

}