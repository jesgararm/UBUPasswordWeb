using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClasesLib;
using Datos;

namespace www
{
    public partial class Logs : System.Web.UI.Page
    {
        Usuario us;
        BaseDatos bd;
        protected void Page_Load(object sender, EventArgs e)
        {
            us = (Usuario)Session["user"];
            bd = (BaseDatos)Application["db"];

            if (us == null || bd == null || !us.Gestor)
            {
                Response.Redirect("InicioSesion.aspx");
            }

            DataTable accesos = new DataTable();
            accesos.Columns.Add("Id.", typeof(String));
            accesos.Columns.Add("Email", typeof(String));
            accesos.Columns.Add("Fecha", typeof(DateTime));
            if (!Page.IsPostBack)
            {
                foreach(Acceso acc in bd.ObtenerAccesos())
                {
                    accesos.Rows.Add(acc.IdAcceso, acc.Usuario.Email, acc.FechaAcceso);
                }
            }
            grdAccesos.DataSource = accesos;
            grdAccesos.DataBind();

        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Server.Transfer("Inicio.aspx", true);
        }
    }
}