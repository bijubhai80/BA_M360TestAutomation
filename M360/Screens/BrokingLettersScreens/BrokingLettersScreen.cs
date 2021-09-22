using ElementControl;
using M360.Pages;
using M360.Screens;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace M360
{
    public class BrokingLettersScreen : BaseScreen
    {
        public AppiumWebElement _office => GetElementByAccessibilityId("TextBoxCode");
        public AppiumWebElement _clients => GetElementByAccessibilityId("textClientCodes");
        public AppiumWebElement _buttonPolicyEllipsis => GetElementByAccessibilityId("buttonPolicyEllipsis");
        public AppiumWebElement _letter => GetElementByAccessibilityId("comboLetter");
        public AppiumWebElement _create => GetElementByAccessibilityId("buttonCreate");
        public AppiumWebElement _textPolicyNumber => GetElementByAccessibilityId("textPolicyNumber");
        public AppiumWebElement _closeWord => GetElementByName("Close");


        public void CreateCofC(JToken testData)
        {
            _office.SetValue(testData["Office"].ToString());
            _clients.SetValue(testData["Client"].ToString());
            Session.Session.M360Session.Keyboard.PressKey(Keys.Tab);
            _buttonPolicyEllipsis.ClickButton();
            var brokingLetterPolicySelect = new BrokingLetterPolicySelectionScreen();
            brokingLetterPolicySelect.searchBrokingLetterPolicy();
            brokingLetterPolicySelect._okButton.ClickButton();
            SwitchToCurrentWindow();
            _letter.ClickButton();
            SelectDropdownOption(18);
            _create.ClickButton();


        }


        public void saveCofCDocument()
        {
            WordDocument word = new WordDocument();
            word.editDocument("Test");
        }


    }
}
