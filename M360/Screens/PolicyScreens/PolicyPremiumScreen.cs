using OpenQA.Selenium.Appium;
using ElementControl;
using NUnit.Framework;
using OpenQA.Selenium;
using M360TestAutomation.Tests;
using System;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Interactions;
using Newtonsoft.Json.Linq;

namespace M360.Pages
{
    public class PolicyPremiumScreen : BaseScreen
    {
        public AppiumWebElement _complete
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Complete");
            }
        }

        public AppiumWebElement _buttonSave
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonSave");
            }
        }

        public AppiumWebElement _premiumSummaryTab
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "tab2");
            }
        }

        public AppiumWebElement _premium
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textBoxPremium");
            }
        }

        public AppiumWebElement _buttonPremiumCalc
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonPremiumCalc");
            }
        }

        public AppiumWebElement _UWPolicyFee
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "UW Policy Fee");
            }
        }

        public AppiumWebElement _brokerage
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Brokerage");
            }
        }

        public AppiumWebElement _brokerageRebate
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Brokerage Rebate");
            }
        }


        public AppiumWebElement _agentCommission
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Agent Commission");
            }
        }

        public AppiumWebElement _businessType
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_comboBoxReason");
            }
        }

        public AppiumWebElement _installments
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonInstalments");
            }
        }

        public AppiumWebElement _createInstallments
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Create");
            }
        }

        public AppiumWebElement _labelInstallment
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "labelInstalment");
            }
        }

        public AppiumWebElement _Ok
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Ok");
            }
        }

        public AppiumWebElement _brokerVarianceReason
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "comboBoxReason");
            }
        }


        public AppiumWebElement _premiumLabel
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "labelPremiumAmt");
            }
        }

        public AppiumWebElement _fslLevyLabel
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "labelFslAmt");
            }
        }

        public AppiumWebElement _UWPolicyFeeLabel
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "labelUwPolicyFeeAmt");
            }
        }

        public AppiumWebElement _stampDuty
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Stamp Duty");
            }
        }

        public AppiumWebElement _documentFee
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Document Fee");
            }
        }

        public AppiumWebElement _labelBrokerFeeAmount
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "labelBrokerFeeAmount");
            }
        }
        public AppiumWebElement _labelAdminFeeTotalAmount
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "labelAdminFeeTotalAmount");
            }
        }

        public AppiumWebElement _labelBrokerageRebateAmt
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "labelBrokerageRebateAmt");
            }
        }

        public AppiumWebElement _labelGstToClientAmt
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "labelGstToClientAmt");
            }
        }

        public AppiumWebElement _labelStampDutyAmt
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "labelStampDutyAmt");
            }
        }
        public AppiumWebElement _labelIptAmt
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "labelIptAmt");
            }
        }

        public AppiumWebElement _labelClientTotalAmt
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "labelClientTotalAmt");
            }
        }

        public AppiumWebElement _labelUwGrossAmt
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "labelUwGrossAmt");
            }
        }

        public AppiumWebElement _labelFbcsAmt
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "labelFbcsAmt");
            }
        }

        public AppiumWebElement _labelTaxAmt
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "labelTaxAmt");
            }
        }

        public AppiumWebElement _labelBrokerageAmt
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "labelBrokerageAmt");
            }
        }

        public AppiumWebElement _labelGstOnBrokerageAmt
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "labelGstOnBrokerageAmt");
            }
        }
        public AppiumWebElement _labelUwNetAmt
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "labelUwNetAmt");
            }
        }
        public AppiumWebElement _labelAgentCommAmt
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "labelAgentCommAmt");
            }
        }

        public AppiumWebElement _close
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Close");
            }
        }

        public AppiumWebElement _yes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Yes");
            }
        }

        public void setPremium(JToken testData, bool installments, bool cancel = false, bool renew = false, bool incomplete=false)
        {
            _premiumSummaryTab.ClickButton();
            if (_yes != null) _yes.ClickButton();
            if (cancel)
            {
                _premium.SetValue('-' + testData["BillPolicy"]["Premium"].ToString());
                _buttonPremiumCalc.ClickButton();
                _UWPolicyFee.SetValue('-' + testData["BillPolicy"]["UWPolicyFee"].ToString());
                _brokerageRebate.SetValue('-' + testData["BillPolicy"]["BrokerageRebate"].ToString());
                _agentCommission.SetValue('-' + testData["BillPolicy"]["AgentCommission"].ToString());
                _brokerageRebate.ClickButton();
            }
            else
            {
                _premium.SetValue(testData["BillPolicy"]["Premium"].ToString());
                _buttonPremiumCalc.ClickButton();
                _UWPolicyFee.SetValue(testData["BillPolicy"]["UWPolicyFee"].ToString());
                _brokerageRebate.ClickButton();
                _stampDuty.SetValue(testData["BillPolicy"]["StampDuty"].ToString());
                _documentFee.SetValue(testData["BillPolicy"]["DocumentFee"].ToString());
                _brokerage.SetValue(testData["BillPolicy"]["Brokerage"].ToString());
                _brokerageRebate.SetValue(testData["BillPolicy"]["BrokerageRebate"].ToString());
                _agentCommission.SetValue(testData["BillPolicy"]["AgentCommission"].ToString());
            }
            if (installments)
            {
                _installments.ClickButton();
                _createInstallments.ClickButton();
                _Ok.ClickButton();
                Assert.IsTrue(_labelInstallment.Text.Contains("Instalment 1 of 12"));
                if (_brokerVarianceReason != null)
                {
                    _brokerVarianceReason.ClickButton();
                    Session.Session.M360Session.Keyboard.SendKeys(Keys.ArrowDown);
                    Session.Session.M360Session.Keyboard.SendKeys(Keys.ArrowDown);
                    Session.Session.M360Session.Keyboard.SendKeys(Keys.Enter);
                    _Ok.ClickButton();
                }
            }
            if(renew)
            {
                _UWPolicyFee.SetValue("100");
                _brokerage.SetValue("100");
                if (!incomplete)
                {   _complete.ClickButton();
                    if (_brokerVarianceReason != null)
                    {
                        _brokerVarianceReason.ClickButton();
                        Session.Session.M360Session.Keyboard.SendKeys(Keys.ArrowDown);
                        Session.Session.M360Session.Keyboard.SendKeys(Keys.ArrowDown);
                        Session.Session.M360Session.Keyboard.SendKeys(Keys.Enter);
                        _Ok.ClickButton();
                    }
                    SwitchToCurrentWindow();
                }
            }
        }

        public void validatePolicy(JToken testData)
        {
            _premiumSummaryTab.ClickButton();
            Assert.AreEqual(Convert.ToDecimal(Regex.Replace(_premiumLabel.Text, "[^0-9.]", "")), Convert.ToDecimal(testData["BillPolicy"]["Premium"].ToString()));
            Assert.AreEqual(Convert.ToDecimal(Regex.Replace(_fslLevyLabel.Text, "[^0-9.]", "")), Convert.ToDecimal(testData["BillPolicy"]["FSLLevy"].ToString()));
            Assert.AreEqual(Convert.ToDecimal(Regex.Replace(_UWPolicyFeeLabel.Text, "[^0-9.]", "")), Convert.ToDecimal(testData["BillPolicy"]["UWPolicyFee"].ToString()));
            Assert.AreEqual(Convert.ToDecimal(Regex.Replace(_labelBrokerFeeAmount.Text, "[^0-9.]", "")), Convert.ToDecimal(testData["BillPolicy"]["BrokerFee"].ToString()));
            Assert.AreEqual(Convert.ToDecimal(Regex.Replace(_labelAdminFeeTotalAmount.Text, "[^0-9.]", "")), Convert.ToDecimal(testData["BillPolicy"]["AdminTotalFee"].ToString()));
            Assert.AreEqual(Convert.ToDecimal(Regex.Replace(_labelBrokerageRebateAmt.Text, "[^0-9.]", "")), Convert.ToDecimal(testData["BillPolicy"]["BrokerageRebate"].ToString()));
            Assert.AreEqual(Convert.ToDecimal(Regex.Replace(_labelGstToClientAmt.Text, "[^0-9.]", "")), Convert.ToDecimal(testData["BillPolicy"]["GSTToClient"].ToString()));
            Assert.AreEqual(Convert.ToDecimal(Regex.Replace(_labelStampDutyAmt.Text, "[^0-9.]", "")), Convert.ToDecimal(testData["BillPolicy"]["StampDuty"].ToString()));
            Assert.AreEqual(Convert.ToDecimal(Regex.Replace(_labelIptAmt.Text, "[^0-9.]", "")), Convert.ToDecimal(testData["BillPolicy"]["IPT"]));
            Assert.AreEqual(Convert.ToDecimal(Regex.Replace(_labelUwGrossAmt.Text, "[^0-9.]", "")), Convert.ToDecimal(testData["BillPolicy"]["UWGross"].ToString()));
            Assert.AreEqual(Convert.ToDecimal(Regex.Replace(_labelFbcsAmt.Text, "[^0-9.]", "")), Convert.ToDecimal(testData["BillPolicy"]["FBCS"].ToString()));
            Assert.AreEqual(Convert.ToDecimal(Regex.Replace(_labelTaxAmt.Text, "[^0-9.]", "")), Convert.ToDecimal(testData["BillPolicy"]["Tax"].ToString()));
            Assert.AreEqual(Convert.ToDecimal(Regex.Replace(_labelBrokerageAmt.Text, "[^0-9.]", "")), Convert.ToDecimal(testData["BillPolicy"]["Brokerage"].ToString()));
            Assert.AreEqual(Convert.ToDecimal(Regex.Replace(_labelGstOnBrokerageAmt.Text, "[^0-9.]", "")), Convert.ToDecimal(testData["BillPolicy"]["GSTBrokerage"].ToString()));
            Assert.AreEqual(Convert.ToDecimal(Regex.Replace(_labelUwNetAmt.Text, "[^0-9.]", "")), Convert.ToDecimal(testData["BillPolicy"]["UWNet"].ToString()));
            Assert.AreEqual(Convert.ToDecimal(Regex.Replace(_labelAgentCommAmt.Text, "[^0-9.]", "")), Convert.ToDecimal(testData["BillPolicy"]["AgentCommission"].ToString()));
            _close.ClickButton();
        }

        public void save()
        {
            _buttonSave.ClickButton();
        }

        public void close()
        {
            _close.ClickButton();
            SwitchToCurrentWindow();
        }

    }
}
