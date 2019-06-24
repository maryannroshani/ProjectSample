using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MarsFramework
{
    internal class ProfilePage : BasePage
    {

        #region  Initialize Web Elements 

        //Click on Profile button
        private IWebElement ProfileEdit => driver.FindElement(By.XPath("//section//a[contains(text(),'Profile')]"));

        //Click on Availability Time write icon
        private IWebElement AvailabilityTime => driver.FindElement(By.XPath("//div[@class='item']//strong[contains(text(),'Availability')]//..//..//i[contains(@class,'write icon')]"));

        //Click on Availability Time option
        private IWebElement AvailabilityTimeOpt => driver.FindElement(By.XPath("//select[@name='availabiltyType']"));

        //Click on Availability Hour dropdown
        private IWebElement AvailabilityHours => driver.FindElement(By.XPath("//div[@class='item']//strong[contains(text(),'Hours')]//..//..//i[contains(@class,'write icon')]"));

        //Click on Add new to add new Language
        private IWebElement AddNewLangBtn => driver.FindElement(By.XPath("//div[contains(text(),'Add New')]"));

        //Enter the Language on text box
        private IWebElement AddLangText => driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));

        //EChoose Languge Level Box
        private IWebElement ChooseLang => driver.FindElement(By.XPath("//select[@name='level']"));

        //Enter the Language on text box      
        private IWebElement ChooseLangOpt => driver.FindElement(By.XPath("//option[@value]"));

        //Add Language      
        private IWebElement AddLang => driver.FindElement(By.XPath("//input[@class='ui teal button']"));

        //ShareSkill Tab
        private IWebElement ShareSkillBtn => driver.FindElement(By.XPath("//a[contains(text(),'Share Skill')]"));

        #endregion

        internal void ClickProfile()
        {
            GlobalDefinitions.WaitForElement(driver, By.XPath("//section//a[contains(text(),'Profile')]"), 10);
            //Click on Edit button
            ProfileEdit.Click();
        }


        internal void SetAvailableTime(string AvailableTime)
        {

            //Test Case 1: To check if user can set the Available Time
            this.AvailabilityTime.Click();
            AvailabilityTimeOpt.Click();

            IList<IWebElement> AvailabilityTime = AvailabilityTimeOpt.FindElements(By.XPath("//select[@name='availabiltyType']//option[not(@hidden)]"));
            int count = AvailabilityTime.Count;
            for (int i = 0; i < count; i++)
            {
                if (AvailabilityTime[i].Text == AvailableTime)
                {
                    AvailabilityTime[i].Click();
                    break;
                }
            }
        }

        internal string GetAvailableTime()
        {
            //To assert Available Time

            //Click on Availability Time option
            IWebElement AvailabilityUpdate = driver.FindElement(By.XPath("//span[contains(text(),'Full Time')]/../.."));
            return AvailabilityUpdate.Text;
        }


        internal void SetHours(string Hours)
        {
            //Test Case 2: To check if user can set Hours 

            //Click Availability Edit box
            AvailabilityHours.Click();

            //Click on Availability Hour DropBox
            GlobalDefinitions.WaitUntilElementClickable(GlobalDefinitions.Driver, 5, "//select[@name='availabiltyHour']", "XPath");
            IWebElement HoursDropBox = GlobalDefinitions.Driver.FindElement(By.XPath("//select[@name='availabiltyHour']"));
            HoursDropBox.Click();

            //Click on Availability Hour Options
            IList<IWebElement> HoursOptions = HoursDropBox.FindElements(By.XPath("//select[@name='availabiltyHour']//option[not(@hidden)]"));
            int count = HoursOptions.Count;
            for (int i = 0; i < count; i++)
            {
                if (HoursOptions[i].Text == Hours)
                {
                    HoursOptions[i].Click();
                    break;
                }
            }
        }

        internal string GetHours()
        {
            //To check if Hours is changed
            IWebElement updatedMessage = GlobalDefinitions.Driver.FindElement(By.XPath("//strong[contains(text(),'Hours')]/../../div"));
            return updatedMessage.Text;
        }

        internal string GetPopMessageContent()
        {
            //To check pop up message 
            GlobalDefinitions.WaitForElement(driver, By.XPath("//div[contains(@class,'ns-box')]"), 5);
            return driver.FindElement(By.XPath("//div[contains(@class,'ns-box')]")).Text;
        }


        internal void AddLanguage(string Languages, string Level)
        {
            //Test Case 3: To check if user can add a "Language"

            //Wait
            GlobalDefinitions.WaitForElement(GlobalDefinitions.Driver, By.XPath("//section//a[contains(text(),'Profile')]"), 10);

            //Click on Profile tab 
            ProfileEdit.Click();
            AddNewLangBtn.Click();
            GlobalDefinitions.WaitForElement(driver, By.XPath("//input[@placeholder='Add Language']"), 10);
            AddLangText.SendKeys(Languages);
            ChooseLang.Click();
            IList<IWebElement> LanguagesLevel = ChooseLangOpt.FindElements(By.XPath("//select[@name='level']//option[@value]"));
            int count = LanguagesLevel.Count;
            for (int i = 0; i < count; i++)
            {
                if (LanguagesLevel[i].Text == Level)
                {
                    LanguagesLevel[i].Click();
                    break;
                }

            }
            AddLang.Click();
        }

        internal void ClickShareSkill()
        {
            //To check if user is able to click ShareSkill
            ShareSkillBtn.Click();
        }
    }
}
