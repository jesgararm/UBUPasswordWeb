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
    public partial class EliminarUsuario : System.Web.UI.Page
    {
        BaseDatos bd;
        Usuario us;
        List<ListItem> listado;

        protected void Page_Load(object sender, EventArgs e)
        {
            bd = (BaseDatos)Application["db"];
            us = (Usuario)Session["user"];
            
            if(us == null || bd == null || !us.Gestor)
            {
                Server.Transfer("InicioSesion.aspx", true);
            }

            listado = (List<ListItem>)Application["listado"];

            if (listado == null)
            {
                listado = new List<ListItem>();
                Application["listado"] = listado;
                foreach (string u in bd.ObtenerListaEmailUsuarios())
                {
                    if (u != us.Email)
                    {
                        listado.Add(new ListItem(u));
                    }
                }
            }

            if (!Page.IsPostBack)
            {
                ddlUsuarios.DataSource = listado;
                ddlUsuarios.DataBind();
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

            string email = ddlUsuarios.SelectedItem.Text;

            if (email != null) 
            {

                if (bd.EliminaUsuario(bd.ObtenerUsuario(email)))
                {
                    lblMessage.Text = "Usuario eliminado correctamente";
                    List<ListItem>listadoNuevo = new List<ListItem>();
                    Application["listado"] = listadoNuevo;
                    foreach (string u in bd.ObtenerListaEmailUsuarios())
                    {
                        if (u != us.Email)
                        {
                            listadoNuevo.Add(new ListItem(u));
                        }
                    }
                }
                else
                {
                    lblMessage.Text = "No se ha podido eliminar el usuario";
                }
            }
            
           
            
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Application["listado"] = null;
            Session["emailSel"] = null;
            Server.Transfer("Inicio.aspx", true);
            
        }

        protected void ddlUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblHelp.Text = "Has seleccionado el usuario " + ddlUsuarios.SelectedItem.Text;
        }
    }
}