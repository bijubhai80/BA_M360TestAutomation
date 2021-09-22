using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M360.Session;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.IO;
using System.Threading;
using M360.Screens;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace M360.Pages
{
    public class PolicyScreen : BaseScreen
    {
        //search policy
        public string _office = "jltaCodeTandemBranch";
        public string _policy = "textPolicy";
        public string _search = "Search";
        public string _renewal = "Renew";
        public string _new = "New";
        public string _save = "buttonSave";        

        //new policy
        public string _client = "_textClientCode";
        public string _existingClient = "radioExistingClient";
        
        public string _class = "TextBoxCode";
        public string _insured = "_textInsuredName";
        public string _situation = "_textSituation";
        public string _maxLimit = "_controlMaxLimit";
        public string _from = "_textPolicyFrom";
        public string _to = "_textPolicyTo";
        public string _clientButton = "Client";
        public string _endorse = "Endorse";
        public string _cancel = "Cancel";        

        //new policy - after save policy
        public string _scheduleTab = "tab4";
        public string _profileButton = "_radioProfile";
        public string _profileType = "_profileComboBox";
        public string _attach = "_buttonAttach";
        public string _documents = "tab9";
        public string _documentButton = "buttonDocDocument";
        public string _documentBuilder = "Document Builder...";
        public string _underWriterTab = "tab0";
        public string _underWriter = "jltaCodeTandemUnderwriter";
        public string _newEDI = "_buttonNew";

        //policyDocumentBuilder
        public string _documentTypes = "_comboDocumentTypes";
        public string _quotationSlipDocType = "Quotation Slip";
        public string _create = "_buttonCreate";
        public string _policyDocBuilderclose = "_buttonClose";


        //Edit policy
        public string _incRnl = "Inc. Rnl";
        public string _modifyRnl = "Modify Rnl";
        public string _bill = "Bill";
        public string _yes = "Yes";
        public string _complete = "Complete";
        public string _stampDuty = "radioButtonYes";
        public string _premiumSummaryTab = "tab2";
        public string _premium = "textBoxPremium";
        public string _buttonPremiumCalc = "buttonPremiumCalc";
        public string _UWPolicyFee = "UW Policy Fee";
        public string _brokerage = "Brokerage";
        public string _brokerageRebate = "Brokerage Rebate";
        public string _agentCommission = "Agent Commission";
        public string _brokerVarianceReason = "comboBoxReason";
        public string _businessType = "_comboBoxReason";
        public string _installments = "Instalments";
        public string _createInstallments = "Create";
        public string _labelInstallment = "labelInstalment";
        
        public string _Ok = "Ok";

        //edi
        public string _ediProduct = "EDI Product";

        //reverse
        public string _transactionsTab = "tab11";
        public string _details = "Details";
        public string _detailsTab = "tab1";
        public string _reverse = "Reverse";
        public string _reverseTransaction = "radioButtonReverseOnly";
        public string _reversePolicy = "radioButtonReverseAndCancel";
        public string _reason = "_comboBoxReason";
        public string _close = "Close";
        public string _OK = "OK";


        //endorsement
        public string _endorsementType = "_comboBoxEndorseType";
        public string _dateFrom = "_dateBoxEndorsePeriodFrom";
        public string _dateTo = "_dateBoxEndorsePeriodTo";
        public string _confirmationTab = "//Tab[@AutomationId='_subTabControl']//TabItem[@Name='tab1']";
        public string _underwriterStatus = "_comboUnderwriterConfirmationStatus";

        //cancel
        public string _cancelType = "_comboBoxCancelType";
        public string _reasonType = "_comboBoxReason";

        //lapse
        public string _lapse = "Lapse";
        public string _lapseReasonType = "_comboBoxReason";        

        public void searchPolicy(string policyNo)
        {
            SwitchToCurrentWindow();
            Session.Session.M360Session.FindElementByAccessibilityId(_policy).SendKeys(policyNo);
            Session.Session.M360Session.FindElementByName(_search).Click();            
        }

        public void searchClient(string client)
        {
            SwitchToCurrentWindow();
            Session.Session.M360Session.FindElementByAccessibilityId(_client).SendKeys(client);
            Session.Session.M360Session.FindElementByName(_search).Click();
        }

        public void closePolicyScreen()
        {
            SwitchToCurrentWindow();
            Session.Session.M360Session.FindElementByName(_close).Click();
            SwitchToCurrentWindow();
        }

        public void renewPolicy()
        {
            SwitchToCurrentWindow();

            if (Session.Session.M360Session.FindElementsByName(_renewal).Count > 0)
            {
                Session.Session.M360Session.FindElementByName(_renewal).Click();
                Thread.Sleep(5000);
                Session.Session.M360Session.SwitchTo().Window(Session.Session.M360Session.WindowHandles[0]);
                Session.Session.M360Session.FindElementByName(_yes).Click();
                Thread.Sleep(5000);
                Session.Session.M360Session.SwitchTo().Window(Session.Session.M360Session.WindowHandles[0]);

            }
            else
            {
                Session.Session.M360Session.FindElementByName(_incRnl).Click();
            }

            if (Session.Session.M360Session.FindElementsByName(_modifyRnl).Count > 0)
            {
                Session.Session.M360Session.FindElementByName(_modifyRnl).Click();
            }

            Session.Session.M360Session.FindElementByName(_bill).Click();
            if (Session.Session.M360Session.FindElementsByName(_yes).Count > 0)
            {
                Session.Session.M360Session.FindElementByName(_yes).Click();
            }

            SwitchToCurrentWindow();
            Session.Session.M360Session.FindElementByName(_premiumSummaryTab).Click();
            Session.Session.M360Session.FindElementByAccessibilityId(_premium).SendKeys("5000");
            Session.Session.M360Session.FindElementByAccessibilityId(_buttonPremiumCalc).Click();
            Session.Session.M360Session.FindElementByName(_UWPolicyFee).SendKeys("100");
            Session.Session.M360Session.FindElementByName(_brokerage).SendKeys("100");
            if (Session.Session.M360Session.FindElementsByName(_brokerageRebate).Count > 0)
            {
                Session.Session.M360Session.FindElementByName(_brokerageRebate).SendKeys("50");
            }
            if (Session.Session.M360Session.FindElementsByName(_agentCommission).Count > 0)
            {
                Session.Session.M360Session.FindElementByName(_agentCommission).SendKeys("10");
                Session.Session.M360Session.FindElementByName(_complete).Click();
                Session.Session.M360Session.FindElementByAccessibilityId(_brokerVarianceReason).Click();
                Session.Session.M360Session.Keyboard.SendKeys(Keys.ArrowDown);
                Session.Session.M360Session.Keyboard.SendKeys(Keys.ArrowDown);
                Session.Session.M360Session.Keyboard.SendKeys(Keys.Enter);
                Session.Session.M360Session.FindElementByName(_Ok).Click();
                SwitchToCurrentWindow();
            }
            if (Session.Session.M360Session.FindElementsByName(_complete).Count > 0)
            {
                Session.Session.M360Session.FindElementByName(_complete).Click();
            }
            
        }
        public void reversePolicy() {
            Session.Session.M360Session.FindElementByName(_transactionsTab).Click();
            Session.Session.M360Session.FindElementByName(_details).Click();
            SwitchToCurrentWindow();
            Session.Session.M360Session.FindElementByName(_reverse).Click();
            if(Session.Session.M360Session.FindElementsByAccessibilityId(_reversePolicy).Count > 0)
            {
                Session.Session.M360Session.FindElementByAccessibilityId(_reversePolicy).Click();
                Session.Session.M360Session.FindElementByName(_OK).Click();
                var wait = new DefaultWait<WindowsDriver<WindowsElement>>(Session.Session.M360Session)
                {
                    Timeout = TimeSpan.FromSeconds(60),
                    PollingInterval = TimeSpan.FromSeconds(1)
                };
                wait.Until(driver => driver.FindElementsByName(_detailsTab).Count > 0);
                Session.Session.M360Session.FindElementByName(_detailsTab).Click();
                Session.Session.M360Session.FindElementByAccessibilityId(_reason).Click();
                Session.Session.M360Session.FindElementByName("Policy Insured Elsewhere").Click();
            }
            else
            {
                Session.Session.M360Session.FindElementByName(_yes).Click();
            }            
            Session.Session.M360Session.FindElementByName(_complete).Click();
        }

        public void setPolicyHeaderDetails()
        {
            if(Session.Session.M360Session.FindElementsByAccessibilityId(_existingClient).Count > 0)
            {
                Session.Session.M360Session.FindElementByAccessibilityId(_existingClient).Click();
            }
            if(Session.Session.M360Session.FindElementsByAccessibilityId(_client).Count > 0)
            {
                Session.Session.M360Session.FindElementByAccessibilityId(_client).SendKeys(SanityTests.testData.GetData("Profile", SanityTests.testData.testCaseId, "Client"));
            }
            else
            {
                Session.Session.M360Session.FindElementByAccessibilityId(_client.Trim('_')).SendKeys(SanityTests.testData.GetData("Profile", SanityTests.testData.testCaseId, "Client"));
            }
            
            Session.Session.M360Session.FindElementByAccessibilityId(_class).SendKeys(SanityTests.testData.GetData("Profile", SanityTests.testData.testCaseId, "Class"));
            Session.Session.M360Session.FindElementByAccessibilityId(_insured).Click();
            Session.Session.M360Session.FindElementByAccessibilityId(_situation).SendKeys(SanityTests.testData.GetData("Profile", SanityTests.testData.testCaseId, "Situation"));            
            Session.Session.M360Session.FindElementByAccessibilityId(_maxLimit).SendKeys(SanityTests.testData.GetData("Profile", SanityTests.testData.testCaseId, "MaxLimit"));
            Session.Session.M360Session.FindElementByAccessibilityId(_from).SendKeys(DateTime.UtcNow.Date.ToString("dd/MM/yyyy"));
            Session.Session.M360Session.FindElementByAccessibilityId(_to).Click();
        }

        public void attachProfile()
        {
            Session.Session.M360Session.FindElementByName(_scheduleTab).Click();
            var wait = new DefaultWait<WindowsDriver<WindowsElement>>(Session.Session.M360Session)
            {
                Timeout = TimeSpan.FromSeconds(60),
                PollingInterval = TimeSpan.FromSeconds(1)
            };
            wait.Until(driver => driver.FindElementsByAccessibilityId(_profileButton).Count > 0);
            Session.Session.M360Session.FindElementByAccessibilityId(_profileButton).Click();
            Session.Session.M360Session.FindElementByAccessibilityId(_profileType).Click();
            Session.Session.M360Session.FindElementByName(SanityTests.testData.GetData("Profile", SanityTests.testData.testCaseId, "ProfileType")).Click();
            Session.Session.M360Session.FindElementByAccessibilityId(_attach).Click();
            Session.Session.M360Session.FindElementByAccessibilityId(_save).Click();
        }

        public void createDocumentBuilder()
        {
            wait.Until(driver => {
                return driver.FindElementsByName(_documents).Count > 0;
            });
            Session.Session.M360Session.FindElementByName(_documents).Click();
            Session.Session.M360Session.FindElementByAccessibilityId(_documentButton).Click();
            Session.Session.M360Session.FindElementByName(_documentBuilder).Click();
            SwitchToCurrentWindow();

            Session.Session.M360Session.FindElementByAccessibilityId(_documentTypes).Click();
            Session.Session.M360Session.FindElementByName(SanityTests.testData.GetData("Profile", SanityTests.testData.testCaseId, "DocumentBuilderType")).Click();
            Session.Session.M360Session.FindElementByAccessibilityId(_create).Click();

            //goto word doc
            /*var action = new Actions(Session.Session.M360Session);
            action.MoveByOffset(70, -380);
            action.Click();
            action.DoubleClick();
            action.Perform();

            var wordDocument = new WordDocument();
            var text = "SITUATION and/ or PREMISES " + "Test Situation" 
                + "From:	" + DateTime.UtcNow.Date.ToString("dd/MM/yyyy")
                + "To: " + DateTime.UtcNow.Date.AddYears(1).ToString("dd/MM/yyyy");            
            wordDocument.verifyText(text);                        
            */

            Session.Session.M360Session.FindElementByAccessibilityId(_policyDocBuilderclose).Click();
            SwitchToCurrentWindow();

        }

        public void createNewPolicy ()
        {
            SwitchToCurrentWindow();
            Session.Session.M360Session.FindElementByAccessibilityId(_office).SendKeys(SanityTests.testData.GetData("Profile", SanityTests.testData.testCaseId, "Office"));
            Session.Session.M360Session.FindElementByName(_new).Click();
            SwitchToCurrentWindow();
        }

        public void billPolicy ()
        {
            Session.Session.M360Session.FindElementByName(_bill).Click();

            SwitchToCurrentWindow();
            Session.Session.M360Session.FindElementByAccessibilityId(_businessType).Click();
            Session.Session.M360Session.FindElementByName(SanityTests.testData.GetData("Profile", SanityTests.testData.testCaseId, "BusinessType")).Click();

            if (Session.Session.M360Session.FindElementsByAccessibilityId(_stampDuty).Count > 0)
            {
                Session.Session.M360Session.FindElementByAccessibilityId(_stampDuty).Click();
            }
        }

        public void setUnderWriter()
        {
            wait.Until(driver => driver.FindElementsByName(_underWriterTab).Count > 0);
            Session.Session.M360Session.FindElementByName(_underWriterTab).Click();
            Session.Session.M360Session.FindElementByAccessibilityId(_underWriter).SendKeys(SanityTests.testData.GetData("Profile", SanityTests.testData.testCaseId, "UnderWriter"));
            Thread.Sleep(5000);
            Session.Session.M360Session.FindElementByAccessibilityId("textUWPolNum").Click();
        }

        public void setRisk(string scheme)
        {
            SchemesScreen schemesRiskTab;
            switch (scheme)
            {
                case "Bike Dealers Arrangement (LVS)":
                    schemesRiskTab = new BikeDealersArrangment();
                    schemesRiskTab.completeRisk();
                    break;
                case "Dirt Bike Insurance":
                    schemesRiskTab = new DirtBikesInsurance();
                    schemesRiskTab.completeRisk();
                    break;
                default:
                    break;
            }            
        }


        public void completeEDI()
        {
            wait.Until(driver => {
                return driver.FindElementsByName(_ediProduct).Count > 0;
            });

            Session.Session.M360Session.FindElementByName(_ediProduct).Click();
            Session.Session.M360Session.FindElementByName(SanityTests.testData.GetData("Profile", SanityTests.testData.testCaseId, "EDIProduct")).Click();
            Session.Session.M360Session.FindElementByName("tab5").Click();
            Session.Session.M360Session.FindElementByAccessibilityId(_newEDI).Click();

            SwitchToCurrentWindow();

            var ediAccountScreen = new AccountDetailsScreen();
            ediAccountScreen.selectAccount();
            var ediCustomerScreen = new CustomerScreen();
            ediCustomerScreen.fillCustomerDetails();
            var ediAddressScreen = new AddressScreen();
            ediAddressScreen.fillAddressDetails();
            var ediBuildingScreen = new BuildingContentsScreen();
            ediBuildingScreen.fillBuildingContentsDetails();
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

        public void finaliseEDI ()
        {
            Session.Session.M360Session.FindElementByName(_premiumSummaryTab).Click();
            Session.Session.M360Session.FindElementByName(_complete).Click();
            Session.Session.M360Session.FindElementByName(_yes).Click();
            SwitchToCurrentWindow();
        }

        public void createPolicy(bool installments = false, bool documentBuilder = false, bool profile = true, bool underWriter = true, bool risk = false, bool premium = true, bool edi = false)
        {
            setPolicyHeaderDetails();
            if (profile)
            {
                attachProfile();
            }
            if (documentBuilder)
            {
                createDocumentBuilder();
            }
            if (underWriter)
            {
                setUnderWriter();
            }
            if(edi)
            {
                completeEDI();
            }
            if(risk)
            {
                setRisk(SanityTests.testData.GetData("Profile", SanityTests.testData.testCaseId, "Scheme"));
            }
            billPolicy();
            if (premium)
            {
                setPremium(installments);
            }
            if (edi)
            {
                finaliseEDI();
            }
            else
            {
                Session.Session.M360Session.FindElementByName(_complete).Click();
                SwitchToCurrentWindow();
            }            
        }

        public void setPremium (bool installments, bool cancel = false)
        {
            Session.Session.M360Session.FindElementByName(_premiumSummaryTab).Click();
            if (cancel)
            {
                Session.Session.M360Session.FindElementByAccessibilityId(_premium).SendKeys('-' + SanityTests.testData.GetData("Profile", SanityTests.testData.testCaseId, "Premium"));
                Session.Session.M360Session.FindElementByAccessibilityId(_buttonPremiumCalc).Click();
                Session.Session.M360Session.FindElementByName(_UWPolicyFee).SendKeys('-' + SanityTests.testData.GetData("Profile", SanityTests.testData.testCaseId, "UWPolicyFee"));
                Session.Session.M360Session.FindElementByName(_brokerageRebate).SendKeys('-' + SanityTests.testData.GetData("Profile", SanityTests.testData.testCaseId, "BrokerageRebate"));
                Session.Session.M360Session.FindElementByName(_agentCommission).SendKeys('-' + SanityTests.testData.GetData("Profile", SanityTests.testData.testCaseId, "AgentCommission"));
                Session.Session.M360Session.FindElementByName(_brokerageRebate).Click();
            }
            else
            {
                Session.Session.M360Session.FindElementByAccessibilityId(_premium).SendKeys(SanityTests.testData.GetData("Profile", SanityTests.testData.testCaseId, "Premium"));
                Session.Session.M360Session.FindElementByAccessibilityId(_buttonPremiumCalc).Click();
                Session.Session.M360Session.FindElementByName(_UWPolicyFee).SendKeys(SanityTests.testData.GetData("Profile", SanityTests.testData.testCaseId, "UWPolicyFee"));
                Session.Session.M360Session.FindElementByName(_brokerageRebate).SendKeys(SanityTests.testData.GetData("Profile", SanityTests.testData.testCaseId, "BrokerageRebate"));
                Session.Session.M360Session.FindElementByName(_agentCommission).SendKeys(SanityTests.testData.GetData("Profile", SanityTests.testData.testCaseId, "AgentCommission"));
                Session.Session.M360Session.FindElementByName(_brokerageRebate).Click();

            }
            if (installments)
            {
                Session.Session.M360Session.FindElementByName(_installments).Click();
                Session.Session.M360Session.FindElementByName(_createInstallments).Click();
                Session.Session.M360Session.FindElementByName(_Ok).Click();
                wait.Until(driver => driver.FindElementsByAccessibilityId(_labelInstallment).Count > 0);
                Assert.IsTrue(Session.Session.M360Session.FindElementByAccessibilityId(_labelInstallment).Text.Contains("Instalment 1 of 12"));
            }           
        }

        public void gotoClientScreen()
        {
            Session.Session.M360Session.FindElementByName(_clientButton).Click();
            SwitchToCurrentWindow();
        }

        public void endorse(bool installments)
        {
            Session.Session.M360Session.FindElementByName(_close).Click();
            SwitchToCurrentWindow();
            Session.Session.M360Session.FindElementByName(_endorse).Click();
            Session.Session.M360Session.FindElementByAccessibilityId(_maxLimit).SendKeys(SanityTests.testData.GetData("Profile", SanityTests.testData.testCaseId, "NewMaxLimit"));
            Session.Session.M360Session.FindElementByName(_bill).Click();
            SwitchToCurrentWindow();
            Session.Session.M360Session.FindElementByAccessibilityId(_endorsementType).Click();
            Session.Session.M360Session.FindElementByName("Ad hoc declaration").Click();
            Session.Session.M360Session.FindElementByAccessibilityId(_dateFrom).SendKeys(DateTime.UtcNow.Date.ToString("dd/MM/yyyy"));
            Session.Session.M360Session.FindElementByAccessibilityId(_dateTo).SendKeys(DateTime.UtcNow.Date.AddYears(1).ToString("dd/MM/yyyy"));
            Session.Session.M360Session.FindElementByXPath(_confirmationTab).Click();
            Session.Session.M360Session.FindElementByAccessibilityId(_underwriterStatus).SendKeys("Not required");
            setPremium(installments);

        }


        public void cancelPolicy(bool installments)
        {
            Session.Session.M360Session.FindElementByName(_cancel).Click();
            wait.Until(driver => driver.FindElementsByName(_bill).Count > 0);
            Session.Session.M360Session.FindElementByName(_bill).Click();
            SwitchToCurrentWindow();
            Session.Session.M360Session.FindElementByAccessibilityId(_cancelType).Click();
            Session.Session.M360Session.FindElementByName("Full cancel").Click();
            Session.Session.M360Session.FindElementByAccessibilityId(_reasonType).Click();
            Session.Session.M360Session.FindElementByName("Policy Insured Elsewhere").Click();
            setPremium(installments, true);
        }

        public void lapsePolicy()
        {
            Session.Session.M360Session.FindElementByName(_lapse).Click();
            SwitchToCurrentWindow();
            Session.Session.M360Session.FindElementByAccessibilityId(_lapseReasonType).Click();
            Session.Session.M360Session.FindElementByName("Policy Insured Elsewhere").Click();
            Session.Session.M360Session.FindElementByName(_complete).Click();
        }
    }
}





