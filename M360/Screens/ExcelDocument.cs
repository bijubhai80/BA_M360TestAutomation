using M360.Pages;
using M360.Support;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace M360.Screens
{
    public class ExcelDocument : BaseScreen
    {
        //word doc
        public string _excelContent = "Grid";
        public string _file = "FileTabButton";
        public string _saveAs = "Save As";
        public string _browse = "Browse";
        public string _save = "Save";
        public string _close = "Close";
        public string _yes = "Yes";
        public string _maximize = "Minimize-Restore";

        public void saveExcel()
        {
            if (File.Exists(@"C:\temp\excel.csv"))
            {
                File.Delete(@"C:\temp\excel.csv");
            }
            if (File.Exists(@"C:\temp\excel.xlsx"))
            {
                File.Delete(@"C:\temp\excel.xlsx");
            }
            AppiumOptions rootCapabilities = new AppiumOptions();
            rootCapabilities.AddAdditionalCapability("app", "Root");
            WindowsDriver<WindowsElement> desktopSession = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), rootCapabilities);
            var wait = new DefaultWait<WindowsDriver<WindowsElement>>(desktopSession)
            {
                Timeout = TimeSpan.FromSeconds(120),
                PollingInterval = TimeSpan.FromSeconds(1)
            };
            wait.Until(driver =>
            {
                return driver.FindElementsByName("Excel 2016 - 1 running window").Count > 0;
            });

            try
            {
                desktopSession.FindElementByAccessibilityId(_maximize).Click();
            }
            catch (Exception e)
            {
                desktopSession.FindElementByName("Excel 2016 - 1 running window").Click();
                desktopSession.FindElementByAccessibilityId(_maximize).Click();
            }
            desktopSession.FindElementByAccessibilityId(_file).Click();
            desktopSession.FindElementByName(_saveAs).Click();
            desktopSession.FindElementByName(_browse).Click();
            desktopSession.Keyboard.SendKeys(@"C:\temp\excel");
            desktopSession.FindElementByName(_save).Click();
            //if (desktopSession.FindElementByName(_yes) != null) desktopSession.FindElementByName(_yes).Click();
            wait.Until(driver => File.Exists(@"C:\temp\excel.csv") || File.Exists(@"C:\temp\excel.xlsx"));
            Processes.Processes.KillApplicationProcesses("EXCEL");


            wait.Until(driver =>
            {
                return driver.FindElementsByName("Excel 2016 - 1 running window").Count == 0;
            });
        }

        public string readExcel(string path)
        {

            var excelExportData = new ExcelData();
            if (path.Contains("xlsx"))
                excelExportData.ReadExcelData(path);
            else
                excelExportData.ReadCSVData(path);
            return excelExportData.GetAllData(0);
        }
    }
}
