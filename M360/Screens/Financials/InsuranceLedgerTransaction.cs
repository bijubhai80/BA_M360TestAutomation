using ElementControl;
using M360TestAutomation.Tests;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;

namespace M360.Pages
{
    public class InsuranceLedgerTransaction : BaseScreen
    {
        public AppiumWebElement _ledger
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "jltaComboLedger");
            }
        }

        public AppiumWebElement _ledgerItem
        {
            get
            {

                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, BaseTest.testData.GetData("Financials", BaseTest.testData.testCaseId, "Ledger Type"));
            }
        }


        public AppiumWebElement _ledgerAccount
        {
            get
            {

                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Account");
            }
        }


        public AppiumWebElement _amount//
        {
            get
            {

                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Amount");
            }
        }

        public AppiumWebElement _bank
        {
            get
            {

                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Bank");
            }
        }


        public AppiumWebElement _bsb
        {
            get
            {

                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "BSB");
            }
        }


        public AppiumWebElement _endBatch
        {
            get
            {

                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonEndBatch");
            }
        }

        public AppiumWebElement _yesOption
        {
            get
            {

                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonYes");
            }
        }

        public AppiumWebElement _nextBatch
        {
            get
            {

                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonNextRcpt");
            }
        }
        public AppiumWebElement _btnYes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonYes");
            }
        }
        public AppiumWebElement _btnComplete
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonComplete");
            }
        }

        public AppiumWebElement _btnNew
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonNew");
            }
        }

        public AppiumWebElement _type
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "jltaComboType");
            }
        }

        public AppiumWebElement _businessType
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "comboBoxBusinessType");
            }
        }

        public AppiumWebElement _comments
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_commentEditorTransaction");
            }
        }

        public AppiumWebElement _ledgercombo
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "jltaComboLedger");
            }
        }

        public AppiumWebElement _LedgerAccount
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "ClientCodeControl");
            }
        }

        public AppiumWebElement _PhasingButton
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_buttonPhasing");
            }
        }

        public AppiumWebElement _complete
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonComplete");
            }
        }

        public AppiumWebElement _yes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonYes");
            }
        }

        public AppiumWebElement _close
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonClose");
            }
        }




        public void createBatchSingleReceiptNoAllocation(JToken testData)
        {
            SwitchToCurrentWindow();
            //To Create one Receipt//
            _ledger.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["LedgerType"].ToString()).Click();

            _ledgerAccount.SetValue(testData["LedgerAccount"].ToString());

            _amount.SetValue(testData["Amount"].ToString());
            _bank.SetValue(testData["Bank"].ToString());
            _bsb.SetValue(testData["BSB"].ToString());

            _nextBatch.ClickButton();
            _yesOption.ClickButton();

            //To Create 2nd Receipt//
            _ledger.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["LedgerType_R2"].ToString()).Click();

            _ledgerAccount.SetValue(testData["LedgerAccount_R2"].ToString());

            _amount.SetValue(testData["Amount_R2"].ToString());
            _bank.SetValue(testData["Bank_R2"].ToString());
            _bsb.SetValue(testData["BSB_R2"].ToString());

            _endBatch.ClickButton();
            _yesOption.ClickButton();
            SwitchToCurrentWindow();


        }
        public void CompleteBatchedReceipts()
        {
            _btnComplete.ClickButton();
            _btnYes.ClickButton();


        }
        public void createBatchMultipleReceiptNoAllocation(JToken testData)
        {
            SwitchToCurrentWindow();
            _ledger.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["LedgerType"].ToString()).Click();

            _ledgerAccount.SetValue(testData["LedgerAccount"].ToString());

            _amount.SetValue(testData["Amount"].ToString());
            _bank.SetValue(testData["Bank"].ToString());
            _bsb.SetValue(testData["BSB"].ToString());
            _endBatch.ClickButton();
            _yesOption.ClickButton();
        }

        public void createInvoiceAndCreditNote(JToken testData)
        {
            _btnNew.ClickButton();
            SwitchToCurrentWindow();
            _type.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["Type"].ToString()).Click();
            _ledgercombo.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["Ledger"].ToString()).Click();
            _LedgerAccount.SetValue(testData["LedgerAccount"].ToString());

            //SelectDropdownOption(1); //Selects "Invoice" in type field
            _businessType.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["Business"].ToString()).Click();
            // SelectDropdownOption(1); //Selects "Repeat Business" in type field
            _comments.SetValue(testData["Comments"].ToString());

            // Enter a value into Amount cell
            var actions = new Actions(Session.Session.M360Session);
            actions.MoveToElement(_PhasingButton).MoveByOffset(0, 50);
            actions.Click();
            actions.Perform();
            actions.SendKeys(testData["Amount"].ToString());
            actions.Perform();

            _complete.ClickButton();
            _yes.ClickButton();
            _close.ClickButton();

        }

    }
}





