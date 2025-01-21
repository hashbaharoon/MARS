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
        public static void AddingNewLanguage()
        {
            //Adding a language with level


            //Click on the Language Tab
            IWebElement languagesTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]");
            languagesTab.Click();

            //Click AddNew Button 
            IWebElement addNew = driver.FindElement(By.XPath(""));
            addNew.Click();

            //Type a Language into Language Textbox 
            IWebElement languageTextBox = driver.FindElement(By.XPath(""));
            languageTextBox.SendKeys("");

            //Click Choose Language Level dropdown and select a level
            IWebElement languageLevelDropdown = driver.FindElement(By.XPath(""));
            languageLevelDropdown.Click();
            var selectElement = new SelectElement(languageLevelDropdown);
            selectElement.SelectByText("Conversational")


            //Click Add Button 








        }




        public static void EditingLanguage()
        {



            
        }
       


      
       


    }
}
