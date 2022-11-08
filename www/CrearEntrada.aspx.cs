using ClasesLib;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace www
{
    public partial class CrearEntrada : System.Web.UI.Page
    {
        Entrada ent;
        Usuario us;
        BaseDatos bd;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblOK.Visible = false;
        
            bd = (BaseDatos)Application["db"];
            us = (Usuario)Session["user"];

            if (bd == null || us == null)
            {
                Response.Redirect("InicioSesion.aspx");
            }
        }

        protected void btnCrearEntrada_Click(object sender, EventArgs e)
        {
            if (txtDesc.Text.Length < 1 && txtPassword.Text.Length < 5)
            {
                btnCrearEntrada.Enabled = false;
            }

            else 
            {
                ent = new Entrada(us, txtPassword.Text, txtDesc.Text, new List<int>());
                bd.InsertaEntrada(ent);
                this.txtPassword.Focus();
                this.txtPassword.Text = String.Empty;
                this.txtDesc.Focus();
                this.txtDesc.Text = String.Empty;
                lblOK.Visible = true;
            }
            
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }
    }
}