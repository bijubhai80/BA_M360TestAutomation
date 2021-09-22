using OpenQA.Selenium.Appium;
using NUnit.Framework;
using ElementControl;
using OpenQA.Selenium.Interactions;
using System.Threading;
using OpenQA.Selenium;
using Newtonsoft.Json.Linq;

namespace M360.Pages
{
    public class ClientReceiptScreen : BaseScreen
    {
        public AppiumWebElement _type
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "jltaComboType");
            }
        }
        public AppiumWebElement _businessTypeField => GetElementByAccessibilityId("comboBoxBusinessType");
        public AppiumWebElement _commentsField => GetElementByAccessibilityId("richTextBox");
        public AppiumWebElement _PhasingButton => GetElementByAccessibilityId("_buttonPhasing");
        public AppiumWebElement _recieptType
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "jltaComboReceiptType");
            }
        }

        public AppiumWebElement _bankAccount
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "accountControl");
            }
        }

        public AppiumWebElement _amount
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "jltaCurrencyAmount");
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

        public void createReceipt()
        {
            _type.ClickButton();
            SelectDropdownOption(3);
            _bankAccount.ClickButton();
            Session.Session.M360Session.Keyboard.PressKey(Keys.PageDown);
            Session.Session.M360Session.Keyboard.PressKey(Keys.Enter);
            _recieptType.ClickButton();
            SelectDropdownOption(5);
            _amount.SetValue("5000");
            _complete.ClickButton();
            _yes.ClickButton();
            _close.ClickButton();
            SwitchToCurrentWindow();
            _close.ClickButton();
            SwitchToCurrentWindow();
        }

        public void createInvoice(JToken testData)
        {
            _type.ClickButton();
            SelectDropdownOption(1); //Selects "Invoice" in type field
            _businessTypeField.ClickButton();
            SelectDropdownOption(1); //Selects "Repeat Business" in type field
            _commentsField.SetValue(testData["Comments"].ToString());

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
            SwitchToCurrentWindow();
            _close.ClickButton();
            SwitchToCurrentWindow();
        }
    }
}







