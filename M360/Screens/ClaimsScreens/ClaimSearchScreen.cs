using OpenQA.Selenium.Appium;
using ElementControl;
using M360TestAutomation.Tests;
using System;

namespace M360.Pages
{
    public class ClaimSearchScreen : BaseScreen
    {
        //Claim Search
        public AppiumWebElement _office
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "TextBoxCode");
            }
        }

        public AppiumWebElement _claim
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textClaimNumber");
            }
        }

        public AppiumWebElement _search
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonSearch");
            }
        }

      
        public AppiumWebElement _new
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "New");
            }
        }

        public void searchClaim(string claimNumber)
        {
            SwitchToCurrentWindow();
            _office.SetValue(BaseTest.testData.GetData("Claim", BaseTest.testData.testCaseId, "Office"));
            _claim.SetValue(claimNumber);
            _search.ClickButton();
            SwitchToCurrentWindow();
        }

        public void createNewClaim()
        {
            SwitchToCurrentWindow();
            _office.SetValue(BaseTest.testData.GetData("Claim", BaseTest.testData.testCaseId, "Office"));
            _new.ClickButton();
            SwitchToCurrentWindow();
        }
    }
}
