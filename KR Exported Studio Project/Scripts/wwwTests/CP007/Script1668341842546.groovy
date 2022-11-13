import static com.kms.katalon.core.checkpoint.CheckpointFactory.findCheckpoint
import static com.kms.katalon.core.testcase.TestCaseFactory.findTestCase
import static com.kms.katalon.core.testdata.TestDataFactory.findTestData
import static com.kms.katalon.core.testobject.ObjectRepository.findTestObject
import com.kms.katalon.core.checkpoint.Checkpoint as Checkpoint
import com.kms.katalon.core.checkpoint.CheckpointFactory as CheckpointFactory
import com.kms.katalon.core.mobile.keyword.MobileBuiltInKeywords as MobileBuiltInKeywords
import com.kms.katalon.core.model.FailureHandling as FailureHandling
import com.kms.katalon.core.testcase.TestCase as TestCase
import com.kms.katalon.core.testcase.TestCaseFactory as TestCaseFactory
import com.kms.katalon.core.testdata.TestData as TestData
import com.kms.katalon.core.testdata.TestDataFactory as TestDataFactory
import com.kms.katalon.core.testobject.ObjectRepository as ObjectRepository
import com.kms.katalon.core.testobject.TestObject as TestObject
import com.kms.katalon.core.webservice.keyword.WSBuiltInKeywords as WSBuiltInKeywords
import com.kms.katalon.core.webui.driver.DriverFactory as DriverFactory
import com.kms.katalon.core.webui.keyword.WebUiBuiltInKeywords as WebUiBuiltInKeywords
import internal.GlobalVariable as GlobalVariable
import com.kms.katalon.core.webui.keyword.WebUiBuiltInKeywords as WebUI
import com.kms.katalon.core.mobile.keyword.MobileBuiltInKeywords as Mobile
import com.kms.katalon.core.webservice.keyword.WSBuiltInKeywords as WS
import com.kms.katalon.core.testobject.SelectorMethod

import com.thoughtworks.selenium.Selenium
import org.openqa.selenium.firefox.FirefoxDriver
import org.openqa.selenium.WebDriver
import com.thoughtworks.selenium.webdriven.WebDriverBackedSelenium
import static org.junit.Assert.*
import java.util.regex.Pattern
import static org.apache.commons.lang3.StringUtils.join
import org.testng.asserts.SoftAssert
import com.kms.katalon.core.testdata.CSVData
import org.openqa.selenium.Keys as Keys

SoftAssert softAssertion = new SoftAssert();
WebUI.openBrowser('https://www.google.com/')
def driver = DriverFactory.getWebDriver()
String baseUrl = "https://www.google.com/"
selenium = new WebDriverBackedSelenium(driver, baseUrl)
selenium.open("https://www.ubu.es/")
selenium.open("https://localhost:44382/InicioSesion.aspx")
selenium.click("id=txtNombreUs")
selenium.type("id=txtNombreUs", ("usuariocaducado@gmail.com").toString())
selenium.type("id=txtPass", "Abcd1234")
selenium.click("id=btnEntrar")
selenium.open("https://localhost:44382/Pass.aspx")
selenium.click("xpath=//*/text()[normalize-space(.)='']/parent::*")
selenium.click("id=txtPass")
selenium.type("id=txtPass", ("Abcde1234!#$%&'+-/=?^_`{|}~").toString())
selenium.click("xpath=//*/text()[normalize-space(.)='']/parent::*")
selenium.click("id=btnOK")
selenium.open("https://localhost:44382/InicioSesion.aspx")
selenium.click("id=txtNombreUs")
selenium.type("id=txtNombreUs", ("usuariocaducado@gmail.com").toString())
selenium.click("id=lblLogin")
selenium.click("id=lblLogin")
selenium.doubleClick("id=lblLogin")
selenium.click("id=lblLogin")
softAssertion.assertEquals("Login", selenium.getText("id=lblLogin"))
selenium.click("id=txtPass")
selenium.type("id=txtPass", ("Abcde1234!#$%&'+-/=?^_`{|}~").toString())
selenium.click("xpath=//*/text()[normalize-space(.)='']/parent::*")
selenium.click("id=btnEntrar")
selenium.open("https://localhost:44382/Inicio.aspx")
selenium.click("xpath=//form[@id='form1']/div[3]/table/tbody/tr/td[3]/strong/span")
selenium.click("xpath=//form[@id='form1']/div[3]/table/tbody/tr/td[3]/strong/span")
selenium.doubleClick("xpath=//form[@id='form1']/div[3]/table/tbody/tr/td[3]/strong/span")
selenium.click("xpath=//form[@id='form1']/div[3]/table/tbody/tr/td[3]/strong/span")
softAssertion.assertEquals("PANEL DE USUARIO", selenium.getText("xpath=//form[@id='form1']/div[3]/table/tbody/tr/td[3]/strong/span"))
selenium.click("xpath=//form[@id='form1']/div[3]/table")
selenium.click("xpath=//*/text()[normalize-space(.)='']/parent::*")
