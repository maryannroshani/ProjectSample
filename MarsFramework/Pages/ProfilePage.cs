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
    internal class ProfilePage
    {
        private IWebDriver driver;

        public ProfilePage()
        {
            this.driver = Global.GlobalDefinitions.driver;
        }

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
        #endregion

        internal void ClickProfile()
        {
            Thread.Sleep(1000);

            //Click on Edit button
            ProfileEdit.Click();
        }


        internal void SetAvailableTime(string AvailableTime) {

            //Test Case 1: To check if user can set the Available Time
            this.AvailabilityTime.Click();
            Actions action = new Actions(driver);
            action.MoveToElement(AvailabilityTimeOpt).Build().Perform();

            IList<IWebElement> AvailabilityTime = AvailabilityTimeOpt.FindElements(By.XPath("//select[@name='availabiltyType']//option"));
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

            internal string GetAvailableTime() {

            //Test Case 1: To check if user can assert Available Time

            //Click on Availability Time option
             IWebElement AvailabilityUpdate = driver.FindElement(By.XPath("//span[contains(text(),'Full Time')]/../.."));

             return AvailabilityUpdate.Text;
        }


        internal void EditProfile()
        {

        

        //Test Case 2: To check if user can select the Available Hours option

        //Click Availability dropbox
        AvailabilityHours.Click();

         //Click on Availability Hour Options
            GlobalDefinitions.waitUntilElementClickable(GlobalDefinitions.driver, 5, "//select[@name='availabiltyHour']", "XPath");
            IWebElement HoursDropBox = GlobalDefinitions.driver.FindElement(By.XPath("//select[@name='availabiltyHour']"));
            HoursDropBox.Click();

         //Click on Availability Hour Options
            IWebElement HoursOptions = GlobalDefinitions.driver.FindElement(By.XPath("//select[@name='availabiltyHour']//option"));

            switch (GlobalDefinitions.ExcelLib.ReadData(3, "Hours"))
            {

                case "As needed":
                    HoursOptions.Click();
                    break;

                   
                case "Less than 30hours a week":
                    HoursOptions.Click();
                    break;
            }
            try
            {
                IWebElement updatedMessage = GlobalDefinitions.driver.FindElement(By.XPath("//div[contains(text(), \"" + GlobalDefinitions.ExcelLib.ReadData(2, "Popup Message") + "\")]"));
                Assert.AreEqual(GlobalDefinitions.ExcelLib.ReadData(2, "Popup Message"), updatedMessage.Text);
                Base.test.Log(LogStatus.Pass, "Available Hours option is updated, Test Passed");
            }

            catch (Exception)
            {
                Base.test.Log(LogStatus.Fail, "Available Hours option is not Selected, Test Failed");
            }


            //Test Case 3: To check "Language"functionality in Profile Page 

            //Wait
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//section//a[@class='item'][contains(text(),'Profile')]"), 10);

            // Click on Profile tab 
            ProfileEdit.Click();
            AddNewLangBtn.Click();
            AddLangText.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Language"));
            ChooseLang.Click();
            IList<IWebElement> LanguagesLevel = ChooseLangOpt.FindElements(By.XPath("//select[@name='level']//option[@value]"));
            int countOne = LanguagesLevel.Count;
            for (int i = 0; i < countOne; i++)
            {
                if (LanguagesLevel[i].Text == GlobalDefinitions.ExcelLib.ReadData(2, "Level"))
                {
                    LanguagesLevel[i].Click();
                    Base.test.Log(LogStatus.Pass, "Language is added, Test Passed");
                    break;
                }

            }
            AddLang.Click();
            GlobalDefinitions.WaitForElement(driver, By.XPath("//div[contains(text(),'English has been added to your languages')]"), 3);            
            IWebElement PopupMessage = GlobalDefinitions.driver.FindElement(By.XPath("//div[contains(text(), \"" + GlobalDefinitions.ExcelLib.ReadData(2, "Language") + "" + GlobalDefinitions.ExcelLib.ReadData(5, "Popup Message") + "\")]"));
            if (PopupMessage.Text == "English has been added to your languages")
            {
                
                Base.test.Log(LogStatus.Pass, "Test Passed");
            }
            else
            {
                Base.test.Log(LogStatus.Fail, "Test Failed");
            }


        }
    }
}