using M360.Pages;
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
    public class FinancialsTests : BaseTest
    {
        [TestCase("CreateAuthorisePaymentUser")]
        [Retrying(Times = 3)]
        [Ignore("Test Not working")]
        [Video(Name = "CreateAuthorisePaymentUser", Mode = SaveMe.OnlyWhenFailed)]
        public static void CreateAuthorisePaymentUser(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreenPage = new HomeScreen();
            homeScreenPage.gotoMenu();
            homeScreenPage.gotoFinancials();
            homeScreenPage.gotoPayCreditorsProcesses();
            homeScreenPage.gotoCreateAuthorisePaymentUser();
            var createAuthoriseUser = new CreateAuthorisePaymentsUser();
            var dataStandard = JObject.Parse(BaseTest.JSONObjects["Financials"]["Standard"].ToString());
            var dataPayments = JObject.Parse(BaseTest.JSONObjects["Financials"]["PayCreditors"]["AuthoriseUser"]["UserCreated_Y"].ToString());
            dataStandard.Merge(dataPayments);
            createAuthoriseUser.createAuthoriseUser(dataStandard);


        }

        [TestCase("PaymentInstruction")]
        [Retrying(Times = 3)]
        [Ignore("Test not working")]
        [Video(Name = "PaymentInstruction", Mode = SaveMe.OnlyWhenFailed)]
        public static void PaymentInstruction(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreenPage = new HomeScreen();
            homeScreenPage.gotoMenu();
            homeScreenPage.gotoFinancials();
            homeScreenPage.gotoPayCreditorsProcesses();
            homeScreenPage.gotoPaymentInstruction();
            homeScreenPage.SwitchToCurrentWindow();
            var paymentInstructionScreen = new PaymentInstruction();
            var dataStandard = JObject.Parse(BaseTest.JSONObjects["Financials"]["Standard"].ToString());
            var dataPayments = JObject.Parse(BaseTest.JSONObjects["Financials"]["PaymentInstruction"].ToString());
            dataStandard.Merge(dataPayments);
            paymentInstructionScreen.PaymentInstructions(dataStandard);

        }

        [TestCase("PayCreditors")]
        [Retrying(Times = 3)]
        [Ignore("Test Not working")]
        [Video(Name = "PayCreditors", Mode = SaveMe.OnlyWhenFailed)]
        public static void PayCreditors(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreenPage = new HomeScreen();
            homeScreenPage.gotoMenu();
            homeScreenPage.gotoFinancials();
            homeScreenPage.gotoPayCreditorsProcesses();
            homeScreenPage.gotoPayCreditorAccounts();
            homeScreenPage.SwitchToCurrentWindow();
            var payCreditorsScreen = new PayCreditorAccountsScreen();
            payCreditorsScreen.processCreditorAccount(BaseTest.JSONObjects["Financials"]["Standard"]);

        }


        [TestCase("AuthorisePayments")]
        [Retrying(Times = 3)]
        [Video(Name = "AuthorisePayments", Mode = SaveMe.OnlyWhenFailed)]
        //[Ignore("Test Not working")]
        public static void AuthorisePayments(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreenPage = new HomeScreen();
            homeScreenPage.gotoMenu();
            homeScreenPage.gotoFinancials();
            homeScreenPage.gotoPayCreditorsProcesses();
            homeScreenPage.gotoAuthorisePayments();
            homeScreenPage.SwitchToCurrentWindow();
            var authorisePaymentsScreen = new AuthorisePaymentsScreen();
            var dataStandard = JObject.Parse(BaseTest.JSONObjects["Financials"]["Standard"].ToString());
            var dataPayments = JObject.Parse(BaseTest.JSONObjects["Financials"]["AuthorisePayments"].ToString());
            dataStandard.Merge(dataPayments);
            authorisePaymentsScreen.searchAuthorisePayment(dataStandard);
            //authorisePaymentsScreen.Review_Payment(dataStandard);
            //authorisePaymentsScreen.Authorise_Payment(dataStandard);

        }

        [TestCase("DispatchInvoices")]
        [Retrying(Times = 3)]
        [Video(Name = "DispatchInvoices", Mode = SaveMe.OnlyWhenFailed)]
        public static void Broking_DispatchInvoices(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreen = new HomeScreen();
            homeScreen.gotoMenu();
            homeScreen.gotoDispatch();
            var dispatchScreen = new DispatchScreen();
            dispatchScreen.searchPolicy(BaseTest.JSONObjects["Dispatch"]["Standard"], "Dispatched", "06/03/2020");
            dispatchScreen.dispatchInvoices();

        }

        [TestCase("GeneralLedgerInquiry_DepartmentAndMarketSegment")]
        [Retrying(Times = 3)]
        [Video(Name = "GeneralLedgerInterface", Mode = SaveMe.OnlyWhenFailed)]
        [Ignore("Test Not working")]
        public static void GeneralLedgerInquiry_DepartmentAndMarketSegment(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreenPage = new HomeScreen();
            var generalLedgerInquiry = new GeneralLedgerInquiry();
            homeScreenPage.gotoMenu();
            homeScreenPage.gotoFinancials();
            generalLedgerInquiry.gotoGeneralLedgerInquiry(JSONObjects["Financials"]["GeneralLedgerInquiry"]);
        }

        [TestCase("GeneralLedgerInquiry_BankAccount")]
        [Retrying(Times = 3)]
        [Video(Name = "GeneralLedgerInterface", Mode = SaveMe.OnlyWhenFailed)]
        public static void GeneralLedgerInquiry_BankAccount(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreenPage = new HomeScreen();
            var generalLedgerInquiry = new GeneralLedgerInquiry();
            homeScreenPage.gotoMenu();
            homeScreenPage.gotoFinancials();
            generalLedgerInquiry.gotoGeneralLedgerInquiry_BankAccount(JSONObjects["Financials"]["GeneralLedgerInquiry"]);
        }

        [TestCase("GeneralLedgerInquiry_ControlAccount")]
        [Retrying(Times = 3)]
        [Ignore("Test not working")]
        [Video(Name = "GeneralLedgerInterface", Mode = SaveMe.OnlyWhenFailed)]
        public static void GeneralLedgerInquiry_ControlAccount(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreenPage = new HomeScreen();
            var generalLedgerInquiry = new GeneralLedgerInquiry();
            homeScreenPage.gotoMenu();
            homeScreenPage.gotoFinancials();
            generalLedgerInquiry.gotoGeneralLedgerInquiry_ControlAccount(JSONObjects["Financials"]["GeneralLedgerInquiry"]);
        }





        [TestCase("GeneralLedgerInterface")]
        [Retrying(Times = 3)]
        [Ignore("Test not working")]
        [Video(Name = "GeneralLedgerInterface", Mode = SaveMe.OnlyWhenFailed)]
        public static void GeneralLedgerInterface(string testCaseId)
        {
            var policyData = new PolicyData()
            {
                branch = BaseTest.JSONObjects["Policies"]["Standard1"]["Office"].ToString(),
                team = "007",
                broker1Username = BaseTest.JSONObjects["Policies"]["Standard1"]["Broker"].ToString(),
                client = BaseTest.JSONObjects["Policies"]["Standard1"]["Client"].ToString(),
                fromDate = new DateTime(2021, 01, 01),
                toDate = new DateTime(2021, 01, 01),
                insuranceClass = BaseTest.JSONObjects["Policies"]["Standard1"]["Class"].ToString(),
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
            var homeScreenPage = new HomeScreen();

            homeScreenPage.gotoMenu();
            homeScreenPage.gotoFinancials();
            homeScreenPage.gotoGeneralLedgerInterface();
            homeScreenPage.SwitchToCurrentWindow();

            var generalLedgerInterfaceScreen = new GeneralLedgerInterfaceScreen();
            generalLedgerInterfaceScreen.process();
            generalLedgerInterfaceScreen.rebuild();
            generalLedgerInterfaceScreen.export(policyNumber);
        }

        [TestCase("BatchedReceipts")]
        [Retrying(Times = 3)]
        [Video(Name = "BatchedReceipts", Mode = SaveMe.OnlyWhenFailed)]
        public static void BatchedReceipts(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreen = new HomeScreen();
            var batchedReceiptsForm = new BatchedReceiptsScreen();
            var insuranceLedgerTransactionForm = new InsuranceLedgerTransaction();
            homeScreen.gotoMenu();
            homeScreen.gotoFinancials();
            homeScreen.gotoBatchedReceipts();
            homeScreen.SwitchToCurrentWindow();
            batchedReceiptsForm.setHeader(BaseTest.JSONObjects["Financials"]["Standard"]);
            insuranceLedgerTransactionForm.createBatchSingleReceiptNoAllocation(BaseTest.JSONObjects["Financials"]["Standard"]);
            insuranceLedgerTransactionForm.CompleteBatchedReceipts();

        }

        [TestCase("InsuranceLedgerTransaction_InvoiceAndCreditNote")]
        [Retrying(Times = 3)]
        [Video(Name = "InsuranceLedgerTransaction_InvoiceAndCreditNote", Mode = SaveMe.OnlyWhenFailed)]
        public static void InvoiceAndCreditNote(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreen = new HomeScreen();
            var insuranceLedgerTransactionForm = new InsuranceLedgerTransaction();
            homeScreen.gotoMenu();
            homeScreen.gotoFinancials();
            homeScreen.gotoInsuranceLedger();
            homeScreen.SwitchToCurrentWindow();
            insuranceLedgerTransactionForm.createInvoiceAndCreditNote(JSONObjects["Financials"]["InsuranceLedger"]["Invoice"]);
            insuranceLedgerTransactionForm.SwitchToCurrentWindow();
            insuranceLedgerTransactionForm.createInvoiceAndCreditNote(JSONObjects["Financials"]["InsuranceLedger"]["CreditNote"]);
            // batchedReceiptsForm.setHeader(BaseTest.JSONObjects["Financials"]["Standard"]);
            // insuranceLedgerTransactionForm.createBatchSingleReceiptNoAllocation(BaseTest.JSONObjects["Financials"]["Standard"]);
            // insuranceLedgerTransactionForm.CompleteBatchedReceipts();

        }



        [TestCase("AutomaticClientAllocation")]
        [Retrying(Times = 3)]
        [Video(Name = "AutomaticClientAllocation", Mode = SaveMe.OnlyWhenFailed)]
        public static void AutomaticClientAllocation(string testCaseId)
        {
            var main = new HomeScreen();
            var automaticClientAllocation = new AutomaticClientAllocationScreen();
            var clientMaintenanceForm = new ClientSearchScreen();
            var financialTab = new ClientFinancialScreen();
            var ledgerForm = new ClientReceiptScreen();

            // Run Automatic Client Allocation
            main.gotoMenu();
            main.gotoFinancials();
            main.gotoAutomaticClientAllocation();
            automaticClientAllocation.selectOffice(JSONObjects["Financials"]["AutomaticClientAllocation"]);
            automaticClientAllocation.process();
            automaticClientAllocation.close();

            main.gotoClients();
            clientMaintenanceForm.searchClient(new string[] { "ClientCode" }, JSONObjects["Financials"]["AutomaticClientAllocation"]);
            clientMaintenanceForm.SwitchToCurrentWindow();
            financialTab.createReceipt();
            ledgerForm.createInvoice(JSONObjects["Financials"]["AutomaticClientAllocation"]);
            financialTab.createReceipt();
            ledgerForm.createReceipt();
            clientMaintenanceForm.home();

            // ReRun Automatic Client Allocation
            main.gotoMenu();
            main.gotoFinancials();
            main.gotoAutomaticClientAllocation();
            automaticClientAllocation.selectOffice(JSONObjects["Financials"]["AutomaticClientAllocation"]);
            automaticClientAllocation.process();
            automaticClientAllocation.close();

            // Check unallocated cash has been allocated
            main.gotoClients();
            clientMaintenanceForm.searchClient(new string[] { "ClientCode" }, JSONObjects["Financials"]["AutomaticClientAllocation"]);
            clientMaintenanceForm.SwitchToCurrentWindow();
            financialTab.goToFinancialstab();
            financialTab.isUnalloactedCashZero();
        }
    }
}
