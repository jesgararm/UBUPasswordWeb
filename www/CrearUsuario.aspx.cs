using ClasesLib;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Comun.Utils;

namespace www
{
    public partial class CrearUsuario : System.Web.UI.Page
    {
        BaseDatos db;
        Usuario us;
        string texto;
        protected void Page_Load(object sender, EventArgs e)
        {
            us = (Usuario)Session["user"];
            db = (BaseDatos)Application["db"];
            texto = (string)Session["labelTres"];

            if (db == null || us == null || !us.Gestor) {
                Response.Redirect("InicioSesion.aspx");
            }

            if (texto == null) {
                texto = "";
            }
            
            lblError.Text = texto;

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Session["labelTres"] = null;
            Server.Transfer("Inicio.aspx");
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            if (!ValidarEmail(txtEmail.Text))
            {
                Session["labelTres"] = "El email no cumple los requisitos";
                txtEmail.Text = "";
                Server.Transfer("CrearUsuario.aspx");
            }

            if (!ValidarPassword(txtPass.Text))
            {
                Session["labelTres"] = "La contraseña no cumple los requisitos";
                txtPass.Text = "";
                Server.Transfer("CrearUsuario.aspx");
            }

            if (db.ObtenerUsuario(txtEmail.Text)!=null)
            {
                Session["labelTres"] = "El usuario ya existe";
                txtEmail.Text = "";
                Server.Transfer("CrearUsuario.aspx");
            }

            bool gestor = false;

            if (lstRol.SelectedValue == "Admin")
                gestor = true;

            db.InsertarUsuario(new Usuario(txtEmail.Text, txtNombre.Text, txtApellido.Text,txtPass.Text, gestor));
            Session["labelTres"] = "Usuario Creado";
            txtEmail.Text = "";
            txtApellido.Text = "";
            txtNombre.Text = "";
            txtPass.Text = "";
            Server.Transfer("CrearUsuario.aspx");
        }
    }
}