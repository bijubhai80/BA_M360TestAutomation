using ElementControl;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Appium;

namespace M360.Pages
{
    public class PolicyEDIScreen : BaseScreen
    {
        public AppiumWebElement _ediProduct
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "EDI Product");
            }
        }

        public AppiumWebElement _newEDI
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_buttonNew");
            }
        }

        public AppiumWebElement _premiumSummaryTab
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "tab2");
            }
        }

        public AppiumWebElement _complete
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Complete");
            }
        }

        public AppiumWebElement _yes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Yes");
            }
        }

        public void completeEDI(JToken testData)
        {
            if (_yes != null) _yes.ClickButton();

            _ediProduct.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["EDIProduct"].ToString()).Click();
            Session.Session.M360Session.FindElementByName("tab5").Click();
            _newEDI.ClickButton();

            SwitchToCurrentWindow();

            var ediAccountScreen = new AccountDetailsScreen();
            ediAccountScreen.selectAccount();
            var ediCustomerScreen = new CustomerScreen();
            ediCustomerScreen.fillCustomerDetails();
            var ediAddressScreen = new AddressScreen();
            ediAddressScreen.fillAddressDetails(testData["Address"].ToString());
            var ediBuildingScreen = new BuildingContentsScreen();
            ediBuildingScreen.fillBuildingContentsDetails(testData);
            var premiumPaymentScreen = new PremiumPaymentScreen();
            premiumPaymentScreen.fillPremiumPaymentDetails();
            var ediPolicyScreen = new EDIPolicyScreen();
            ediPolicyScreen.confirmPolicy();
            var ediHistoryScreen = new HistoryScreen();
            ediHistoryScreen.fillHistoryDetails();
            var ediPremiumFinalScreen = new PremiumFinalScreen();
            ediPremiumFinalScreen.gotoPaymentTab();
            var ediPaymentScreen = new PaymentScreen();
            ediPaymentScreen.fillPaymentDetails();
            ediPremiumFinalScreen.confirmEDIPolicy();
            SwitchToCurrentWindow();

        }

        public void completeEDIPolicy(JToken testData)
        {
            var ediAccountScreen = new AccountDetailsScreen();
            ediAccountScreen.accountNumber();
            var ediCustomerScreen = new CustomerScreen();
            ediCustomerScreen.fillCustomerDetails();
            var ediAddressScreen = new AddressScreen();
            ediAddressScreen.fillAddressDetails(testData["Address"].ToString());
            var ediBuildingScreen = new BuildingContentsScreen();
            ediBuildingScreen.fillBuildingContentsDetails(testData);
            var premiumPaymentScreen = new PremiumPaymentScreen();
            premiumPaymentScreen.fillPremiumPaymentDetails();
            var ediPolicyScreen = new EDIPolicyScreen();
            ediPolicyScreen.confirmPolicy();
            var ediHistoryScreen = new HistoryScreen();
            ediHistoryScreen.fillHistoryDetails();
            var ediPremiumFinalScreen = new PremiumFinalScreen();
            ediPremiumFinalScreen.gotoPaymentTab();
            var ediPaymentScreen = new PaymentScreen();
            ediPaymentScreen.fillPaymentDetails();
            ediPremiumFinalScreen.confirmEDIPolicy();
            SwitchToCurrentWindow();

        }

        public void finaliseEDI()
        {
            _premiumSummaryTab.ClickButton();
            _complete.ClickButton();
            _yes.ClickButton();
            SwitchToCurrentWindow();
        }
    }
}
