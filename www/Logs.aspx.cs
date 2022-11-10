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
        string accSel;
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

            accSel = (string)Session["accesoSeleccionado"];

            if (accSel != null) 
            {
                DataTable logs = new DataTable();
                grdLogs.Visible = true;
                logs.Columns.Add("Id.", typeof(String));
                logs.Columns.Add("Fecha", typeof(DateTime));

                foreach (EntradaLog log in bd.ObtenerAcceso(Int32.Parse(accSel)).EntradasLog)
                {
                    logs.Rows.Add(log.Entrada.IdEntrada, log.Fecha);
                }
                grdLogs.DataSource = logs;
                grdLogs.DataBind();
            }
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Server.Transfer("Inicio.aspx", true);
        }

        protected void grdAccesos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int row = Convert.ToInt32(e.CommandArgument);
            Session["accesoSeleccionado"] = grdAccesos.Rows[row].Cells[0].Text;
            Server.Transfer("Logs.aspx", true);
        }
    }
}