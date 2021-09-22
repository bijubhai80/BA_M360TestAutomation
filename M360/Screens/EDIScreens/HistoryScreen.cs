using OpenQA.Selenium.Appium;
using ElementControl;
using M360TestAutomation.Tests;

namespace M360.Pages
{
    public class HistoryScreen : BaseScreen
    {
        public AppiumWebElement _yes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@Name='Script Error']//Button[@AutomationId='btnYes']");
            }
        }

        public AppiumWebElement _refusedInsurance
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "question01Answer");
            }
        }
        public AppiumWebElement _conviction
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "question02Answer");
            }
        }

        public AppiumWebElement _loss
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "question03Answer");
            }
        }

        public AppiumWebElement _next
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Next");
            }
        }        

        public void fillHistoryDetails()
        {
            _yes.ClickButton();
            _refusedInsurance.ClickButton();
            SelectDropdownOption(2);
            _conviction.ClickButton();
            SelectDropdownOption(2); 
            _loss.ClickButton();
            SelectDropdownOption(2);
            _next.ClickButton();
        }        
    }
}
