# ProjectSamples
Here is a code snippet/sample of a project that I was Involved.

Project Overview
Project Mars - SkillSwap - Project Mars is a cloud-based social-media platform that allows users to trade skills with each other. I contributed as a Test Analyst in both Manual and Automation Testing. 

Technologies Used: 
.NET core - 
Selenium Webdriver - Framework: POM and Nunit - Reporting: Extent Reports - Data Driven Testing: Excel Reader - AutoIT - Docker

Learning outcomes: 
○ Utilized Page Object Model (POM) to reduce duplicate test code, resue of code and Improves readability and better Test Scripts.
○ Nunit Framework results can be run continuously and Test results are provided immediately for each test case in the Test controller. 
○ Extent Reporting is a Customized HTML reports provides a Graphical UI of the test results such as pie chart representation, test stepwise report generation, adding screenshots etc. 
○ Excel Data Reader suport to run a test case multiple times with different input and validation values.
○ AutoIT can be used in window control manipulation to automate a task which is not possible by selenium webdriver.
○ Docker: Run Project Mars Containers using Docker Compose for Test Environment, able to run the application solution locally and independantly. 

Acheivement:
I was able to improve the existing project framework. 
 ☻ The existing framework had code for every test case to generate HTML Extent Reporting which I belived it was repetition of code and not a good practice. I included the Extent reporting code in the TearDown Scenario, where it exectutes the postconditions of the test case at the end of each test in the TearDown method and flushing the report. 
 ☻ The existing framework has Screen capture/Screenshots in both pass/fail test execution. I'd prefer to capture screenshot only if a test step fails as the images will consume more memory if captured on every test step.
