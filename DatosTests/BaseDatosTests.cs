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
            db.InsertarUsuario(usuario2);
            Usuario usuarioE = db.ObtenerUsuario("juan@gmail.com");
            // Probamos que no elimina nada si no existe
            Assert.IsFalse(db.EliminaUsuario(usuarioE));
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
            // Eliminamos un usuario que existe, tiene estradas propias
            // y tiene acceso a una entrada
            Usuario usuario4 = db.ObtenerUsuario("cay_arr@gmail.com");
            // Creamos una entrada con este usuario
            Entrada entrada = new Entrada(usuario4, "123456", "test", new List<int>());
            db.InsertaEntrada(entrada);
            //obtenemos otro usuario
            Usuario usuario5 = db.ObtenerUsuario("glo_san@gmail.com");
            //añadimos el id del primero a la lista que pasaremos a la nueva
            //entrada del segundo usuario
            List<int> listaUsuarios = new List<int>();
            listaUsuarios.Add(usuario4.IdUsuario);
            Entrada entrada1 = new Entrada(usuario5, "123456", "test", listaUsuarios);
            db.InsertaEntrada(entrada1);

            Assert.IsTrue(db.EliminaUsuario(usuario4));
            // Probamos el número de usuarios inicializados en la BBDD si ha cambiado
            Assert.AreEqual(49, db.NumeroUsuarios());
            // comprobamos que se elimina la entrada perteneciante al usuario4
            Assert.AreEqual(db.ObtenerIdEntradasPropiedadUsuario(usuario4).Count,0);

            // comprobamos que se elimina al usuario4 de las listas de usuarios permitidos de las entradas 
            // a las que tiene acceso
            Assert.AreEqual(db.ObtenerIdEntradasAccesoUsuario(usuario4).Count, 0);
            #endregion
        }

        [TestMethod()]
        public void ModificarDatosUsuarioTest()
        {
            BaseDatos db = new BaseDatos();

            #region Caso 1
            // Usuario es null
            Usuario usuario = null;
            Assert.IsFalse(db.ModificarDatosUsuario(usuario));
            #endregion

            #region Caso 2
            // Usuario no existente en la BBDD o tiene idUsuario = 0
            Usuario usuario2 = new Usuario("juan@gmail.com", "Juan", "Bellido", "abcd1234");
            // Probamos que no elimina nada si no existe
            Assert.IsFalse(db.ModificarDatosUsuario(usuario2));
            #endregion

            #region Caso 3
            // Modificamos un usuario que existe
            Usuario usuario3 = db.ObtenerUsuario("agu_gra@gmail.com");
            usuario3.Nombre = "nombreTest";
            usuario3.Apellido = "apellidoTest"; 
            Assert.IsTrue(db.ModificarDatosUsuario(usuario3));
            //comprobamos que se han modificado los campos
            Usuario usuarioRecuperado = db.ObtenerUsuario(usuario3.Email);
            Assert.AreEqual(usuarioRecuperado.Nombre, "nombreTest");
            Assert.AreEqual(usuarioRecuperado.Nombre, "apellidoTest");
            #endregion
        }

        [TestMethod()]
        public void ObtenerUsuarioTest()
        {
            #region Caso 1
            // Usuario es null
            Usuario usuario = null;
            //Assert.IsFalse(db.ModificarDatosUsuario(usuario));
            #endregion
        }
        [TestMethod()]
        public void ObtenerListaEmailUsuariosTest()
        {
            Assert.Fail();
        }
        
        [TestMethod()]
        public void ObtenerEntradaTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ObtenerIdEntradasPropiedadUsuario()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void ObtenerIdEntradasAccesoUsuario()
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