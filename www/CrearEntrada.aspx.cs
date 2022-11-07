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
            
            if (!IsPostBack)
            {
                bd = (BaseDatos)Application["db"];
                us = (Usuario)Session["user"];
            }
            
            if (txtDesc.Text.Length<1 && txtPassword.Text.Length < 5)
            {
                btnCrearEntrada.Enabled = false;
            }

            btnCrearEntrada.Enabled = true;
        }

        protected void btnCrearEntrada_Click(object sender, EventArgs e)
        {
            ent = new Entrada(us, txtPassword.Text, txtDesc.Text, new List<int>());
            bd.InsertaEntrada(ent);
            lblOK.Visible = true;
            Response.Redirect("CrearEntrada.aspx");

        }
    }
}