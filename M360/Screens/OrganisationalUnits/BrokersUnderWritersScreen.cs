using OpenQA.Selenium.Appium;
using System;
using OpenQA.Selenium;
using System.IO;
using ElementControl;
using M360TestAutomation.Tests;
using Newtonsoft.Json.Linq;

namespace M360.Pages
{
    public class BrokersUnderWritersScreen : BaseScreen
    {
        public AppiumWebElement _findText
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textFindWhat");
            }
        }

        public AppiumWebElement _find
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonFind");
            }
        }

        public AppiumWebElement _close
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonClose");
            }
        }

        public AppiumWebElement _securityTab
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "tabPageSecurity");
            }
        }

        public AppiumWebElement _active
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "checkBoxActive");
            }
        }

        public AppiumWebElement _yes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Yes");
            }
        }

        public AppiumWebElement _reason
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Reason Inactive");
            }
        }


        public AppiumWebElement _save
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Save");
            }
        }

        public AppiumWebElement _all
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "radioAll");
            }
        }

        public void toggleUW(JToken testData)
        {
            SwitchToCurrentWindow();
            _all.ClickButton();
            _find.ClickButton();
            _findText.SetValue(testData["UnderWriterModified"].ToString());
            _find.ClickButton();
            _close.ClickButton();
            _securityTab.ClickButton();
            _active.ClickButton();
            if (_yes != null) {
                _yes.ClickButton();
            }            
            if (_reason != null)
            {
                _reason.SetValue(testData["UWReason"].ToString());
            }
            _save.ClickButton();
            _close.ClickButton();
            SwitchToCurrentWindow();
        }
    }
}
