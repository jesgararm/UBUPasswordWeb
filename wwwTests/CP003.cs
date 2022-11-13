using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class CP003
    {
        private static IWebDriver driver;
        private static IWebDriver driverDos;

        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            driver = new ChromeDriver();
            driverDos = new EdgeDriver();
        }

        
        [TestMethod]
        public void TheCP003TestChrome()
        {
            driver.Navigate().GoToUrl("https://www.ubu.es/");
            driver.Navigate().GoToUrl("https://localhost:44382/InicioSesion.aspx");
            driver.FindElement(By.Id("txtNombreUs")).Click();
            driver.FindElement(By.Id("txtNombreUs")).Clear();
            driver.FindElement(By.Id("txtNombreUs")).SendKeys("agu_gra@gmail.com");
            driver.FindElement(By.Id("txtPass")).Clear();
            driver.FindElement(By.Id("txtPass")).SendKeys("abcd123");
            driver.FindElement(By.Id("btnEntrar")).Click();
            driver.FindElement(By.Id("lblErrorInicioSesion")).Click();
            driver.FindElement(By.Id("lblErrorInicioSesion")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | id=lblErrorInicioSesion | ]]
            driver.FindElement(By.Id("lblErrorInicioSesion")).Click();
            
            
            Assert.AreEqual("Contraseña incorrecta", driver.FindElement(By.Id("lblErrorInicioSesion")).Text);
            

        }

        [TestMethod]
        public void TheCP003TestEdge()
        {
            driver = driverDos;
            
            driver.Navigate().GoToUrl("https://www.ubu.es/");
            driver.Navigate().GoToUrl("https://localhost:44382/InicioSesion.aspx");
            driver.FindElement(By.Id("txtNombreUs")).Click();
            driver.FindElement(By.Id("txtNombreUs")).Clear();
            driver.FindElement(By.Id("txtNombreUs")).SendKeys("agu_gra@gmail.com");
            driver.FindElement(By.Id("txtPass")).Clear();
            driver.FindElement(By.Id("txtPass")).SendKeys("abcd123");
            driver.FindElement(By.Id("btnEntrar")).Click();
            driver.FindElement(By.Id("lblErrorInicioSesion")).Click();
            driver.FindElement(By.Id("lblErrorInicioSesion")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | id=lblErrorInicioSesion | ]]
            driver.FindElement(By.Id("lblErrorInicioSesion")).Click();


            Assert.AreEqual("Contraseña incorrecta", driver.FindElement(By.Id("lblErrorInicioSesion")).Text);


        }
    }
}
