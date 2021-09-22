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
using M360TestAutomation.ExcelReader;
using M360TestAutomation;
using System.Linq;
using System.Collections.Generic;

namespace M360
{
    public class DispatchTests : BaseTest
    {
        [TestCase("NewPolicyTransactionAndRebuild")]
        [Retrying(Times = 3)]
        [Video(Name = "NewPolicyTransactionAndRebuild", Mode = SaveMe.OnlyWhenFailed)]
        public static void NewPolicyTransactionAndRebuild(string testCaseId)
        {
            var policyData = new PolicyData()
            {
                branch = BaseTest.JSONObjects["Policies"]["Standard"]["Office"].ToString(),
                team = "007",
                broker1Username = BaseTest.JSONObjects["Policies"]["Standard"]["Broker"].ToString(),
                client = BaseTest.JSONObjects["Policies"]["Standard"]["Client"].ToString(),
                fromDate = new DateTime(2021, 01, 01),
                toDate = new DateTime(2021, 01, 01),
                insuranceClass = BaseTest.JSONObjects["Policies"]["Standard"]["Class"].ToString(),
                locations = new[] { "SA" }.ToList(),
                marketSegment = "BR",
                maxLiability = 2000000,
                scheduleText = "Sample Text",
                situationText = "Anywhere in Australia",
                underwriters = new[] { "AIGS" }.ToList(),
            };

            var creator = new PolicyCreator();
            var success = creator.CreatePolicy(policyData, out PolicyMetaData policyMetaData, out List<string> errorList);
            Assert.IsTrue(success);
            var policyNumber = policyMetaData.PolicyNumber.ToString();

            testData.testCaseId = testCaseId;
            var homeScreen = new HomeScreen();
            homeScreen.gotoPolicies();
            var policySearchScreen = new PolicySearchScreen();

            //search policy
            var policyCreateScreen = new PolicyCreateNewScreen();
            policySearchScreen.searchPolicy(policyNumber, BaseTest.JSONObjects["Policies"]["Standard"]);
            policyCreateScreen.editPolicy();
            policyCreateScreen.billPolicy(BaseTest.JSONObjects["Policies"]["Standard"]);
            var policyPremiumScreen = new PolicyPremiumScreen();
            policyPremiumScreen.setPremium(BaseTest.JSONObjects["Policies"]["Standard"], installments: false, renew: false);
            policyCreateScreen.completePolicy(false);
            policyCreateScreen._close.ClickButton();
            policyCreateScreen.SwitchToCurrentWindow();
            policySearchScreen._close.ClickButton();
            policySearchScreen.SwitchToCurrentWindow();
             
            homeScreen.gotoMenu();
            homeScreen.gotoDispatch();
            var dispatchScreen = new DispatchScreen();
            dispatchScreen.searchPolicy(testData: BaseTest.JSONObjects["Dispatch"]["Standard"], "Outstanding", DateTime.Now.ToString("dd/MM/yyyy"));
            dispatchScreen.viewTransaction();
            policyPremiumScreen.validatePolicy(BaseTest.JSONObjects["Policies"]["Standard"]);            
        }
    }
}
