using ElementControl;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace M360.Pages
{
    public class AutomaticClientAllocationScreen : BaseScreen
    {
        public AppiumWebElement _officeEllipsesButton => GetElementByAccessibilityId("buttonEllipsis");
        public AppiumWebElement _processButton => GetElementByAccessibilityId("buttonProcess");
        public AppiumWebElement _yesButton => GetElementByAccessibilityId("buttonYes");
        public AppiumWebElement _okButton => GetElementByAccessibilityId("buttonOk");
        public AppiumWebElement _closeButton => GetElementByAccessibilityId("buttonClose");

        public AppiumWebElement _ouBtnOk => GetElementByAccessibilityId("buttonOK");

        public AppiumWebElement _buttonCancel => GetElementByAccessibilityId("buttonCancel");

        public AppiumWebElement _ouBtnAll => GetElementByAccessibilityId("buttonAll");

        public AppiumWebElement _scrollDown
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "DownPageButton");
            }
        }

        public void selectOffice(JToken testData)
        {
            if (_officeEllipsesButton != null)
            {
                _officeEllipsesButton.ClickButton();

                var actions = new Actions(Session.Session.M360Session);
                actions.MoveToElement(_buttonCancel);
                actions.MoveByOffset(10, -20);
                actions.Click();
                _scrollDown.ClickButton();
                var actions1 = new Actions(Session.Session.M360Session);
                actions1.MoveToElement(_ouBtnAll);
                actions1.MoveByOffset(25, -300);
                actions1.Click();
                actions1.SendKeys(Keys.Space);
                actions1.Perform();
                _ouBtnOk.ClickButton();
                //var selectOrgUnits = new BranchScreen();
                //selectOrgUnits.selectBranch(testData);
            }
            /*var actions = new Actions(Session.Session.M360Session);
            actions.MoveToElement(_buttonCancel);
            actions.MoveByOffset(10, -20);
            actions.Click();
            _scrollDown.ClickButton();
            var actions = new Actions(Session.Session.M360Session);
            actions.MoveToElement(_ouBtnAll);
            actions.MoveByOffset(20, -300);
            actions.Click();
            actions.SendKeys(Keys.Space);
            actions.Perform();
            _ouBtnOk.ClickButton();*/
        }

        public void selectCurrency()
        {

        }

        public void selectDebtWriteOff()
        {

        }

        public void process()
        {
            _processButton.ClickButton();
            _yesButton.ClickButton();

            while (_okButton == null)
            {
                Thread.Sleep(500);
            }
            _okButton.ClickButton();
        }

        public void close()
        {
            _closeButton.ClickButton();
            SwitchToCurrentWindow();
        }

    }
}





