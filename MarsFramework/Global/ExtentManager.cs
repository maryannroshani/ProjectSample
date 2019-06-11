using MarsFramework.Config;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Global
{
    internal class ExtentManager
    {
        private static readonly ExtentReports _instance =
            new ExtentReports(MarsResource.ReportPath, DisplayOrder.OldestFirst)
            .LoadConfig(MarsResource.ReportXMLPath);

        static ExtentManager() { }

        private ExtentManager() { }

        public static ExtentReports Instance
        {
            get
            {
                return _instance;
            }
        }
    }

}
