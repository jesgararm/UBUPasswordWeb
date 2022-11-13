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
            Assert.AreEqual(55, db.NumeroUsuarios());
        }

        [TestMethod()]
        public void InsertarUsuarioTest()
        {
            BaseDatos db = new BaseDatos();

            #region Caso 1
            // Probamos que inserta satisfactoriamente un nuevo usuario
            Usuario usuario = new Usuario("juan@gmail.com", "Juan", "Bellido", "abcd1234");
            Assert.IsTrue(db.InsertarUsuario(usuario));
            #endregion

            #region Caso 2
            // Probamos que no inserta un usuario que ya existe
            Assert.IsFalse(db.InsertarUsuario(usuario));
            usuario = new Usuario("admin@gmail.com", "admin", "pérez", "123456", true);
            Assert.IsFalse(db.InsertarUsuario(usuario));
            #endregion
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
            Assert.AreEqual(55, db.NumeroUsuarios());
            #endregion

            #region Caso 2
            // Usuario no existente en la BBDD o tiene idUsuario = 0
            Usuario usuario2 = new Usuario("juan@gmail.com", "Juan", "Bellido", "abcd1234");
            // Probamos que no elimina nada si no existe
            Assert.IsFalse(db.EliminaUsuario(usuario2));
            // Probamos el número de usuarios inicializados en la BBDD no ha cambiado
            Assert.AreEqual(55, db.NumeroUsuarios());
            #endregion

            #region Caso 3
            // Eliminamos un usuario que existe y no tiene estradas propias
            // ni tiene acceso a ninguna entrada
            Usuario usuario3 = db.ObtenerUsuario("agu_gra@gmail.com");
            Assert.IsTrue(db.EliminaUsuario(usuario3));
            // Probamos el número de usuarios inicializados en la BBDD si ha cambiado
            Assert.AreEqual(54, db.NumeroUsuarios());
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
            Assert.AreEqual(53, db.NumeroUsuarios());
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
            Assert.AreEqual(usuarioRecuperado.Apellido, "apellidoTest");
            #endregion
        }

        [TestMethod()]
        public void ObtenerUsuarioTest()
        {
            BaseDatos db = new BaseDatos();

            #region Caso 1
            // Email de usuario que no existe
            Assert.IsNull(db.ObtenerUsuario("prueba@gmail.com"));
            #endregion

            #region Caso 2
            // Email de usuario que existe en la BBDD
            Usuario usuarioRecuperado = db.ObtenerUsuario("agu_gra@gmail.com");
            Assert.IsNotNull(usuarioRecuperado);
            Assert.AreEqual(usuarioRecuperado.Email,"agu_gra@gmail.com");
            #endregion
        }

        [TestMethod()]
        public void ObtenerListaEmailUsuariosTest()
        {
            BaseDatos db = new BaseDatos();

            Assert.AreEqual(db.ObtenerListaEmailUsuarios().Count, db.NumeroUsuarios());
        }
        
        [TestMethod()]
        public void ObtenerEntradaTest()
        {
            BaseDatos db = new BaseDatos();

            #region Caso 1
            // id inexistente
            Assert.IsNull(db.ObtenerEntrada(1));
            #endregion

            #region Caso 2
            Usuario usuario1 = db.ObtenerUsuario("cay_arr@gmail.com");
            // Creamos una entrada con este usuario
            Entrada entrada = new Entrada(usuario1, "123456", "test", new List<int>());
            db.InsertaEntrada(entrada);

            Assert.IsNotNull(db.ObtenerEntrada(1));
            #endregion
        }

        [TestMethod()]
        public void ObtenerIdEntradasPropiedadUsuario()
        {
            BaseDatos db = new BaseDatos();

            #region Caso 1
            // el usuario tiene entradas y se recuperan correctamente los ids
            Usuario usuario = db.ObtenerUsuario("agu_gra@gmail.com");
            // Creamos una entrada con este usuario
            Entrada entrada = new Entrada(usuario, "123456", "test", new List<int>()); // tendra id 1
            Entrada entrada1 = new Entrada(usuario, "123456", "test", new List<int>()); // tendra id 2
            Entrada entrada2 = new Entrada(usuario, "123456", "test", new List<int>()); // tendra id 3
            //insertamos la entradas
            db.InsertaEntrada(entrada);
            db.InsertaEntrada(entrada1);
            db.InsertaEntrada(entrada2);

            var lista = db.ObtenerIdEntradasPropiedadUsuario(usuario);
            //comprobamos que contiene los ids y la cantidad de elementos es la correcta
            Assert.IsTrue(lista.Contains(1));
            Assert.IsTrue(lista.Contains(2));
            Assert.IsTrue(lista.Contains(3));
            int num = lista.Count;
            Assert.AreEqual(num,3);
            #endregion

            #region Caso 2
            // el usuario no tiene entradas
            Usuario usuario1 = db.ObtenerUsuario("glo_san@gmail.com");

            var lista1 = db.ObtenerIdEntradasPropiedadUsuario(usuario1);
            //comprobamos que contiene los ids y la cantidad de elementos es la correcta
            int num1 = lista1.Count;
            Assert.AreEqual(num1, 0);
            #endregion
        }
        [TestMethod()]
        public void ObtenerIdEntradasAccesoUsuario()
        {
            BaseDatos db = new BaseDatos();

            #region Caso 1
            // el usuario tiene acceso a varias entradas que no le pertenecen
            Usuario usuario = db.ObtenerUsuario("agu_gra@gmail.com");
            // Creamos una entrada con este usuario
            Entrada entrada = new Entrada(usuario, "123456", "test", new List<int>());
            Entrada entrada1 = new Entrada(usuario, "123456", "test", new List<int>());
            Entrada entrada2 = new Entrada(usuario, "123456", "test", new List<int>());
            //insertamos la entradas
            db.InsertaEntrada(entrada);
            db.InsertaEntrada(entrada1);
            db.InsertaEntrada(entrada2);
            //cogemos otro usuario y le damos acceso a la entrada
            Usuario usuario1 = db.ObtenerUsuario("cay_arr@gmail.com");
            entrada.AgregarUsuario(usuario1);
            entrada1.AgregarUsuario(usuario1);
            entrada2.AgregarUsuario(usuario1);
            //buscamos la entradas a las que tiene acceso el nuevo usuario
            var lista = db.ObtenerIdEntradasAccesoUsuario(usuario1);
            //comprobamos que contiene los ids y la cantidad de elementos es la correcta
            Assert.IsTrue(lista.Contains(1));
            Assert.IsTrue(lista.Contains(2));
            Assert.IsTrue(lista.Contains(3));
            int num = lista.Count;
            Assert.AreEqual(num, 3);
            #endregion

            #region Caso 2
            // el usuario no tiene accesoa a entradas que no le pertenecen
            Usuario usuario2 = db.ObtenerUsuario("glo_san@gmail.com");

            var lista1 = db.ObtenerIdEntradasPropiedadUsuario(usuario2);
            //comprobamos que contiene los ids y la cantidad de elementos es la correcta
            int num1 = lista1.Count;
            Assert.AreEqual(num1, 0);
            #endregion
        }

        [TestMethod()]
        public void InsertaEntradaTest()
        {
            BaseDatos db = new BaseDatos();

            #region Caso 1
            int numeroEntradas = db.NumeroEntradas();
            // Probamos que inserta satisfactoriamente
            Usuario usuario1 = db.ObtenerUsuario("cay_arr@gmail.com");
            // Creamos una entrada con este usuario
            Entrada entrada = new Entrada(usuario1, "123456", "test", new List<int>());
            Assert.IsTrue(db.InsertaEntrada(entrada));
            Assert.AreEqual(++numeroEntradas, db.NumeroEntradas());
            #endregion

            #region Caso 2
            // Probamos que no inserta una entrada que ya existe
            Entrada entrada1 = db.ObtenerEntrada(numeroEntradas);
            Assert.IsFalse(db.InsertaEntrada(entrada1));
            Assert.AreEqual(numeroEntradas, db.NumeroEntradas());
            #endregion
        }

        [TestMethod()]
        public void EliminaEntradaTest()
        {
            BaseDatos db = new BaseDatos();

            #region Caso 1
            int numeroEntradas = db.NumeroEntradas();
            // Probamos que inserta satisfactoriamente
            Usuario usuario1 = db.ObtenerUsuario("cay_arr@gmail.com");
            // Creamos una entrada con este usuario
            Entrada entrada = new Entrada(usuario1, "123456", "test", new List<int>());
            Assert.IsTrue(db.InsertaEntrada(entrada));
            Assert.AreEqual(++numeroEntradas, db.NumeroEntradas());
            Entrada entrada1 = db.ObtenerEntrada(numeroEntradas);
            Assert.IsTrue(db.EliminaEntrada(entrada1));
            Assert.AreEqual(--numeroEntradas, db.NumeroEntradas());
            #endregion

            #region Caso 2
            //comprobamos que no elimina nada si la entrada no existe
            Entrada entrada2 = new Entrada(usuario1, "123456", "test", new List<int>());
            entrada.IdEntrada = 99999;
            Assert.IsFalse(db.EliminaEntrada(entrada2));
            Assert.AreEqual(numeroEntradas, db.NumeroEntradas());
            #endregion
        }

        [TestMethod()]
        public void InsertaAccesoTest()
        {
            BaseDatos db = new BaseDatos();

            #region Caso 1
            int numeroAccesos = db.NumeroAccesos();
            // Probamos que inserta satisfactoriamente
            Usuario usuario1 = db.ObtenerUsuario("cay_arr@gmail.com");
            // Creamos un acceso con este usuario
            Acceso acceso = new Acceso(usuario1);
            Assert.IsTrue(db.InsertaAcceso(acceso));
            Assert.AreEqual(++numeroAccesos, db.NumeroAccesos());
            #endregion

            #region Caso 2
            // Probamos que no inserta una entrada que ya existe
            Acceso acceso1 = db.ObtenerAcceso(numeroAccesos);
            Assert.IsFalse(db.InsertaAcceso(acceso1));
            Assert.AreEqual(numeroAccesos, db.NumeroAccesos());
            #endregion
        }

        [TestMethod()]
        public void ObtenerAccesoTest()
        {
            BaseDatos db = new BaseDatos();

            #region Caso 1
            // id inexistente
            Assert.IsNull(db.ObtenerAcceso(1));
            #endregion

            #region Caso 2
            Usuario usuario1 = db.ObtenerUsuario("cay_arr@gmail.com");
            // Creamos un acceso con este usuario
            Acceso acceso = new Acceso(usuario1);
            db.InsertaAcceso(acceso);

            Assert.IsNotNull(db.ObtenerAcceso(1));
            #endregion
        }

        [TestMethod()]
        public void NumeroUsuariosTest()
        {
            BaseDatos db = new BaseDatos();

            Assert.AreEqual(55, db.NumeroUsuarios());
        }

        [TestMethod()]
        public void NumeroEntradasTest()
        {
            BaseDatos db = new BaseDatos();

            Assert.AreEqual(0, db.NumeroEntradas());
        }

        [TestMethod()]
        public void NumeroAccesosTest()
        {
            BaseDatos db = new BaseDatos();

            Assert.AreEqual(0, db.NumeroAccesos());
        }
    }
}