using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using M360.Session;
using M360.Support;
using M360TestAutomation.ExcelReader;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace M360TestAutomation.Tests
{
    public abstract class BaseTest
    {
        public static ExcelData testData = new ExcelData();
        public static Dictionary<String, JObject> JSONObjects = new Dictionary<String, JObject>();

        public static ExtentReports extent = new ExtentReports();
        public static ExtentTest test;
        public static ExtentHtmlReporter htmlreporter = new ExtentHtmlReporter(@"C:\temp\TestRunResult" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");

        [SetUp]
        public static void SetUp()
        {
            extent.AttachReporter(htmlreporter);
            test = extent.CreateTest(TestContext.CurrentContext.Test.FullName);

            Processes.Processes.KillApplicationProcesses();
            if (TestContext.Parameters.Count > 0)
            {
                Processes.Processes.StartWinAppDriver(TestContext.Parameters.Get("winAppDriverDir"));
                JSONObjects = JSONData.ReadAllJSONFiles();

                var appiumOptions = new AppiumOptions();
                appiumOptions.AddAdditionalCapability("app", TestContext.Parameters.Get("app"));
                appiumOptions.AddAdditionalCapability("platformName", @"Windows");
                appiumOptions.AddAdditionalCapability("appWorkingDir", TestContext.Parameters.Get("appWorkingDir"));
                Session.M360Session = new WindowsDriver<WindowsElement>(new Uri(TestContext.Parameters.Get("winAppDriver")), appiumOptions);
                Session.M360Session.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 90);
            }
            else
            {
                Processes.Processes.StartWinAppDriver(ConfigurationManager.AppSettings.Get("winAppDriverDir"));
                JSONObjects = JSONData.ReadAllJSONFiles();

                var appiumOptions = new AppiumOptions();
                appiumOptions.AddAdditionalCapability("app", ConfigurationManager.AppSettings.Get("app"));
                appiumOptions.AddAdditionalCapability("platformName", @"Windows");
                appiumOptions.AddAdditionalCapability("appWorkingDir", ConfigurationManager.AppSettings.Get("appWorkingDir"));
                Session.M360Session = new WindowsDriver<WindowsElement>(new Uri(ConfigurationManager.AppSettings.Get("winAppDriver")), appiumOptions);
                Session.M360Session.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 1, 90);
            }
            if (Session.M360Session.FindElementsByName("Ok").Count > 0)
            {
                Processes.Processes.KillApplicationProcesses();
                updateJBS();
            }
        }

        private static void updateJBS()
        {
            Process process = new Process();
            process.StartInfo.FileName = ConfigurationManager.AppSettings.Get("updater");
            process.StartInfo.Arguments = ConfigurationManager.AppSettings.Get("ini");
            process.Start();
            process.WaitForExit();
            SetUp();
            Session.M360Session.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 2, 60);
        }

        [TearDown]
        public static void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;
            var errorMessage = TestContext.CurrentContext.Result.Message;

            if (status == TestStatus.Failed)
            {
                test.Log(Status.Fail, errorMessage + "\n" + stackTrace);
            }
            else
            {
                test.Log(Status.Pass, "Test Passed");
            }

            var filePath = Path.Combine(@"C:\temp", testData.testCaseId + ".jpg");

            try
            {
                Session.M360Session.SwitchTo().Window(Session.M360Session.WindowHandles[0]);
                var image = ((ITakesScreenshot)Session.M360Session).GetScreenshot();
                image.SaveAsFile(filePath);
                test.AddScreenCaptureFromPath(filePath);
            }
            catch (Exception e)
            {
                Log.Log.Message("Error saving screenshot: {0}", e.Message + "\n" + e.StackTrace);
            }
            Processes.Processes.KillApplicationProcesses();
        }

        [OneTimeTearDown]
        public static void EndReport()
        {
            //End Report
            extent.Flush();
        }
    }
}
