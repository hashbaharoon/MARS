using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;
using TechTalk.SpecFlow;

namespace MARS
{
    [Binding]
    public class LoginStepDefinitions
    {
        IWebDriver driver = new ChromeDriver();

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            //Open Chrome Browser
            

            //Launch MARS Portal
            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);

            //Identify the Sign In button and click on it
            IWebElement signinButton = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            signinButton.Click();
        }

        [When(@"I enter a valid username ""([^""]*)"" and password ""([^""]*)""")]
        public void WhenIEnterAValidUsernameAndPassword(string username, string password)
        {
            IWebElement usernameTextbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
            IWebElement passwordTextbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));

            usernameTextbox.SendKeys(username);
            passwordTextbox.SendKeys(password);

            //Identify Remember Me checkbox and click on it
            IWebElement rememberMeCheckbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[3]/div/input"));
            rememberMeCheckbox.Click();

        }

        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            IWebElement loginButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            loginButton.Click();

            Thread.Sleep(5000);
        }

        [Then(@"I should be redirected to the dashboard")]
        public void ThenIShouldBeRedirectedToTheDashboard()
        {
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[1]"));
            Assert.That(newCode.Text == "Dashboard", "Userlogged in successfully and redirected to the dashboard");

        }

        [When(@"I enter the username that is already registered")]
        public void WhenIEnterTheUsernameThatIsAlreadyRegistered()
        {
            IWebElement usernameTextbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
            usernameTextbox.SendKeys("hashba95@gmail.com");
        }

        [When(@"I enter a valid password")]
        public void WhenIEnterAValidPassword()
        {
            IWebElement passwordTextbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
            passwordTextbox.SendKeys("Aroha@95");
        }

        [Then(@"I should see a send verification email dialog box")]
        public void ThenIShouldSeeASendVerificationEmailDialogBox()
        {
            IWebElement sendVerificationEmail = driver.FindElement(By.XPath("//*[@id=\"submit-btn\"]"));
            Assert.That(sendVerificationEmail.Text == "Send Verification Email", "User was not able to login");

        }



        [When(@"I leave the username and password fields blank")]
        public void WhenILeaveTheUsernameAndPasswordFieldsBlank()
        {
            //Do not enter anything
        }


        [Then(@"I should see an error message asking to enter a valid email address and password")]
        public void ThenIShouldSeeAnErrorMessageAskingToEnterAValidEmailAddressAndPassword()
        {
            IWebElement errorMessage = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/div"));
            Assert.That(errorMessage.Text == "Please enter a valid email address", "User was not able to login");

        }

        [When(@"I enter invalid username ""([^""]*)"" and password ""([^""]*)""")]
        public void WhenIEnterInvalidUsernameAndPassword(string username, string password)
        {
            IWebElement usernameTextbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
            IWebElement passwordTextbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
            usernameTextbox.SendKeys(username);
            passwordTextbox.SendKeys(password);
        }

        [Then(@"an error message Please Enter a valid email address shows")]
        public void ThenAnErrorMessagePleaseEnterAValidEmailAddressShows()
        {
            IWebElement errorMessage = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/div"));
            Assert.That(errorMessage.Text == "Please enter a valid email address", "User was not able to login");
        
        }


        [When(@"I enter ""([^""]*)"" as the username")]
        public void WhenIEnterAsTheUsername( string Testing)
        {
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input")).SendKeys(Testing);
        }


        [When(@"I enter a valid username ""([^""]*)""")]
        public void WhenIEnterAValidUsername(string validusername)
        {
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input")).SendKeys(validusername);
        }


        [When(@"I enter ""([^""]*)"" as the password")]
        public void WhenIEnterAsThePassword(string password)
        {
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input")).SendKeys(password);
        }


        [Then(@"I should see an error message saying Password must be at least (.*) characters")]
        public void ThenIShouldSeeAnErrorMessageSayingPasswordMustBeAtLeastCharacters(int p0)
        {
            IWebElement errorMsg = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/div"));
            Assert.That(errorMsg.Text == "Password must be at least 6 characters", "User was not able to login");

        }


        [Then(@"a Send verification email dialogue box pops up")]
        public void ThenASendVerificationEmailDialogueBoxPopsUp()
        {
            IWebElement popUpBox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div/div[2]/div"));
            Assert.That(popUpBox.Text == "SEND VERIFICATION EMAIL", "User was not able to login");
        }
        
        [When(@"I select the Remember_Me checkbox")]
        public void WhenISelectTheRemember_MeCheckbox()
        {
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[3]/div/input")).Click();
        }




       [Then(@"I should remain logged in even after reopening the browser")]
        public void ThenIShouldRemainLoggedInEvenAfterReopeningTheBrowser()
        {
            // Close the browser
            driver.Quit();

            // Reinitialize the WebDriver to simulate reopening the browser
            IWebDriver newDriver = new ChromeDriver();

            newDriver.Navigate().GoToUrl("http://localhost:5000/");

            // Navigate back to the website
            newDriver.Navigate().GoToUrl("http://localhost:5000/");

            // Verify if the user is still logged in (this might involve checking a specific element)
            IWebElement isLoggedIn = newDriver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div[2]/div/span"));

            // Assert that the user remains logged in
            Assert.That(isLoggedIn.Text == "Hi Hashbah Haroon", "User was not able to login");
        }


        [When(@"I click on the Forgot your password\? link")]
        public void WhenIClickOnTheForgotYourPasswordLink()
        {
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[1]/a")).Click();
        }


        [When(@"I click on the Join link")]
        public void WhenIClickOnTheJoinLink()
        {
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[2]/a")).Click();
        }


        [Then(@"I should be redirected to the join page")]
        public void ThenIShouldBeRedirectedToTheJoinPage()
        {
            IWebElement firstNameField = driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/input"));
            Assert.That(firstNameField.Displayed, Is.True, "The Joint page is not displayed");

        }
       

    }
}
