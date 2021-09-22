using OpenQA.Selenium.Appium;
using ElementControl;

namespace M360.Pages
{
    public class PaymentScreen : BaseScreen
    {
        public AppiumWebElement _yes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@Name='Script Error']//Button[@AutomationId='btnYes']");
            }
        }

        public AppiumWebElement _next
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Next");
            }
        }
        
        public void fillPaymentDetails()
        {
            if(_yes != null) _yes.ClickButton();
            _next.ClickButton();
        }        
    }
}




