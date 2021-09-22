using ElementControl;
using OpenQA.Selenium.Appium;

namespace M360.Pages
{
    public class CustomerScreen : BaseScreen
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

        public void fillCustomerDetails()
        {
            _yes.ClickButton();
            _next.ClickButton();
        }
    }
}
