using ElementControl;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System.Threading;

namespace M360.Pages
{
    public class AccountDetailsScreen : BaseScreen
    {
        //lapse
        public AppiumWebElement _yes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@Name='Script Error']//Button[@AutomationId='btnYes']");
            }
        }

        public AppiumWebElement _yesInsurer
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Yes");
            }
        }

        public AppiumWebElement _accountNumber
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//DataItem[position()=11]/ComboBox");
            }
        }

        public AppiumWebElement _save
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Save");
            }
        }

        public void selectAccount()
        {
            _yes.ClickButton();
            if (_yesInsurer != null) _yesInsurer.ClickButton();
            _accountNumber.ClickButton();
            Thread.Sleep(5000);
            Session.Session.M360Session.Keyboard.PressKey(Keys.ArrowDown);
            Session.Session.M360Session.Keyboard.PressKey(Keys.Enter);
            _save.ClickButton();
        }
        public void accountNumber()
        {
            _accountNumber.ClickButton();
        }
    }
}





