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
            // Comprobamos que crea un usuario
            Usuario usuario = new Usuario("email@email.com", "nombre", "apellido", "password");
            Assert.IsTrue(usuario.ValidaPassword("password"));

            Assert.IsFalse(usuario.ValidaPassword("123456"));
        }

        [TestMethod()]
        public void AgregarPasswordAlmacenTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RecuperarPasswordActualAlmacenTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ExistePasswordAlmacenTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PasswordCaducadaTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CambiarPasswordTest()
        {
            Assert.Fail();
        }
    }
}