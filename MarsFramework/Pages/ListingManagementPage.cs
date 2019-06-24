using MarsFramework.Global;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;

namespace MarsFramework.Pages
{
    internal class ListingManagementPage : BasePage
    {
 
        #region Initialize WebElements

        //Get Table Row
        private IWebElement TableBody => driver.FindElement(By.XPath("//div[@id='listing-management-section']//table//tbody"));

        //Click "Yes" For Delete COnfirmation
        private IWebElement RemoveConfirm => driver.FindElement(By.XPath("//button[@class='ui icon positive right labeled button']"));

        #endregion

        
        internal bool CheckListAdded(string Title, string Description)
        {
            //Test Case 17: To check if user is able to View "Listing table" upon clicking "Manage Listings"
            GlobalDefinitions.WaitForElement(driver, By.XPath("//h2[contains(text(),'Manage Listings')]/..//table[@class='ui striped table']"), 10);

            bool shareSkillPresent = false;
            IWebElement tableElement = GlobalDefinitions.Driver.FindElement(By.XPath("//*[@class='ui striped table']"));
            IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tr"));
            foreach (IWebElement row in tableRow)
            {
                if (row.Text.Contains(Title) && row.Text.Contains(Description))
                {
                    shareSkillPresent = true;
                    break;
                }
            }
            return shareSkillPresent;
        }

        internal void DeleteServiceSkill(string Title, string Description, string DeleteMessage)
        {
            //Test Case 19: To check if user is able to "Remove" the Added 'Service Skill" 
            GlobalDefinitions.WaitForElement(driver, By.XPath("//h2[contains(text(),'Manage Listings')]/..//table[@class='ui striped table']"), 10);
            DeleteService(Title, Description, DeleteMessage);
        }


        //Remove Method       
        public void DeleteService(string Title, string Description,string DeleteMessage)
        {
            IList<IWebElement> tableRows = TableBody.FindElements(By.TagName("tr"));
            foreach (IWebElement row in tableRows)
            {
                if (row.Text.Contains(Title) && row.Text.Contains(Description))
                {
                    var deleteList = driver.FindElement(By.XPath("//td[text()='" + Title + "']/..//td/i[3]"));
                    deleteList.Click();
                    RemoveConfirm.Click();                  
                    GlobalDefinitions.WaitForElement(driver, By.XPath("//div[contains(text(),'" + DeleteMessage + " has been deleted')]"), 50);                    
                }
                break;
            }
        }
    }
}
