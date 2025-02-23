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

        public void DeleteLanguage(string languageName)
        {
            //Deleting the language

            // Locate the row that contains the language
            IWebElement languageRow = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).FirstOrDefault(row => row.Text.Contains(languageName));

            if (languageRow != null)
            {
                // Click the delete button/icon for that skill
                languageRow.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).Click();
                Thread.Sleep(2000); // Wait for the action to be processed
            }

        }
        
        public bool IsLanguagePresent(string languageName)
        {
            return driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"))
                         .Any(language => language.Text.Equals(languageName, StringComparison.OrdinalIgnoreCase));
        }

        public void AddingNewSkill(string skill, string level)
        {
            try
            {
                //Click on the Skills Tab
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
            Thread.Sleep(2000);

            //Click Choose Skill Level dropdown and select a level
            IWebElement SkillLevelDropdown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select"));
            SkillLevelDropdown.Click();
            Thread.Sleep(2000);
            SelectElement selectLevel = new SelectElement(SkillLevelDropdown);
            selectLevel.SelectByText(level);
            Thread.Sleep(3000);

            //Click Add Button 
            IWebElement addButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
            addButton.Click();
            Thread.Sleep(2000);

        }

        public void AddingNewSkillWithoutLevel()
        {
            //Adding  skill without  level

            Thread.Sleep(3000);

            //Click on the Skills Tab
            IWebElement SkillsTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            SkillsTab.Click();

            //Click AddNew Button 
            IWebElement addNew = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNew.Click();
            Thread.Sleep(2000);

            //Type a Skill into Skill Textbox 
            IWebElement SkillTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input"));
            SkillTextBox.SendKeys("Sewing");

            //Click Add Button 
            IWebElement addButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
            addButton.Click();

        }

        public void EditingSkill(string skill)
        {
            //Click on the Skills Tab
            IWebElement SkillsTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            SkillsTab.Click();

            //Editing the skill

            //Click on the pencil icon
            IWebElement pencilIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
            pencilIcon.Click();

            //Edit skill on the skill textbox 
            IWebElement SkillTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input"));
            SkillTextBox.Click();
            SkillTextBox.Clear();
            SkillTextBox.SendKeys(skill);
            Thread.Sleep(3000);

            //Edit level on the level dropdown box
            IWebElement SkillLevelDropdown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select"));
            SkillLevelDropdown.Click();
            var selectElement = new SelectElement(SkillLevelDropdown);
            selectElement.SelectByText("Expert");
            Thread.Sleep(2000);

            //Click  Update Button
            IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
            updateButton.Click();
            Thread.Sleep(3000);

        }

        public void DeleteSkill(string skillName)
        {
            //Deleting the skill

            //Click on the Skills Tab
            IWebElement SkillsTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            SkillsTab.Click();
            Thread.Sleep(2000);

            // Locate the row that contains the skill
            IWebElement skillRow = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td[1]")).FirstOrDefault(row => row.Text.Contains(skillName));

            if (skillRow != null)
            {
                // Click the delete button/icon for that skill
                skillRow.FindElement(By.XPath(".//td[last()]/span[@class='remove']")).Click();
                Thread.Sleep(2000); // Wait for the action to be processed
            }
        }

        public bool IsSkillPresent(string skillName)
        {
            return driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td[1]"))
                         .Any(skill => skill.Text.Equals(skillName, StringComparison.OrdinalIgnoreCase));
        }
    }

    
}

