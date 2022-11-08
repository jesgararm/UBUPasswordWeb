using ClasesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace www
{
    public partial class Inicio : System.Web.UI.Page
    {
        Acceso acceso;
        Usuario us;
        protected void Page_Load(object sender, EventArgs e)
        {
            acceso = (Acceso)Session["acceso"];
            us = (Usuario)Session["user"];
            lblEmail.Text = us.Email;
            lblNom.Text = us.Nombre;
            lblAp.Text = us.Apellido;
            if (us.Gestor)
                { lblPriv.Text = "Admin"; }
            else { lblPriv.Text = "Usuario"; }

            lblFechaAcceso.Text = acceso.FechaAcceso.ToString();
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Session["acceso"] = null;
            Response.Redirect("InicioSesion.aspx");
        }

        protected void btnAddEnt_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearEntrada.aspx");
        }
    }
}