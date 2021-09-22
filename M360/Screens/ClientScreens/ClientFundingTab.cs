using ElementControl;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace M360.Pages
{
    public class ClientFundingScreen : BaseScreen
    {
        public AppiumWebElement _fundingTab
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "tabFunding");
            }
        }

        public AppiumWebElement _details
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Details");
            }
        }

        public AppiumWebElement _new
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "New");
            }
        }

        public AppiumWebElement _yes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Yes");
            }
        }

        public AppiumWebElement _totalFunded
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Total Funded");
            }
        }

        public AppiumWebElement _continue
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Continue");
            }
        }


        public AppiumWebElement _getQuote
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "jltaButtonGetQuote");
            }
        }
        public AppiumWebElement _deselectAll
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonDeselectAll");
            }
        }

        public AppiumWebElement _save
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Save");
            }
        }

        public AppiumWebElement _close
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonClose");
            }
        }

        public AppiumWebElement _funder
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@Name=\"Funder\"][@AutomationId=\"codeTandemFunder\"]/Edit[@AutomationId=\"TextBoxCode\"]");
            }
        }

        public AppiumWebElement _status
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textBoxSubStatus");
            }
        }

        public AppiumWebElement _loanNo
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textBoxLoanNo");
            }
        }

        public void verifyFundingContract(JToken testData)
        {
            _fundingTab.ClickButton();
            _details.ClickButton();
            SwitchToCurrentWindow();
            var totalFunded = _totalFunded.Text;
            Assert.IsTrue(totalFunded.Contains(testData["TotalFunded1"].ToString()) || totalFunded.Contains(testData["TotalFunded2"].ToString()));
        }

        public void createQuote()
        {
            SwitchToCurrentWindow();
            _fundingTab.ClickButton();
            _new.ClickButton();
            if (_yes != null) _yes.ClickButton();
            SwitchToCurrentWindow();
            if (_continue != null)
            {
                _continue.Click();
            }
            //_getQuote.ClickButton();
            _deselectAll.ClickButton();
            Thread.Sleep(30000);

            Actions actions = new Actions(Session.Session.M360Session);
            actions.MoveByOffset(-100, -260);
            actions.Click();
            actions.Perform();

            _funder.SetValue("ATTVES");
            Session.Session.M360Session.Keyboard.PressKey(Keys.Tab);
            _status.SetValue("Quoted");
            _loanNo.SetValue("123456789");
            _save.ClickButton();
            _yes.ClickButton();
            if (_yes != null) _yes.ClickButton();
            wait.Until(driver => _close != null);
            _close.ClickButton();
            SwitchToCurrentWindow();
        }
    }
}







