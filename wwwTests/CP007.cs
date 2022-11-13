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
    public class CP007
    {
        private static IWebDriver driver;
        
        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            driver = new ChromeDriver();
        }
        
        
        [TestMethod]
        public void TheCP007Test()
        {
            driver.Navigate().GoToUrl("https://www.ubu.es/");
            driver.Navigate().GoToUrl("https://localhost:44382/InicioSesion.aspx");
            driver.FindElement(By.Id("txtNombreUs")).Click();
            driver.FindElement(By.Id("txtNombreUs")).Clear();
            driver.FindElement(By.Id("txtNombreUs")).SendKeys("usuariocaducado2@gmail.com");
            driver.FindElement(By.Id("txtPass")).Clear();
            driver.FindElement(By.Id("txtPass")).SendKeys("Admin1234");
            driver.FindElement(By.Id("btnEntrar")).Click();
            driver.Navigate().GoToUrl("https://localhost:44382/Pass.aspx");
            driver.FindElement(By.XPath("//*/text()[normalize-space(.)='']/parent::*")).Click();
            driver.FindElement(By.Id("txtPass")).Click();
            driver.FindElement(By.Id("txtPass")).Clear();
            driver.FindElement(By.Id("txtPass")).SendKeys("Abcde1234!#$%&'+-/=?^_`{|}~");
            driver.FindElement(By.XPath("//*/text()[normalize-space(.)='']/parent::*")).Click();
            driver.FindElement(By.Id("btnOK")).Click();
            driver.Navigate().GoToUrl("https://localhost:44382/InicioSesion.aspx");
            driver.FindElement(By.Id("txtNombreUs")).Click();
            driver.FindElement(By.Id("txtNombreUs")).Clear();
            driver.FindElement(By.Id("txtNombreUs")).SendKeys("usuariocaducado2@gmail.com");
            driver.FindElement(By.Id("lblLogin")).Click();
            driver.FindElement(By.Id("lblLogin")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | id=lblLogin | ]]
            driver.FindElement(By.Id("lblLogin")).Click();
            
                Assert.AreEqual("Login", driver.FindElement(By.Id("lblLogin")).Text);
            
            driver.FindElement(By.Id("txtPass")).Click();
            driver.FindElement(By.Id("txtPass")).Clear();
            driver.FindElement(By.Id("txtPass")).SendKeys("Abcde1234!#$%&'+-/=?^_`{|}~");
            driver.FindElement(By.XPath("//*/text()[normalize-space(.)='']/parent::*")).Click();
            driver.FindElement(By.Id("btnEntrar")).Click();
            driver.Navigate().GoToUrl("https://localhost:44382/Inicio.aspx");
            driver.FindElement(By.XPath("//form[@id='form1']/div[3]/table/tbody/tr/td[3]/strong/span")).Click();
            driver.FindElement(By.XPath("//form[@id='form1']/div[3]/table/tbody/tr/td[3]/strong/span")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | xpath=//form[@id='form1']/div[3]/table/tbody/tr/td[3]/strong/span | ]]
            driver.FindElement(By.XPath("//form[@id='form1']/div[3]/table/tbody/tr/td[3]/strong/span")).Click();
          
                Assert.AreEqual("PANEL DE USUARIO", driver.FindElement(By.XPath("//form[@id='form1']/div[3]/table/tbody/tr/td[3]/strong/span")).Text);
            
            driver.FindElement(By.XPath("//form[@id='form1']/div[3]/table")).Click();
            driver.FindElement(By.XPath("//*/text()[normalize-space(.)='']/parent::*")).Click();

            driver.Close();
        }
    }
}
