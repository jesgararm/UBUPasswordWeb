using System;
using System.Text;
namespace Comun
{
    public static class Utils
    {
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
    }
}