using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Comun.Utils;

namespace ClasesLib.Tests
{
    [TestClass()]
    public class UsuarioTests
    {
        [TestMethod()]
        public void UsuarioTest()
        {
            // Comprobamos que crea un usuario
            Usuario usuario = new Usuario("email@email.com", "nombre", "apellido", "password");
            Assert.IsNotNull(usuario);
            Assert.AreEqual(usuario.Email, "email@email.com");
            Assert.AreEqual(usuario.Nombre, "nombre");
            Assert.AreEqual(usuario.Apellido, "apellido");
            Assert.AreEqual(usuario.Password, Encriptar("password"));
        }

        [TestMethod()]
        public void ValidaPasswordTest()
        {
            Usuario usuario = new Usuario("email@email.com", "nombre", "apellido", "password");
            Assert.IsTrue(usuario.ValidaPassword("password"));

            Assert.IsFalse(usuario.ValidaPassword("123456"));
        }

        [TestMethod()]
        public void AgregarPasswordAlmacenTest()
        {
            Usuario usuario = new Usuario("email@email.com", "nombre", "apellido", "password");
            Assert.AreEqual(usuario.PasswordRecuerdo[0], Encriptar("password"));
            Assert.AreEqual(usuario.ContadorPassword, 1);
            usuario.AgregarPasswordAlmacen("prueba");
            Assert.AreEqual(usuario.PasswordRecuerdo[1],Encriptar("prueba"));
            Assert.AreEqual(usuario.ContadorPassword, 2);
            usuario.AgregarPasswordAlmacen("prueba2");
            Assert.AreEqual(usuario.PasswordRecuerdo[2], Encriptar("prueba2"));
            Assert.AreEqual(usuario.ContadorPassword, 0);
            usuario.AgregarPasswordAlmacen("reset");
            Assert.AreEqual(usuario.PasswordRecuerdo[0], Encriptar("reset"));
            Assert.AreEqual(usuario.ContadorPassword, 1);
        }

        [TestMethod()]
        public void ExistePasswordAlmacenTest()
        {
            Usuario usuario = new Usuario("email@email.com", "nombre", "apellido", "password");
            Assert.AreEqual(usuario.PasswordRecuerdo[0], Encriptar("password"));
            Assert.AreEqual(usuario.ContadorPassword, 1);
            Assert.IsTrue(usuario.ExistePasswordAlmacen("password"));
            usuario.AgregarPasswordAlmacen("prueba");
            Assert.IsTrue(usuario.ExistePasswordAlmacen("prueba"));
            Assert.AreEqual(usuario.PasswordRecuerdo[1], Encriptar("prueba"));
            Assert.AreEqual(usuario.ContadorPassword, 2);
            Assert.IsTrue(usuario.ExistePasswordAlmacen("prueba"));
            usuario.AgregarPasswordAlmacen("prueba2");
            Assert.AreEqual(usuario.PasswordRecuerdo[2], Encriptar("prueba2"));
            Assert.AreEqual(usuario.ContadorPassword, 0);
            Assert.IsTrue(usuario.ExistePasswordAlmacen("prueba2"));
            usuario.AgregarPasswordAlmacen("reset");
            Assert.AreEqual(usuario.PasswordRecuerdo[0], Encriptar("reset"));
            Assert.AreEqual(usuario.ContadorPassword, 1);
            Assert.IsTrue(usuario.ExistePasswordAlmacen("reset"));

            Assert.IsFalse(usuario.ExistePasswordAlmacen("password"));
        }

        [TestMethod()]
        public void PasswordCaducadaTest()
        {
            Usuario usuario = new Usuario("email@email.com", "nombre", "apellido", "password");
            //fecha caducidad igual a hoy
            Assert.IsFalse(usuario.PasswordCaducada());
            //fecha caducidad en 1 mes
            usuario.CaducidadPassword = usuario.CaducidadPassword.AddDays(30);
            Assert.IsFalse(usuario.PasswordCaducada());
            //fecha caducada
            usuario.CaducidadPassword = DateTime.MinValue;
            Assert.IsTrue(usuario.PasswordCaducada());
        }

        [TestMethod()]
        public void CambiarPasswordTest()
        {
            Usuario usuario = new Usuario("email@email.com", "nombre", "apellido", "password");
            Assert.IsTrue(usuario.CambiarPassword("Email1234"));

            Assert.IsFalse(usuario.CambiarPassword("password"));
            Assert.IsFalse(usuario.CambiarPassword("Email1234"));

            usuario.CaducidadPassword = DateTime.Today.AddDays(-10);
            Assert.IsTrue(usuario.CambiarPassword("Abcde1234"));
            Assert.AreEqual(usuario.CaducidadPassword, DateTime.Today.AddDays(30));
        }
    }
}