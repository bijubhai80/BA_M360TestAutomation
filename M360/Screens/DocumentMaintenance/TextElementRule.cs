using ElementControl;
using M360.Pages;
using OpenQA.Selenium.Appium;

namespace M360TestAutomation.Screens.DocumentMaintenance
{
    public class TextElementRule : BaseScreen
    {
        public AppiumWebElement _closeButton
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(M360.Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonClose");
            }
        }

        public AppiumWebElement _saveButton
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(M360.Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonSave");
            }
        }


        public AppiumWebElement _addButton
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(M360.Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonAddAction");
            }
        }

        public void closeDetails()
        {
            SwitchToCurrentWindow();
            _closeButton.ClickButton();
        }

        public void addNewRule()
        {
            SwitchToCurrentWindow();
            _addButton.ClickButton();

            var newRuleScreenOk = WinAppDriverControlMethods.GetElement(M360.Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonCreateOk");
            newRuleScreenOk.ClickButton();

            _saveButton.ClickButton();
        }
    }
}
