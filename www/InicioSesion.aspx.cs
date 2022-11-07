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
    public partial class InicioSesion : System.Web.UI.Page
    {
        // Variables de aplicacion
        Usuario user;
        BaseDatos db;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            lblLogin.Text = "Login";
            lblErrorInicioSesion.Visible = false;

            db = (BaseDatos)Application["db"];
            if (db == null)
            {
                db = new BaseDatos();
                Application["db"] = db;
            }
            user = null;
            user = (Usuario)Session["user"];
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            this.user = db.ObtenerUsuario(txtNombreUs.Text);
            if (user != null)
                {
                    if (Desencriptar(user.Password) == txtPass.Text)
                    {
                        Session["user"] = user;
                        Acceso acc = new Acceso(user);
                        db.InsertaAcceso(acc);
                        Session["acceso"] = acc;
                        Response.Redirect("Inicio.aspx");
                    }
                    else
                    {
                        lblErrorInicioSesion.Visible = true;
                        lblErrorInicioSesion.Text = "Contraseña incorrecta";
                    }
                }
            else
                {
                    lblErrorInicioSesion.Visible = true;
                    lblErrorInicioSesion.Text = "Usuario incorrecto";
                }
            }
        }
    }