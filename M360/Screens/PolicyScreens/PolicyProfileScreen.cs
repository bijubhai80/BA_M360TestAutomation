using OpenQA.Selenium.Appium;
using ElementControl;
using M360TestAutomation.Tests;
using Newtonsoft.Json.Linq;

namespace M360.Pages
{
    public class PolicyProfileScreen : BaseScreen
    {
        //policyDocumentBuilder
        public AppiumWebElement _save
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonSave");
            }
        }

        public AppiumWebElement _scheduleTab
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "tab4");
            }
        }

        public AppiumWebElement _profileButton
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_radioProfile");
            }
        }

        public AppiumWebElement _profileType
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_profileComboBox");
            }
        }

        public AppiumWebElement _attach
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_buttonAttach");
            }
        }

        public AppiumWebElement _schedule
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Schedule");
            }
        }

        public AppiumWebElement _scheduleText
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "richTextBox");
            }
        }

        public void attachProfile(JToken testData)
        {
            _scheduleTab.ClickButton();
            _profileButton.ClickButton();
            _profileType.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["ProfileType"].ToString()).Click();
            _attach.ClickButton();
            _save.ClickButton();
        }

        public void setSchedule(JToken testData)
        {
            _scheduleTab.ClickButton();
            _schedule.ClickButton();
            _scheduleText.SetValue(testData["ScheduleText"].ToString());
            _save.ClickButton();
        }
    }
}
