using ElementControl;
using OpenQA.Selenium.Appium;

namespace M360.Pages
{
    public class DirectDebitScreen : BaseScreen
    {
        public AppiumWebElement _yes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@Name='Script Error']//Button[@AutomationId='btnYes']");
            }
        }

        public AppiumWebElement _agree
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "I AGREE");
            }
        }

        public AppiumWebElement _next
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Next");
            }
        }

        public void fillDirectDebitDetails()
        {
            _yes.ClickButton();
            _agree.ClickButton();
            _next.ClickButton();
        }
    }
}
