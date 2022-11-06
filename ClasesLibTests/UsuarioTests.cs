using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}