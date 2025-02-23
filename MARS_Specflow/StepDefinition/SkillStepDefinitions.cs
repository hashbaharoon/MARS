using Docker.DotNet.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.Log;
using System;
using TechTalk.SpecFlow;

namespace MARS.StepDefinition
{
    [Binding]
    public class SkillStepDefinitions
    {
        //Object Creation
        private IWebDriver driver;
        private LoginStepDefinitions _loginPage;
        private ProfilePage _profilePageObj;

        public  SkillStepDefinitions()
        {
            this.driver= Hooks.TestHooks.driver;    // Use SpecFlow Hooks WebDriver
            _loginPage= new LoginStepDefinitions();
            _profilePageObj = new ProfilePage(driver);

        }


        [When(@"I add new skill ""([^""]*)"" with a level ""([^""]*)""")]
        public void WhenIAddNewSkillWithALevel(string skill, string level)
        {
            
            _profilePageObj.AddingNewSkill(skill, level);
        }


        [Then(@"the skill should be added successfully")]
        public void ThenTheSkillShouldBeAddedSuccessfully_()
        {
            IWebElement newSkillName = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]"));
            Assert.That(newSkillName.Text == "Presentation", "New skill was not added");

        }


        [When(@"I add new skill without selecting a level")]
        public void WhenIAddNewSkillWithoutSelectingALevel()
        {
            _profilePageObj.AddingNewSkillWithoutLevel( );
        }


        [Then(@"the skill is not added and an error message pops up")]
        public void ThenTheSkillIsNotAddedAndAnErrorMessagePopsUp()
        {
            IWebElement errorMessage = driver.FindElement(By.XPath("/html/body/div[1]/div"));
            Assert.That(errorMessage.Text == "Please enter skill and experience level", "User was not able to add the skill");
        }



            [When(@"I update the existing skill to a new skill name ""([^""]*)""")]
        public void WhenIUpdateTheExistingSkillToANewSkillName(string skill)
        {
            _profilePageObj.EditingSkill(skill);
        }


        [Then(@"the changes should be saved successfully and updated skill ""([^""]*)"" should be visible in the profile")]
        public void ThenTheChangesShouldBeSavedSuccessfullyAndUpdatedSkillShouldBeVisibleInTheProfile(string skill)
        {
            Thread.Sleep(1000);
            // Verify the updated skill is visible in the profile
            IWebElement updatedSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]"));
            Assert.That(updatedSkill.Text, Is.EqualTo(skill), "The skill was not updated successfully.");


            
        }


        
        
        [When(@"I delete the skill ""([^""]*)""")]
        public void WhenIDeleteTheSkill(string skillName)
        {
            _profilePageObj.DeleteSkill(skillName);
        }



        [Then(@"the skill should be removed from the profile")]
        public void ThenTheSkillShouldBeRemovedFromTheProfile()
        {
            // Verify that the skill is no longer present in the list
           
            bool isSkillDeleted = !_profilePageObj.IsSkillPresent("Coaching");
            Assert.That(isSkillDeleted, Is.True, "The skill was not deleted successfully.");
            Thread.Sleep(2000);
        }


        [Given(@"I have an existing skill added to my profile")]
        public void GivenIHaveAnExistingSkillAddedToMyProfile()
        {
            // Verify that at least one skill exists in the list
            IWebElement existingSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]"));
            Assert.That(existingSkill, Is.Not.Null, "No skill found in the profile.");

        }

        [When(@"I try to add the same skill ""([^""]*)"" with the same level ""([^""]*)""")]
        public void WhenITryToAddTheSameSkillWithTheSameLevel(string skill, string level)
        {
            _profilePageObj.AddingNewSkill(skill, level);
        }


        [When(@"an error message should appear stating that Duplicated Data")]
        public void WhenAnErrorMessageShouldAppearStatingThatDuplicatedData()
        {
            IWebElement errorMsg = driver.FindElement(By.XPath("/html/body/div[1]/div"));
            Assert.That(errorMsg.Text, Does.Contain("Duplicated"), "Expected error message did not appear for duplicate skill entry.");
        }


        [When(@"I try to add a skill name ""([^""]*)"" with unsupported characters with a level ""([^""]*)""")]
        public void WhenITryToAddASkillNameWithUnsupportedCharactersWithALevel(string unsupportedSkill, string level)
        {
            _profilePageObj.AddingNewSkill(unsupportedSkill, level);

        }


        [Then(@"the system should not allow to save the skill")]
        public void ThenTheSystemShouldNotAllowToSaveTheSkill()
        {
            int existingSkills = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).Count;

            // Verify that the new skill was not added
            int totalSkillsAfterAttempt = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tr/td[1]")).Count;
            Assert.That(totalSkillsAfterAttempt, Is.EqualTo(existingSkills), "The system allowed an unsupported language.");
        }

    }

}
