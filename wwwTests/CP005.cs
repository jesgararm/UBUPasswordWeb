using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class CP005
    {
        private static IWebDriver driver;
        
        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            driver = new ChromeDriver();
           
        }
        
        [TestMethod]
        public void TheCP005Test()
        {
            driver.Navigate().GoToUrl("https://www.ubu.es/");
            driver.Navigate().GoToUrl("https://localhost:44382/InicioSesion.aspx");
            driver.FindElement(By.Id("txtNombreUs")).Click();
            driver.FindElement(By.Id("txtNombreUs")).Clear();
            driver.FindElement(By.Id("txtNombreUs")).SendKeys("usuariocaducado@gmail.com");
            driver.FindElement(By.Id("txtPass")).Clear();
            driver.FindElement(By.Id("txtPass")).SendKeys("Admin1234");
            driver.FindElement(By.Id("btnEntrar")).Click();
            driver.Navigate().GoToUrl("https://localhost:44382/Pass.aspx");
            driver.FindElement(By.Id("txtPass")).Click();
            driver.FindElement(By.Id("txtPass")).Clear();
            driver.FindElement(By.Id("txtPass")).SendKeys("Abcde1234");
            
            
            Assert.AreEqual("CONTRASEÑA CADUCADA", driver.FindElement(By.XPath("//form[@id='form1']/div[3]/table/tbody/tr/td[2]/strong/span")).Text);
            
         
            driver.FindElement(By.Id("btnOK")).Click();
            driver.Navigate().GoToUrl("https://localhost:44382/InicioSesion.aspx");
            driver.FindElement(By.Id("lblLogin")).Click();
            driver.FindElement(By.Id("lblLogin")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | id=lblLogin | ]]
            
            Assert.AreEqual("Login", driver.FindElement(By.Id("lblLogin")).Text);
            
         
            
            driver.FindElement(By.Id("txtNombreUs")).Click();
            driver.FindElement(By.Id("txtNombreUs")).Clear();
            driver.FindElement(By.Id("txtNombreUs")).SendKeys("usuariocaducado@gmail.com");
            driver.FindElement(By.Id("txtPass")).Clear();
            driver.FindElement(By.Id("txtPass")).SendKeys("Abcde1234");
            driver.FindElement(By.Id("btnEntrar")).Click();
            driver.Navigate().GoToUrl("https://localhost:44382/Inicio.aspx");
            driver.FindElement(By.XPath("//form[@id='form1']/div[3]/table/tbody/tr/td[3]/strong/span")).Click();
            driver.FindElement(By.XPath("//form[@id='form1']/div[3]/table/tbody/tr/td[3]/strong/span")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | xpath=//form[@id='form1']/div[3]/table/tbody/tr/td[3]/strong/span | ]]
            driver.FindElement(By.XPath("//form[@id='form1']/div[3]/table/tbody/tr/td[3]/strong/span")).Click();
           
            
            Assert.AreEqual("PANEL DE USUARIO", driver.FindElement(By.XPath("//form[@id='form1']/div[3]/table/tbody/tr/td[3]/strong/span")).Text);

            driver.Close();
        }
    }
}
