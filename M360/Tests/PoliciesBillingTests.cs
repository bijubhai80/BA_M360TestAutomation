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
using M360.Screens;
using Newtonsoft.Json.Linq;
using System.Linq;
using M360TestAutomation;
using System.Collections.Generic;

namespace M360
{
    public class PolicyBillingTests : BaseTest
    {
        [TestCase("IncompleteEndorsement")]
        [Retrying(Times = 3)]
        [Video(Name = "Profile", Mode = SaveMe.OnlyWhenFailed)]
        public static void IncompleteEndorsement(string testCaseId)
        {
            var policyData = new PolicyData()
            {
                branch = BaseTest.JSONObjects["Policies"]["Standard"]["Office"].ToString(),
                team = "007",
                broker1Username = BaseTest.JSONObjects["Policies"]["Standard"]["Broker"].ToString(),
                client = BaseTest.JSONObjects["Policies"]["Standard"]["Client"].ToString(),
                fromDate = new DateTime(2021, 01, 01),
                toDate = new DateTime(2021, 01, 01),
                insuranceClass = BaseTest.JSONObjects["Policies"]["Standard"]["InsuranceClass"].ToString(),
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

            var testData1 = JObject.Parse(BaseTest.JSONObjects["Policies"]["Standard"].ToString());
            var testData2 = JObject.Parse(BaseTest.JSONObjects["Dispatch"]["Standard"].ToString());
            testData1.Merge(testData2);

            policyCreateScreen.incompleteEndrosement(testData1);
            policyCreateScreen.closePolicyScreen();
            policySearchScreen._close.ClickButton();
            policySearchScreen.SwitchToCurrentWindow();
            policySearchScreen._close.ClickButton();
            policySearchScreen.SwitchToCurrentWindow();

            homeScreen.gotoMenu();
            homeScreen.gotoDispatch();
            var dispatchScreen = new DispatchScreen();
            dispatchScreen.searchPolicy(testData: testData1, "Outstanding", date: DateTime.Now.ToString("dd/MM/yyyy"), selectAll: true);
            dispatchScreen.dispatchInvoices();
        }

        [TestCase("PartialCancellation")]
        [Retrying(Times = 3)]
        [Video(Name = "Profile", Mode = SaveMe.OnlyWhenFailed)]
        public static void PartialCancellation(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreen = new HomeScreen();
            homeScreen.gotoPolicies();
            var policySearchScreen = new PolicySearchScreen();
            policySearchScreen.createNewPolicy(BaseTest.JSONObjects["Policies"]["Standard"]);
            var policyCreateScreen = new PolicyCreateNewScreen();
            policyCreateScreen.createPolicy(BaseTest.JSONObjects["Policies"]["Standard"]);
            policyCreateScreen.cancelPolicy(BaseTest.JSONObjects["Policies"]["Standard"], false, "Partial cancel");                        
        }

        [TestCase("PolicyWithMultipleClients")]
        [Retrying(Times = 3)]
        [Video(Name = "Profile", Mode = SaveMe.OnlyWhenFailed)]
        public static void PolicyWithMultipleClients(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreen = new HomeScreen();
            homeScreen.gotoPolicies();
            var policySearchScreen = new PolicySearchScreen();
            var testData1 = JObject.Parse(BaseTest.JSONObjects["Policies"]["Standard"].ToString());
            var testData2 = JObject.Parse(BaseTest.JSONObjects["Policies"]["MultipleClients"].ToString());
            testData1.Merge(testData2);
            policySearchScreen.createNewPolicy(testData1);
            var policyCreateScreen = new PolicyCreateNewScreen();
            policyCreateScreen.createPolicy(testData1, complete: false);
            var premiumScreen = new PolicyPremiumScreen();
            policyCreateScreen.addMultipleClients(testData1);
            policyCreateScreen.addMultipleAgents(testData1);
            policyCreateScreen.completePolicy(edi: false);            
        }

        [TestCase("PostingAnalysis")]
        [Retrying(Times = 3)]
        [Video(Name = "Profile", Mode = SaveMe.OnlyWhenFailed)]
        public static void PostingAnalysis(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreen = new HomeScreen();
            homeScreen.gotoPolicies();
            var policySearchScreen = new PolicySearchScreen();
            policySearchScreen.createNewPolicy(BaseTest.JSONObjects["Policies"]["Standard"]);
            var policyCreateScreen = new PolicyCreateNewScreen();
            policyCreateScreen.createPolicy(BaseTest.JSONObjects["Policies"]["Standard"], complete:false);
           
            var policyPostingAnalysisScreen = new PolicyPostingAnalysisScreen();
            policyPostingAnalysisScreen.gotoPostingAnalysis();
            policyPostingAnalysisScreen.export();                        

        }


        [TestCase("LapsePolicy")]
        [Retrying(Times = 3)]
        [Video(Name = "LapsePolicy", Mode = SaveMe.OnlyWhenFailed)]
        public static void LapsePolicy(string testCaseId)
        {
            var policyData = new PolicyData()
            {
                branch = BaseTest.JSONObjects["Policies"]["Standard"]["Office"].ToString(),
                team = "007",
                broker1Username = BaseTest.JSONObjects["Policies"]["Standard"]["Broker"].ToString(),
                client = BaseTest.JSONObjects["Policies"]["Standard"]["Client"].ToString(),
                fromDate = new DateTime(2021, 01, 01),
                toDate = new DateTime(2021, 01, 01),
                insuranceClass = BaseTest.JSONObjects["Policies"]["Standard"]["InsuranceClass"].ToString(),
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

            policyCreateScreen.lapsePolicy();
            policyCreateScreen.closePolicyScreen();
            policySearchScreen._close.ClickButton();
            policySearchScreen.SwitchToCurrentWindow();            

            homeScreen.gotoMenu();
            homeScreen.gotoDispatch();

            var testData1 = JObject.Parse(BaseTest.JSONObjects["Policies"]["Standard"].ToString());
            var testData2 = JObject.Parse(BaseTest.JSONObjects["Dispatch"]["Standard"].ToString());
            testData1.Merge(testData2);

            var dispathScreen = new DispatchScreen();
            dispathScreen.searchPolicy(testData: testData1, "Outstanding", date: DateTime.Now.ToString("dd/MM/yyyy"), selectAll: true);
            dispathScreen.dispatchInvoices();
        }

        [TestCase("Renew_ChangeUnderwriter")]
        [Retrying(Times = 3)]
        [Video(Name = "Renew_ChangeUnderwriter", Mode = SaveMe.OnlyWhenFailed)]
        public static void Renew_ChangeUnderwriter(string testCaseId)
        {
            var policyData = new PolicyData()
            {
                branch = BaseTest.JSONObjects["Policies"]["Standard"]["Office"].ToString(),
                team = "007",
                broker1Username = BaseTest.JSONObjects["Policies"]["Standard"]["Broker"].ToString(),
                client = BaseTest.JSONObjects["Policies"]["Standard"]["Client"].ToString(),
                fromDate = new DateTime(2021, 01, 01),
                toDate = new DateTime(2021, 01, 01),
                insuranceClass = BaseTest.JSONObjects["Policies"]["Standard"]["InsuranceClass"].ToString(),
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
            var testData1 = JObject.Parse(BaseTest.JSONObjects["Policies"]["Standard"].ToString());
            var testData2 = JObject.Parse(BaseTest.JSONObjects["Policies"]["ChangedUnderwriter"].ToString());
            testData1.Merge(testData2);

            var homeScreen = new HomeScreen();
            homeScreen.gotoPolicies();
            var policySearchScreen = new PolicySearchScreen();

            //search policy
            var policyCreateScreen = new PolicyCreateNewScreen();
            policySearchScreen.searchPolicy(policyNumber, testData1);
            policyCreateScreen.editPolicy();
            policyCreateScreen.billPolicy(testData1);
            var policyPremiumScreen = new PolicyPremiumScreen();
            policyPremiumScreen.setPremium(testData1, installments: false, renew: false);
            policyCreateScreen.completePolicy(false);

            policyCreateScreen.renewPolicy(testData1, modifyUnderWriter: true);
            policyCreateScreen.closePolicyScreen();
            policySearchScreen._close.ClickButton();
            policySearchScreen.SwitchToCurrentWindow();           

            homeScreen.gotoMenu();
            homeScreen.gotoDispatch();
            var dispathScreen = new DispatchScreen();
            dispathScreen.searchPolicy(testData: BaseTest.JSONObjects["Dispatch"]["Standard"], "Outstanding", date:DateTime.Now.ToString("dd/MM/yyyy"));
            dispathScreen.viewClosing();
            dispathScreen.ensureLapse();            
        }

        [TestCase("Renew_DeactivateUnderwriter")]
        [Retrying(Times = 3)]
        [Video(Name = "Renew_DeactivateUnderwriter", Mode = SaveMe.OnlyWhenFailed)]
        public static void Renew_DeactivateUnderwriter(string testCaseId)
        {
            var policyData = new PolicyData()
            {
                branch = BaseTest.JSONObjects["Policies"]["DeactivatedUnderwriter"]["Office"].ToString(),
                team = "007",
                broker1Username = BaseTest.JSONObjects["Policies"]["DeactivatedUnderwriter"]["Broker"].ToString(),
                client = BaseTest.JSONObjects["Policies"]["DeactivatedUnderwriter"]["Client"].ToString(),
                fromDate = new DateTime(2021, 01, 01),
                toDate = new DateTime(2021, 01, 01),
                insuranceClass = BaseTest.JSONObjects["Policies"]["DeactivatedUnderwriter"]["InsuranceClass"].ToString(),
                locations = new[] { "SA" }.ToList(),
                marketSegment = "BR",
                maxLiability = 2000000,
                scheduleText = "Sample Text",
                situationText = "Anywhere in Australia",
                underwriters = new[] { "XLIMGA" }.ToList(),
            };

            var creator = new PolicyCreator();
            var success = creator.CreatePolicy(policyData, out PolicyMetaData policyMetaData, out List<string> errorList);
            Assert.IsTrue(success);
            var policyNumber = policyMetaData.PolicyNumber.ToString();
            var homeScreen = new HomeScreen();
            var policySearchScreen = new PolicySearchScreen();
            var policyCreateScreen = new PolicyCreateNewScreen();
            homeScreen.gotoPolicies();
            policySearchScreen.searchPolicy(policyNumber, BaseTest.JSONObjects["Policies"]["DeactivatedUnderwriter"]);
            policyCreateScreen.editPolicy();
            policyCreateScreen.billPolicy(BaseTest.JSONObjects["Policies"]["DeactivatedUnderwriter"]);
            var policyPremiumScreen = new PolicyPremiumScreen();
            policyPremiumScreen.setPremium(BaseTest.JSONObjects["Policies"]["DeactivatedUnderwriter"], installments: false, renew: false);
            policyCreateScreen.completePolicy(false);

            policyCreateScreen.renewPolicy(BaseTest.JSONObjects["Policies"]["DeactivatedUnderwriter"], incomplete: true);
            policyCreateScreen.closePolicyScreen();
            policySearchScreen._close.ClickButton();
            policySearchScreen.SwitchToCurrentWindow();

            homeScreen.gotoMenu();
            homeScreen.gotoUtilities();
            homeScreen.gotoUnderWritersAnBrokers();
            var brokerUWScreen = new BrokersUnderWritersScreen();
            brokerUWScreen.toggleUW(BaseTest.JSONObjects["Policies"]["DeactivatedUnderwriter"]);
            homeScreen.gotoPolicies();
            
            policySearchScreen.searchPolicy(policyNumber, BaseTest.JSONObjects["Policies"]["DeactivatedUnderwriter"]);
            policyCreateScreen.renewPolicy(BaseTest.JSONObjects["Policies"]["DeactivatedUnderwriter"], billPolicyCondition: false);
            var policyUWScreen = new PolicyUnderWriterScreen();
            policyUWScreen.validateInactiveUW();

            policyCreateScreen.closePolicyScreen();
            policySearchScreen._close.ClickButton();
            policySearchScreen.SwitchToCurrentWindow();
            homeScreen.gotoMenu();
            homeScreen.gotoUtilities();
            homeScreen.gotoUnderWritersAnBrokers();
            brokerUWScreen.toggleUW(BaseTest.JSONObjects["Policies"]["DeactivatedUnderwriter"]);
        }
    }
}
