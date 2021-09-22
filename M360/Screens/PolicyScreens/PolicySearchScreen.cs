using ElementControl;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using System;
using System.Threading;

namespace M360.Pages
{
    public class PolicySearchScreen : BaseScreen
    {
        //search policy
        public AppiumWebElement _office
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "jltaCodeTandemBranch");
            }
        }

        public AppiumWebElement _policy
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textPolicy");
            }
        }
        public AppiumWebElement _search
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Search");
            }
        }

        public AppiumWebElement _new
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "New");
            }
        }

        public AppiumWebElement _close
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Close");
            }
        }

        public AppiumWebElement _results
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "jltaProgressStatus");
            }
        }

        public AppiumWebElement _ok
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "textBoxMessage");
            }
        }


        public void searchPolicy(string policyNo, JToken testData)
        {
            SwitchToCurrentWindow();
            _office.SetValue(testData["Office"].ToString());
            _policy.SetValue(policyNo);
            _search.ClickButton();
            Thread.Sleep(5000);
            try
            {
                SwitchToCurrentWindow();
            }
            catch (Exception e)
            {
                if (_ok != null)
                {
                    Assert.IsTrue(_results.Text.Contains("Your search criteria returned no results"));
                    _ok.ClickButton();
                }
            }
        }

        public void searchPolicyWithClaim(JToken testData)
        {
            SwitchToCurrentWindow();
            _office.SetValue(testData["Office"].ToString());
            _policy.SetValue(testData["Policy"].ToString());
            _search.ClickButton();
            SwitchToCurrentWindow();
        }



        public void createNewPolicy(JToken testData)
        {
            SwitchToCurrentWindow();
            _office.SetValue(testData["Office"].ToString());
            _new.ClickButton();
            SwitchToCurrentWindow();
        }

        public void close()
        {
            _close.ClickButton();
            SwitchToCurrentWindow();
        }
    }
}





