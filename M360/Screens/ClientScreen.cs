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

namespace M360.Pages
{
    public class ClientScreen : BaseScreen
    {
        public string _office = "TextBoxCode";
        public string _clientCode = "textClientCode";
        public string _search = "buttonSearch";
        public string _profileTab = "tabProfile";
        public string _tableControl = "tableControl1";
        public string _ok = "buttonOk";
        public string _yes = "Yes";
        public string _delete = "Delete";


        public string _edit = "buttonEdit";
        public string _new = "New";
        public string _close = "Close";
        public string _profileType = "comboProfileType";
        public string _insert = "Insert";

        public string _wordContent = "Page 1 content";
        public string _wordFileTab = "File Tab";
        public string _wordClose = "Close";
        public string _wordYes = "Yes";


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
            Thread.Sleep(10000);
            Session.Session.M360Session.SwitchTo().Window(Session.Session.M360Session.WindowHandles[0]);
            Session.Session.M360Session.FindElementByAccessibilityId(_office).SendKeys("062");
            Session.Session.M360Session.FindElementByAccessibilityId(_clientCode).SendKeys("ALBAN");
            Session.Session.M360Session.FindElementByAccessibilityId(_search).Click();
        }

        public void editProfileDocs()
        {
            Thread.Sleep(10000);
            Session.Session.M360Session.SwitchTo().Window(Session.Session.M360Session.WindowHandles[0]);
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
            Thread.Sleep(10000);
            Session.Session.M360Session.SwitchTo().Window(Session.Session.M360Session.WindowHandles[0]);
        }

        private void editWordDoc()
        {
            Actions action = new Actions(Session.Session.M360Session);
            action.MoveByOffset(70, -380);
            action.Click();
            action.DoubleClick();
            action.Perform();

            AppiumOptions rootCapabilities = new AppiumOptions();
            rootCapabilities.AddAdditionalCapability("app", "Root");
            // Create a session for the desktop
            WindowsDriver<WindowsElement> desktopSession = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), rootCapabilities);
            var wait = new DefaultWait<WindowsDriver<WindowsElement>>(desktopSession)
            {
                Timeout = TimeSpan.FromSeconds(60),
                PollingInterval = TimeSpan.FromSeconds(1)
            };
            wait.Until(driver => {
                return driver.FindElementsByName("Word 2016 - 1 running window").Count > 0;
            });
            desktopSession.FindElementByName(_wordContent).SendKeys("12323");
            var x = desktopSession.FindElementsByName(_wordClose);
            x[0].Click();
            desktopSession.FindElementByName(_wordYes).Click();
            
            action.Perform();
            
            wait.Until(driver => {
                return driver.FindElementsByName("Word 2016 - 1 running window").Count > 0;
            });
            var textContent = desktopSession.FindElementByName(_wordContent).Text;
            Assert.IsTrue(textContent.Contains("12323"));
            x = desktopSession.FindElementsByName(_wordClose);
            x[0].Click();
            Session.Session.M360Session.FindElementByName(_close).Click();
            Thread.Sleep(10000);
            Session.Session.M360Session.SwitchTo().Window(Session.Session.M360Session.WindowHandles[0]);           
        }

        public void createNewClient()
        {
            Thread.Sleep(10000);
            Session.Session.M360Session.SwitchTo().Window(Session.Session.M360Session.WindowHandles[0]);
            Session.Session.M360Session.FindElementByName(_new).Click();
            Thread.Sleep(10000);
            Session.Session.M360Session.SwitchTo().Window(Session.Session.M360Session.WindowHandles[0]);
            Session.Session.M360Session.FindElementByAccessibilityId(_code).SendKeys("062");
            Session.Session.M360Session.FindElementByAccessibilityId(_name).SendKeys("Test Client");
            Session.Session.M360Session.FindElementByAccessibilityId(_dept).Click();
            Session.Session.M360Session.FindElementByName("P. Smith (001)").Click();
            Session.Session.M360Session.FindElementByAccessibilityId(_segment).Click();
            Session.Session.M360Session.FindElementByName("Affinity (AF)").Click();
            Session.Session.M360Session.FindElementByAccessibilityId(_sic).Click();
            Session.Session.M360Session.FindElementByName("AABTH Members (6655)").Click();
            Session.Session.M360Session.FindElementByXPath(_broker).Click();
            Session.Session.M360Session.FindElementByName("Adams, John (ADAMJ)").Click();
            Session.Session.M360Session.FindElementByAccessibilityId(_save).Click();
            Session.Session.M360Session.FindElementByName(_profileTab).Click();
            Session.Session.M360Session.FindElementByAccessibilityId(_profileTypeDropdown).Click();            
            Session.Session.M360Session.FindElementByName("Client Profile - Marsh").Click();
            Session.Session.M360Session.FindElementByName(_insert).Click();
            //editWordDoc();
            Session.Session.M360Session.FindElementByName(_delete).Click();
            Thread.Sleep(10000);
            Session.Session.M360Session.SwitchTo().Window(Session.Session.M360Session.WindowHandles[0]);
            Session.Session.M360Session.FindElementByName(_yes).Click();
            Thread.Sleep(10000);
            Session.Session.M360Session.SwitchTo().Window(Session.Session.M360Session.WindowHandles[0]);
        }
    }
}







