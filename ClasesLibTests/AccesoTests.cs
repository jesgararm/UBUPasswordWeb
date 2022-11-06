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
    public class AccesoTests
    {
        [TestMethod()]
        public void AccesoTest()
        {
            // Creamos un usuario de prueba y una entrada de prueba.
            Usuario usuario = new Usuario("usuario@usuario.com", "Usuario", "Prueba", "1234");
            Entrada entrada = new Entrada(usuario, "12345", "Texto", new List<int> { 1, 2, 3, 4, 5 });

            // Creamos un acceso
            Acceso acceso = new Acceso(usuario);

            // Comprobamos que se crea correctamente y de forma consistente.
            Assert.IsNotNull(acceso);
            Assert.IsNotNull(acceso.Usuario);
            Assert.IsNotNull(acceso.EntradasLog);
            Assert.IsNotNull(acceso.FechaAcceso);
            Assert.AreEqual(acceso.Usuario, usuario);
            Assert.AreEqual(acceso.EntradasLog.Count, 0);
            
        }

        [TestMethod()]
        public void InsertarEntradaTest()
        {
            // Creamos un usuario de prueba y una entrada de prueba.
            Usuario usuario = new Usuario("usuario@usuario.com", "Usuario", "Prueba", "1234");
            Entrada entrada = new Entrada(usuario, "12345", "Texto", new List<int> { 1, 2, 3, 4, 5 });

            // Creamos un acceso
            Acceso acceso = new Acceso(usuario);

            // Hacemos que el usuario acceda a la entrada.
            EntradaLog entr = new EntradaLog(entrada, DateTime.Now);

            // Lo añadimos
            acceso.InsertarEntrada(entr);

            // Comprobamos que se ejecuta correctamente
            Assert.AreEqual(acceso.EntradasLog.Count, 1);
            Assert.AreEqual(acceso.EntradasLog[0], entr);

            // Creamos un log con una fecha anterior e intentamos añadirlo
            EntradaLog entr3 = new EntradaLog(entrada, DateTime.Now.AddDays(-1));
            acceso.InsertarEntrada(entr3);

            // Comprobamos que no se inserta
            Assert.AreEqual(acceso.EntradasLog.Count, 1);

            // Creamos un log con un usuario sin permisos e intentamos añadirlo
            Usuario usuario2 = new Usuario("usuario2@user.com", "Usuario", "Prueba", "1234");
            acceso = new Acceso(usuario2);
            EntradaLog entr2 = new EntradaLog(entrada, DateTime.Now);
            acceso.InsertarEntrada(entr2);

            // Comprobamos que no se inserta
            Assert.AreEqual(acceso.EntradasLog.Count, 0);

        }

        [TestMethod()]
        public void BuscarEntradaTest()
        {
            // Creamos un usuario de prueba y una entrada de prueba.
            Usuario usuario = new Usuario("usuario@usuario.com", "Usuario", "Prueba", "1234");
            Entrada entrada = new Entrada(usuario, "12345", "Texto", new List<int> { 1, 2, 3, 4, 5 });

            // Creamos un acceso
            Acceso acceso = new Acceso(usuario);

            // Hacemos que el usuario acceda a la entrada.
            EntradaLog entr = new EntradaLog(entrada, DateTime.Now);

            // Lo añadimos
            acceso.InsertarEntrada(entr);

            // Buscamos la entrada
            List<EntradaLog> entr2 = acceso.BuscarEntrada(entrada);

            // Comprobamos
            Assert.AreEqual(entr2.Count, 1);
            Assert.AreEqual(entr2[0], entr);
            
            // Realizamos otra entrada a la misma
            entr = new EntradaLog(entrada, DateTime.Now);
            acceso.InsertarEntrada(entr);

            // Buscamos la entrada
            entr2 = acceso.BuscarEntrada(entrada);

            // Comprobamos
            Assert.AreEqual(entr2.Count, 2);


        }
    }
}