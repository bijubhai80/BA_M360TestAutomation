using M360.Pages;
using M360TestAutomation;
using M360TestAutomation.Tests;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NUnitRetrying;
using NunitVideoRecorder;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace M360
{
    public class PoliciesTests : BaseTest
    {
        [TestCase("Search")]
        [Retrying(Times = 3)]
        [Video(Name = "Search", Mode = SaveMe.OnlyWhenFailed)]
        public static void Search(string testCaseId)
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

            //get policy number from new screen and make sure it is same as search policy number
            Assert.IsTrue(policyCreateScreen._policyNumber.Text.TrimStart(new Char[] { '0' }) == policyNumber);
        }

        [TestCase("CreatePolicy")]
        [Retrying(Times = 3)]
        [Video(Name = "CreatePolicy", Mode = SaveMe.OnlyWhenFailed)]
        public void CreatePolicy(string testCaseId)
        {
            var main = new HomeScreen();
            var policySearchForm = new PolicySearchScreen();
            var policyMaintenanceForm = new PolicyCreateNewScreen();
            var clientSearchForm = new ClientSearchScreen();

            main.gotoPolicies();
            policySearchForm.createNewPolicy(JSONObjects["Policies"]["CreatePolicy"]);
            policyMaintenanceForm.checkNewPolicyMode();
            policyMaintenanceForm.clientSearch();
            clientSearchForm.searchClient(new[] { "ClientCode" }, JSONObjects["Policies"]["CreatePolicy"], false);
            policyMaintenanceForm.setClass(JSONObjects["Policies"]["CreatePolicy"]);
            policyMaintenanceForm.setSituation(JSONObjects["Policies"]["CreatePolicy"]);
            policyMaintenanceForm.setMaxLimit(JSONObjects["Policies"]["CreatePolicy"]);
            policyMaintenanceForm.setMMARiskID(JSONObjects["Policies"]["CreatePolicy"]);
            policyMaintenanceForm.setFrom();
            policyMaintenanceForm.uncheckRenewable();
            policyMaintenanceForm.addUnderwriter(JSONObjects["Policies"]["CreatePolicy"]);
            //CREATE in PolicySearchScreen or use from PolicyUnderWriterScreen
            //policyMaintenanceForm.deleteUnderwriter(JSONObjects["Policies"]["CreatePolicy"]);
            //policyMaintenanceForm.addUnderwriter(JSONObjects["Policies"]["CreatePolicy"]);
            policyMaintenanceForm.insertSchedule(JSONObjects["Policies"]["CreatePolicy"]);
            policyMaintenanceForm.setComments(JSONObjects["Policies"]["CreatePolicy"]);
            policyMaintenanceForm.closePolicyScreen();
            //main.openfromMRU();
            //policyMaintenanceForm.documentsTab.isVisible();
            //policyMaintenanceForm.transactionsTab.isVisible();
        }

        [TestCase("EditPolicy")]
        [Retrying(Times = 3)]
        [Video(Name = "EditPolicy", Mode = SaveMe.OnlyWhenFailed)]
        public static void EditPolicy(string testCaseId)
        {
            var main = new HomeScreen();
            var policySearchForm = new PolicySearchScreen();
            var policyMaintenanceForm = new PolicyCreateNewScreen();
            var policyBillingForm = new PolicyPremiumScreen();
            string policyNumber = "";

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
            policyNumber = policyMetaData.PolicyNumber.ToString();

            main.gotoPolicies();
            policySearchForm.searchPolicy(policyNumber, BaseTest.JSONObjects["Policies"]["Standard"]);
            policyMaintenanceForm.isReadOnly();
            policyMaintenanceForm.edit();
            policyMaintenanceForm.saveAsQuote();
            policyMaintenanceForm.gotoPolicyBillingForm();
            policyBillingForm.setPremium(JSONObjects["Policies"]["Standard"], false);
            policyBillingForm.save();
            policyBillingForm.close();
            policyMaintenanceForm.saveQuoteAsNew();
            policyMaintenanceForm.isIncomplete();
            policyMaintenanceForm.save();
            policyMaintenanceForm.closePolicyScreen();
            policySearchForm.close();
        }

        [TestCase("CreateQuoteAndNewEDIPolicy")]
        [Retrying(Times = 0)]
        [Video(Name = "CreateQuoteAndNewEDIPolicy", Mode = SaveMe.OnlyWhenFailed)]
        public void CreateQuoteAndNewEDIPolicy(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreen = new HomeScreen();
            var policySearchForm = new PolicySearchScreen();
            var policyMaintenanceForm = new PolicyCreateNewScreen();
            var ediSearchWebFrom = new PolicyEDIScreen();

            //Create New policy
            homeScreen.gotoPolicies();
            var testData1 = JObject.Parse(BaseTest.JSONObjects["Policies"]["EDI"].ToString());
            var testData2 = JObject.Parse(BaseTest.JSONObjects["EDI"]["EDIStandard"].ToString());
            testData1.Merge(testData2);
            policySearchForm.createNewPolicy(BaseTest.JSONObjects["Policies"]["EDIPolicy"]);
            policyMaintenanceForm.setClient(BaseTest.JSONObjects["Policies"]["EDIPolicy"]);
            policyMaintenanceForm.setClass(BaseTest.JSONObjects["Policies"]["EDIPolicy"]);
            policyMaintenanceForm.setSituation(BaseTest.JSONObjects["Policies"]["EDIPolicy"]);
            policyMaintenanceForm.setMaxLimit(BaseTest.JSONObjects["Policies"]["EDIPolicy"]);
            policyMaintenanceForm.setFrom();
            policyMaintenanceForm.addUnderwriter(BaseTest.JSONObjects["Policies"]["EDIPolicy"]);
            Session.Session.M360Session.Keyboard.PressKey(Keys.Tab);
            Thread.Sleep(5000);
            policyMaintenanceForm.setEDIProduct(BaseTest.JSONObjects["Policies"]["EDIPolicy"]);
            policyMaintenanceForm.gotoSchedule();
            policyMaintenanceForm.gotoButtonNewEDI();

            //Enter EDI Web interface
            ediSearchWebFrom.completeEDIPolicy(testData1);
            // policyMaintenanceForm.billPolicy(testData1);
            //var policyPremiumScreen = new PolicyPremiumScreen();
            //policyPremiumScreen._premiumSummaryTab.ClickButton();
            // policyMaintenanceForm.completePolicy(false);
        }

        [TestCase("DeletePolicy")]
        [Retrying(Times = 3)]
        [Video(Name = "Profile", Mode = SaveMe.OnlyWhenFailed)]
        public static void DeletePolicy(string testCaseId)
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
            policySearchScreen.searchPolicy(policyNumber, BaseTest.JSONObjects["Policies"]["Standard"]);
            var policyCreateScreen = new PolicyCreateNewScreen();
            policyCreateScreen.editPolicy();
            policyCreateScreen.deletePolicy();
            policySearchScreen.searchPolicy(policyNumber, BaseTest.JSONObjects["Policies"]["Standard"]);
        }

        [TestCase("CreatePolicyWithScheduleAndComments")]
        [Retrying(Times = 3)]
        [Video(Name = "CreatePolicyWithScheduleAndComments", Mode = SaveMe.OnlyWhenFailed)]
        public static void Policies_CreatePolicyWithScheduleAndComments(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreen = new HomeScreen();
            homeScreen.gotoPolicies();
            var policySearchScreen = new PolicySearchScreen();
            policySearchScreen.createNewPolicy(testData: BaseTest.JSONObjects["Policies"]["Standard"]);
            var policyCreateNewScreen = new PolicyCreateNewScreen();
            policyCreateNewScreen.createPolicy(testData: BaseTest.JSONObjects["Policies"]["Standard"], comments: true);
            policyCreateNewScreen.closePolicyScreen();
        }


    }
}
