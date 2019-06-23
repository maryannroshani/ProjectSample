using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Global
{
   
    class BasePage
    {
        public readonly IWebDriver driver;
        public BasePage()
        {
            this.driver = Global.GlobalDefinitions.Driver;
        }
        internal string GetPageTitle()
        {
            return driver.Title;
        }
    }
}
