using ElementControl;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Appium;

namespace M360.Pages
{
    public class BikeDealersArrangment : SchemesScreen
    {
        //schemes search
        public AppiumWebElement _riskPremium
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Custom[@ClassName='LowVolumeSchemesRiskPanelV02Wpf']/Text[@ClassName='TextBlock']");
            }
        }
        public AppiumWebElement _riskPremiumEdit
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Custom[@ClassName='LowVolumeSchemesRiskPanelV02Wpf']/Edit[@ClassName='TextBox']");
            }
        }

        public override void completeRisk(JToken testData)
        {
            _riskPremium.ClickButton();
            _riskPremiumEdit.SetValue(testData["RiskPremium"].ToString());
        }
    }
}
