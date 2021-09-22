using ElementControl;
using OpenQA.Selenium.Appium;

namespace M360.Pages
{
    public class PremiumFinalScreen : BaseScreen
    {
        public AppiumWebElement _yes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@Name='Script Error']//Button[@AutomationId='btnYes']");
            }
        }

        public AppiumWebElement _complete
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "completeMenuLink");
            }
        }

        public AppiumWebElement _completeTransaction
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Complete Transaction");
            }
        }

        public AppiumWebElement _next
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Next");
            }
        }

        public void confirmEDIPolicy()
        {
            _yes.ClickButton();
            _complete.ClickButton();
            _completeTransaction.ClickButton();
        }

        public void gotoPaymentTab()
        {
            _yes.ClickButton();
            _next.ClickButton();
        }
    }
}



