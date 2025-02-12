using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.Log;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARS
{
    public class ProfilePage
    {
        IWebDriver driver;

        public ProfilePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void AddingNewLanguage(string language, string level)
        {

            //Click AddNew Button 
            IWebElement AddNew = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            AddNew.Click();
            Thread.Sleep(2000);

            //Type a Language into Language Textbox 
            IWebElement languageTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
            languageTextBox.SendKeys(language);

            //Click Choose Language Level dropdown and select a level
            IWebElement languageLevelDropdown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
            languageLevelDropdown.Click();
            SelectElement selectLevel = new SelectElement(languageLevelDropdown);
            selectLevel.SelectByText(level);

            //Click Add Button 
            IWebElement addButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            addButton.Click();
            Thread.Sleep(2000);


        }

        public void AddingNewLanguageWithoutLevel()
        {
            //Adding  language without  level

            Thread.Sleep(3000);

            //Click AddNew Button 
            IWebElement addNew = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNew.Click();
            Thread.Sleep(2000);

            //Type a Language into Language Textbox 
            IWebElement languageTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
            languageTextBox.SendKeys("Spanish");

            //Click Add Button 
            IWebElement addButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            addButton.Click();

        }

        public void EditingLanguage(string language)
        {
            //Editing the language

            //Click on the pencil icon
            IWebElement pencilIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]/i"));
            pencilIcon.Click();

            //Edit language on the language textbox 
            IWebElement languageTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/div[1]/input"));
            languageTextBox.Click();
            languageTextBox.Clear();
            languageTextBox.SendKeys(language);
            Thread.Sleep(3000);

            //Edit level on the level dropdown box
            IWebElement languageLevelDropdown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/div[2]/select"));
            languageLevelDropdown.Click();
            var selectElement = new SelectElement(languageLevelDropdown);
            selectElement.SelectByText("Basic");
            Thread.Sleep(2000);

            //Click  Update Button
            IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]"));
            updateButton.Click();
            Thread.Sleep(2000);

        }

        public void DeletingLanguage()
        {
            //Deleting the language

            //Click on the delete icon beside the language you want to delete
            IWebElement deleteIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]/i"));
            Thread.Sleep(2000);

        }

        public void AddingNewSkill(string skill, string level)
        {
            try
            {
                //Click on the Language Tab
                IWebElement SkillsTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
                SkillsTab.Click();
            }
            catch (Exception)
            {
                Assert.Fail("Skills Tab hasn't been found");
            }


            //Click AddNew Button 
            IWebElement AddNew = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            AddNew.Click();
            Thread.Sleep(2000);

            //Type a skill into Skill Textbox 
            IWebElement SkillTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input"));
            SkillTextBox.SendKeys(skill);

            //Click Choose Skill Level dropdown and select a level
            IWebElement SkillLevelDropdown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select"));
            SkillLevelDropdown.Click();
            SelectElement selectLevel = new SelectElement(SkillLevelDropdown);
            selectLevel.SelectByText(level);

            //Click Add Button 
            IWebElement addButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
            addButton.Click();
            Thread.Sleep(2000);

        }

        public void AddingNewSkillWithoutLevel()
        {
            //Adding  skill without  level

            Thread.Sleep(3000);

            //Click AddNew Button 
            IWebElement addNew = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNew.Click();
            Thread.Sleep(2000);

            //Type a Skill into Skill Textbox 
            IWebElement SkillTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input"));
            SkillTextBox.SendKeys("Spanish");

            //Click Add Button 
            IWebElement addButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
            addButton.Click();

        }

        public void EditingSkill(string skill)
        {
            //Editing the skill

            //Click on the pencil icon
            IWebElement pencilIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
            pencilIcon.Click();

            //Edit skill on the skill textbox 
            IWebElement SkillTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input"));
            SkillTextBox.Click();
            SkillTextBox.Clear();
            SkillTextBox.SendKeys(skill);
            Thread.Sleep(3000);

            //Edit level on the level dropdown box
            IWebElement SkillLevelDropdown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select"));
            SkillLevelDropdown.Click();
            var selectElement = new SelectElement(SkillLevelDropdown);
            selectElement.SelectByText("Expert");
            Thread.Sleep(2000);

            //Click  Update Button
            IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
            updateButton.Click();
            Thread.Sleep(2000);

        }

        public void DeletingSkill()
        {
            //Deleting the skill

            //Click on the delete icon beside the skill you want to delete
            IWebElement deleteIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
            Thread.Sleep(2000);

        }

    }
}

