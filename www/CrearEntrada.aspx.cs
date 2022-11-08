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
        List<ListItem> listado;
        List<ListItem> listadoSel;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblOK.Visible = false;
            bd = (BaseDatos)Application["db"];
            us = (Usuario)Session["user"];

            if (bd == null || us == null)
            {
                Response.Redirect("InicioSesion.aspx");
            }
            listado = (List<ListItem>)Session["listado"];
            listadoSel = (List<ListItem>)Session["listadoSel"];

            if (listado == null)
            {
                listado = new List<ListItem>();
                listadoSel = new List<ListItem>();

                foreach (string s in bd.ObtenerListaEmailUsuarios())
                {
                    listado.Add(new ListItem(s));
                }
                Session["listado"] = listado;
                Session["listadoSel"] = listadoSel;
            }

            llEmail.DataSource = listado;
            llEmail.DataBind();
            llEmailSel.DataSource = listadoSel;
            llEmailSel.DataBind();
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
            Session["listado"] = null;
            Session["listadoSel"] = null;
            Response.Redirect("Inicio.aspx");
        }

        protected void btnAddEnt_Click(object sender, EventArgs e)
        {
            ListItem sel = llEmail.SelectedItem;
            listado.Remove(sel);
            listadoSel.Add(sel);
            Session["listado"] = listado;
            Session["listadoSel"] = listadoSel;

        }
    }
}