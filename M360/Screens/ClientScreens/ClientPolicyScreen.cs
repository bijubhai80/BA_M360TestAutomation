using ElementControl;
using M360.Pages;
using OpenQA.Selenium.Appium;

namespace M360TestAutomation.Screens.ClientScreens
{
    public class ClientPolicyScreen : BaseScreen
    {
        public AppiumWebElement _policiesTab
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(M360.Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "tabPolicies");
            }
        }

        public void gotoPolicyTab()
        {
            SwitchToCurrentWindow();
            _policiesTab.Click();
        }
    }
}
