using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class SignIn
    {
        private IWebDriver driver;

        public SignIn()
        {
            this.driver = Global.GlobalDefinitions.Driver;
        }

        #region  Initialize Web Elements 
        //Finding the Sign Link
        private IWebElement SignIntab => driver.FindElement(By.XPath("//a[contains(text(),'Sign In')]"));


        // Finding the Email Field
        private IWebElement Email => driver.FindElement(By.XPath("//input[@placeholder='Email address']"));

        //Finding the Password Field

        private IWebElement Password => driver.FindElement(By.XPath("//input[@placeholder='Password']"));

        //Finding the Login Button

        private IWebElement LoginBtn => driver.FindElement(By.XPath("//button[contains(text(),'Login')]"));

        #endregion

        internal void LoginSteps()
        {
            //extent Reports
            Base.test = Base.extent.StartTest("Login Test");

            //Populate the Excel sheet
            Global.GlobalDefinitions.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "SignIn");

            //Navigate to the Url
            Global.GlobalDefinitions.Driver.Navigate().GoToUrl(Global.GlobalDefinitions.ExcelLib.ReadData(2,"Url"));

            //Click on Sign In tab
            SignIntab.Click();
            Thread.Sleep(500);

            //Enter the data in Username textbox
            Email.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2,"Username"));
            Thread.Sleep(500);

            //Enter the password 
            Password.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            //Click on Login button
            LoginBtn.Click();
            Thread.Sleep(1500);

            GlobalDefinitions.WaitForElement(driver, By.XPath("//a[contains(text(),'Mars Logo')]"), 5);

            string text = Global.GlobalDefinitions.Driver.FindElement(By.XPath("//a[contains(text(),'Mars Logo')]")).Text;

            if (text == "Mars Logo")
            {
                Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Login Successful");
            }
            else
                Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Login Unsuccessful");

        }
    }
}