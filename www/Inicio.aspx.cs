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
    public partial class Inicio : System.Web.UI.Page
    {
        Acceso acceso;
        Usuario us;
        BaseDatos db;
        List<ListItem> misEntradas;
        List<ListItem> entradas;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            acceso = (Acceso)Session["acceso"];
            us = (Usuario)Session["user"];
            db = (BaseDatos)Application["db"];
            if (acceso == null || us == null)
            {
                Response.Redirect("InicioSesion.aspx");
            }
            else
            {
                lblBienvenida.Text = "Bienvenido " + us.Nombre;
            }

            lblEmail.Text = us.Email;
            lblNom.Text = us.Nombre;
            lblAp.Text = us.Apellido;
            if (us.Gestor)
                { lblPriv.Text = "Admin"; }
            else { lblPriv.Text = "Usuario"; }

            lblFechaAcceso.Text = acceso.FechaAcceso.ToString();

            // Igualamos a variables de sesion
            misEntradas = (List<ListItem>)Session["misEntradas"];
            entradas = (List<ListItem>)Session["entradas"];

            if (misEntradas == null||entradas == null)
            {
                misEntradas = new List<ListItem>();
                List<int> entradasProp = db.ObtenerIdEntradasPropiedadUsuario(us);
                foreach (int id in entradasProp)
                {
                    ListItem li = new ListItem(id.ToString());
                    misEntradas.Add(li);
                }
                Session["misEntradas"] = misEntradas;
                entradas = new List<ListItem>();
                List<int> entradasCom = db.ObtenerIdEntradasAccesoUsuario(us);
                foreach (int id in entradasCom)
                {
                    ListItem li = new ListItem(id.ToString());
                    entradas.Add(li);
                }
                Session["entradas"] = entradas;

                llMisEntradas.DataSource = misEntradas;
                llMisEntradas.DataBind();
                llEntradas.DataSource = entradas;
                llEntradas.DataBind();
            }
            
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Session["acceso"] = null;
            Session["misEntradas"] = null;
            Session["entradas"] = null;
            Response.Redirect("InicioSesion.aspx");
        }

        protected void btnAddEnt_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearEntrada.aspx");
        }

        protected void btnMisEntradas_Click(object sender, EventArgs e)
        {
            Entrada en = db.ObtenerEntrada(int.Parse(llMisEntradas.SelectedValue));
            lblMiEntrada.Text = "Entrada: " + llMisEntradas.SelectedValue + $"{Environment.NewLine}Descripcion: " + en.Descripcion
                + $"{Environment.NewLine}Contraseña: " + Desencriptar(en.Password);
        }

        protected void btnEntradasAccesibles_Click(object sender, EventArgs e)
        {
            Entrada en = db.ObtenerEntrada(int.Parse(llEntradas.SelectedValue));
            lblMiEntrada.Text = "Entrada: " + llEntradas.SelectedValue + $"{Environment.NewLine}Descripcion: " + en.Descripcion
                + $"{Environment.NewLine}\nContraseña: " + Desencriptar(en.Password);
        }
    }
}