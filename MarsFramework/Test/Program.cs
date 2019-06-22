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
            public void TC_001_02_SetAvailabilityTime()
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

        }
        [TestFixture]
        class ServiceList : MarsFramework.Global.Base
        {
            [Test]
            public void TC_002_01_AddServiceSkill()
            {
                // Creates a toggle for the given test
                test = extent.StartTest("List a Service Skill");

                // Create an class and object to call the method
                ServiceListingPage service = new ServiceListingPage();
            }

        }


        [TestFixture]
        class ManageList : Global.Base
        {
            [Test]
            public void TC_003_01_ManageListings()
            {
                // Creates a toggle for the given test
                test = extent.StartTest("Manage Service List");

                // Create an class and object to call the method
                ListingManagementPage lists = new ListingManagementPage();
                lists.ManageList();
            }
        }

    }
}

