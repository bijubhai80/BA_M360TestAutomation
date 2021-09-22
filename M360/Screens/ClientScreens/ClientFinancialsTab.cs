using OpenQA.Selenium.Appium;
using NUnit.Framework;
using ElementControl;
using OpenQA.Selenium.Interactions;
using System.Threading;
using Newtonsoft.Json.Linq;
using System;

namespace M360.Pages
{
    public class ClientFinancialScreen : BaseScreen
    {
        public AppiumWebElement _financialsTab
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "tabFinancials");
            }
        }

        public AppiumWebElement _ledger
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Ledger");
            }
        }

        public AppiumWebElement _new
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "New");
            }
        }

        public AppiumWebElement _ok
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Ok");
            }
        }

        public AppiumWebElement _account
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "_tabPageAccount");
            }
        }

        public AppiumWebElement _details
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Details");
            }
        }

        public AppiumWebElement _close
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Close");
            }
        }

        public AppiumWebElement _closeFee
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonClose");
            }
        }

        public AppiumWebElement _yes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Yes");
            }
        }

        public AppiumWebElement _reverse
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonReverse");
            }
        }

        public AppiumWebElement _ledgerClose
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonClose");
            }
        }

        public AppiumWebElement _currentstatement
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "_tabPageCurrentStatement");
            }
        }

        public AppiumWebElement _FeeInvoice
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonFeeInvoice");
            }
        }

        public AppiumWebElement _businessType
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "comboBoxBusinessType");
            }
        }

        public AppiumWebElement _commentfield
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "RichEdit Control");
            }
        }

        public AppiumWebElement _InvoiceComplete
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonComplete");
            }
        }

        public AppiumWebElement _invoiceComplete
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonComplete");
            }
        }

        

        public AppiumWebElement _PhasingButton
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_buttonPhasing");
            }
        }

        public AppiumWebElement _ledgerButton
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonLedger");
            }
        }

        public AppiumWebElement _clientButton
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Client");
            }
        }
        




        public AppiumWebElement _unallocatedCashField => GetElementByAccessibilityId("jltaSingleTextUnallocatedCash");


        public void createReceipt()
        {
            _financialsTab.ClickButton();
            _ledger.ClickButton();
            SwitchToCurrentWindow();
            _new.ClickButton();
            if (_ok != null) _ok.ClickButton();
            SwitchToCurrentWindow();
        }

        public void goToFinancialstab()
        {
            _financialsTab.Click();
        }

        public void selectpolicyTransaction()
        {

            var actions = new Actions(Session.Session.M360Session);
            actions.MoveToElement(_account).MoveByOffset(0, 83);
            actions.Click();
            actions.Perform();
        }

        public void selectnonpolicyTransaction()
        {
            //_currentstatement.Click();
            _account.Click();
            var actions = new Actions(Session.Session.M360Session);
            actions.MoveToElement(_account).MoveByOffset(0, 125);
            actions.Click();
            actions.Perform();
        }

        public void openPolicyTransaction()
        {
            _details.ClickButton();
            SwitchToCurrentWindow();
            _close.ClickButton();
            SwitchToCurrentWindow();
            var actions = new Actions(Session.Session.M360Session);
            actions.MoveToElement(_account).MoveByOffset(0, 83);
            actions.DoubleClick();
            actions.Perform();
            SwitchToCurrentWindow();
            _close.ClickButton();

        }

        public void opennonPolicyTransaction()
        {
            _details.ClickButton();

        }

        public void goToledger()
        {
            _ledgerButton.ClickButton();
            SwitchToCurrentWindow();
            _ledgerClose.ClickButton();
            SwitchToCurrentWindow();
            _ledgerButton.ClickButton();
            SwitchToCurrentWindow();
            _clientButton.ClickButton();
            SwitchToCurrentWindow();


        }

        public void ReversenonPolicyTransaction()
        {
            _reverse.ClickButton();
            _yes.ClickButton();
            _ledgerClose.ClickButton();

        }

        public void CreateFeeInvoice(JToken testData)
        {
            _FeeInvoice.ClickButton();
            SwitchToCurrentWindow();
            _businessType.ClickButton();
            SelectDropdownOption(1);
            _commentfield.SetValue(testData["Comments"].ToString());
            var actions = new Actions(Session.Session.M360Session);
            actions.MoveToElement(_PhasingButton).MoveByOffset(0, 50);
            actions.Click();
            actions.Perform();
            actions.SendKeys(testData["Amount"].ToString());
            actions.Perform();
            _invoiceComplete.ClickButton();
            _closeFee.ClickButton();
            SwitchToCurrentWindow();
        }
        public bool isUnalloactedCashZero()
        {
            if (_unallocatedCashField.Text == "$0.00")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}







