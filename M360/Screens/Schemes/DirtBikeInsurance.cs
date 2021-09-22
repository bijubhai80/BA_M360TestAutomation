using ElementControl;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System.Linq;

namespace M360.Pages
{
    public class DirtBikesInsurance : SchemesScreen
    {
        //add bike
        public AppiumWebElement _year
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "comboBoxYear");
            }
        }

        public AppiumWebElement _make
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textBoxMake");
            }
        }
        public AppiumWebElement _model
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textBoxModel");
            }
        }
        public AppiumWebElement _variant
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textBoxVariant");
            }
        }

        public AppiumWebElement _vin
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textBoxVin");
            }
        }

        public AppiumWebElement _marketValue
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textBoxMarketValue");
            }
        }

        public AppiumWebElement _accessories
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textBoxAccessories");
            }
        }

        public AppiumWebElement _regNo
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textBoxRegNo");
            }
        }

        public AppiumWebElement _listOfAccessories
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textBoxListOfAccessories");
            }
        }

        public AppiumWebElement _financeCo
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@AutomationId='jltaCodeTandemFinanceCo']/Edit[@AutomationId='TextBoxCode']");
            }
        }

        public AppiumWebElement _addBike
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonAddBike");
            }
        }

        public AppiumWebElement _yes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Yes");
            }
        }

        public AppiumWebElement _downButton
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "DownPageButton");
            }
        }

        public AppiumWebElement _upButton
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "UpPageButton");
            }
        }

        //questionnairre
        public AppiumWebElement _questionairreTab
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "tabPageQuestionnaire");
            }
        }

        public AppiumWebElement _policyDeclined
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@AutomationId='panelIsPolicyDeclined']//RadioButton[@AutomationId='radioButtonNo']");
            }
        }

        public AppiumWebElement _criminalConviction
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@AutomationId='panelIsCriminalConviction']//RadioButton[@AutomationId='radioButtonNo']");
            }
        }

        public AppiumWebElement _threeClaims
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@AutomationId='panelIsInsuraceClaim']//RadioButton[@AutomationId='radioButtonNo']");
            }
        }

        public AppiumWebElement _trafficFines
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@AutomationId='panelIsTrafficfines']//RadioButton[@AutomationId='radioButtonNo']");
            }
        }

        public AppiumWebElement _bankrupt
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@AutomationId='_panelTextYesNoBankrupt']//RadioButton[@AutomationId='radioButtonNo']");
            }
        }

        public AppiumWebElement _source
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_comboBoxSource");
            }
        }

        public AppiumWebElement _address
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Edit[starts-with(@AutomationId,'_textAddress')]");
            }
        }

        public AppiumWebElement _state
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_comboState");
            }
        }

        public AppiumWebElement _postCode
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_textPostCode");
            }
        }

        public AppiumWebElement _referral
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_comboBoxReferralStatus");
            }
        }

        public AppiumWebElement _save
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_comboBoxReferralStatus");
            }
        }

        public AppiumWebElement _deleteBike
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonDeleteBike");
            }
        }

        public AppiumWebElement _payer
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "comboBoxPayer");
            }
        }

        public AppiumWebElement _ok
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Ok");
            }
        }

        public override void completeRisk(JToken testData)
        {
            if (_ok != null)
            {
                _ok.Click();
            }
            _referral.ClickButton();
            Session.Session.M360Session.FindElementByName("Accepted").Click();

            _year.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["Year"].ToString()).Click();
            _make.SetValue(testData["Make"].ToString());
            _model.SetValue(testData["Model"].ToString());
            _variant.SetValue(testData["Variant"].ToString());
            _vin.SetValue(testData["VIN"].ToString());
            _marketValue.SetValue(testData["MarketValue"].ToString());
            _accessories.SetValue(testData["Accessories"].ToString());
            _regNo.SetValue(testData["RegNo"].ToString());
            _listOfAccessories.SetValue(testData["ListOfAccessories"].ToString());
            _financeCo.SetValue(testData["FinanceCo"].ToString());
            _listOfAccessories.ClickButton();
            _addBike.ClickButton();

            _deleteBike.ClickButton();
            _yes.ClickButton();

            _questionairreTab.ClickButton();
            _policyDeclined.ClickButton();
            _criminalConviction.ClickButton();
            _threeClaims.ClickButton();
            Session.Session.M360Session.FindElementsByAccessibilityId("DownPageButton").ElementAt(0).Click();
            _trafficFines.ClickButton();
            _bankrupt.ClickButton();
            _source.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["Source"].ToString()).Click();
            Session.Session.M360Session.Keyboard.SendKeys(Keys.Tab);
            Session.Session.M360Session.Keyboard.SendKeys(testData["Address"].ToString());
            Session.Session.M360Session.FindElementsByAccessibilityId("_comboState").ElementAt(1).Click();
            Session.Session.M360Session.FindElementByName(testData["State"].ToString()).Click();
            Session.Session.M360Session.FindElementsByAccessibilityId("_textPostCode").ElementAt(1).SendKeys(testData["PostCode"].ToString());

            _payer.Click();
            Session.Session.M360Session.FindElementByName("Client").Click();
        }
    }


}

