using OpenQA.Selenium.Appium;
using ElementControl;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace M360.Pages
{
    public class ClientContacts : BaseScreen
    {
        private AppiumWebElement _contactsTab => WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "tabContacts");
        
        // Fields on the Contacts tab
        private AppiumWebElement _type => WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "comboBoxAddType");
        private AppiumWebElement _contact => WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textBoxContact");
        private AppiumWebElement _position => WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textBoxPosition");
        private AppiumWebElement _mobile => WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textBoxMobileNumber");
        private AppiumWebElement _email => WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textBoxEmailAddress");
        private AppiumWebElement _salutation => WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textBoxSalutation");
        private AppiumWebElement _comments => WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "multiTextBoxComments");
        
        // Buttons
        private AppiumWebElement _saveClientButton => WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonSave");
        private AppiumWebElement _closeClientButton => WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonClose");
        private AppiumWebElement _addContactButton => WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonAdd");
        private AppiumWebElement _removeContactButton => WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonRemove");
        private AppiumWebElement _yesButton => WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonYes");
        private AppiumWebElement _switchToSingleViewButton => WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonSwitchView");
        private AppiumWebElement _moveToNextContactButton => WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonNext");


        public void GoToContacts()
        {
            _contactsTab.ClickButton();
        }

        public void AddContact(JToken testData)
        {
            // Click on add contact
            _addContactButton.ClickButton();

            // Fill out form
            _type.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["Type"].ToString()).Click();
            _contact.SetValue(testData["Contact"].ToString());
            _position.SetValue(testData["Position"].ToString());
            _mobile.SetValue(testData["Mobile"].ToString());
            _email.SetValue(testData["Email"].ToString());
            _salutation.SetValue(testData["Salutation"].ToString());
            _comments.SetValue(testData["Comments"].ToString());

            // Save
            _saveClientButton.ClickButton();

            // Close
            _closeClientButton.ClickButton();
        }

        public void VerifyContact(JToken testData)
        {
            // Move to the second contact.
            _switchToSingleViewButton.ClickButton();
            _moveToNextContactButton.ClickButton();

            // Verify the contact.
            Assert.IsTrue(_type.Text.Equals(testData["Type"].ToString()));
            Assert.IsTrue(_contact.Text.Equals(testData["Contact"].ToString()));
            Assert.IsTrue(_position.Text.Equals(testData["Position"].ToString()));
            Assert.IsTrue(_mobile.Text.Equals(testData["Mobile"].ToString()));
            Assert.IsTrue(_email.Text.Equals(testData["Email"].ToString()));
            Assert.IsTrue(_salutation.Text.Equals(testData["Salutation"].ToString()));
            Assert.IsTrue(_comments.Text.Equals(testData["Comments"].ToString()));
        }

        public void DeleteContact(JToken testData)
        {
            // Click Remove and then Yes on the confirmation dialog.
            _removeContactButton.ClickButton();
            _yesButton.ClickButton();

            // Save
            _saveClientButton.ClickButton();

            // Close
            _closeClientButton.ClickButton();
        }
    }
}


