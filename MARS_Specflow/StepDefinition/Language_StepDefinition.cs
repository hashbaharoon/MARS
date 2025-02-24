using Docker.DotNet.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.Log;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Reflection.Emit;
using TechTalk.SpecFlow;

namespace MARS
{
    [Binding]
    public class Language_StepDefinition
    {

        //Object Creation
        private IWebDriver driver;
        private LoginStepDefinitions _loginPage;
        private ProfilePage _profilePageObj;

        public Language_StepDefinition()
        {
            this.driver = Hooks.TestHooks.driver;  // Use SpecFlow Hooks WebDriver
            _profilePageObj = new ProfilePage(driver);
            _loginPage = new LoginStepDefinitions();
        }

        [Given(@"I logged in to MARS portal successfully")]
        public void GivenILoggedInToMARSPortalSuccessfully()
        {
            _loginPage.GivenIAmOnTheLoginPage();
            _loginPage.WhenIEnterAValidUsernameAndPassword("hashba95@gmail.com", "Hashsab@95");
            _loginPage.WhenIClickTheLoginButton();
        }


        [When(@"I navigate to profile page")]
        public void WhenINavigateToProfilePage()
        {
            _loginPage.ThenIShouldBeRedirectedToTheProfilePage();
        }

        [When(@"I add new language ""([^""]*)"" with a level ""([^""]*)""")]
        public void WhenIAddNewLanguageWithALevel(string language, string level)
        {
            _profilePageObj.AddingNewLanguage(language, level);
        }
    
        [Then(@"the language should be added successfully")]
        public void ThenTheLanguageShouldBeAddedSuccessfully()
        {
           
            IWebElement newLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
            Assert.That(newLanguage.Text == "French", "New language has been created");

        }



        [When(@"I add new language without selecting a level")]
        public void WhenIAddNewLanguageWithoutSelectingALevel()
        {
            _profilePageObj.AddingNewLanguageWithoutLevel();
        }

        [Then(@"the language is not added and an error message pops up")]
        public void ThenTheLanguageIsNotAddedAndAnErrorMessagePopsUp()
        {
            
            IWebElement errorMessage = driver.FindElement(By.XPath("/html/body/div[1]/div"));
            Assert.That(errorMessage.Text == "Please enter language and level", "User was not able to add the language");
        }

        [When(@"I update the existing language to a new language name ""([^""]*)""")]
        public void WhenIUpdateTheExistingLanguageToANewLanguageName(string language)
        {
            _profilePageObj.EditingLanguage(language);
        }


        [Then(@"the changes should be saved successfully and updated ""([^""]*)"" should be visible in the profile")]
        public void ThenTheChangesShouldBeSavedSuccessfullyAndUpdatedShouldBeVisibleInTheProfile(string language)
        {
            
            // Verify the updated language is visible in the profile
            IWebElement updatedLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]"));
            Assert.That(updatedLanguage.Text, Is.EqualTo(language), "The language was not updated successfully.");

            // Close the browser
            driver.Quit();
        }
       

        [When(@"I delete the  language ""([^""]*)""")]
        public void WhenIDeleteTheLanguage(string languageName)
        {
            _profilePageObj.DeleteLanguage(languageName);
        }



            [Then(@"the language should be removed from the profile")]
        public void ThenTheLanguageShouldBeRemovedFromTheProfile()
        {
            // Verify that the language is no longer present in the list
            Thread.Sleep(2000);
            bool isLanguageDeleted = !_profilePageObj.IsLanguagePresent("Mandarin");
            Assert.That(isLanguageDeleted, Is.True, "The language was not deleted successfully.");
            
        }


        [Then(@"a confirmation message should appear")]
        public void ThenAConfirmationMessageShouldAppear()
        {   
            // Locate and verify confirmation message
            IWebElement confirmationMessage = driver.FindElement(By.XPath("/html/body/div[1]/div")); 
            Assert.That(confirmationMessage.Text, Does.Contain("has been deleted"), "No confirmation message appeared after deleting language.");   
        }

        [Given(@"I have an existing language added to my profile")]
        public void GivenIHaveAnExistingLanguageAddedToMyProfile()
        {
            // Verify that at least one language exists in the list
            IWebElement existingLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[1]"));
            Assert.That(existingLanguage, Is.Not.Null, "No language found in the profile.");

        }

        [When(@"I try to add the same language ""([^""]*)"" with the same level ""([^""]*)""")]
        public void WhenITryToAddTheSameLanguageWithTheSameLevel(string language, string level)
        {

            _profilePageObj.AddingNewLanguage(language,level);

        }

        [When(@"an error message should appear stating that this language already exist")]
        public void WhenAnErrorMessageShouldAppearStatingThatThisLanguageAlreadyExist_()
        {
            
            IWebElement errorMsg = driver.FindElement(By.XPath("/html/body/div[1]/div"));
            Assert.That(errorMsg.Text, Does.Contain("already exist"), "Expected error message did not appear for duplicate language entry.");
        }


        [When(@"I try to add a language name ""([^""]*)"" with unsupported characters with a level ""([^""]*)""")]
        public void WhenITryToAddALanguageNameWithUnsupportedCharactersWithALevel(string unsupportedLanguage, string level)
        {
            _profilePageObj.AddingNewLanguage(unsupportedLanguage, level);
        }


        [Then(@"the system should not allow it")]
        public void ThenTheSystemShouldNotAllowIt()
        {
            int existingLanguages = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).Count;

            // Verify that the new language was not added
            int totalLanguagesAfterAttempt = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[1]")).Count;
            Assert.That(totalLanguagesAfterAttempt, Is.EqualTo(existingLanguages), "The system allowed an unsupported language.");
        }

        [Then(@"an error message should appear stating undefined")]
        public void ThenAnErrorMessageShouldAppearStatingUndefined()
        {
            //Locate ther error message element
            IWebElement error_msg =  driver.FindElement(By.XPath("/html/body/div[1]/div"));

            //Assert that the expected error message is displayed
            Assert.That(error_msg.Text == "undefined", "Error message not displayed");
        }

        [Given(@"I have already added the maximum number of allowed languages")]
        public void GivenIHaveAlreadyAddedTheMaximumNumberOfAllowedLanguages()
        {
            int existingLanguages = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).Count;

            // Add languages only if less than 4 are present
            for (int i = existingLanguages; i < 4; i++)
            {
                _profilePageObj.AddingNewLanguage($"TestLanguage{i + 1}", "Fluent");
            }
            Thread.Sleep(1000);
            // Verify that 4 languages have been added
            int totalLanguages = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).Count;
            Assert.That(totalLanguages, Is.EqualTo(4), "The maximum number of allowed languages was not added.");
        }


        [Then(@"the Add button should not be visible")]
        public void ThenTheAddButtonShouldNotBeVisible()
        {
            try
            {
                IWebElement addButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
                Assert.Fail("The 'Add' button is still visible, but it should be hidden after reaching the maximum limit.");
            }
            catch (NoSuchElementException)
            {
                // Expected behavior: The 'Add' button should not be found
                Assert.Pass("The 'Add' button is not visible as expected.");
            }
        }

    }

}
