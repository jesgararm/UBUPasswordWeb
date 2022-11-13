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
    public class CP004
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
        public void TheCP004TestChrome()
        {
            driver.Navigate().GoToUrl("https://www.ubu.es/");
            driver.Navigate().GoToUrl("https://localhost:44382/InicioSesion.aspx");
            driver.FindElement(By.Id("txtNombreUs")).Click();
            driver.FindElement(By.Id("txtNombreUs")).Clear();
            driver.FindElement(By.Id("txtNombreUs")).SendKeys("usuariocaducado@gmail.com");
            driver.FindElement(By.Id("txtPass")).Clear();
            driver.FindElement(By.Id("txtPass")).SendKeys("admin");
            driver.FindElement(By.Id("form1")).Submit();
            driver.Navigate().GoToUrl("https://localhost:44382/Pass.aspx");
            
            
            Assert.AreEqual("CONTRASEÑA CADUCADA", driver.FindElement(By.XPath("//form[@id='form1']/div[3]/table/tbody/tr/td[2]/strong/span")).Text);
            

        }

        [TestMethod]
        public void TheCP004TestEdge()
        {
            driver = driverDos;
            
            driver.Navigate().GoToUrl("https://www.ubu.es/");
            driver.Navigate().GoToUrl("https://localhost:44382/InicioSesion.aspx");
            driver.FindElement(By.Id("txtNombreUs")).Click();
            driver.FindElement(By.Id("txtNombreUs")).Clear();
            driver.FindElement(By.Id("txtNombreUs")).SendKeys("usuariocaducado@gmail.com");
            driver.FindElement(By.Id("txtPass")).Clear();
            driver.FindElement(By.Id("txtPass")).SendKeys("admin");
            driver.FindElement(By.Id("form1")).Submit();
            driver.Navigate().GoToUrl("https://localhost:44382/Pass.aspx");


            Assert.AreEqual("CONTRASEÑA CADUCADA", driver.FindElement(By.XPath("//form[@id='form1']/div[3]/table/tbody/tr/td[2]/strong/span")).Text);


        }
    }
}
