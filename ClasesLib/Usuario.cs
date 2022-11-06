using System;
using static Comun.Utils;

namespace ClasesLib
{
    public class Usuario
    {
        // Atributos
        private int idUsuario;
        private string nombre;
        private string apellido;
        private string email;
        private string password;
        private bool gestor;
        
        // Constructor de clase
        public Usuario(string email, string nombre, string apellido, string password, bool gestor = false)
        {
            this.idUsuario = 0;
            this.email = email;
            this.nombre = nombre;
            this.apellido = apellido;
            this.password = Encriptar(password);
            this.gestor = gestor;
        }

        // Getters y Setters
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = Encriptar(value); }
        }
        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }
        public bool Gestor
        {
            get { return gestor; }
            set { gestor = value; }
        }
    }
}