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
    public class EntradaTests
    {
        [TestMethod()]
        public void EntradaTest()
        {
            // Creamos usuario para pruebas
            Usuario usuario = new Usuario("Usuario1@gmail.com", "Usuario1","Pérez", "1234");
            // Comprobamos que se crea una entrada correctamente
            Entrada entrada = new Entrada(usuario, "1234", "Entrada de prueba", new List<int>());
            Assert.AreEqual(entrada.Usuario, usuario);
            Assert.AreEqual(entrada.Password, Encriptar("1234"));
            Assert.AreEqual(entrada.Descripcion, "Entrada de prueba");
            Assert.AreEqual(entrada.ListaAccesoUsuarios.Count, 0);
            Assert.IsNotNull(entrada);
            Assert.AreEqual(entrada.IdEntrada, 0);
        }

        [TestMethod()]
        public void AgregarUsuarioTest()
        {
            // Creamos usuario para pruebas
            Usuario usuario = new Usuario("Usuario1@gmail.com", "Usuario1", "Pérez", "1234");
            // Creamos entrada para pruebas
            Entrada entrada = new Entrada(usuario, "1234", "Entrada de prueba", new List<int>());

            // Añadimos un usuario a la lista de acceso
            entrada.AgregarUsuario(usuario);
            // Comprobamos que se añade.
            Assert.AreEqual(entrada.ListaAccesoUsuarios.Count, 1);
            Assert.AreEqual(entrada.ListaAccesoUsuarios[0], usuario.IdUsuario);
            
        }

        [TestMethod()]
        public void EliminarUsuarioTest()
        {
            // Creamos usuario para pruebas
            Usuario usuario = new Usuario("Usuario1@gmail.com", "Usuario1", "Pérez", "1234");
            // Creamos entrada para pruebas
            Entrada entrada = new Entrada(usuario, "1234", "Entrada de prueba", new List<int>());

            // Añadimos un usuario a la lista de acceso
            entrada.AgregarUsuario(usuario);
            // Comprobamos que se añade.
            Assert.AreEqual(entrada.ListaAccesoUsuarios.Count, 1);
            Assert.AreEqual(entrada.ListaAccesoUsuarios[0], usuario.IdUsuario);
            // Lo eliminamos
            entrada.EliminarUsuario(usuario);
            // Comprobamos que se elimina
            Assert.AreEqual(entrada.ListaAccesoUsuarios.Count, 0);
        }

        [TestMethod()]
        public void ExisteUsuarioTest()
        {
            // Creamos usuario para pruebas
            Usuario usuario = new Usuario("Usuario1@gmail.com", "Usuario1", "Pérez", "1234");
            usuario.IdUsuario = 1;
            // Creamos entrada para pruebas
            Entrada entrada = new Entrada(usuario, "1234", "Entrada de prueba", new List<int>());

            // Creamos usuario para pruebas
            Usuario usuario2 = new Usuario("juanito@gmail.com", "Usuario2", "Pérez", "1234");
            usuario2.IdUsuario = 2;
            // Añadimos un usuario a la lista de acceso
            entrada.AgregarUsuario(usuario);
            entrada.AgregarUsuario(usuario2);

            Assert.IsTrue(entrada.ExisteUsuario(usuario));
            Assert.IsTrue(entrada.ExisteUsuario(usuario2));

            // Creamos usuario para pruebas
            Usuario usuario3 = new Usuario("pepito@gmail.com", "Usuario3", "Pérez", "1234");
            usuario3.IdUsuario = 3;

            Assert.IsFalse(entrada.ExisteUsuario(usuario3));
        }
        
    }
}