using AutoItX3Lib;
using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    internal class ServiceListingPage : BasePage
    {
        
        #region Initialize Web Elements
      
        //Main category
        private IWebElement MainCategoryDropDown => driver.FindElement(By.XPath("//div[@class='listing']//select[@name='categoryId']"));

        //Category Options
        private IWebElement CategoryOpt => driver.FindElement(By.XPath("//option[contains(text(),'Select Category')]"));

        //Subcategory
        private IWebElement SubcategoryDropDown => driver.FindElement(By.XPath("//div[@class='listing']//select[@name='subcategoryId']"));

        //SubCategory Options
        private IWebElement SubCategoryOpt => driver.FindElement(By.XPath("//option[contains(text(),'Select Subcategory')]"));

        //Click Upload button
        private IWebElement UploadButton => driver.FindElement(By.XPath("//i[@class='huge plus circle icon padding-25']"));

        #endregion


      
        internal void SelectMainCategory(string MainCat)
        {
            //Test case 1: To check if user is able to Select MainCategory 
            SelectElement DropDown = new SelectElement(MainCategoryDropDown);
            DropDown.SelectByText(MainCat);
        }

        internal string GetMainCategory()
        {
            SelectElement DropDown = new SelectElement(MainCategoryDropDown);
            return DropDown.SelectedOption.Text;
        }

        internal void SelectSubCategory(string MainCat)
        {
            //Test case 2: To check if user is able to Select SubCategory 

            GlobalDefinitions.WaitUntilElementClickable(driver, 1000, "//div[@class='listing']//select[@name='subcategoryId']", "XPath");
            SelectElement DropDown = new SelectElement(SubcategoryDropDown);
            DropDown.SelectByText(MainCat);
        }

        internal string GetSubCategory()
        {
            SelectElement DropDown = new SelectElement(SubcategoryDropDown);
            return DropDown.SelectedOption.Text;
        }


        internal void UploadFile() { 
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
