using AutoItX3Lib;
using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System.Threading;


namespace MarsFramework.Pages
{
    internal class ServiceListingPage : BasePage
    {

        #region Initialize Web Elements

        //Main category
        private IWebElement MainCategoryDropDown => driver.FindElement(By.XPath("//div[@class='listing']//select[@name='categoryId']"));
       
        //Subcategory
        private IWebElement SubcategoryDropDown => driver.FindElement(By.XPath("//div[@class='listing']//select[@name='subcategoryId']"));

        //Click Upload button
        private IWebElement UploadButton => driver.FindElement(By.XPath("//i[@class='huge plus circle icon padding-25']"));

        //Click on Manage Listings
        private IWebElement ManageListing => driver.FindElement(By.XPath("//a[contains(text(),'Manage Listings')]"));

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


        internal void UploadFile(string FilePath)
        {
            //Test Case 2: To check if user can only upload a .ppt file using AutoIT
            UploadButton.Click();
            Thread.Sleep(1000);
            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate("Open");
            autoIt.Send(FilePath);
            Thread.Sleep(1000);
            autoIt.Send("{Enter}");

            //File type error
            GlobalDefinitions.WaitForElement(driver, By.XPath("//div[contains(text(),\"" + GlobalDefinitions.ExcelLib.ReadData(5, "Error Message Displays") + "\")]"), 2);
        }

        internal void ClickManageListingsTab()
        {
            //Click on "Manage Listings"
            ManageListing.Click();
        }
    }
}
