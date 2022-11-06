using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Comun.Utils;

namespace ClasesLib
{
    public class Entrada
    {
        private Usuario usuario;
        private String password;
        private String descripcion;
        private int idEntrada;
        List<int> listaAccesoUsuarios;
        public Entrada(Usuario usuario,String password, String descripcion,List<int> listUsuarios) 
        {
            this.usuario = usuario;
            this.password = Encriptar(password);
            this.descripcion = descripcion;
            this.listaAccesoUsuarios = listUsuarios;
            this.idEntrada = 0;
        }

        // Getters y Setters
        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = Encriptar(value); }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public List<int> ListaAccesoUsuarios
        {
            get { return listaAccesoUsuarios; }
            set { listaAccesoUsuarios = value; }
        }
        public int IdEntrada
        {
            get { return idEntrada; }
            set { idEntrada = value; }
        }

        // Métodos
        public void AgregarUsuario(Usuario usuario)
        {
            listaAccesoUsuarios.Add(usuario.IdUsuario);
        }
        public void EliminarUsuario(Usuario usuario)
        {
            listaAccesoUsuarios.Remove(usuario.IdUsuario);
        }
        
    }

}
