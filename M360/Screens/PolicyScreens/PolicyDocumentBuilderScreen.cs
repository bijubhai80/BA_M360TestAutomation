using ElementControl;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Appium;

namespace M360.Pages
{
    public class PolicyDocumentBuilderScreen : BaseScreen
    {
        //policyDocumentBuilder
        public AppiumWebElement _documentTypes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_comboDocumentTypes");
            }
        }

        public AppiumWebElement _quotationSlipDocType
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Quotation Slip");
            }
        }

        public AppiumWebElement _create
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_buttonCreate");
            }
        }

        public AppiumWebElement _save
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonSave");
            }
        }

        public AppiumWebElement _scheduleTab
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "tab4");
            }
        }

        public AppiumWebElement _profileButton
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_radioProfile");
            }
        }

        public AppiumWebElement _profileType
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_profileComboBox");
            }
        }

        public AppiumWebElement _attach
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_buttonAttach");
            }
        }
        public AppiumWebElement _documents
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "tab9");
            }
        }
        public AppiumWebElement _policyDocBuilderclose
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_buttonClose");
            }
        }

        public AppiumWebElement _documentButton
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonDocDocument");
            }
        }

        public AppiumWebElement _documentBuilder
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "Document Builder...");
            }
        }


        public void attachProfile(JToken testData)
        {
            _scheduleTab.ClickButton();
            _profileButton.ClickButton();
            _profileType.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["ProfileType"].ToString()).Click();
            _attach.ClickButton();
            _save.ClickButton();
        }

        public void createDocumentBuilder(JToken testData)
        {
            _documents.ClickButton();
            _documentButton.ClickButton();
            _documentBuilder.ClickButton();
            SwitchToCurrentWindow();

            _documentTypes.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["DocumentBuilderType"].ToString()).Click();
            _create.ClickButton();

            //goto word doc
            /*var action = new Actions(Session.Session.M360Session);
            action.MoveByOffset(70, -380);
            action.Click();
            action.DoubleClick();
            action.Perform();

            var wordDocument = new WordDocument();
            var text = "SITUATION and/ or PREMISES " + "Test Situation" 
                + "From:	" + DateTime.UtcNow.Date.ToString("dd/MM/yyyy")
                + "To: " + DateTime.UtcNow.Date.AddYears(1).ToString("dd/MM/yyyy");            
            wordDocument.verifyText(text);                        
            */

            _policyDocBuilderclose.ClickButton();
            SwitchToCurrentWindow();
        }
    }
}
