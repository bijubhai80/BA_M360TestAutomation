using ElementControl;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
//using System.Windows.Forms;

namespace M360.Pages
{
    public class RolesScreen : BaseScreen
    {
        //Need to amend the broker if you are selecting different broker.
        public AppiumWebElement _roles => GetElementByName("_All privileges");
        public AppiumWebElement _scrollBar => GetElementByAccessibilityId("DownPageButton");
        public AppiumWebElement _dmgReviewClient => GetElementByName("DMG Review Clients");
        public AppiumWebElement _save => GetElementByAccessibilityId("buttonSave");
        public AppiumWebElement _close => GetElementByAccessibilityId("buttonClose");

        public void assignPermission()
        {
            _roles.ClickButton();
            Session.Session.M360Session.Keyboard.PressKey(Keys.Tab);
        }

        public void setBroker()
        {

            _roles.ClickButton();
            Session.Session.M360Session.Keyboard.PressKey(Keys.Tab);
        }

        public void checkBrokerRole()
        {
            var homeScreen = new HomeScreen();
            homeScreen.gotoMenu();
            homeScreen.gotoUtilities();
            homeScreen.gotoSecurity();
            // homeScreen.usersMenu();

        }
        public void selectRoles()
        {
            if (_dmgReviewClient != null)
            {
                _dmgReviewClient.ClickButton();
                Session.Session.M360Session.Keyboard.PressKey(Keys.Space);
                _save.ClickButton();
                wait.Timeout = new TimeSpan(0, 3, 60);
                wait.Until(driver => _save != null);
                wait.Timeout = new TimeSpan(0, 1, 30);
                _close.ClickButton();
            }
            else
            {
                _close.ClickButton();
            }

        }
    }
}
