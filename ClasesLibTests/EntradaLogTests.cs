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
    public class EntradaLogTests
    {
        [TestMethod()]
        public void EntradaLogTest()
        {
            // Creamos una entrada y un usuario de pruebas
            Usuario usuario = new Usuario("usuario@usuario.com","Usuario","Prueba","1234");
            Entrada entrada = new Entrada(usuario, "12345", "Texto", new List<int> { 1, 2, 3, 4, 5 });

            // Creamos un log
            DateTime time = DateTime.Now;
            EntradaLog log = new EntradaLog(entrada, time);
            // Comprobamos que se crea
            Assert.IsNotNull(log);
            Assert.IsNotNull(log.Entrada);
            Assert.IsNotNull(log.Fecha);
            Assert.AreEqual(log.Entrada, entrada);
            Assert.AreEqual(log.Fecha, time);
        }
    }
}