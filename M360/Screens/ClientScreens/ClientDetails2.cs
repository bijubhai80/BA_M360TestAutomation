using System;
using OpenQA.Selenium.Appium;
using ElementControl;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace M360.Pages
{
    public class ClientDetails2 : BaseScreen
    {
        private AppiumWebElement _details2Tab =>
            WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "tabDetails2");

        private AppiumWebElement _comboBoxAgreementType => WinAppDriverControlMethods.GetElement(Session.Session.M360Session,
            WinAppDriverControlMethods.SearchBy.AccessibilityId, "_comboBoxAgreementType");

        private AppiumWebElement _dateDispatched => WinAppDriverControlMethods.GetElement(Session.Session.M360Session,
            WinAppDriverControlMethods.SearchBy.AccessibilityId, "DateTextBoxDispatched");

        private AppiumWebElement _dateAgreementSigned => WinAppDriverControlMethods.GetElement(Session.Session.M360Session,
            WinAppDriverControlMethods.SearchBy.AccessibilityId, "_dateTextBoxAgreementSigned");

        private AppiumWebElement _dateAgreementExpiry => WinAppDriverControlMethods.GetElement(Session.Session.M360Session,
            WinAppDriverControlMethods.SearchBy.AccessibilityId, "DateTextBoxAgreementExpiry");

        private AppiumWebElement _comboBoxLolAmount => WinAppDriverControlMethods.GetElement(Session.Session.M360Session,
            WinAppDriverControlMethods.SearchBy.AccessibilityId, "ComboBoxLolAmount");

        private AppiumWebElement _textComments => WinAppDriverControlMethods.GetElement(Session.Session.M360Session,
            WinAppDriverControlMethods.SearchBy.AccessibilityId, "richTextBox");

        private AppiumWebElement _checkNswSdExempt => WinAppDriverControlMethods.GetElement(Session.Session.M360Session,
            WinAppDriverControlMethods.SearchBy.AccessibilityId, "checkNswSdExempt");

        private AppiumWebElement _checkSanctionsScreening => WinAppDriverControlMethods.GetElement(Session.Session.M360Session,
            WinAppDriverControlMethods.SearchBy.AccessibilityId, "_sanctionsScreeningCheckBox");

        private AppiumWebElement _comboBoxLolAmountDownButton => WinAppDriverControlMethods.GetElement(Session.Session.M360Session,
            WinAppDriverControlMethods.SearchBy.XPath, "//ComboBox[@Name=\"LOL Amount\"]//Button[@Name=\"Open\"]");

        public void GotoDetails2Tab()
        {
            _details2Tab.ClickButton();
        }

        public void EnterDetails2(JToken testData)
        {
            _comboBoxAgreementType.SetValue(testData["Details2"]["AgreementType"].ToString());
            _dateDispatched.SetValue(testData["Details2"]["Dispatched"].ToString());
            _dateAgreementSigned.SetValue(testData["Details2"]["AgreementSigned"].ToString());
            _dateAgreementExpiry.SetValue(testData["Details2"]["AgreementExpiry"].ToString());
            _comboBoxLolAmountDownButton.ClickButton();
            _comboBoxLolAmount.FindElementByName(testData["Details2"]["LolAmount"].ToString()).ClickButton();
            _textComments.SetValue(testData["Details2"]["Comments"].ToString());
            _checkNswSdExempt.CheckBoxSetValue(Convert.ToBoolean(testData["Details2"]["NswSdExempt_bool"]));
            _checkSanctionsScreening.CheckBoxSetValue(Convert.ToBoolean(testData["Details2"]["SanctionsScreening_bool"]));
        }

        public void VerifyDetails2(JToken testData)
        {
            Assert.Contains(_comboBoxAgreementType.Text, new[] {testData["Details2"]["AgreementType"].ToString()});
            Assert.Contains(_dateDispatched.Text, new[] {testData["Details2"]["Dispatched"].ToString()});
            Assert.Contains(_dateAgreementSigned.Text, new[] {testData["Details2"]["AgreementSigned"].ToString()});
            Assert.Contains(_dateAgreementExpiry.Text, new[] {testData["Details2"]["AgreementExpiry"].ToString()});
            Assert.Contains(_comboBoxLolAmount.Text, new[] {testData["Details2"]["LolAmount"].ToString()});
            Assert.Contains(_textComments.Text.TrimEnd(), new[] { testData["Details2"]["Comments"].ToString() });
            Assert.Contains(_checkNswSdExempt.GetAttribute("Toggle.ToggleState"), new[] { Convert.ToBoolean(testData["Details2"]["NswSdExempt_bool"]) ? "1" : "0"});
            Assert.Contains(_checkSanctionsScreening.GetAttribute("Toggle.ToggleState"), new[] { Convert.ToBoolean(testData["Details2"]["SanctionsScreening_bool"]) ? "1" : "0" });
        }
    }
}







