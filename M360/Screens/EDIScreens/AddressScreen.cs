using ElementControl;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System.Threading;

namespace M360.Pages
{
    public class AddressScreen : BaseScreen
    {
        public AppiumWebElement _yes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@Name='Script Error']//Button[@AutomationId='btnYes']");
            }
        }

        public AppiumWebElement _address
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "addressSearch");
            }
        }

        public AppiumWebElement _street
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "situationAddressStreet");
            }
        }

        public AppiumWebElement _save
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Save");
            }
        }

        public void fillAddressDetails(string address)
        {
            _yes.ClickButton();
            _address.SetValue(address);
            _address.ClickButton();
            Thread.Sleep(5000);
            Session.Session.M360Session.Keyboard.SendKeys(Keys.Down);
            Session.Session.M360Session.Keyboard.SendKeys(Keys.Down);
            Session.Session.M360Session.Keyboard.SendKeys(Keys.Enter);
            wait.Until(driver => address.ToUpper().Contains(_street.Text));
            _save.ClickButton();
        }
    }
}






