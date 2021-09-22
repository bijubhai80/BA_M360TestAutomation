using OpenQA.Selenium.Appium;
using ElementControl;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace M360.Pages
{
    public class ClientDetails1 : BaseScreen
    {
        public AppiumWebElement _address1
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textAddress1");
            }
        }

        public AppiumWebElement _address2
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textAddress2");
            }
        }

        public AppiumWebElement _address3
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textAddress3");
            }
        }

        public AppiumWebElement _address4
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textAddress4");
            }
        }

        public AppiumWebElement _state
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "jltaComboBoxState");
            }
        }

        public AppiumWebElement _postCode
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textPostCode");
            }
        }

        public AppiumWebElement _position
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textPosition");
            }
        }

        public AppiumWebElement _contact
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textContact");
            }
        }

        public AppiumWebElement _phoneNumber
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textPhoneNumber");
            }
        }

        public AppiumWebElement _faxNumber
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textFaxNumber");
            }
        }

        public AppiumWebElement _email
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textEmail");
            }
        }

        public AppiumWebElement _mobile
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textMobile");
            }
        }

        public AppiumWebElement _webAddress
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textWebAddress");
            }
        }

        public AppiumWebElement _salutation
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textSalutation");
            }
        }

        public AppiumWebElement _broker1
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[starts-with(@AutomationId,'jltaCodeTandemBroker1')]/ComboBox[@AutomationId='comboBoxItem']");
            }
        }

        public AppiumWebElement _broker2
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[starts-with(@AutomationId,'jltaCodeTandemBroker2')]/ComboBox[@AutomationId='comboBoxItem']");
            }
        }

        public AppiumWebElement _edit
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Edit");
            }
        }

        public AppiumWebElement _ok
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Ok");
            }
        }

        public void enterDetails1(JToken testData)
        {
            if(_ok!=null)
            {
                _ok.ClickButton();
                SwitchToCurrentWindow();
            }
            _edit.ClickButton();
            _address1.SetValue(testData["Address1"].ToString());
            _address2.SetValue(testData["Address2"].ToString());
            _address3.SetValue(testData["Address3"].ToString());
            _address4.SetValue(testData["Address4"].ToString());
            _state.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["State"].ToString()).Click();
            _postCode.SetValue(testData["PostCode"].ToString());
            _contact.SetValue(testData["Contact"].ToString());
            _position.SetValue(testData["Position"].ToString());
            _phoneNumber.SetValue(testData["Phone"].ToString());
            _mobile.SetValue(testData["Mobile"].ToString());
            _faxNumber.SetValue(testData["Fax"].ToString());
            _email.SetValue(testData["Email"].ToString());
            _salutation.SetValue(testData["Salutation"].ToString());
            _webAddress.SetValue(testData["Web"].ToString());
            _broker1.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["Broker1"].ToString()).Click();
            _broker2.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["Broker2"].ToString()).Click();
        }

        public void verifyDetails1(JToken testData)
        {
            Assert.Contains(_address1.Text, new string[] { testData["Address1"].ToString() });
            Assert.Contains(_address2.Text, new string[] { testData["Address2"].ToString() });
            Assert.Contains(_address3.Text, new string[] { testData["Address3"].ToString() });
            Assert.Contains(_address4.Text, new string[] { testData["Address4"].ToString() });
            Assert.Contains(_state.Text, new string[] { testData["State"].ToString() });
            Assert.Contains(_postCode.Text, new string[] { testData["PostCode"].ToString() });
            Assert.Contains(_position.Text, new string[] { testData["Position"].ToString() });
            Assert.Contains(_contact.Text, new string[] { testData["Contact"].ToString() });
            Assert.Contains(_phoneNumber.Text, new string[] { testData["Phone"].ToString() });
            Assert.Contains(_faxNumber.Text, new string[] { testData["Fax"].ToString() });
            Assert.Contains(_email.Text, new string[] { testData["Email"].ToString() });
            Assert.Contains(_mobile.Text, new string[] { testData["Mobile"].ToString() });
            Assert.Contains(_webAddress.Text, new string[] { testData["Web"].ToString() });
            Assert.Contains(_salutation.Text, new string[] { testData["Salutation"].ToString() });
            Assert.Contains(_broker1.Text, new string[] { testData["Broker1"].ToString()});
            Assert.Contains(_broker2.Text, new string[] { testData["Broker2"].ToString()});
        }
    }
}







