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
            SqlCommand cmd = new SqlCommand("Select DescripcionProvincia from Provincias order by Id", conex);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListItem item = new ListItem();
                item.Text = reader["DescripcionProvincia"].ToString();
                item.Value = reader["Id_Provncia"].ToString();
                ddlProvincias.Items.Add(item);
            }

            reader.Close();
            Conexion.Close(conex);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                CargarProvincias();
            }
        }
    }
}