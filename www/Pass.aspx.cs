using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Comun.Utils;
using Datos;
using ClasesLib;

namespace www
{
    public partial class Pass : System.Web.UI.Page
    {
        BaseDatos db;
        Usuario user;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = (BaseDatos)Application["db"];
            user = (Usuario)Session["user"];
            if (user == null)
            {
                Response.Redirect("InicioSesion.aspx");
            }
            
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (!ValidarPassword(txtPass.Text))
            {
                lblError.Text = "La contraseña no cumple los requisitos";
                txtPass.Text = "";

            }

            else 
            {
                if (user.ExistePasswordAlmacen(txtPass.Text))
                {
                    lblError.Text = "La contraseña ya ha sido utilizada";
                    txtPass.Text = "";

                }

                else 
                {
                    user.CambiarPassword(txtPass.Text);
                    db.CambiarPasswordUsuario(user);
                    Response.Redirect("Inicio.aspx");
                }

            }
            
            }
        }
    }
