using ElementControl;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using System.Linq;

namespace M360.Pages
{
    public class eFileScreen : BaseScreen
    {
        public AppiumWebElement _eFileTab
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "tab11");
            }
        }

        public AppiumWebElement _clientDocs
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Client Documents");
            }
        }

        public AppiumWebElement _generalFolder
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "General");
            }
        }
        public AppiumWebElement _Ok
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Ok");
            }
        }

        public string GetClosingFileNameFromEfileTab()
        {
            if (_Ok != null) _Ok.ClickButton();
            _eFileTab.Click();
            _clientDocs.ClickButton();

            var actions = new Actions(Session.Session.M360Session);
            actions.MoveToElement(_generalFolder).DoubleClick();
            actions.Perform();

            var _dispatchNotice = Session.Session.M360Session.FindElementsByXPath("//Text[starts-with(@AutomationId,\"ListViewSubItem-\")]")
                .First(t => t.Text.ToUpper().Contains("CLOSING"));
            return _dispatchNotice.Text;
        }
    }
}
