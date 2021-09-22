using ElementControl;
using M360.Screens;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace M360.Pages
{
    class GeneralLedgerInquiry : BaseScreen
    {



        public AppiumWebElement _generalLedgerInquiry
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "General Ledger Inquiry");
            }
        }

        public AppiumWebElement _branchledger
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textBoxCode");
            }
        }

        public AppiumWebElement _account
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonAccount");
            }
        }

        public AppiumWebElement _buttonOk
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonOK");
            }
        }

        public AppiumWebElement _buttonCancel
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonCancel");
            }
        }

        public AppiumWebElement _scrollDown
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "DownButton");
            }
        }

        public AppiumWebElement _buttonClose
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonClose");
            }
        }

        public AppiumWebElement _policyClose
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonClose");
            }
        }


        public AppiumWebElement _buttonDetails
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonDetails");
            }
        }

        public AppiumWebElement _export
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonExportGLInquiry");
            }
        }






        public void gotoGeneralLedgerInquiry(JToken testData)
        {
            _generalLedgerInquiry.ClickButton();
            SwitchToCurrentWindow();
            _branchledger.SetValue(testData["Office"].ToString());
            SelectAccount_DepartmentAndMarketSegment();
            SelectTransaction();
            _buttonDetails.ClickButton();
            SwitchToCurrentWindow();
            _policyClose.ClickButton();
            SwitchToCurrentWindow();
            Export();
            _buttonClose.ClickButton();

        }

        public void gotoGeneralLedgerInquiry_BankAccount(JToken testData)
        {
            _generalLedgerInquiry.ClickButton();
            SwitchToCurrentWindow();
            _branchledger.SetValue(testData["Office"].ToString());
            SelectAccount_BankAccount();

            SelectTransaction();
            _buttonDetails.ClickButton();
            SwitchToCurrentWindow();
            _policyClose.ClickButton();
            SwitchToCurrentWindow();
            Export();
            _buttonClose.ClickButton();

        }

        public void gotoGeneralLedgerInquiry_ControlAccount(JToken testData)
        {
            _generalLedgerInquiry.ClickButton();
            SwitchToCurrentWindow();
            _branchledger.SetValue(testData["Office"].ToString());
            SelectAccount_ControlAccount();

            SelectTransaction();
            _buttonDetails.ClickButton();
            SwitchToCurrentWindow();
            _policyClose.ClickButton();
            SwitchToCurrentWindow();
            Export();
            _buttonClose.ClickButton();

        }

        public void SelectAccount_DepartmentAndMarketSegment()
        {

            _account.ClickButton();
            Thread.Sleep(1000);
            //select Department/market segment
            var actions = new Actions(Session.Session.M360Session);
            actions.MoveToElement(_buttonCancel);
            actions.MoveByOffset(-214, -513);
            actions.DoubleClick();
            actions.Perform();
            //select construction(052)
            var actions1 = new Actions(Session.Session.M360Session);
            actions1.MoveToElement(_buttonCancel);
            actions1.MoveByOffset(-273, -172);
            actions1.DoubleClick();
            actions1.Perform();
            //select Brokerage Account
            var actions2 = new Actions(Session.Session.M360Session);
            actions2.MoveToElement(_buttonCancel);
            actions2.MoveByOffset(-320, -97);
            actions2.DoubleClick();
            actions2.Perform();
            //select  Brokerage, Team 052, AC, Repeat Business
            _scrollDown.Click();
            _scrollDown.Click();
            var actions3 = new Actions(Session.Session.M360Session);
            actions3.MoveToElement(_buttonCancel);
            actions3.MoveByOffset(-320, -39);
            actions3.Click();
            actions3.Perform();
            Thread.Sleep(2000);
            _buttonOk.ClickButton();
        }


        public void SelectAccount_BankAccount()
        {

            _account.ClickButton();
            Thread.Sleep(1000);
            var actions = new Actions(Session.Session.M360Session);
            actions.MoveToElement(_buttonCancel);
            actions.MoveByOffset(-345, -477);
            actions.DoubleClick();
            actions.Perform();
            // Thread.Sleep(2000);

            var actions3 = new Actions(Session.Session.M360Session);
            actions3.MoveToElement(_buttonCancel);
            actions3.MoveByOffset(-356, -458);
            actions3.Click();
            actions3.Perform();
            Thread.Sleep(2000);
            _buttonOk.ClickButton();
        }

        public void SelectAccount_ControlAccount()
        {

            _account.ClickButton();
            Thread.Sleep(1000);
            var actions = new Actions(Session.Session.M360Session);
            actions.MoveToElement(_buttonCancel);
            actions.MoveByOffset(-314, -496);
            actions.DoubleClick();
            actions.Perform();
            // Thread.Sleep(2000);

            var actions3 = new Actions(Session.Session.M360Session);
            actions3.MoveToElement(_buttonCancel);
            actions3.MoveByOffset(-358, -477);
            actions3.Click();
            actions3.Perform();
            Thread.Sleep(2000);
            _buttonOk.ClickButton();
        }

        public void SelectTransaction()
        {
            var actions = new Actions(Session.Session.M360Session);
            actions.MoveToElement(_buttonClose);
            actions.MoveByOffset(-243, -323);
            actions.DoubleClick();
            actions.Perform();
        }

        public void Export()
        {
            _export.ClickButton();
            var excelDoc = new ExcelDocument();
            excelDoc.saveExcel();

        }


    }
}
