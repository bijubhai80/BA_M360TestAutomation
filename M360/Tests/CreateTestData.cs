using System;
using M360.Support;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System.Configuration;
using M360.Pages;
using ElementControl;
using NUnitRetrying;
using NunitVideoRecorder;
using M360TestAutomation.Tests;
using Newtonsoft.Json.Linq;
using M360TestAutomation.ExcelReader;

namespace M360
{
    public class CreateTestData : BaseTest
    {
        [TestCase("CreateClient_EDI")]
        [TestCase("CreateClient_FBI")]
        [TestCase("CreateClient_Profile")]
        [TestCase("CreateClient_Schedule")]
        [Ignore("Test not for daily test run")]
        [Retrying(Times = 3)]
        //[Video(Name = "CreateNewClient", Mode = SaveMe.OnlyWhenFailed)]
        public static void Clients_EditDocs_NewClient(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreen = new HomeScreen();
            homeScreen.gotoClients();
            var clientSearchScreen = new ClientSearchScreen();
            clientSearchScreen.createNewClient(BaseTest.JSONObjects["Clients"][testCaseId]);
            var newClientScreen = new ClientNewClientScreen();
            newClientScreen.enterHeaderDetails(BaseTest.JSONObjects["Clients"][testCaseId]);
            newClientScreen.save();            
            var clientProfileTab = new ClientProfileScreen();
            if (testCaseId == "CreateClient_Profile")
            {
                clientProfileTab.InsertProfile(BaseTest.JSONObjects["Clients"][testCaseId]);
            }
            newClientScreen.close();
        }
    }
}
