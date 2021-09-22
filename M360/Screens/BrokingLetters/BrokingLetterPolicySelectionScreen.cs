using ElementControl;
using M360.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M360
{
    public class BrokingLetterPolicySelectionScreen : BaseScreen
    {
        public AppiumWebElement _buttonSearch => GetElementByAccessibilityId("buttonSearch");
        public AppiumWebElement _gridPolicies => GetElementByAccessibilityId("gridPolicies");
        public AppiumWebElement _okButton => GetElementByAccessibilityId("buttonOkay");

        public void selectPolicyFromGrid()
        {
            Actions action = new Actions(Session.Session.M360Session);
            action.MoveByOffset(-700, 58);
            action.Click();
            action.DoubleClick();
            action.Perform();
        }

        
    }
}
