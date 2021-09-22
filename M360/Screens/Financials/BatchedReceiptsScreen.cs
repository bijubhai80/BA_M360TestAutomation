using OpenQA.Selenium.Appium;
using ElementControl;
using M360TestAutomation.Tests;
using Newtonsoft.Json.Linq;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;

namespace M360.Pages
{
    public class BatchedReceiptsScreen : BaseScreen
    {
        public AppiumWebElement _office
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Office");
            }
        }

        public AppiumWebElement _bankAccount
        {
            get
            {

                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Bank Account");
            }
        }

        public AppiumWebElement _bankAccountItem
        {
            get
            {

                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name,
                    BaseTest.JSONObjects["Financials"]["Standard"]["Bank Account"].ToString());
            }
        }

        public AppiumWebElement _add
        {
            get
            {

                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonAdd");
            }
        }
        public AppiumWebElement _ledger
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "jltaComboLedger");
            }
        }

        public AppiumWebElement _btnComplete
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonComplete");
            }
        }
        public AppiumWebElement _btnYes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonYes");
            }
        }
        

        public void setHeader(JToken testData)
        {
            _office.SetValue(testData["Office"].ToString());
            Session.Session.M360Session.Keyboard.SendKeys(Keys.Tab);
            _bankAccount.ClickButton();            
            Session.Session.M360Session.FindElementByName(testData["BankAccount"].ToString()).Click();
            _add.ClickButton();
        }
       



    }
}





