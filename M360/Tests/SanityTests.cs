using ElementControl;
using M360.Pages;
using M360.Support;
using M360TestAutomation;
using M360TestAutomation.Tests;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NUnitRetrying;
using NunitVideoRecorder;
using System;
using System.Collections.Generic;
using System.Linq;

namespace M360
{
    public class SanityTests : BaseTest
    {
        [TestCase("ReportsManager")]
        [Category("SanityTests")]
        [Retrying(Times = 3)]
        [Video(Name = "ReportsManager", Mode = SaveMe.OnlyWhenFailed)]
        public static void ReportsManager_generateReport_OutstandingRenewalsExpiredNonRenewableReport(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreen = new HomeScreen();
            homeScreen.gotoMenu();
            homeScreen.gotoReports();
            homeScreen.gotoReportManager();
            var reportsScreen = new ReportsScreen();
            reportsScreen.generateSanityTestReport();
            var reportsFile = new ExcelData();
            reportsFile.ReadCSVData(@"C:\temp\Outstanding Renewals and Expired Non Renewables Report.csv");
            var policyNumber = reportsFile.GetCSVData(1, "Policy Reference");
            Assert.IsNotNull(policyNumber);
            reportsScreen._close.ClickButton();
            reportsScreen.SwitchToCurrentWindow();
        }


        [TestCase("Policy_RenewReverseAndReRenew_ExistingPolicy")]
        [Retrying(Times = 3)]
        [Category("SanityTests")]
        [Video(Name = "Policy_RenewReverseAndReRenew_ExistingPolicy", Mode = SaveMe.OnlyWhenFailed)]
        public static void Policies_RenewReverseAndReRenew_ExistingPolicy(string testCaseId)
        {
            //create policy in code
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
            policyCreateScreen.renewPolicy(BaseTest.JSONObjects["Policies"]["Standard"]);
            policyCreateScreen.reversePolicy();
            policyCreateScreen.renewPolicy(BaseTest.JSONObjects["Policies"]["Standard"]);
            policyCreateScreen.closePolicyScreen();
        }

        [TestCase("ExistingClientEditDoc")]
        [Category("SanityTests")]
        [Retrying(Times = 3)]
        [Video(Name = "ExistingClientEditDoc", Mode = SaveMe.OnlyWhenFailed)]
        public static void Clients_EditDocs_ExistingClient(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreen = new HomeScreen();
            homeScreen.gotoClients();
            var clientSearchScreen = new ClientSearchScreen();
            clientSearchScreen.searchClient(new string[] { "ClientCode" }, BaseTest.JSONObjects["Clients"]["Search"]);
            var clientProfileScreen = new ClientProfileScreen();
            clientProfileScreen.gotoProfileTab();
            clientProfileScreen.editProfileDocs();
        }

        [TestCase("CreateNewClient")]
        [Category("SanityTests")]
        [Retrying(Times = 3)]
        [Video(Name = "CreateNewClient", Mode = SaveMe.OnlyWhenFailed)]
        public static void Clients_EditDocs_NewClient(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreen = new HomeScreen();
            homeScreen.gotoClients();
            var clientSearchScreen = new ClientSearchScreen();
            var newClientScreen = new ClientNewClientScreen();
            clientSearchScreen.searchClient(new string[] { "ClientCode" }, BaseTest.JSONObjects["Clients"]["New"]);
            newClientScreen.DeleteClient();

            clientSearchScreen.createNewClient(BaseTest.JSONObjects["Clients"]["New"], false);
            newClientScreen.enterHeaderDetails(BaseTest.JSONObjects["Clients"]["New"]);
            newClientScreen.save();
            var clientProfileTab = new ClientProfileScreen();
            clientProfileTab.InsertProfile(BaseTest.JSONObjects["Clients"]["New"]);
            clientProfileTab.editProfileDocs();
            newClientScreen.DeleteClient();
        }

        [TestCase("DispatchInvoices")]
        [Category("SanityTests")]
        [Retrying(Times = 3)]
        [Video(Name = "DispatchInvoices", Mode = SaveMe.OnlyWhenFailed)]
        public static void Broking_DispatchInvoices(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreen = new HomeScreen();
            homeScreen.gotoMenu();
            homeScreen.gotoDispatch();
            var dispatchScreen = new DispatchScreen();
            dispatchScreen.searchPolicy(BaseTest.JSONObjects["Dispatch"]["Standard"], "Dispatched", "01/01/2020");
            dispatchScreen.dispatchInvoices();

        }

        [TestCase("CreatePolicyWithScheduleAndComments")]
        [Category("SanityTests")]
        [Retrying(Times = 3)]
        [Video(Name = "CreatePolicyWithScheduleAndComments", Mode = SaveMe.OnlyWhenFailed)]
        public static void Policies_CreatePolicyWithScheduleAndComments(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreen = new HomeScreen();
            homeScreen.gotoPolicies();
            var policySearchScreen = new PolicySearchScreen();
            policySearchScreen.createNewPolicy(BaseTest.JSONObjects["Policies"]["Standard"]);
            var policyCreateNewScreen = new PolicyCreateNewScreen();
            policyCreateNewScreen.createPolicy(testData: BaseTest.JSONObjects["Policies"]["Standard"], comments: true);
            policyCreateNewScreen.closePolicyScreen();
        }

        [TestCase("CreatePolicyWithoutInstallments")]
        [Category("SanityTests")]
        [Retrying(Times = 3)]
        [Video(Name = "CreatePolicyWithoutInstallments", Mode = SaveMe.OnlyWhenFailed)]
        public static void Policies_CreatePolicyWithoutInstallments_RenewThenReverseThenRenew(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreen = new HomeScreen();
            homeScreen.gotoPolicies();
            var policySearchScreen = new PolicySearchScreen();
            policySearchScreen.createNewPolicy(BaseTest.JSONObjects["Policies"]["Standard"]);
            var policyCreateNewScreen = new PolicyCreateNewScreen();
            policyCreateNewScreen.createPolicy(BaseTest.JSONObjects["Policies"]["Standard"]);
            policyCreateNewScreen.renewPolicy(BaseTest.JSONObjects["Policies"]["Standard"]);
            policyCreateNewScreen.reversePolicy();
            policyCreateNewScreen.renewPolicy(BaseTest.JSONObjects["Policies"]["Standard"]);
            policyCreateNewScreen.closePolicyScreen();
        }

        [TestCase("CreatePolicyWithInstallments")]
        [Category("SanityTests")]
        [Retrying(Times = 3)]
        [Video(Name = "CreatePolicyWithInstallments", Mode = SaveMe.OnlyWhenFailed)]
        public static void Policies_CreatePolicyWithInstallments(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            JObject testData1 = JObject.Parse(BaseTest.JSONObjects["Policies"]["Standard"].ToString());
            JObject testData2 = JObject.Parse(BaseTest.JSONObjects["Policies"]["Installments"].ToString());
            testData1.Merge(testData2);
            var homeScreen = new HomeScreen();
            homeScreen.gotoPolicies();
            var policySearchScreen = new PolicySearchScreen();
            policySearchScreen.createNewPolicy(testData1);
            var policyCreateScreen = new PolicyCreateNewScreen();
            policyCreateScreen.createPolicy(testData1);
        }

        [TestCase("CreatePolicyWithFBIPotential")]
        [Category("SanityTests")]
        [Retrying(Times = 3)]
        [Video(Name = "CreatePolicyWithFBIPotential", Mode = SaveMe.OnlyWhenFailed)]
        public static void Policies_CreatePolicyWithFBIPotential(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreen = new HomeScreen();
            homeScreen.gotoPolicies();
            var policySearchScreen = new PolicySearchScreen();
            policySearchScreen.createNewPolicy(BaseTest.JSONObjects["Policies"]["FBIPotential"]);
            var policyCreateScreen = new PolicyCreateNewScreen();
            policyCreateScreen.createPolicy(BaseTest.JSONObjects["Policies"]["FBIPotential"]);
            policyCreateScreen.gotoClientScreen();
            var clientScreen = new ClientFundingScreen();
            clientScreen.verifyFundingContract(BaseTest.JSONObjects["Policies"]["FBIPotential"]);
        }

        [TestCase("EndorsePolicy")]
        [Category("SanityTests")]
        [Retrying(Times = 3)]
        [Video(Name = "EndorsePolicy", Mode = SaveMe.OnlyWhenFailed)]
        public static void Policies_Endorsement(string testCaseId)
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
            policyCreateScreen.gotoClientScreen();
            var clientScreen = new ClientNewClientScreen();
            clientScreen.closeClientScreen();
            policyCreateScreen.endorse(testData: BaseTest.JSONObjects["Policies"]["Standard"], installments: false);
        }

        [TestCase("FullCancelPolicy")]
        [Category("SanityTests")]
        [Retrying(Times = 3)]
        [Video(Name = "FullCancelPolicy", Mode = SaveMe.OnlyWhenFailed)]
        public static void Policies_FullCancelPolicy(string testCaseId)
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
            policyCreateScreen.cancelPolicy(BaseTest.JSONObjects["Policies"]["Standard"], false);
        }

        [TestCase("LapsePolicy")]
        [Category("SanityTests")]
        [Retrying(Times = 3)]
        [Video(Name = "LapsePolicy", Mode = SaveMe.OnlyWhenFailed)]
        public static void Policies_Lapse(string testCaseId)
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

        }

        [TestCase("SchemeWithoutProfile")]
        [Category("SanityTests")]
        [Retrying(Times = 3)]
        [Video(Name = "SchemeWithoutProfile", Mode = SaveMe.OnlyWhenFailed)]
        public static void Schemes_NewPolicyWithOutProfile(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreen = new HomeScreen();
            homeScreen.gotoSchemes();
            var schemesScreen = new SchemesScreen();
            var testData1 = JObject.Parse(BaseTest.JSONObjects["Policies"]["Schemes"].ToString());
            var testData2 = JObject.Parse(BaseTest.JSONObjects["Schemes"]["WithoutProfile"].ToString());
            testData1.Merge(testData2);
            schemesScreen.createSchemePolicy(testData1);
            var policyScreen = new PolicyCreateNewScreen();
            policyScreen.createPolicy(testData1, scheme: true, underWriter: false, premium: false, risk: true);

        }

        [TestCase("SchemeWithProfile")]
        [Category("SanityTests")]
        [Retrying(Times = 3)]
        [Video(Name = "SchemeWithProfile", Mode = SaveMe.OnlyWhenFailed)]
        public static void Schemes_NewPolicyWithProfile(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreen = new HomeScreen();
            homeScreen.gotoSchemes();
            var schemesScreen = new SchemesScreen();
            var testData1 = JObject.Parse(BaseTest.JSONObjects["Policies"]["Schemes"].ToString());
            var testData2 = JObject.Parse(BaseTest.JSONObjects["Schemes"]["WithProfile"].ToString());
            testData1.Merge(testData2);
            schemesScreen.createSchemePolicy(testData1);
            var policyScreen = new PolicyCreateNewScreen();
            policyScreen.createPolicy(testData1, scheme: true, underWriter: false, premium: false, risk: true);
        }


        [TestCase("EDIPolicy")]
        [Category("SanityTests")]
        [Retrying(Times = 0)]
        [Video(Name = "EDIPolicy", Mode = SaveMe.OnlyWhenFailed)]
        public static void Policies_EDIPolicy(string testCaseId)
        {
            var policyData = new PolicyData()
            {
                branch = BaseTest.JSONObjects["Policies"]["EDI"]["Office"].ToString(),
                team = "090",
                broker1Username = BaseTest.JSONObjects["Policies"]["EDI"]["Broker"].ToString(),
                client = BaseTest.JSONObjects["Policies"]["EDI"]["Client"].ToString(),
                fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                toDate = new DateTime(DateTime.Now.Year + 1, DateTime.Now.Month, DateTime.Now.Day),
                insuranceClass = BaseTest.JSONObjects["Policies"]["EDI"]["Class"].ToString(),
                locations = new[] { "SA" }.ToList(),
                marketSegment = "AF",
                maxLiability = 2000000,
                scheduleText = "Sample Text",
                situationText = "Anywhere in Australia",
                underwriters = new[] { "CGUSE" }.ToList(),
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

            var testData1 = JObject.Parse(BaseTest.JSONObjects["Policies"]["EDI"].ToString());
            var testData2 = JObject.Parse(BaseTest.JSONObjects["EDI"]["EDIStandard"].ToString());
            testData1.Merge(testData2);
            var policyCreateScreen = new PolicyCreateNewScreen();
            policySearchScreen.searchPolicy(policyNumber, testData1);
            policyCreateScreen.editPolicy();
            var ediScreen = new PolicyEDIScreen();
            ediScreen.completeEDI(testData1);
            policyCreateScreen.billPolicy(testData1);
            var policyPremiumScreen = new PolicyPremiumScreen();
            policyPremiumScreen._premiumSummaryTab.ClickButton();
            policyCreateScreen.completePolicy(false);
        }


        [TestCase("CreateQuote")]
        [Category("SanityTests")]
        [Retrying(Times = 3)]
        [Video(Name = "CreateQuote", Mode = SaveMe.OnlyWhenFailed)]
        public static void CreateQuote(string testCaseId)
        {

            testData.testCaseId = testCaseId;
            var homeScreen = new HomeScreen();
            homeScreen.gotoClients();
            var clientSearchScreen = new ClientSearchScreen();
            clientSearchScreen.searchClient(new string[] { "ClientCode" }, BaseTest.JSONObjects["Clients"]["Search"]);
            var clientFundingScreen = new ClientFundingScreen();
            clientFundingScreen.createQuote();
        }

        [TestCase("CreateAction")]
        [Category("SanityTests")]
        [Retrying(Times = 3)]
        [Video(Name = "CreateActionAndReceipt", Mode = SaveMe.OnlyWhenFailed)]
        public static void CreateAction(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreen = new HomeScreen();
            homeScreen.gotoClients();
            var clientSearchScreen = new ClientSearchScreen();
            clientSearchScreen.searchClient(new string[] { "ClientCode" }, BaseTest.JSONObjects["Clients"]["Search"]);
            var newClientScreen = new ClientNewClientScreen();
            newClientScreen.SwitchToCurrentWindow();
            newClientScreen.createDiaryAction();
            var diaryClientScreen = new ClientActionScreen();
            diaryClientScreen.createAction();
        }

        [TestCase("CreateReceipt")]
        [Category("SanityTests")]
        [Retrying(Times = 3)]
        [Video(Name = "CreateReceipt", Mode = SaveMe.OnlyWhenFailed)]
        public static void CreateReceipt(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreen = new HomeScreen();
            homeScreen.gotoClients();
            var clientSearchScreen = new ClientSearchScreen();
            clientSearchScreen.searchClient(new string[] { "ClientCode" }, BaseTest.JSONObjects["Clients"]["Search"]);
            var newClientScreen = new ClientNewClientScreen();
            newClientScreen.SwitchToCurrentWindow();
            var financialScreen = new ClientFinancialScreen();
            financialScreen.createReceipt();
            var receiptsScreen = new ClientReceiptScreen();
            receiptsScreen.createReceipt();
            newClientScreen.generateStatement();
        }
    }
}
