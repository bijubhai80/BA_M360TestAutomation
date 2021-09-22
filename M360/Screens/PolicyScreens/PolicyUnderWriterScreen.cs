using ElementControl;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium.Appium;

namespace M360.Pages
{
    public class PolicyUnderWriterScreen : BaseScreen
    {
        public AppiumWebElement _underWriterTab
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "tab0");
            }
        }

        public AppiumWebElement _underWriter
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "jltaCodeTandemUnderwriter");
            }
        }

        public AppiumWebElement _policyNum
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textUWPolNum");
            }
        }

        public AppiumWebElement _deleteUW
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Delete UW");
            }
        }

        public AppiumWebElement _addUW
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Add UW");
            }
        }

        public AppiumWebElement _yes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Yes");
            }
        }
        public AppiumWebElement _invalidUW
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textBoxMessage");
            }
        }

        public AppiumWebElement _OK
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Ok");
            }
        }

        public void setUnderWriter(JToken testData, bool changeUnderWriter = false)
        {
            _underWriterTab.ClickButton();
            if (changeUnderWriter)
            {
                _underWriter.SetValue(testData["UnderWriterModified"].ToString());
            }
            else
            {
                _underWriter.SetValue(testData["Underwriter"].ToString());
            }
            _policyNum.ClickButton();
        }

        public void deleteUnderWriter()
        {
            _deleteUW.ClickButton();
            _yes.ClickButton();
        }

        public void addUnderWriter(JToken testData)
        {
            var policyUnderWriterScreen = new PolicyUnderWriterScreen();
            policyUnderWriterScreen.setUnderWriter(testData, changeUnderWriter: true);
        }

        public void validateInactiveUW()
        {
            Assert.IsTrue(_invalidUW.Text.Contains("The following underwriter is no longer valid and will be deleted."));
            _OK.Click();
        }

    }
}
