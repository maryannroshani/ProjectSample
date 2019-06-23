using AutoItX3Lib;
using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    internal class ServiceListingPage
    {
        private IWebDriver driver;

        public ServiceListingPage()
        {
            this.driver = Global.GlobalDefinitions.Driver;
        }

        #region Initialize Web Elements
        //Main category
        private IWebElement SelectCategory => driver.FindElement(By.XPath("//div[@class='listing']//select[@name='categoryId']"));

        //Category Options
        private IWebElement CategoryOpt => driver.FindElement(By.XPath("//option[contains(text(),'Select Category')]"));

        //Subcategory
        private IWebElement SelectSubcategory => driver.FindElement(By.XPath("//div[@class='listing']//select[@name='subcategoryId']"));

        //SubCategory Options
        private IWebElement SubCategoryOpt => driver.FindElement(By.XPath("//option[contains(text(),'Select Subcategory')]"));

        //Click Upload button
        private IWebElement UploadButton => driver.FindElement(By.XPath("//i[@class='huge plus circle icon padding-25']"));

        #endregion

        internal void AddServiceSkill()
        {
            //Test case 1: To check if user is able to add a Subcategory for Skill service 
            Actions action = new Actions(GlobalDefinitions.Driver);
            action.MoveToElement(SelectCategory).Build().Perform();
            GlobalDefinitions.Wait(1000);

            Boolean isFound = false;

            IList<IWebElement> category = CategoryOpt.FindElements(By.XPath("//option[@value]"));
            int count = category.Count;
            for (int i = 0; i < count; i++)
            {
                if (category[i].Text == GlobalDefinitions.ExcelLib.ReadData(2, "Category"))
                {
                    category[i].Click();
                    Base.test.Log(LogStatus.Pass, "Programming & Tech is Selected");
                    isFound = true;
                    break;
                }
            }
            if (isFound)
            {

                GlobalDefinitions.WaitUntilElementClickable(driver, 1000, "//div[@class='listing']//select[@name='subcategoryId']", "XPath");
                SelectSubcategory.Click();
                action.MoveToElement(SelectSubcategory).Build().Perform();
                IList<IWebElement> subCategory = SubCategoryOpt.FindElements(By.XPath("//select[@name='subcategoryId']//option[@value]"));
                int subCount = subCategory.Count;
                for (int k = 0; k < subCount; k++)
                {
                    if (subCategory[k].Text == GlobalDefinitions.ExcelLib.ReadData(2, "Subcategory"))
                    {
                        subCategory[k].Click();
                        Base.test.Log(LogStatus.Pass, "QA is selected from SubCategory");
                    }
                }
            }

            //Test Case 2: To check if user can only upload a .ppt file: Using AutoIT
            UploadButton.Click();
            Thread.Sleep(1000);
            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate("Open");
            autoIt.Send(GlobalDefinitions.ExcelLib.ReadData(3, "Upload File Path"));
            Thread.Sleep(1000);
            autoIt.Send("{Enter}");

            GlobalDefinitions.WaitForElement(driver, By.XPath("//div[contains(text(),\"" + GlobalDefinitions.ExcelLib.ReadData(5, "Error Message Displays") + "\")]"), 2);

            //File type error
            IWebElement fileTypeError = driver.FindElement(By.XPath("//div[contains(text(), \"" + GlobalDefinitions.ExcelLib.ReadData(5, "Error Message Displays") + "\")]"));
            if (fileTypeError.Text == GlobalDefinitions.ExcelLib.ReadData(4, "Error Message Displays"))
            {

                Base.test.Log(LogStatus.Pass, "This File type is not allowed. Uploaded Unsuccesful.");
            }

        }
    }
}
