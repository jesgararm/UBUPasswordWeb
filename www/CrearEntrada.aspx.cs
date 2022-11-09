using ClasesLib;
using Datos;
using static Comun.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace www
{
    public partial class CrearEntrada : System.Web.UI.Page
    {
        Entrada ent;
        Usuario us;
        BaseDatos bd;
        List<ListItem> listado;
        List<ListItem> listadoSel;
        String texto;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            bd = (BaseDatos)Application["db"];
            us = (Usuario)Session["user"];
            texto = (String)Session["label"];
            if (bd == null || us == null)
            {
                Response.Redirect("InicioSesion.aspx");
            }
            listado = (List<ListItem>)Session["listado"];
            listadoSel = (List<ListItem>)Session["listadoSel"];
            
            if (texto == null)
            {
                texto = "";
            }
            
            lblOK.Text = texto;

            if (listado == null)
            {
                listado = new List<ListItem>();
                listadoSel = new List<ListItem>();

                foreach (string s in bd.ObtenerListaEmailUsuarios())
                {
                    listado.Add(new ListItem(s));
                }
                listado.Remove(new ListItem(us.Email));
                Session["listado"] = listado;
                Session["listadoSel"] = listadoSel;

                llEmail.DataSource = listado;
                llEmail.DataBind();
                llEmailSel.DataSource = listadoSel;
                llEmailSel.DataBind();
            }
        }

        protected void btnCrearEntrada_Click(object sender, EventArgs e)
        {
            if (ValidarPassword(txtPassword.Text))
            {
                List<int> listado = new List<int>();

                // Recorremos los datos de llEmailSel
                foreach (ListItem li in llEmailSel.Items)
                {
                    listado.Add(bd.ObtenerUsuario(li.Value).IdUsuario);
                }

                ent = new Entrada(us, txtPassword.Text, txtDesc.Text, listado);
                bd.InsertaEntrada(ent);
                Session["label"] = "Entrada creada";
            }
            else 
            {
                Session["label"] = "La contraseña no cumple con los estándares establecidos";

            }
            
            this.txtPassword.Text = String.Empty;
            this.txtDesc.Text = String.Empty;

            Session["listado"] = null;
            Session["listadoSel"] = null;
            Response.Redirect("CrearEntrada.aspx");
         
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session["listado"] = null;
            Session["listadoSel"] = null;
            Session["entradas"] = null;
            Session["misEntradas"] = null;
            Response.Redirect("Inicio.aspx");
        }

        protected void btnAddEnt_Click(object sender, EventArgs e)
        {
            var sel = llEmail.SelectedItem;
            if (sel != null)
            {
                listado.Remove(sel);
                listadoSel.Add(sel);
                llEmail.DataSource = listado;
                llEmail.DataBind();
                llEmailSel.DataSource = listadoSel;
                llEmailSel.DataBind();
            }
            
        }

        protected void btnRem_Click(object sender, EventArgs e)
        {
            var sel = llEmailSel.SelectedItem;
            if (sel != null)
            {
                listadoSel.Remove(sel);
                listado.Add(sel);
                llEmail.DataSource = listado;
                llEmail.DataBind();
                llEmailSel.DataSource = listadoSel;
                llEmailSel.DataBind();
            }
        }
    }
}