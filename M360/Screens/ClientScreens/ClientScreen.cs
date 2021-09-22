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
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Interactions.Internal;
using System.Drawing;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using M360.Screens;

namespace M360.Pages
{
    public class ClientScreen : BaseScreen
    {
        //client screen
        public string _office = "TextBoxCode";
        public string _clientCode = "textClientCode";
        public string _search = "buttonSearch";
        public string _profileTab = "tabProfile";
        public string _fundingTab = "tabFunding";
        public string _tableControl = "tableControl1";
        public string _details = "Details";
        public string _ok = "buttonOk";
        public string _yes = "Yes";
        public string _delete = "Delete";

        //profile Tab
        public string _edit = "buttonEdit";
        public string _new = "New";
        public string _close = "Close";
        public string _profileType = "comboProfileType";
        public string _insert = "Insert";

        //fundingTab
        public string _totalFunded = "Total Funded";

        //word doc
        public string _wordContent = "Page 1 content";
        public string _wordFileTab = "File Tab";
        public string _wordClose = "Close";
        public string _wordYes = "Yes";

        //?
        public string _code = "textCode";
        public string _name = "textName";
        public string _dept = "jltaCodeTandemTeam";
        public string _segment = "jltaCodeTandemMarSeg";
        public string _sic = "jltaCodeTandemStandardIndustryClass";
        public string _broker = "//Pane[starts-with(@AutomationId,'jltaCodeTandemBroker')]/ComboBox[@AutomationId='comboBoxItem']";
        public string _profileTypeDropdown = "comboProfileType";

        public string _save = "buttonSave";
        
        public void searchClient()
        {
            SwitchToCurrentWindow();
            Session.Session.M360Session.FindElementByAccessibilityId(_office).SendKeys("062");
            Session.Session.M360Session.FindElementByAccessibilityId(_clientCode).SendKeys("ALBAN");
            Session.Session.M360Session.FindElementByAccessibilityId(_search).Click();
        }

        public void editProfileDocs()
        {
            SwitchToCurrentWindow();
            Session.Session.M360Session.FindElementByName(_profileTab).Click();
            Session.Session.M360Session.FindElementByAccessibilityId(_edit).Click();
            var wait = new DefaultWait<WindowsDriver<WindowsElement>>(Session.Session.M360Session)
            {
                Timeout = TimeSpan.FromSeconds(60),
                PollingInterval = TimeSpan.FromSeconds(1)
            };
            wait.Until(driver => {
                return driver.FindElementByAccessibilityId(_edit).Enabled == false;
            });
            editWordDoc();
            Session.Session.M360Session.FindElementByName(_close).Click();
            SwitchToCurrentWindow();
        }

        private void editWordDoc()
        {
            Actions action = new Actions(Session.Session.M360Session);
            action.MoveByOffset(70, -380);
            action.Click();
            action.DoubleClick();
            action.Perform();

            var wordDocument = new WordDocument();
            wordDocument.editDocument("Sample Text");

            action = new Actions(Session.Session.M360Session);
            action.Click();
            action.DoubleClick();
            action.Perform();

            wordDocument.verifyText("Sample Text");
            Session.Session.M360Session.FindElementByName(_close).Click();
            SwitchToCurrentWindow();
        }

        public void createNewClient()
        {
            SwitchToCurrentWindow();
            Session.Session.M360Session.FindElementByName(_new).Click();
            SwitchToCurrentWindow();
            Session.Session.M360Session.FindElementByAccessibilityId(_code).SendKeys(SanityTests.testData.GetData("Client", SanityTests.testData.testCaseId, "Code"));
            Session.Session.M360Session.FindElementByAccessibilityId(_name).SendKeys(SanityTests.testData.GetData("Client", SanityTests.testData.testCaseId, "Name"));
            Session.Session.M360Session.FindElementByAccessibilityId(_dept).Click();
            Session.Session.M360Session.FindElementByName(SanityTests.testData.GetData("Client", SanityTests.testData.testCaseId, "Dept")).Click();
            Session.Session.M360Session.FindElementByAccessibilityId(_segment).Click();
            Session.Session.M360Session.FindElementByName(SanityTests.testData.GetData("Client", SanityTests.testData.testCaseId, "Segment")).Click();
            Session.Session.M360Session.FindElementByAccessibilityId(_sic).Click();
            Session.Session.M360Session.FindElementByName(SanityTests.testData.GetData("Client", SanityTests.testData.testCaseId, "SIC")).Click();
            Session.Session.M360Session.FindElementByXPath(_broker).Click();
            Session.Session.M360Session.FindElementByName(SanityTests.testData.GetData("Client", SanityTests.testData.testCaseId, "Broker")).Click();
            Session.Session.M360Session.FindElementByAccessibilityId(_save).Click();
            Session.Session.M360Session.FindElementByName(_profileTab).Click();
            Session.Session.M360Session.FindElementByAccessibilityId(_profileTypeDropdown).Click();            
            Session.Session.M360Session.FindElementByName(SanityTests.testData.GetData("Client", SanityTests.testData.testCaseId, "ProfileType")).Click();
            Session.Session.M360Session.FindElementByName(_insert).Click();
            //editWordDoc();
            Session.Session.M360Session.FindElementByName(_delete).Click();
            SwitchToCurrentWindow();
            Session.Session.M360Session.FindElementByName(_yes).Click();
            SwitchToCurrentWindow();
        }

        public void verifyFundingContract()
        {
            Session.Session.M360Session.FindElementByName(_fundingTab).Click();
            Session.Session.M360Session.FindElementByName(_details).Click();
            SwitchToCurrentWindow();
            var totalFunded = Session.Session.M360Session.FindElementByName(_totalFunded).Text;
            Assert.IsTrue(totalFunded.Contains(SanityTests.testData.GetData("Profile", SanityTests.testData.testCaseId, "TotalFunded")));            
        }
    }
}







