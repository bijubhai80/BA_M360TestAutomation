using ElementControl;
using M360.Pages;
using OpenQA.Selenium.Appium;

namespace M360TestAutomation.Screens.UserScreens
{
    public class UserSearchScreen : BaseScreen
    {

        private AppiumWebElement TextUsername => WinAppDriverControlMethods.GetElement(M360.Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId,
            "textBoxUserName");

        private AppiumWebElement ButtonSearch => WinAppDriverControlMethods.GetElement(M360.Session.Session.M360Session,
            WinAppDriverControlMethods.SearchBy.AccessibilityId,
            "buttonSearch");

        public AppiumWebElement ButtonClose =>
            WinAppDriverControlMethods.GetElement(M360.Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Close");


        public void SearchUser(string username)
        {
            SwitchToCurrentWindow();
            TextUsername.SetValue(username);
            ButtonSearch.ClickButton();
            SwitchToCurrentWindow();
        }
    }
}
