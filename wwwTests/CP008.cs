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
    public class CP008
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
        public void TheCP008TestChrome()
        {
            driver.Navigate().GoToUrl("https://www.ubu.es/");
            driver.Navigate().GoToUrl("https://localhost:44382/InicioSesion.aspx");
            driver.FindElement(By.Id("txtNombreUs")).Click();
            driver.FindElement(By.Id("txtNombreUs")).Clear();
            driver.FindElement(By.Id("txtNombreUs")).SendKeys("usuariocaducado3@gmail.com");
            driver.FindElement(By.Id("txtPass")).Clear();
            driver.FindElement(By.Id("txtPass")).SendKeys("Admin1234");
            driver.FindElement(By.Id("btnEntrar")).Click();
            driver.Navigate().GoToUrl("https://localhost:44382/Pass.aspx");
            driver.FindElement(By.Id("txtPass")).Click();
            driver.FindElement(By.Id("txtPass")).Clear();
            driver.FindElement(By.Id("txtPass")).SendKeys("Admin1234");
            driver.FindElement(By.Id("btnOK")).Click();
            driver.FindElement(By.Id("lblError")).Click();
            driver.FindElement(By.Id("lblError")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | id=lblError | ]]
            driver.FindElement(By.Id("lblError")).Click();
            
                Assert.AreEqual("La contraseña ya ha sido utilizada", driver.FindElement(By.Id("lblError")).Text);

            driver.Close();
         
        }

        [TestMethod]
        public void TheCP008TestEdge()
        {
            driver = driverDos;
            driver.Navigate().GoToUrl("https://www.ubu.es/");
            driver.Navigate().GoToUrl("https://localhost:44382/InicioSesion.aspx");
            driver.FindElement(By.Id("txtNombreUs")).Click();
            driver.FindElement(By.Id("txtNombreUs")).Clear();
            driver.FindElement(By.Id("txtNombreUs")).SendKeys("usuariocaducado3@gmail.com");
            driver.FindElement(By.Id("txtPass")).Clear();
            driver.FindElement(By.Id("txtPass")).SendKeys("Admin1234");
            driver.FindElement(By.Id("btnEntrar")).Click();
            driver.Navigate().GoToUrl("https://localhost:44382/Pass.aspx");
            driver.FindElement(By.Id("txtPass")).Click();
            driver.FindElement(By.Id("txtPass")).Clear();
            driver.FindElement(By.Id("txtPass")).SendKeys("Admin1234");
            driver.FindElement(By.Id("btnOK")).Click();
            driver.FindElement(By.Id("lblError")).Click();
            driver.FindElement(By.Id("lblError")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | id=lblError | ]]
            driver.FindElement(By.Id("lblError")).Click();

            Assert.AreEqual("La contraseña ya ha sido utilizada", driver.FindElement(By.Id("lblError")).Text);

            driverDos.Close();

        }
    }
}
