using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using static Comun.Utils;

namespace ClasesLib
{
    public class Usuario
    {
        private static readonly int TAM = 3;

        // Atributos
        private int idUsuario;
        private string nombre;
        private string apellido;
        private string email;
        private string password;
        private bool gestor;
        private bool activo;
        private string[] passwordRecuerdo;
        private DateTime caducidadPassword;
        private int contadorPassword;
        // Constructor de clase
        public Usuario(string email, string nombre, string apellido, string password, bool gestor = false)
        {
            this.idUsuario = 0;
            this.email = email;
            this.nombre = nombre;
            this.apellido = apellido;
            this.password = Encriptar(password);
            this.gestor = gestor;
            this.activo = false;
            this.passwordRecuerdo = new string[TAM];
            this.caducidadPassword = new DateTime();
            this.contadorPassword = 0;

            AgregarPasswordAlmacen(password);
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
        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }
        public string[] PasswordRecuerdo
        {
            get { return passwordRecuerdo; }
            set { passwordRecuerdo = value; }
        }
        public DateTime CaducidadPassword
        {
            get { return caducidadPassword; }
            set { caducidadPassword = value; }
        }
        // Valida contraseña de usuario
        public bool ValidaPassword(string password)
        {
            return this.password == Encriptar(password);
        }
        public int ContadorPassword
        {
            get { return contadorPassword; }
            set { contadorPassword = value; }
        }
        public void AgregarPasswordAlmacen(string password) 
        {
            switch (contadorPassword) 
            {
                case 0:
                    passwordRecuerdo[contadorPassword] = Encriptar(password);
                    contadorPassword++;
                    break;
                case 1:
                    passwordRecuerdo[contadorPassword] = Encriptar(password);
                    contadorPassword++;
                    break;
                case 2:
                    passwordRecuerdo[contadorPassword] = Encriptar(password);
                    contadorPassword = 0;
                    break;
            }
        }

        public bool ExistePasswordAlmacen(string password) 
        {
            foreach (string s in passwordRecuerdo) 
            {
                if (s == Encriptar(password))
                    return true;
            }

            return false;
        }

        public bool PasswordCaducada() 
        {
            if (caducidadPassword < DateTime.Today)
                return true;
            return false;
        }

        public bool CambiarPassword(string password) 
        {
            // si ya existe en algunos de los slot de memoria de password
            if (ExistePasswordAlmacen(password))
                return false;

            this.password = password;
            return true;
        }
    }
}