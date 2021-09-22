using ElementControl;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Appium;

namespace M360.Pages
{
    public class HomeScreen : BaseScreen
    {


        //Menu Buttons
        public AppiumWebElement _menu
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "MENU");
            }
        }

        public AppiumWebElement _clients
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "CLIENTS");
            }
        }

        public AppiumWebElement _policies
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "POLICIES");
            }
        }

        public AppiumWebElement _claims
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "CLAIMS");
            }
        }

        public AppiumWebElement _schemes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "SCHEMES");
            }
        }

        public AppiumWebElement _workQueue
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "WORKQUEUE");
            }
        }

        //Reports
        public AppiumWebElement _reports
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Reports");
            }
        }

        public AppiumWebElement _reportManager
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Report Manager");
            }
        }

        public AppiumWebElement _security => GetElementByName("Security");
        public AppiumWebElement _users => GetElementByName("Users");

        public AppiumWebElement _financials
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Financials");
            }
        }

        public AppiumWebElement _financialDocuments
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Financial Documents");
            }
        }

        public AppiumWebElement _fundingQuoteBatches
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Funding Quote Batches");
            }
        }

        public AppiumWebElement _CreateAuthorisePaymentUser
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Create Authorise Payments User");
            }
        }
        public AppiumWebElement _payCreditorsProcesses
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Pay Creditors Processes");
            }
        }


        public AppiumWebElement _payCreditorAccounts
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Pay Creditor Accounts");
            }
        }

        public AppiumWebElement _authorisedPayments
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Authorise Payments");
            }
        }


        public AppiumWebElement _paymentInstruction
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Payment Instructions");
            }
        }

        //Dispatch Invoices And Closings
        public AppiumWebElement _broking
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Broking");
            }
        }

        public AppiumWebElement _dispatch
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Dispatch Invoices & Closings");
            }
        }

        public AppiumWebElement _utilities
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Utilities");
            }
        }

        public AppiumWebElement _batchedReceipts
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Batched Receipts");
            }
        }

        public AppiumWebElement _generalLedgerInterface
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "General Ledger Interface");
            }
        }

        public AppiumWebElement _generalLedgerInquiry
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "General Ledger Inquiry");
            }
        }

        public AppiumWebElement _orgUnits
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Organisational Units");
            }
        }

        public AppiumWebElement _externalParties
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "External Parties");
            }
        }

        public AppiumWebElement _underWritersAndBrokers
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Underwriters and Brokers");
            }
        }

        public AppiumWebElement _automaticClientAllocation => GetElementByName("Automatic Client Allocation");

        public AppiumWebElement _InsuranceLedger
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Insurance Ledger");
            }
        }


        public AppiumWebElement _documentMaintenance
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Document Maintenance");
            }
        }

        public string Username => Session.Session.M360Session.FindElementsByXPath("//Text[@ClassName =\"Text\"]")[3].Text;

        //Security under Utilities
        public AppiumWebElement _securityMenu => GetElementByName("Security");
        public AppiumWebElement _textElement => GetElementByAccessibilityId("_menuItemsTextElements");
        public AppiumWebElement _bankDeposit
        {
            get
            {
                AppiumWebElement financialsPopup = WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.ClassName, "Popup");
                AppiumWebElement bankdeposit = financialsPopup.FindElementByName("Bank Deposits");
                return bankdeposit;
                //return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Bank Deposits");
            }
        }
        public AppiumWebElement _roles => GetElementByName("Roles");

        public AppiumWebElement _brokingLetters => GetElementByName("Broking Letters");

        public AppiumWebElement _branchledger
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "jltaCodeTandemBranch");
            }
        }
        public AppiumWebElement _account
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonAccount");
            }
        }

        public AppiumWebElement _selectledger
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "SelectGeneralLedgerDialog");
            }
        }
        public void gotoBrokingLetters()
        {
            _brokingLetters.ClickButton();
            SwitchToCurrentWindow();
        }
        public void gotoClients()
        {
            _clients.ClickButton();

        }
        public void gotoPolicies()
        {
            _policies.ClickButton();
        }

        public void gotoClaims()
        {
            _claims.ClickButton();
        }

        public void gotoSchemes()
        {
            _schemes.ClickButton();
        }

        public void gotoWorkQueue()
        {
            _workQueue.ClickButton();
        }

        public void gotoDispatch()
        {
            _broking.ClickButton();
            _dispatch.ClickButton();
        }

        public void gotoMenu()
        {
            _menu.ClickButton();
        }

        public void gotoReports()
        {
            _reports.ClickButton();
        }

        public void gotoReportManager()
        {
            _reportManager.ClickButton();
        }

        public void gotoFinancials()
        {
            _financials.ClickButton();
        }

        public void gotoFinancialDocuments()
        {
            _financialDocuments.ClickButton();
        }

        public void gotoFundingQuoteBatches()
        {
            _fundingQuoteBatches.ClickButton();
        }

        public void gotoBatchedReceipts()
        {
            _batchedReceipts.ClickButton();
        }

        public void gotoInsuranceLedger()
        {
            _InsuranceLedger.ClickButton();
        }

        public void gotoPayCreditorsProcesses()
        {
            _payCreditorsProcesses.ClickButton();
        }

        public void gotoPayCreditorAccounts()
        {
            _payCreditorAccounts.ClickButton();
        }

        public void gotoCreateAuthorisePaymentUser()
        {
            _CreateAuthorisePaymentUser.ClickButton();
        }

        public void gotoPaymentInstruction()
        {
            _paymentInstruction.ClickButton();
        }

        public void gotoAuthorisePayments()
        {
            _authorisedPayments.ClickButton();
        }

        public void gotoGeneralLedgerInterface()
        {
            _generalLedgerInterface.ClickButton();
        }

        public void gotoGeneralLedgerInquiry(JToken testData)
        {
            _generalLedgerInquiry.ClickButton();
            _branchledger.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["Office"].ToString()).Click();
            //_branchledger.SetValue(testData["Office"].ToString());
            _account.ClickButton();
            _selectledger.Click();
        }

        public void gotoUtilities()
        {
            _utilities.ClickButton();
        }
        public void gotoDocumentMaintenance()
        {
            _documentMaintenance.ClickButton();
        }
        public void gotoTextElement()
        {
            _textElement.ClickButton();
        }

        public void gotoOrganisationalUnits()
        {
            _orgUnits.ClickButton();
        }

        public void gotoSecurity()
        {
            _securityMenu.ClickButton();
        }

        public void gotoRoles()
        {
            _menu.ClickButton();
            _utilities.ClickButton();
            _securityMenu.ClickButton();
            _roles.ClickButton();
            SwitchToCurrentWindow();
        }
        public void gotoUnderWritersAnBrokers()
        {
            _externalParties.ClickButton();
            _underWritersAndBrokers.ClickButton();
        }

        public void gotoAutomaticClientAllocation()
        {
            _automaticClientAllocation.ClickButton();
            SwitchToCurrentWindow();
        }

        public void gotoUsers()
        {
            _utilities.ClickButton();
            _security.ClickButton();
            _users.ClickButton();
        }
        public void usersMenu()
        {
            _users.ClickButton();
        }

        public void gotoBankDeposit()
        {
            _bankDeposit.ClickButton();
        }

    }
}
