using System;
using System.CodeDom;
using System.Text;
using System.Text.RegularExpressions;
namespace Comun
{
    public static class Utils
    {
        private static Regex reg = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$");

        // Encripta en base 64 el string pasado
        // retorna el string encriptado.
        public static string Encriptar(string password)
        {
            byte[] encriptado = Encoding.Unicode.GetBytes(password);
            return Convert.ToBase64String(encriptado);
        }

        // Desencripta el string pasado en base 64
        // retorna el string desencriptado.
        public static string Desencriptar(string passwordEncriptada)
        {
            byte[] desencriptar = Convert.FromBase64String(passwordEncriptada);
            return Encoding.Unicode.GetString(desencriptar);
        }

        // Valida si la contraseña cumple con los requisitos
        // retorna true si cumple, false si no.
        public static bool ValidarPassword(string password)
        {
            return reg.IsMatch(password);
        }
    }
}