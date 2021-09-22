using ElementControl;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.IO;

namespace M360.Pages
{
    public class ReportsScreen : BaseScreen
    {
        public AppiumWebElement _officeEllipses
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonOrganisationUnits");
            }
        }



        public AppiumWebElement _sanityTestReport
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Outstanding Renewals and Expired Non Renewables Report");
            }
        }

        public AppiumWebElement _policyExpiryDateFrom
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "POLICY_EXPIRY_FROM");
            }
        }

        public AppiumWebElement _policyExpiryDateTo
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "POLICY_EXPIRY_TO");
            }
        }

        public AppiumWebElement _outputType
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Output Type");
            }
        }

        public AppiumWebElement _saveAsFile
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Save as File");
            }
        }

        public AppiumWebElement _run
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Run");
            }
        }

        public AppiumWebElement _yes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Yes");
            }
        }

        public AppiumWebElement _close
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Close");
            }
        }

        public AppiumWebElement _office060 => GetElementByName("Perth (060)");
        public AppiumWebElement _ok => GetElementByName("Ok");


        public void generateSanityTestReport()
        {
            SwitchToCurrentWindow();
            _sanityTestReport.ClickButton();
            _officeEllipses.ClickButton();
            _office060.ClickButton();
            Session.Session.M360Session.Keyboard.SendKeys(Keys.Space);
            _ok.ClickButton();
            _policyExpiryDateFrom.SetValue(DateTime.UtcNow.Date.ToString("dd/MM/yyyy"));
            _policyExpiryDateTo.SetValue(DateTime.UtcNow.Date.AddDays(120).ToString("dd/MM/yyyy"));
            _outputType.ClickButton();
            _saveAsFile.ClickButton();
            _run.ClickButton();
            if (File.Exists(@"C:\temp\Outstanding Renewals and Expired Non Renewables Report.csv"))
            {
                File.Delete(@"C:\temp\Outstanding Renewals and Expired Non Renewables Report.csv");
            }
            var fileName = @"C:\temp\Outstanding Renewals and Expired Non Renewables Report.csv";
            Session.Session.M360Session.Keyboard.SendKeys(fileName);
            Session.Session.M360Session.Keyboard.PressKey(Keys.Tab);
            Session.Session.M360Session.Keyboard.PressKey(Keys.ArrowDown);
            Session.Session.M360Session.Keyboard.PressKey(Keys.ArrowDown);
            Session.Session.M360Session.Keyboard.PressKey(Keys.Tab);
            Session.Session.M360Session.Keyboard.PressKey(Keys.Enter);
            _yes.ClickButton();
            if (_ok != null) _ok.ClickButton();

            wait.Timeout = new TimeSpan(0, 0, 500);
            wait.Until(driver =>
            {
                return File.Exists(fileName);
            });
        }
    }
}
