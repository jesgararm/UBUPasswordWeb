using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class CP001
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
        public void TheCP001TestChrome()
        {
            driver.Navigate().GoToUrl("https://localhost:44382/InicioSesion.aspx");
            driver.FindElement(By.Id("txtNombreUs")).Click();
            driver.FindElement(By.Id("txtNombreUs")).Clear();
            driver.FindElement(By.Id("txtNombreUs")).SendKeys("agu_gra@gmail.com");
            driver.FindElement(By.Id("txtPass")).Clear();
            driver.FindElement(By.Id("txtPass")).SendKeys("Agu_Gra57");
            driver.FindElement(By.Id("btnEntrar")).Click();
            driver.Navigate().GoToUrl("https://localhost:44382/Inicio.aspx");
            driver.FindElement(By.XPath("//form[@id='form1']/div[3]/table/tbody/tr/td[3]")).Click();
            driver.FindElement(By.XPath("//form[@id='form1']/div[3]/table/tbody/tr/td[3]")).Click();
            driver.FindElement(By.XPath("//form[@id='form1']/div[3]/table/tbody/tr/td[3]")).Click();
            driver.FindElement(By.XPath("//form[@id='form1']/div[3]/table/tbody/tr/td[3]/strong/span")).Click();
            driver.FindElement(By.XPath("//form[@id='form1']/div[3]/table/tbody/tr/td[3]/strong/span")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | xpath=//form[@id='form1']/div[3]/table/tbody/tr/td[3]/strong/span | ]]
            driver.FindElement(By.XPath("//form[@id='form1']/div[3]/table/tbody/tr/td[3]/strong/span")).Click();
            driver.FindElement(By.XPath("//form[@id='form1']/div[3]/table/tbody/tr/td[3]/strong/span")).Click();
       
           Assert.AreEqual("PANEL DE USUARIO", driver.FindElement(By.XPath("//form[@id='form1']/div[3]/table/tbody/tr/td[3]/strong/span")).Text);
           
           driver.FindElement(By.XPath("//form[@id='form1']/div[3]/table/tbody/tr[15]/td[4]")).Click();

            driver.Close();
        }
        [TestMethod]
        public void TheCP001TestEdge()
        {
            driver = driverDos;
            driver.Navigate().GoToUrl("https://localhost:44382/InicioSesion.aspx");
            driver.FindElement(By.Id("txtNombreUs")).Click();
            driver.FindElement(By.Id("txtNombreUs")).Clear();
            driver.FindElement(By.Id("txtNombreUs")).SendKeys("agu_gra@gmail.com");
            driver.FindElement(By.Id("txtPass")).Clear();
            driver.FindElement(By.Id("txtPass")).SendKeys("Agu_Gra57");
            driver.FindElement(By.Id("btnEntrar")).Click();
            driver.Navigate().GoToUrl("https://localhost:44382/Inicio.aspx");
            driver.FindElement(By.XPath("//form[@id='form1']/div[3]/table/tbody/tr/td[3]")).Click();
            driver.FindElement(By.XPath("//form[@id='form1']/div[3]/table/tbody/tr/td[3]")).Click();
            driver.FindElement(By.XPath("//form[@id='form1']/div[3]/table/tbody/tr/td[3]")).Click();
            driver.FindElement(By.XPath("//form[@id='form1']/div[3]/table/tbody/tr/td[3]/strong/span")).Click();
            driver.FindElement(By.XPath("//form[@id='form1']/div[3]/table/tbody/tr/td[3]/strong/span")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | xpath=//form[@id='form1']/div[3]/table/tbody/tr/td[3]/strong/span | ]]
            driver.FindElement(By.XPath("//form[@id='form1']/div[3]/table/tbody/tr/td[3]/strong/span")).Click();
            driver.FindElement(By.XPath("//form[@id='form1']/div[3]/table/tbody/tr/td[3]/strong/span")).Click();

            Assert.AreEqual("PANEL DE USUARIO", driver.FindElement(By.XPath("//form[@id='form1']/div[3]/table/tbody/tr/td[3]/strong/span")).Text);

            driver.FindElement(By.XPath("//form[@id='form1']/div[3]/table/tbody/tr[15]/td[4]")).Click();

            driverDos.Close();
        }
    }
}
