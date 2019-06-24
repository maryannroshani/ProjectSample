using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        class Profile : Global.Base
        {
            [Test]
            public void TC_001_01_ClickProfile()
            {
                // Creates a toggle for the given test
                test = extent.StartTest("Click Profile Page Test");

                //Populate the Excel Sheet
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

                // Create an class and object to call the method
                ProfilePage profile = new ProfilePage();

                //Click Profile 
                profile.ClickProfile();
            }


            [Test]
            public void TC_001_02_SetAvailability()
            {
                // Creates a toggle for the given test
                test = extent.StartTest("Set Availability Time Test");

                //Populate the Excel Sheet
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

                // Create an class and object to call the method
                ProfilePage profile = new ProfilePage();

                string AvailableTime = GlobalDefinitions.ExcelLib.ReadData(2, "AvailableTime");
                profile.SetAvailableTime(AvailableTime);
                StringAssert.Contains(AvailableTime, profile.GetAvailableTime());
            }


            [Test]
            public void TC_001_03_SetHours()
            {
                // Creates a toggle for the given test
                test = extent.StartTest("Set Hours Test");

                //Populate the Excel Sheet
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

                // Create an class and object to call the method
                ProfilePage profile = new ProfilePage();

                string Hours = GlobalDefinitions.ExcelLib.ReadData(3, "Hours");
                profile.SetHours(Hours);
                string PopMessage = GlobalDefinitions.ExcelLib.ReadData(2, "Popup Message");
                StringAssert.Contains(PopMessage, profile.GetPopMessageContent());
                Assert.AreEqual(Hours, profile.GetHours());
            }


            [Test]
            public void TC_001_04_AddLanguages()
            {
                // Creates a toggle for the given test
                test = extent.StartTest("Add multiple Languages Test");

                //Populate the Excel Sheet
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Languages");

                // Create an class and object to call the method
                ProfilePage profile = new ProfilePage();

                for (int i = 2; i <= 5; i++)
                {
                    string Language = GlobalDefinitions.ExcelLib.ReadData(i, "Language");
                    string Level = GlobalDefinitions.ExcelLib.ReadData(i, "Level");
                    profile.AddLanguage(Language, Level);

                    string SuccessMsg = GlobalDefinitions.ExcelLib.ReadData(2, "Popup Message");
                    StringAssert.Contains(Language + SuccessMsg, profile.GetPopMessageContent());
                }
            }
        }


        [TestFixture]
        class ServiceList : MarsFramework.Global.Base
        {
            [Test]
            public void TC_002_01_ClickShareSkill()
            {
                // Creates a toggle for the given test
                test = extent.StartTest("Go to ShareSkill Page Test");

                // Create an class and object to call the method
                ProfilePage profile = new ProfilePage();
                profile.ClickShareSkill();
                string ExpectedTitle = "ServiceListing";
                Assert.AreEqual(ExpectedTitle, profile.GetPageTitle());
            }


            [Test]
            public void TC_002_02_SelectCategory()
            {
                // Creates a toggle for the given test
                test = extent.StartTest("Click Category Test");

                //Click ShareSkill Button 
                ProfilePage profile = new ProfilePage();
                profile.ClickShareSkill();

                //Populate the Excel Sheet
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");

                // Create an class and object to call the method
                ServiceListingPage service = new ServiceListingPage();

                string MainCat = GlobalDefinitions.ExcelLib.ReadData(2, "Category");
                service.SelectMainCategory(MainCat);
                Assert.AreEqual(MainCat, service.GetMainCategory());

                string SubCat = GlobalDefinitions.ExcelLib.ReadData(2, "Subcategory");
                service.SelectSubCategory(SubCat);
                Assert.AreEqual(SubCat, service.GetSubCategory());
            }


            [Test]
            public void TC_002_03_UploadFile()
            {
                // Creates a toggle for the given test
                test = extent.StartTest("Upload an Invalid File type Test");

                //Click ShareSkill Button 
                ProfilePage profile = new ProfilePage();
                profile.ClickShareSkill();

                //Populate the Excel Sheet
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");

                //Create an class and object to call the method
                ServiceListingPage service = new ServiceListingPage();

                string UploadFilePath = GlobalDefinitions.ExcelLib.ReadData(3, "Upload File Path");
                service.UploadFile(UploadFilePath);

                string FileErrorMessage = GlobalDefinitions.ExcelLib.ReadData(5, "Error Message Displays");
                StringAssert.Contains(FileErrorMessage, profile.GetPopMessageContent());
            }
        }


        [TestFixture]
        class ManageList : Global.Base
        {
            [Test]
            public void TC_003_01_ClickManageListingsTab()
            {
                // Creates a toggle for the given test
                test = extent.StartTest("Click Manage Listings Tab Test");

                //Create an class and object to call the method
                ServiceListingPage service = new ServiceListingPage();
                service.ClickManageListingsTab();

                //verify page Title
                BasePage page = new BasePage();
                string ExpectedTitle = "ListingManagement";
                Assert.AreEqual(ExpectedTitle, page.GetPageTitle());
            }

            [Test]
            public void TC_003_02_CheckListAdded()
            {
                // Creates a toggle for the given test
                test = extent.StartTest("Click Manage Listings Tab Test");

                //Populate the Excel Sheet
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");

                //Create an class and object to call the method
                ServiceListingPage service = new ServiceListingPage();
                service.ClickManageListingsTab();

                // Create an class and object to call the method
                ListingManagementPage list = new ListingManagementPage();

                string Title = Global.GlobalDefinitions.ExcelLib.ReadData(3, "Title");
                string Description = Global.GlobalDefinitions.ExcelLib.ReadData(3, "Description");
                list.CheckListAdded(Title, Description);
                Assert.True(list.CheckListAdded(Title, Description), "Title and Description cannot be Found");
            }

            [Test]
            public void TC_003_03_DeleteServiceSkill()
            {
                // Creates a toggle for the given test
                test = extent.StartTest("Delete a Service Skill Test");

                //Populate the Excel Sheet
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");

                //Create an class and object to call the method
                ServiceListingPage service = new ServiceListingPage();
                service.ClickManageListingsTab();

                // Create an class and object to call the method
                ListingManagementPage list = new ListingManagementPage();
                ProfilePage profile = new ProfilePage();

                string Title = Global.GlobalDefinitions.ExcelLib.ReadData(3, "Title");
                string Description = Global.GlobalDefinitions.ExcelLib.ReadData(3, "Description");
                String DeleteMessage = GlobalDefinitions.ExcelLib.ReadData(3, "Title");
                list.DeleteServiceSkill(Title, Description, DeleteMessage);
                StringAssert.Contains(DeleteMessage, profile.GetPopMessageContent());
            }
        }
    }
}

