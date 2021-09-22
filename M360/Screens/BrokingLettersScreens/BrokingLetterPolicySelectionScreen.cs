using ElementControl;
using M360.Pages;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;

namespace M360
{
    public class BrokingLetterPolicySelectionScreen : BaseScreen
    {
        public AppiumWebElement _buttonSearch => GetElementByAccessibilityId("buttonSearch");
        public AppiumWebElement _gridPolicies => GetElementByAccessibilityId("gridPolicies");
        public AppiumWebElement _okButton => GetElementByAccessibilityId("buttonOkay");
        public void searchBrokingLetterPolicy()
        {
            if (_buttonSearch != null) _buttonSearch.ClickButton();

        }

        public void selectPolicyFromGrid()
        {
            SwitchToCurrentWindow();
            Actions action = new Actions(Session.Session.M360Session);
            action.MoveByOffset(-700, 58);
            action.Click();
            action.DoubleClick();
            action.Perform();
        }


    }
}
