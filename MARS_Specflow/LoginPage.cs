using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARS
{
    public class LoginPage
    {

        public void LoginActions(IWebDriver driver)
        {

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

                Thread.Sleep(5000);


                IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[1]"));
                Assert.That(newCode.Text == "Dashboard", "Userlogged in successfully and redirected to the dashboard");




        }
    }
}
