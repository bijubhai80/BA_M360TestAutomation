using ElementControl;
using M360.Screens;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using System;

namespace M360.Pages
{
    public class PolicyCreateNewScreen : BaseScreen
    {
        public AppiumWebElement _buttonEdit
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonEdit");
            }
        }

        public AppiumWebElement _buttonSave
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonSave");
            }
        }

        public AppiumWebElement _buttonSaveAs
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonSaveAs");
            }
        }

        public AppiumWebElement _buttonOK
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonOk");
            }
        }

        public AppiumWebElement _buttonYes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonYes");
            }
        }

        public AppiumWebElement _buttonQuotation
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonBillQ");
            }
        }

        public AppiumWebElement _radioButtonQuote
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "radioButtonQuoteIncomplete");
            }
        }

        public AppiumWebElement _radioButtonNew
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "radioButtonNew");
            }
        }

        public AppiumWebElement _search
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Search");
            }
        }

        public AppiumWebElement _client
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session,
                    WinAppDriverControlMethods.SearchBy.XPath,
                    "//Edit[contains(@AutomationId,\"textClientCode\")]");
            }
        }

        public AppiumWebElement _existingClient
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "radioExistingClient");
            }
        }

        public AppiumWebElement _class
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "TextBoxCode");
            }
        }

        public AppiumWebElement _insured
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_textInsuredName");
            }
        }

        public AppiumWebElement _situation
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_textSituation");
            }
        }

        public AppiumWebElement _maxLimit
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_controlMaxLimit");
            }
        }

        public AppiumWebElement _mmaRiskID
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_textBoxMmaRiskId");
            }
        }

        public AppiumWebElement _from
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_textPolicyFrom");
            }
        }

        public AppiumWebElement _to
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_textPolicyTo");
            }
        }

        public AppiumWebElement _clientButton
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Client");
            }
        }

        public AppiumWebElement _close
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Close");
            }
        }

        public AppiumWebElement _bill
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Bill");
            }
        }

        public AppiumWebElement _stampDuty
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@AutomationId=\"_panelDeclarationForNswStampDuty\"]//RadioButton[@Name=\"Yes\"]");
            }
        }

        public AppiumWebElement _businessType
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_comboBoxReason");
            }
        }

        public AppiumWebElement _complete
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Complete");
            }
        }

        //endorsement
        public AppiumWebElement _endorsementType
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_comboBoxEndorseType");
            }
        }

        public AppiumWebElement _dateFrom
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_dateBoxEndorsePeriodFrom");
            }
        }

        public AppiumWebElement _dateTo
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_dateBoxEndorsePeriodTo");
            }
        }

        public AppiumWebElement _confirmationTab
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Tab[@AutomationId='_subTabControl']//TabItem[@Name='tab1']");
            }
        }

        public AppiumWebElement _underwriterStatus
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_comboUnderwriterConfirmationStatus");
            }
        }
        public AppiumWebElement _cancelType
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_comboBoxCancelType");
            }
        }

        public AppiumWebElement _reasonType
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_comboBoxReason");
            }
        }

        public AppiumWebElement _lapse
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Lapse");
            }
        }

        public AppiumWebElement _lapseReasonType
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_comboBoxReason");
            }
        }

        //reverse
        public AppiumWebElement _transactionsTab
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "tab11");
            }
        }

        public AppiumWebElement _details
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Details");
            }
        }

        public AppiumWebElement _detailsTab
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "tab1");
            }
        }

        public AppiumWebElement _reverse
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Reverse");
            }
        }

        public AppiumWebElement _endorse
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Endorse");
            }
        }


        public AppiumWebElement _reverseTransaction
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "radioButtonReverseOnly");
            }
        }

        public AppiumWebElement _reversePolicy
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "radioButtonReverseAndCancel");
            }
        }

        public AppiumWebElement _reason
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_comboBoxReason");
            }
        }

        public AppiumWebElement _OK
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "OK");
            }
        }
        public AppiumWebElement _Ok
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Ok");
            }
        }

        public AppiumWebElement _cancel
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Cancel");
            }
        }

        public AppiumWebElement _yes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Yes");
            }
        }

        public AppiumWebElement _no
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "No");
            }
        }
        public AppiumWebElement _renewal
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Renew");
            }

        }

        public AppiumWebElement _incRnl
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Inc. Rnl");
            }
        }

        public AppiumWebElement _modifyRnl
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Modify Rnl");
            }
        }

        public AppiumWebElement _profileTab
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "tab3");
            }
        }

        public AppiumWebElement _incomplete
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonIncomplete");
            }
        }

        public AppiumWebElement _incompleteEndorsement
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonEndorseI");
            }
        }

        public AppiumWebElement _modifyEndorsement
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonEndorseM");
            }
        }

        public AppiumWebElement _cancelDate
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_dateTextBoxCancelDate");
            }
        }

        public AppiumWebElement _delete
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonDelete");
            }
        }

        public AppiumWebElement _multiClient
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Multi Client");
            }
        }

        public AppiumWebElement _multiAgent
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Multi Agent");
            }
        }

        public AppiumWebElement _addClient
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Add Client");
            }
        }

        public AppiumWebElement _premiumSummaryTab
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "tab2");
            }
        }

        public AppiumWebElement _addAgent
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Add Agent");
            }
        }

        public AppiumWebElement _agentAccount
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "jltaCodeTandemAgent");
            }
        }

        public AppiumWebElement _policyNumber
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_labelPolicyNumber");
            }
        }

        public AppiumWebElement _policyNumber2
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "lblPolicyID");
            }
        }

        public AppiumWebElement _consolidatedNo
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "No");
            }
        }

        public AppiumWebElement _edit
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonEdit");
            }
        }

        public AppiumWebElement _claimTab
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "tab14");
            }
        }

        public AppiumWebElement _outstanding
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "radioClaimOutstanding");
            }
        }
        public AppiumWebElement _settled
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "radioClaimSettled");
            }
        }

        private AppiumWebElement _all
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "radioClaimAll");
            }
        }

        public AppiumWebElement _export
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonClaimExport");
            }
        }

        public AppiumWebElement _brokerVarianceReason
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "comboBoxReason");
            }
        }

        public AppiumWebElement _buttonClientSearch
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonClient");
            }
        }

        public AppiumWebElement _checkboxRenewable
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "checkRenewable");
            }
        }

        public AppiumWebElement _incLapse
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Inc. Lapse");
            }
        }

        public AppiumWebElement _ediProduct => GetElementByName("EDI Product");
        public AppiumWebElement _schedule => GetElementByName("tab5");
        public AppiumWebElement _buttonNewEDI => GetElementByAccessibilityId("_buttonNew");


        public void closePolicyScreen()
        {
            _close.ClickButton();
            if (_no != null) _no.Click();
            SwitchToCurrentWindow();
        }

        public void setPolicyHeaderDetails(JToken testData)
        {
            if (_existingClient != null)
            {
                _existingClient.ClickButton();
            }
            if (_client != null)
            {
                _client.SetValue(testData["Client"].ToString());
            }
            else
            {
                Session.Session.M360Session.FindElementByAccessibilityId("textClientCode").SetValue(testData["Client"].ToString());
            }

            _class.SetValue(testData["Class"].ToString());
            _insured.ClickButton();
            _situation.SetValue(testData["Situation"].ToString());
            _maxLimit.SetValue(testData["MaxLimit"].ToString());
            if (testData["Date"] != null)
                _from.SetValue(testData["Date"].ToString());
            else
                _from.SetValue(DateTime.UtcNow.Date.ToString("dd/MM/yyyy"));
            _to.ClickButton();
        }

        public void editPolicy()
        {
            if (_Ok != null) _Ok.ClickButton();
            _edit.ClickButton();
        }

        public void billPolicy(JToken testData)
        {
            _bill.ClickButton();
            if (_yes != null)
            {
                _yes.ClickButton();
            }
            SwitchToCurrentWindow();
            _detailsTab.Click();
            _businessType.ClickButton();
            if (_yes != null)
            {
                _yes.ClickButton();
                _businessType.ClickButton();
            }
            Session.Session.M360Session.FindElementByName(testData["BillPolicy"]["BusinessType"].ToString()).Click();

            if (_stampDuty != null)
            {
                _stampDuty.ClickButton();
            }
            if (_consolidatedNo != null) _consolidatedNo.Click();
        }

        public string createPolicy(JToken testData, bool bill = true, bool installments = false, bool documentBuilder = false, bool profile = false, bool underWriter = true, bool risk = false, bool premium = true, bool edi = false, bool complete = true, bool comments = false, bool scheme = false, bool renew = false)
        {
            setPolicyHeaderDetails(testData);
            if (comments)
            {
                var policyCommentsScreen = new PolicyCommentsScreen();
                policyCommentsScreen.setComments(testData);
            }
            if (profile)
            {
                var profileScreen = new PolicyProfileScreen();
                profileScreen.attachProfile(testData);
            }
            else if (!scheme && !profile)
            {
                var profileScreen = new PolicyProfileScreen();
                profileScreen.setSchedule(testData);
            }
            if (documentBuilder)
            {
                var documentBuilderScreen = new PolicyDocumentBuilderScreen();
                documentBuilderScreen.createDocumentBuilder(testData);
            }
            if (underWriter)
            {
                var underWriterScreen = new PolicyUnderWriterScreen();
                underWriterScreen.setUnderWriter(testData);
            }
            if (edi)
            {
                var ediScreen = new PolicyEDIScreen();
                ediScreen.completeEDI(testData);
            }
            if (risk)
            {
                var policyRiskScreen = new PolicyRiskScreen();
                policyRiskScreen.setRisk(testData);
            }
            if (bill)
            {
                billPolicy(testData);
                if (premium)
                {
                    var policyPremiumScreen = new PolicyPremiumScreen();
                    policyPremiumScreen.setPremium(testData, installments: installments, renew: renew);
                }
            }
            if (complete)
            {
                if (edi)
                {
                    var ediScreen = new PolicyEDIScreen();
                    ediScreen.finaliseEDI();
                }
                else
                {
                    completePolicy(edi);
                }

                return _policyNumber.Text;
            }

            return _policyNumber != null ? _policyNumber.Text : _policyNumber2.Text;
        }

        public void completePolicy(bool edi)
        {
            if (edi)
            {
                var ediScreen = new PolicyEDIScreen();
                ediScreen.finaliseEDI();
            }
            else
            {
                _complete.ClickButton();
                if (_brokerVarianceReason != null)
                {
                    _brokerVarianceReason.ClickButton();
                    Session.Session.M360Session.Keyboard.SendKeys(Keys.ArrowDown);
                    Session.Session.M360Session.Keyboard.SendKeys(Keys.ArrowDown);
                    Session.Session.M360Session.Keyboard.SendKeys(Keys.Enter);
                    _Ok.ClickButton();
                }
                if (_yes != null)
                {
                    _yes.ClickButton();
                }
                SwitchToCurrentWindow();
            }
        }

        public void gotoClientScreen()
        {
            _clientButton.ClickButton();
            if (_yes != null) _yes.Click();
            SwitchToCurrentWindow();
        }


        public void endorse(JToken testData, bool installments)
        {
            _endorse.ClickButton();
            _maxLimit.SetValue(testData["NewMaxLimit"].ToString());
            _bill.ClickButton();
            SwitchToCurrentWindow();
            _endorsementType.ClickButton();
            Session.Session.M360Session.FindElementByName("Ad hoc declaration").Click();
            _dateFrom.SetValue(DateTime.UtcNow.Date.ToString("dd/MM/yyyy"));
            _dateTo.SetValue(DateTime.UtcNow.Date.AddYears(1).ToString("dd/MM/yyyy"));
            _confirmationTab.ClickButton();
            _underwriterStatus.SetValue("Not required");
            var policyPremiumScreen = new PolicyPremiumScreen();
            policyPremiumScreen.setPremium(testData, installments: installments);
            if (_yes != null) _yes.Click();
        }

        public void incompleteEndrosement(JToken testData)
        {
            _endorse.ClickButton();
            _incomplete.ClickButton();
            _yes.Click();
            _incompleteEndorsement.ClickButton();
            _modifyEndorsement.ClickButton();
            _bill.ClickButton();
            SwitchToCurrentWindow();
            _endorsementType.ClickButton();
            Session.Session.M360Session.FindElementByName("Ad hoc declaration").Click();
            _dateFrom.SetValue(DateTime.UtcNow.Date.ToString("dd/MM/yyyy"));
            _dateTo.SetValue(DateTime.UtcNow.Date.AddYears(1).ToString("dd/MM/yyyy"));
            _confirmationTab.ClickButton();
            _underwriterStatus.SetValue("Not required");
            var policyPremiumScreen = new PolicyPremiumScreen();
            policyPremiumScreen.setPremium(testData, false);

        }

        public void cancelPolicy(JToken testData, bool installments, string cancelType = "Full Cancel")
        {
            _cancel.ClickButton();
            _bill.ClickButton();
            SwitchToCurrentWindow();
            _cancelType.ClickButton();
            if (cancelType == "Full Cancel")
            {
                Session.Session.M360Session.FindElementByName("Full cancel").Click();
            }
            else
            {
                Session.Session.M360Session.FindElementByName("Part cancel").Click();
                _cancelDate.SetValue(DateTime.Now.ToString("dd/MM/yyyy"));
            }
            _reasonType.ClickButton();
            Session.Session.M360Session.FindElementByName("Policy Insured Elsewhere").Click();
            var policyPremiumScreen = new PolicyPremiumScreen();
            policyPremiumScreen.setPremium(testData, installments, true);
            _complete.ClickButton();
        }

        public void deletePolicy()
        {
            _delete.ClickButton();
            _yes.ClickButton();
        }

        public void lapsePolicy()
        {
            _lapse.ClickButton();
            if (_incLapse != null) _incLapse.ClickButton();
            SwitchToCurrentWindow();
            _lapseReasonType.ClickButton();
            Session.Session.M360Session.FindElementByName("Policy Insured Elsewhere").Click();
            _complete.ClickButton();
            SwitchToCurrentWindow();
        }

        public void reversePolicy()
        {
            _transactionsTab.ClickButton();
            _details.ClickButton();
            SwitchToCurrentWindow();
            _reverse.ClickButton();
            if (_reversePolicy != null)
            {
                _reversePolicy.ClickButton();
                _OK.ClickButton();
                _detailsTab.ClickButton();
                _reason.ClickButton();
                Session.Session.M360Session.FindElementByName("Policy Insured Elsewhere").Click();
            }
            else
            {
                _yes.ClickButton();
            }
            _complete.ClickButton();
            SwitchToCurrentWindow();
        }

        public void renewPolicy(JToken testData, bool modifyUnderWriter = false, bool incomplete = false, bool billPolicyCondition = true)
        {
            if (_renewal != null)
            {
                _renewal.ClickButton();
                if (_yes != null) _yes.ClickButton();
            }
            else
            {
                _incRnl.ClickButton();
            }
            if (_modifyRnl != null)
            {
                _modifyRnl.ClickButton();
            }

            if (modifyUnderWriter)
            {
                var policyUnderWriterScreen = new PolicyUnderWriterScreen();
                policyUnderWriterScreen.deleteUnderWriter();
                policyUnderWriterScreen.addUnderWriter(testData);
            }

            var premiumScreen = new PolicyPremiumScreen();

            if (billPolicyCondition)
            {
                if (!incomplete)
                {
                    billPolicy(testData);
                    premiumScreen.setPremium(testData, false, false);
                    _complete.ClickButton();
                    if (_brokerVarianceReason != null)
                    {
                        _brokerVarianceReason.ClickButton();
                        Session.Session.M360Session.Keyboard.SendKeys(Keys.ArrowDown);
                        Session.Session.M360Session.Keyboard.SendKeys(Keys.ArrowDown);
                        Session.Session.M360Session.Keyboard.SendKeys(Keys.Enter);
                        _Ok.ClickButton();
                        if (_yes != null) _yes.ClickButton();
                    }
                    SwitchToCurrentWindow();
                }
                else
                {
                    billPolicy(testData);
                    premiumScreen.setPremium(testData, false, false, true, true);
                    _incomplete.ClickButton();
                    if (_brokerVarianceReason != null)
                    {
                        _brokerVarianceReason.ClickButton();
                        Session.Session.M360Session.Keyboard.SendKeys(Keys.ArrowDown);
                        Session.Session.M360Session.Keyboard.SendKeys(Keys.ArrowDown);
                        Session.Session.M360Session.Keyboard.SendKeys(Keys.Enter);
                        _Ok.ClickButton();
                    }
                    _yes.ClickButton();
                    SwitchToCurrentWindow();
                }
            }
        }

        public void gotoProfileTab()
        {
            _profileTab.ClickButton();
        }

        public void addMultipleClients(JToken testData)
        {
            _multiClient.ClickButton();
            _addClient.ClickButton();
            Session.Session.M360Session.Keyboard.SendKeys(testData["AdditionalClient"].ToString());
            Session.Session.M360Session.Keyboard.PressKey(Keys.Tab);
            Session.Session.M360Session.Keyboard.SendKeys((Decimal.Parse(testData["BillPolicy"]["Premium"].ToString()) / 2).ToString());
            var actions = new Actions(Session.Session.M360Session);
            actions.MoveToElement(_complete);
            actions.MoveByOffset(270, -400);
            actions.Click();
            actions.Perform();
            Session.Session.M360Session.Keyboard.SendKeys((Decimal.Parse(testData["BillPolicy"]["Premium"].ToString()) / 2).ToString());
            Session.Session.M360Session.Keyboard.PressKey(Keys.Tab);
            _premiumSummaryTab.ClickButton();
            wait.Until(driver => _multiClient == null);
        }


        public void addMultipleAgents(JToken testData)
        {
            _multiAgent.ClickButton();
            _addAgent.ClickButton();
            _agentAccount.SetValue(testData["AdditionalAgent"].ToString());
            _OK.Click();
            Session.Session.M360Session.Keyboard.SendKeys((Decimal.Parse(testData["BillPolicy"]["AgentCommission"].ToString()) / 2).ToString());
            var actions = new Actions(Session.Session.M360Session);
            actions.MoveToElement(_complete);
            actions.MoveByOffset(660, -400);
            actions.Click();
            actions.Perform();
            Session.Session.M360Session.Keyboard.SendKeys((Decimal.Parse(testData["BillPolicy"]["AgentCommission"].ToString()) / 2).ToString());
            Session.Session.M360Session.Keyboard.PressKey(Keys.Tab);
            _premiumSummaryTab.ClickButton();
            wait.Until(driver => _multiAgent == null);
        }


        public void gotoClaimTab()
        {
            _claimTab.ClickButton();
        }


        public void exportClaims(string radioButton)
        {
            switch (radioButton)
            {
                case "Outstanding":
                    _outstanding.ClickButton();
                    break;
                case "Settled":
                    _settled.ClickButton();
                    break;
                case "All":
                    _all.ClickButton();
                    break;
            }
            _export.ClickButton();
        }

        public void verifyResults(string expectedResult)
        {
            var excelDoc = new ExcelDocument();
            excelDoc.saveExcel();
            var excelTextActual = excelDoc.readExcel(@"C:\temp\excel.xls");
            Assert.IsTrue(excelTextActual.Contains(expectedResult));
        }

        public void saveAsQuote()
        {
            _buttonSaveAs.ClickButton();
            _radioButtonQuote.ClickButton();
            _buttonOK.ClickButton();
            _buttonYes.ClickButton();
        }

        public void saveQuoteAsNew()
        {
            _buttonSaveAs.ClickButton();
            _radioButtonNew.ClickButton();
            _buttonOK.ClickButton();
            _buttonYes.ClickButton();
        }

        public void gotoPolicyBillingForm()
        {
            _buttonQuotation.ClickButton();
            SwitchToCurrentWindow();
        }

        public void edit()
        {
            _buttonEdit.ClickButton();
            // TO DO: check fields are editable
        }

        public void isReadOnly()
        {
            //TO DO Check fields are read only
        }

        public void isIncomplete()
        {
            //TO DO Check policy is incomplete
        }

        public void save()
        {
            _buttonSave.ClickButton();
        }

        public string getPolicyNumber()
        {
            return _policyNumber.Text;
        }

        public void checkNewPolicyMode()
        {
            //var policyNumber = policyMaintenanceForm.getPolicyNumber();
            //policyMaintenanceForm.scheduleTab.isVisible();
            //policyMaintenanceForm.commentsTab.isVisible();
        }

        public void clientSearch()
        {
            _buttonClientSearch.ClickButton();
        }
        public void setClient(JToken testData)
        {
            _client.SetValue(testData["ClientCode"].ToString());
        }

        public void setClass(JToken testData)
        {
            _class.SetValue(testData["Class"].ToString());
        }

        public void setSituation(JToken testData)
        {
            _situation.SetValue(testData["Situation"].ToString());
        }

        public void setMaxLimit(JToken testData)
        {
            _maxLimit.SetValue(testData["MaxLimit"].ToString());
        }

        public void setMMARiskID(JToken testData)
        {
            _mmaRiskID.SetValue(testData["MMARiskID"].ToString());
        }

        public void setFrom()
        {
            _from.SetValue(DateTime.UtcNow.Date.ToString("dd/MM/yyyy"));
            _to.ClickButton();
        }

        public void uncheckRenewable()
        {
            _checkboxRenewable.ClickButton();
        }

        public void addUnderwriter(JToken testData)
        {
            var underWriterScreen = new PolicyUnderWriterScreen();
            underWriterScreen.setUnderWriter(testData);
        }

        public void insertSchedule(JToken testData)
        {
            var profileScreen = new PolicyProfileScreen();
            profileScreen.setSchedule(testData);
        }

        public void setComments(JToken testData)
        {
            var policyCommentsScreen = new PolicyCommentsScreen();
            policyCommentsScreen.setComments(testData);
        }

        public void gotoSchedule()
        {
            _schedule.ClickButton();
        }

        public void setEDIProduct(JToken testData)
        {
            _ediProduct.SetValue(testData["EDIProduct"].ToString());
        }

        public void gotoButtonNewEDI()
        {
            _buttonNewEDI.ClickButton();
        }



    }
}




