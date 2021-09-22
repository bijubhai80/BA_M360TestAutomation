using ElementControl;
using OpenQA.Selenium.Appium;

namespace M360.Pages
{
    public class PremiumPaymentScreen : BaseScreen
    {
        public AppiumWebElement _yes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@Name='Script Error']//Button[@AutomationId='btnYes']");
            }
        }
        public AppiumWebElement _save
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Save");
            }
        }

        public void fillPremiumPaymentDetails()
        {
            _yes.ClickButton();
            _save.ClickButton();
        }
    }
}






