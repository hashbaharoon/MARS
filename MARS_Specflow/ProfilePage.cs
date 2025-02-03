using NUnit.Framework;
using OpenQA.Selenium;
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
        public  void AddingNewLanguage(IWebDriver driver)
        {
            //Adding a language with level
            try
            {
                //Click on the Language Tab
                IWebElement languagesTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]"));
                languagesTab.Click();
            }
            catch (Exception)
            {
                Assert.Fail("LanguagesTab hasn't been found");
            }


            Thread.Sleep(3000);

            //Click AddNew Button 
            IWebElement addNew = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNew.Click();
            Thread.Sleep(2000);

            //Type a Language into Language Textbox 
            IWebElement languageTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
            languageTextBox.SendKeys("French");

            //Click Choose Language Level dropdown and select a level
            IWebElement languageLevelDropdown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
            languageLevelDropdown.Click();
            var selectElement = new SelectElement(languageLevelDropdown);
            selectElement.SelectByText("Conversational");

            //Click Add Button 
            IWebElement addButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            addButton.Click();

        }

        public void AddingNewLanguageWithoutLevel(IWebDriver driver)
        {
            //Adding  language without  level


            try
            {
                //Click on the Language Tab
                IWebElement languagesTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]"));
                languagesTab.Click();
            }
            catch (Exception)
            {
                Assert.Fail("LanguagesTab hasn't been found");
            }


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

        public static void EditingLanguage(IWebDriver driver)

        {
            //Editing the language

            //Click on the pencil icon
            IWebElement pencilIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
            pencilIcon.Click();

            //Edit language on the language textbox 
            IWebElement languageTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[3]/tr/td[3]/span[1]/i"));
            languageTextBox.Clear();
            languageTextBox.SendKeys("German");
            Thread.Sleep(1000);

            //Edit level on the level dropdown box
            IWebElement languageLevelDropdown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[3]/tr/td/div/div[2]/select"));
            languageLevelDropdown.Click();
            var selectElement = new SelectElement(languageLevelDropdown);
            selectElement.SelectByText("Basic");

            //Click  Update Button
            IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[3]/tr/td/div/span/input[1]"));
            updateButton.Click();

        }

        public void DeletingLanguage(IWebDriver driver) 
        {
            //Deleting the language

            //Click on the delete icon beside the language you want to delete
            IWebElement deleteIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[3]/tr/td[3]/span[2]/i"));
            deleteIcon.Click();

        }

       


      
       


    }
}
