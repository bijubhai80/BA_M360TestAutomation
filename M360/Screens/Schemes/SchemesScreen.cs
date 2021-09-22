using ElementControl;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Appium;

namespace M360.Pages
{
    public class SchemesScreen : BaseScreen
    {
        public AppiumWebElement _office
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "jltaCodeTandemBranch");
            }
        }

        public AppiumWebElement _clientCode
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "clientCodeTextBox");
            }
        }

        public AppiumWebElement _scheme
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "jltaComboBoxScheme");
            }
        }

        public AppiumWebElement _newPolicy
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonNewPolicy");
            }
        }

        public void createSchemePolicy(JToken testData)
        {
            SwitchToCurrentWindow();
            _office.SetValue(testData["Office"].ToString());
            _clientCode.ClickButton();
            _scheme.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["Scheme"].ToString()).Click();
            _newPolicy.ClickButton();
            SwitchToCurrentWindow();
        }

        public virtual void completeRisk(JToken testData)
        {
        }
    }
}

