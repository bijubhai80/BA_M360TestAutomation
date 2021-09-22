using ElementControl;
using M360.Pages;
using M360TestAutomation.Tests;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace M360
{
   public class BrokingLettersScreen: BaseScreen
    {
        public AppiumWebElement _office => GetElementByAccessibilityId("TextBoxCode");
        public AppiumWebElement _clients => GetElementByAccessibilityId("textClientCodes");
        public AppiumWebElement _buttonPolicyEllipsis => GetElementByAccessibilityId("buttonPolicyEllipsis");
        public AppiumWebElement _letter => GetElementByAccessibilityId("comboLetter");
        public AppiumWebElement _create => GetElementByAccessibilityId("buttonCreate");
        public AppiumWebElement _textPolicyNumber => GetElementByAccessibilityId("textPolicyNumber");
      

        public void CreateCofC(JToken testData)
        {
            _office.SetValue(testData["Office"].ToString());
            _clients.SetValue(testData["Client"].ToString());
            Session.Session.M360Session.Keyboard.PressKey(Keys.Tab);
            // wait.Until(driver => _textPolicyNumber.Enabled);
            _buttonPolicyEllipsis.ClickButton();
            var brokingLetterPolicySelect = new BrokingLetterPolicySelectionScreen();
            Thread.Sleep(4000);
            brokingLetterPolicySelect._buttonSearch.ClickButton();
            brokingLetterPolicySelect.selectPolicyFromGrid();
           // brokingLetterPolicySelect._okButton.ClickButton();
           // _letter.SetValue(testData["Letter"].ToString());
            //Session.Session.M360Session.Keyboard.PressKey(Keys.Tab);
            // _create.ClickButton();

            /* _buttonPolicyEllipsis.ClickButton();
            var brokingLetterPolicySelect = new BrokingLetterPolicySelectionScreen();
            Thread.Sleep(2000);
            brokingLetterPolicySelect._buttonSearch.ClickButton();
            brokingLetterPolicySelect._gridPolicies.ClickButton();
            Session.Session.M360Session.Keyboard.PressKey(Keys.Space);
            brokingLetterPolicySelect._okButton.ClickButton();*/
            //  _textPolicyNumber.SetValue(testData["Policy"].ToString());
            // Session.Session.M360Session.Keyboard.PressKey(Keys.Tab);

        }
    }
}
