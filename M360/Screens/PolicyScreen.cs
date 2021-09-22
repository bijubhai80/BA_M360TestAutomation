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

namespace M360.Pages
{
    public class PolicyScreen : BaseScreen
    {
        public string _policy = "textPolicy";
        public string _search = "Search";
        public string _renewal = "Renew";

        public string _incRnl = "Inc. Rnl";
        public string _modifyRnl = "Modify Rnl";
        public string _bill = "Bill";
        public string _yes = "Yes";
        public string _complete = "Complete";
        public string _premiumSummaryTab = "tab2";
        public string _premium = "textBoxPremium";
        public string _buttonPremiumCalc = "buttonPremiumCalc";
        public string _UWPolicyFee = "UW Policy Fee";
        public string _brokerage = "Brokerage";

        public string _transactions = "tab11";
        public string _details = "Details";
        public string _reverse = "Reverse";
        public string _close = "Close";

        public void searchPolicy(string policyNo)
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

            Session.Session.M360Session.FindElementByAccessibilityId(_policy).SendKeys(policyNo);
            Session.Session.M360Session.FindElementByName(_search).Click();            
        }

        public void renewPolicy()
        {
            Thread.Sleep(10000);
            Session.Session.M360Session.SwitchTo().Window(Session.Session.M360Session.WindowHandles[0]);

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
            Session.Session.M360Session.FindElementByName(_yes).Click();

            Thread.Sleep(10000);
            Session.Session.M360Session.SwitchTo().Window(Session.Session.M360Session.WindowHandles[0]);
            Session.Session.M360Session.FindElementByName(_yes).Click();
            Session.Session.M360Session.FindElementByName(_premiumSummaryTab).Click();
            Session.Session.M360Session.FindElementByAccessibilityId(_premium).SendKeys("5000");
            Session.Session.M360Session.FindElementByAccessibilityId(_buttonPremiumCalc).Click();
            Session.Session.M360Session.FindElementByName(_UWPolicyFee).SendKeys("100");
            Session.Session.M360Session.FindElementByName(_brokerage).SendKeys("100");
            Session.Session.M360Session.FindElementByName(_complete).Click();
            
        }
        public void reversePolicy() {
            Thread.Sleep(10000);
            Session.Session.M360Session.SwitchTo().Window(Session.Session.M360Session.WindowHandles[0]);
            Session.Session.M360Session.FindElementByName(_transactions).Click();
            Session.Session.M360Session.FindElementByName(_details).Click();
            Thread.Sleep(10000);
            Session.Session.M360Session.SwitchTo().Window(Session.Session.M360Session.WindowHandles[0]);
            Session.Session.M360Session.FindElementByName(_reverse).Click();
            Session.Session.M360Session.FindElementByName(_yes).Click();
            Session.Session.M360Session.FindElementByName(_complete).Click();
        }
    }
}



