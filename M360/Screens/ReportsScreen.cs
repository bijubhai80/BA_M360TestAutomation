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

namespace M360.Pages
{
    public class ReportsScreen : BaseScreen
    {
        public string _sanityTestReport = "Outstanding Renewals and Expired Non Renewables Report";
        public string _policyExpiryDateFrom = "POLICY_EXPIRY_FROM";
        public string _policyExpiryDateTo = "POLICY_EXPIRY_TO";
        public string _outputType = "Output Type";
        public string _saveAsFile = "Save as File";
        public string _run = "Run";
        public string _yes = "Yes";
        public string _close = "Close";


        public void generateSanityTestReport()
        {
            var wait = new DefaultWait<WindowsDriver<WindowsElement>>(Session.Session.M360Session)
            {
                Timeout = TimeSpan.FromSeconds(60),
                PollingInterval = TimeSpan.FromSeconds(1)
            };
            wait.Until(driver => {
                return driver.WindowHandles.Count == 2;
            });

            Session.Session.M360Session.SwitchTo().Window(Session.Session.M360Session.WindowHandles[0]);
            Session.Session.M360Session.FindElementByName(_sanityTestReport).Click();
            Session.Session.M360Session.FindElementByAccessibilityId(_policyExpiryDateFrom).SendKeys(DateTime.UtcNow.Date.ToString("dd/MM/yyyy"));
            Session.Session.M360Session.FindElementByAccessibilityId(_policyExpiryDateTo).SendKeys(DateTime.UtcNow.Date.AddDays(120).ToString("dd/MM/yyyy"));
            Session.Session.M360Session.FindElementByName(_outputType).Click();
            Session.Session.M360Session.FindElementByName(_saveAsFile).Click();
            Session.Session.M360Session.FindElementByName(_run).Click();
            var fileName = @"C:\temp\Outstanding Renewals and Expired Non Renewables Report.csv";
            Session.Session.M360Session.Keyboard.SendKeys(fileName);
            Session.Session.M360Session.Keyboard.PressKey(Keys.Tab);
            Session.Session.M360Session.Keyboard.PressKey(Keys.ArrowDown);            
            Session.Session.M360Session.Keyboard.PressKey(Keys.ArrowDown);
            Session.Session.M360Session.Keyboard.PressKey(Keys.Tab);
            Session.Session.M360Session.Keyboard.PressKey(Keys.Enter);
            Session.Session.M360Session.FindElementByName(_yes).Click();
            wait.Until(driver => {
                return File.Exists(fileName);
            });
        }
    }
}
