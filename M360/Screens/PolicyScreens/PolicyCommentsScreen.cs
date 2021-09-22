using OpenQA.Selenium.Appium;
using ElementControl;
using M360TestAutomation.Tests;
using Newtonsoft.Json.Linq;

namespace M360.Pages
{
    public class PolicyCommentsScreen : BaseScreen
    {
        public AppiumWebElement _commentsTab
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "tab8");
            }
        }

        public AppiumWebElement _commentsText
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "richTextBox");
            }
        }

        public AppiumWebElement _save
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Save");
            }
        }


        public void setComments(JToken testData)
        {
            _commentsTab.ClickButton();
            _commentsText.SetValue(testData["CommentsText"].ToString());
            _save.ClickButton();
        }
    }
}
