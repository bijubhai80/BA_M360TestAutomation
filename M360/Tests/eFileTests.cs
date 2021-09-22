using ElementControl;
using M360.Pages;
using M360TestAutomation;
using M360TestAutomation.Tests;
using NUnit.Framework;
using NUnitRetrying;
using NunitVideoRecorder;
using System;
using System.Collections.Generic;
using System.Linq;

namespace M360
{
    public class eFileTests : BaseTest
    {
        //only works on UAT where eFile is fully enabled
        [TestCase("PolicyDispatcheFileEmail")]
        [Retrying(Times = 3)]
        [Ignore("Takes too long to load efile results, so test fails -env issue")]
        [Video(Name = "PolicyDispatcheFileEmail", Mode = SaveMe.OnlyWhenFailed)]
        public static void PolicyDispatcheFileEmail(string testCaseId)
        {
            var policyData = new PolicyData()
            {
                branch = BaseTest.JSONObjects["Policies"]["EFile"]["Office"].ToString(),
                team = "017",
                broker1Username = BaseTest.JSONObjects["Policies"]["EFile"]["Broker"].ToString(),
                client = BaseTest.JSONObjects["Policies"]["EFile"]["Client"].ToString(),
                fromDate = new DateTime(2021, 01, 01),
                toDate = new DateTime(2021, 01, 01),
                insuranceClass = BaseTest.JSONObjects["Policies"]["EFile"]["Class"].ToString(),
                locations = new[] { "SA" }.ToList(),
                marketSegment = "RS",
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
            policySearchScreen.searchPolicy(policyNumber, BaseTest.JSONObjects["Policies"]["EFile"]);
            policyCreateScreen.editPolicy();
            policyCreateScreen.billPolicy(BaseTest.JSONObjects["Policies"]["EFile"]);
            var policyPremiumScreen = new PolicyPremiumScreen();
            policyPremiumScreen.setPremium(BaseTest.JSONObjects["Policies"]["EFile"], installments: false, renew: false);
            policyCreateScreen.completePolicy(false);

            policyCreateScreen._close.ClickButton();
            policyCreateScreen.SwitchToCurrentWindow();
            policySearchScreen._close.ClickButton();
            policySearchScreen.SwitchToCurrentWindow();

            homeScreen.gotoMenu();
            homeScreen.gotoDispatch();
            var dispatchScreen = new DispatchScreen();
            dispatchScreen.searchPolicy(BaseTest.JSONObjects["Dispatch"]["EFile"], "Outstanding",
                DateTime.Now.ToString("dd/MM/yyyy"), true);
            dispatchScreen.dispatchInvoices();
            dispatchScreen.SwitchToCurrentWindow();

            homeScreen.gotoPolicies();
            policySearchScreen.searchPolicy(policyNumber, BaseTest.JSONObjects["Policies"]["EFile"]);

            var eFileScreen = new eFileScreen();
            var closingFileName = eFileScreen.GetClosingFileNameFromEfileTab();

            var transactionsTab = new PolicyTransactionTabScreeen();
            transactionsTab.VerifyReferenceNumber(closingFileName);
        }
    }
}
