using MarsFramework.Global;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    internal class ListingManagementPage
    {
        private IWebDriver driver;

        public ListingManagementPage()
            {
            this.driver = Global.GlobalDefinitions.Driver;
            }

        #region Initialize WebElements

        //Click on Manage Listings
        private IWebElement ManageListing => driver.FindElement(By.XPath("//a[contains(text(),'Manage Listings')]"));

        //Get Table Row
        private IWebElement TableBody => driver.FindElement(By.XPath("//div[@id='listing-management-section']//table//tbody"));

        //Click "Yes" For Delete COnfirmation
        private IWebElement RemoveConfirm => driver.FindElement(By.XPath("//button[@class='ui icon positive right labeled button']"));

        #endregion
        internal void ManageList()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");

            //Click on "Manage Listings"
            ManageListing.Click();


            //Test Case 17: To check if user is able to View "Listing table" upon clicking "Manage Listings"
            GlobalDefinitions.WaitForElement(driver, By.XPath("//h2[contains(text(),'Manage Listings')]/..//table[@class='ui striped table']"), 10);

            bool shareSkillPresent = false;
            IWebElement tableElement = GlobalDefinitions.Driver.FindElement(By.XPath("//*[@class='ui striped table']"));
            IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tr"));
            foreach (IWebElement row in tableRow)
            {
                if (row.Text.Contains(Global.GlobalDefinitions.ExcelLib.ReadData(3, "Title")) && row.Text.Contains(Global.GlobalDefinitions.ExcelLib.ReadData(3, "Description")))
                {
                    shareSkillPresent = true;
                    break;
                }
            }
            if (shareSkillPresent)
            {
                Base.test.Log(LogStatus.Pass, "Test Passed, Service Skill  is added Successfully");
            }
            else
            {
                Base.test.Log(LogStatus.Fail, "Test Failed, Service Skill is not added Successfully");
            }


            //Test Case 19: To check if user is able to "Remove" the Added 'Service Skill" (Scenario:1)
            GlobalDefinitions.WaitForElement(driver, By.XPath("//h2[contains(text(),'Manage Listings')]/..//table[@class='ui striped table']"), 10);
            DeleteService();

        }

        //Remove Method       
        public void DeleteService()
        {

            IList<IWebElement> tableRows = TableBody.FindElements(By.TagName("tr"));
            foreach (IWebElement row in tableRows)
            {
                if (row.Text.Contains(GlobalDefinitions.ExcelLib.ReadData(3, "Title")) && row.Text.Contains(GlobalDefinitions.ExcelLib.ReadData(3, "Description")))
                {
                    var deleteList = driver.FindElement(By.XPath("//td[text()='" + GlobalDefinitions.ExcelLib.ReadData(3, "Title") + "']/..//td/i[3]"));
                    deleteList.Click();
                    RemoveConfirm.Click();

                    String deleteMessage = GlobalDefinitions.ExcelLib.ReadData(3, "Title");
                    GlobalDefinitions.WaitForElement(driver, By.XPath("//div[contains(text(),'" + deleteMessage + " has been deleted')]"), 50);
                    IWebElement deleteSuccess = driver.FindElement(By.XPath("//div[contains(text(),'" + deleteMessage + " has been deleted')]"));

                    if (deleteSuccess.Text == deleteMessage + " has been deleted")
                    {
                        Base.test.Log(LogStatus.Pass, "Added Service is Removed Successfully. Test Passed");
                    }
                    break;
                }
            }
        }
    }
}
