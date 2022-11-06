using Microsoft.VisualStudio.TestTools.UnitTesting;
using Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun.Tests
{
    [TestClass()]
    public class UtilsTests
    {
        [TestMethod()]
        public void EncriptarTest()
        {
            // Encripta un texto simple
            Assert.AreEqual(Utils.Encriptar("hola"), Convert.ToBase64String(Encoding.Unicode.GetBytes("hola")));

            // Encripta un texto alfanumérico
            Assert.AreEqual(Utils.Encriptar("hola123"), Convert.ToBase64String(Encoding.Unicode.GetBytes("hola123")));

            // Encripta un texto alfanumérico con caracteres especiales
            Assert.AreEqual(Utils.Encriptar("hola123!@#$%^&*()_+"), Convert.ToBase64String(Encoding.Unicode.GetBytes("hola123!@#$%^&*()_+")));

            // Encripta un texto acentuado
            Assert.AreEqual(Utils.Encriptar("holaáéíóú"), Convert.ToBase64String(Encoding.Unicode.GetBytes("holaáéíóú")));

            // Encripta un texto con ñ
            Assert.AreEqual(Utils.Encriptar("holañ"), Convert.ToBase64String(Encoding.Unicode.GetBytes("holañ")));
        }

        [TestMethod()]
        public void DesencriptarTest()
        {
            // Desencripta un texto simple
            Assert.AreEqual(Utils.Desencriptar(Convert.ToBase64String(Encoding.Unicode.GetBytes("hola"))), "hola");

            // Desencripta un texto alfanumérico
            Assert.AreEqual(Utils.Desencriptar(Convert.ToBase64String(Encoding.Unicode.GetBytes("hola123"))), "hola123");

            // Desencripta un texto alfanumérico con caracteres especiales
            Assert.AreEqual(Utils.Desencriptar(Convert.ToBase64String(Encoding.Unicode.GetBytes("hola123!@#$%^&*()_+"))), "hola123!@#$%^&*()_+");
            
            // Desencripta un texto acentuado
            Assert.AreEqual(Utils.Desencriptar(Convert.ToBase64String(Encoding.Unicode.GetBytes("holaáéíóú"))), "holaáéíóú");

            // Desencripta un texto con ñ
            Assert.AreEqual(Utils.Desencriptar(Convert.ToBase64String(Encoding.Unicode.GetBytes("holañ"))), "holañ");
        }
    }
}