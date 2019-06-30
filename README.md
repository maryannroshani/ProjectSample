# ProjectSample
Here is a code snippet/sample of a project that I was Involved.

You can view this on here too : https://maryannroshani.github.io/ProjectSample/

Project Overview
Project Mars is a cloud-based social-media platform that allows users to trade skills with each other. I contributed as a Test Analyst in both Manual and Automation Testing. 

Technologies Used and Learning outcomes: 

○ .NET core in Visual Studio 2019 along with Selenium Webdriver

○ Page Object Model (POM) to reduce duplicate test code, resue of code and Improves readability and for better Test Scripts.

○ Nunit Framework as Test runner and provide immediate test reuslts for each test case in the Test controller. 

○ Extent Reporting is a Customized HTML reports provides a Graphical UI of the test results such as pie chart representation, test stepwise report generation, adding screenshots etc. 

○ Excel Data Reader support to run a test case multiple times with different input and validation values.

○ AutoIT for window control manipulation to automate a task which is not possible by selenium webdriver. Example: Upload/Download files.

○ Docker: Run Project Mars Image in the Test Environment, using Docker Compose Tool. Docker is made to run the application solution locally and independantly. 

Acheivement:

I was able to improve the existing project framework. 

⦿ In the existing framework, the code to log HTML Extent Reporting was repeated in every test case  which I believe is a repetition of code and not a good practice in programming. I included the test log code in the Tear Down Scenario, where it manages reporting for all test cases, so that you have to focus only on creating your tests as you normally do.
	
⦿ In the existing framework, the code was written to capture Screenshot for both passed and failed test cases. I prefer to capture screenshot only if a test step fails as the images will consume more memory if captured on every test step. If an assert causes a failure, it will be caught and reported to Extent Reporting. 

⦿ I also managed to extract the Test Context for failed test cases in the HTML reporting, so it is more transparent and displays exact context.  Here is an example of the HTML Extent reporting on the project I worked for. 
https://maryannroshani.github.io/TestReports/MarsReports.html
  
⦿ In the existing framework, Test Data reads in  the Page Object Classes, I believe Test Data should be in the Test Class. Pages only knows how to set and retrieve data from the web page and also verify certain things, But has no clue what data it needs to enter to the page. Test class knows what data and when it needs to send to the page in order to test something. 

⦿ Also, in the Existing Framework, for all the test cases in Page object had one test runner, if a test case fails the whole Test suite fails. In the new Framework, the test cases are independent, if one test case fails it doesn’t stop running the rest of the test cases, it will continue until all the test cases are executed.  

⦿ Refactoring Methods: 
SelectElement class in Selenium provides a convenience method for manipulating selections of options in an HTML select element. I have used this method in DropDown selections and was able to reduce the no of code. 
