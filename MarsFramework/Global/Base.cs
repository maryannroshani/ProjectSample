using MarsFramework.Config;
using MarsFramework.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework.Global
{
    class Base
    {
        #region To access Path from resource file

        public static int Browser = Int32.Parse(MarsResource.Browser);
        public static String ExcelPath = MarsResource.ExcelPath;
        public static string ScreenshotPath = MarsResource.ScreenShotPath;
        public static string ReportPath = MarsResource.ReportPath;
        #endregion

        #region reports
        public static ExtentTest test;
        public static ExtentReports extent;
        #endregion

        #region setup and tear down

        [OneTimeSetUp]
        public void FixtureInit()
        {
            extent = ExtentManager.Instance;
        }


        [SetUp]
        public void Inititalize()
        {

            // advisasble to read this documentation before proceeding http://extentreports.relevantcodes.com/net/
            switch (Browser)
            {

                case 1:
                    GlobalDefinitions.Driver = new FirefoxDriver();
                    break;
                case 2:
                    GlobalDefinitions.Driver = new ChromeDriver();
                    GlobalDefinitions.Driver.Manage().Window.Maximize();
                    break;

            }

            if (MarsResource.IsLogin == "true")
            {
                SignIn loginobj = new SignIn();
                loginobj.LoginSteps();
            }
            else
            {
                SignUp obj = new SignUp();
                obj.register();
            }
            
        }


        [TearDown]
        public void TearDown()
        {
            // Screenshot
            String img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.Driver, "Report");
            test.Log(LogStatus.Info, "Snapshot below: " + test.AddScreenCapture(img));

            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                                                                    ? ""
                                                                    : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.StackTrace);
            LogStatus logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = LogStatus.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = LogStatus.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = LogStatus.Skip;
                    break;
                default:
                    logstatus = LogStatus.Pass;
                    break;
            }

            if (!string.IsNullOrEmpty(TestContext.CurrentContext.Result.Message)) {
                test.Log(logstatus, TestContext.CurrentContext.Result.Message);
            }

            test.Log(logstatus, "Test ended with " + logstatus + stacktrace);

            extent.EndTest(test);
            extent.Flush();

            // Close the driver :)            
            GlobalDefinitions.Driver.Close();
        }
        #endregion

    }
}