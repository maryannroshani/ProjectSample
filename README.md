# ProjectSamples
Here is a code snippet/sample of a project that I was Involved.

Project Overview
Project Mars - SkillSwap - Project Mars is a cloud-based social-media platform that allows users to trade skills with each other. I contributed as a Test Analyst in both Manual and Automation Testing. 


Technologies Used and Learning outcomes: 

○ .NET core in Visual Studio 2019 along with Selenium Webdriver

○ Page Object Model (POM) to reduce duplicate test code, resue of code and Improves readability and better Test Scripts.

○ Nunit Framework as Test runner and provide immediate test reuslts for each test case in the Test controller. 

○ Extent Reporting is a Customized HTML reports provides a Graphical UI of the test results such as pie chart representation, test stepwise report generation, adding screenshots etc. 

○ Excel Data Reader support to run a test case multiple times with different input and validation values.

○ AutoIT for window control manipulation to automate a task which is not possible by selenium webdriver. Example: Upload/Download files.

○ Docker: Run Project Mars Image in the Test Environment, using Docker Compose Tool. Docker is made to run the application solution locally and independantly. 

Acheivement:

I was able to improve the existing project framework. 

 ☻ The existing framework with Nunit had code for every test case to generate HTML Extent Reporting which I belived it was repetition of code and not a good practice. I included the Extent reporting code in the TearDown Scenario, where it manages automatic failure messages so you only have to create your tests as you normally do. If an assert causes a failure, it will be caught and reported to Extent here. http://extentreports.com/docs/versions/2/net/ 
	
☻ The existing framework had Screen capture/Screenshot in both pass/fail test execution. It would be prefer to capture screenshot only if a test step fails as the images will consume more memory if captured on every test step.

☻ The existing framework had Excel data reading in Page Object Classes, I belive Test Reports and Data should be in the Test Controller/Classes, Pages only knows how to set and retrieve data from the web page and also verify certain things, But has no clue what data it needs to enter to the page. Test class knows what data and when it needs to send to the page in order to test something. The test classes themselves pull this test data and pass it into the Page Objects (when needed), or the Page Object methods for validation purposes.So basically Test class knows how to test. Page class knows only how to enter data or read data from a particular web page as instructed or passed by the test class. 

