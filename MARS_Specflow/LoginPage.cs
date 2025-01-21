using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARS
{
    public class MARS_Program
    {
        private static void Main(string [] args)
        {
            //Open Chrome Browser
              IWebDriver driver = new ChromeDriver();


            //Launch MARS Portal
             driver.Navigate().GoToUrl("http://localhost:5000/");
             driver.Manage().Window.Maximize();
            Thread.Sleep(1000);


            //Identify the Sign In button and click on it
            IWebElement signinButton = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            signinButton.Click();

            //Identify Username Textbox and enter valid username
            IWebElement usernameTextbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
            usernameTextbox.SendKeys("hashba95@gmail.com");

            //Identify Password Textbox and enter valid password
            IWebElement passwordTextbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
            passwordTextbox.SendKeys("Hashsab@95");

            //Identify Remember Me checkbox and click on it
            IWebElement rememberMeCheckbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[3]/div/input"));
            rememberMeCheckbox.Click();

            //Identify Login Button and click on it
            IWebElement loginButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            loginButton.Click();





        }

    }
}
