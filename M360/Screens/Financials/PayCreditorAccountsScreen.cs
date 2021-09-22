using OpenQA.Selenium.Appium;
using ElementControl;
using M360TestAutomation.Tests;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using Newtonsoft.Json.Linq;

namespace M360.Pages
{
    public class PayCreditorAccountsScreen : BaseScreen
    {
        public AppiumWebElement _officeEllipses
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "jltaEllipseButtonBranch");
            }
        }

        public AppiumWebElement _office
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, BaseTest.JSONObjects["Financials"]["Standard"]["Office"].ToString());
            }
        }

        public AppiumWebElement _ouBtnAll
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonAll");
            }
        }

        public AppiumWebElement _ouBtnNone
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonNone");
            }
        }
        public AppiumWebElement _ouBtnOk
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonOK");
            }
        }
        public AppiumWebElement _creditorType
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "jltaComboBoxCreditorType");
            }
        }

        public AppiumWebElement _accountEllipses
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "jltaEllipseButtonAccount");
            }
        }

        
         public AppiumWebElement _accTypeBtnAll
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonAll");
            }
        }

        public AppiumWebElement _accTypeBtnOk
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonOK");
            }
        }
        
        public AppiumWebElement _btnBuild
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonBuild");
            }
        }
        public AppiumWebElement _messageBox
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "JibMessageBox");
            }
        }

        public AppiumWebElement _messageboxBtnYes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonYes");
            }
        }

        public AppiumWebElement _scrollDown
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "DownPageButton");
            }
        }

        public AppiumWebElement _bankAccount
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "jltaComboBoxBankAccount");
            }
        }

        public void processCreditorAccount(JToken testData)
        {
            //seelect office           
            _officeEllipses.ClickButton();
            
            _scrollDown.ClickButton();

            var actions = new Actions(Session.Session.M360Session);
            actions.MoveToElement(_ouBtnAll);
            actions.MoveByOffset(40, -40);
            actions.Click();
            actions.SendKeys(Keys.Space);
            actions.Perform();            

            _ouBtnOk.ClickButton();
            _bankAccount.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["BankAccount"].ToString()).Click();


            _creditorType.SetValue(testData["CreditorType"].ToString());
            _accountEllipses.ClickButton();
            
            _accTypeBtnAll.ClickButton();
            _accTypeBtnOk.ClickButton();
            _btnBuild.ClickButton();
            _messageBox.ClickButton();
            _messageboxBtnYes.ClickButton();

        }


    }
}





