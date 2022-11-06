using Microsoft.VisualStudio.TestTools.UnitTesting;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesLib;

namespace Datos.Tests
{
    [TestClass()]
    public class BaseDatosTests
    {
        [TestMethod()]
        public void BaseDatosTest()
        {
            BaseDatos db = new BaseDatos();
            // Probamos que el constructor funciona
            Assert.IsNotNull(db);
            // Probamos el número de usuarios inicializados en la BBDD
            Assert.AreEqual(51, db.NumeroUsuarios());
        }

        [TestMethod()]
        public void InsertarUsuarioTest()
        {
            // Probamos que inserta satisfactoriamente un nuevo usuario
            BaseDatos db = new BaseDatos();
            Usuario usuario = new Usuario("juan@gmail.com", "Juan", "Bellido", "abcd1234");
            Assert.IsTrue(db.InsertarUsuario(usuario));

            // Probamos que no inserta un usuario que ya existe
            Assert.IsFalse(db.InsertarUsuario(usuario));
            usuario = new Usuario("admin@gmail.com", "admin", "pérez", "123456", true);
            Assert.IsFalse(db.InsertarUsuario(usuario));
        }

        [TestMethod()]
        public void EliminaUsuarioTest()
        {
            BaseDatos db = new BaseDatos();

            #region Caso 1
            // Usuario es null
            Usuario usuario = null;
            Assert.IsFalse(db.EliminaUsuario(usuario));
            // Probamos el número de usuarios inicializados en la BBDD no ha cambiado
            Assert.AreEqual(51, db.NumeroUsuarios());
            #endregion

            #region Caso 2
            // Usuario no existente en la BBDD o tiene idUsuario = 0
            Usuario usuario2 = new Usuario("juan@gmail.com", "Juan", "Bellido", "abcd1234");
            // Probamos que no elimina nada si no existe
            Assert.IsFalse(db.EliminaUsuario(usuario2));
            // Probamos el número de usuarios inicializados en la BBDD no ha cambiado
            Assert.AreEqual(51, db.NumeroUsuarios());
            #endregion

            #region Caso 3
            // Eliminamos un usuario que existe y no tiene estradas propias
            // ni tiene acceso a ninguna entrada
            Usuario usuario3 = db.ObtenerUsuario("agu_gra@gmail.com");
            Assert.IsTrue(db.EliminaUsuario(usuario3));
            // Probamos el número de usuarios inicializados en la BBDD si ha cambiado
            Assert.AreEqual(50, db.NumeroUsuarios());
            #endregion

            #region Caso 4
            // Eliminamos un usuario que existe y no tiene estradas propias
            // ni tiene acceso a ninguna entrada
            Usuario usuario4 = db.ObtenerUsuario("cay_arr@gmail.com");

            Entrada entrada = new Entrada(usuario4, "123456", "test", new List<int>());

            Usuario usuario5 = db.ObtenerUsuario("glo_san@gmail.com");

            List<int> listaUsuarios = new List<int>();
            listaUsuarios.Add(usuario4.IdUsuario);

            Entrada entrada1 = new Entrada(usuario5, "123456", "test", listaUsuarios);

            Assert.IsTrue(db.EliminaUsuario(usuario4));
            // Probamos el número de usuarios inicializados en la BBDD si ha cambiado
            Assert.AreEqual(49, db.NumeroUsuarios());
            // comprobamos que se elimina la entrada perteneciante al usuario4
            Assert.IsNull(db.ObtenerEntrada(entrada.IdEntrada));
            // comprobamos que se elimina al usuario4 de las listas de usuarios permitidos de las entradas 
            // a las que tiene acceso

            #endregion
        }

        [TestMethod()]
        public void ModificarUsuarioTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ObtenerUsuarioTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ObtenerEntradaTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InsertaEntradaTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EliminaEntradaTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InsertaAccesoTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ObtenerAccesoTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void NumeroUsuariosTest()
        {
            Assert.Fail();
        }
    }
}