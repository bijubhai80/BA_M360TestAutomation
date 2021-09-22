using ElementControl;
using M360.Screens;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium.Appium;

namespace M360.Pages
{
    public class ClientSearchScreen : BaseScreen
    {
        public AppiumWebElement _office
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "TextBoxCode");
            }
        }

        public AppiumWebElement _clientCode
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textClientCode");
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


        public AppiumWebElement _bpay
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textBpay");
            }
        }

        public AppiumWebElement _name
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textClientName");
            }
        }

        public AppiumWebElement _broker
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@AutomationId=\"jltaCodeTandemBroker\"]/Edit[@AutomationId=\"TextBoxCode\"]");
            }
        }

        public AppiumWebElement _dept
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@AutomationId=\"jltaCodeTandemTeam\"]/Edit[@AutomationId=\"TextBoxCode\"]");
            }
        }

        public AppiumWebElement _marketSegment
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@AutomationId=\"jltaCodeTandemMS\"]/Edit[@AutomationId=\"TextBoxCode\"]");
            }
        }

        public AppiumWebElement _group
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@AutomationId=\"jltaCodeTandemGroup\"]/Edit[@AutomationId=\"TextBoxCode\"]");
            }
        }

        public AppiumWebElement _companyNumber
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textCompanyNumber");
            }
        }

        public AppiumWebElement _okButton
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonOk");
            }
        }

        public AppiumWebElement _checkActiveClients
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "checkActiveClients");
            }
        }

        public AppiumWebElement _checkPendingApprovalOnly
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "checkPendingApprovalOnly");
            }
        }
        public AppiumWebElement _radioButtonId
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "radioClientId");
            }
        }

        public AppiumWebElement _export
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Export");
            }
        }

        public AppiumWebElement _utilities
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Utilities");
            }
        }

        public AppiumWebElement _closeButton
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonClose");
            }
        }
        public AppiumWebElement _homeButton => GetElementByAccessibilityId("buttonExit");


        public void closeSearchForm()
        {
            _closeButton.ClickButton();

        }

        public void searchClient(string[] searchTypes, JToken testData, bool switchWindow = true)
        {
            if (switchWindow)
            {
                SwitchToCurrentWindow();
            }

            _office.SetValue(testData["Code"].ToString());
            SetSearchValues(searchTypes, testData);
            _search.ClickButton();
        }

        public void searchClientWithHistory(JToken testData)
        {
            SwitchToCurrentWindow();
            _office.SetValue(testData["Office"].ToString());
            _clientCode.SetValue(testData["ClientCode"].ToString());
            _search.ClickButton();
        }

        public void SearchClientCompany(string[] searchTypes, JToken testData)
        {
            SwitchToCurrentWindow();
            _office.SetValue(testData["Code"].ToString());

            SetSearchValues(searchTypes, testData);

            _search.ClickButton();
            _okButton.ClickButton();
        }

        public void SearchClientInactive(string[] searchTypes, JToken testData)
        {
            SwitchToCurrentWindow();
            _office.SetValue(testData["Code"].ToString());

            SetSearchValues(searchTypes, testData);

            _checkActiveClients.ClickButton();
            _search.ClickButton();
        }

        public void searchClientWithDMGReview(JToken testData)
        {
            SwitchToCurrentWindow();
            _office.SetValue(testData["Code"].ToString());
            _clientCode.SetValue(testData["ClientCode"].ToString());
            _search.ClickButton();
            SwitchToCurrentWindow();
        }

        public void searchInactiveClient(JToken testData)
        {
            SwitchToCurrentWindow();
            _office.SetValue(testData["Code"].ToString());
            _clientCode.SetValue(testData["ClientCode"].ToString());
            _checkActiveClients.ClickButton();
            _checkPendingApprovalOnly.ClickButton();
            _search.ClickButton();
            SwitchToCurrentWindow();
        }

        public void SearchClientById(string[] searchTypes, JToken testData)
        {
            SwitchToCurrentWindow();
            _office.SetValue(testData["Code"].ToString());

            // Click the radio button before setting the values as it clears the textbox.
            _radioButtonId.ClickButton();

            SetSearchValues(searchTypes, testData);

            _search.ClickButton();
            _okButton.ClickButton();
        }

        //verifies that the correct client turns up in the search results
        public void verifyClientExcel(string clientNo)
        {   //if on client screen (i.e. one client only), return client number
            //assert the text on the element _clientCode is ALBAN
            _export.ClickButton();
            var excelDoc = new ExcelDocument();
            excelDoc.saveExcel();
            var excelText = excelDoc.readExcel(@"C:\temp\excel.csv");
            Assert.IsTrue(excelText.Contains(clientNo));
        }

        public void verifyClientScreen(string clientNo)
        {   //if on client screen (i.e. one client only), return client number
            //assert the text on the element _clientCode is ALBAN
            SwitchToCurrentWindow();
            var clientScreen = new ClientNewClientScreen();
            var clientCode = clientScreen._code.Text;
            Assert.IsTrue(clientCode.Contains(clientNo));
        }


        public void createNewClient(JToken testData, bool switchToWindow = true)
        {
            if (switchToWindow) SwitchToCurrentWindow();
            _office.SetValue(testData["Code"].ToString());
            _new.ClickButton();
            SwitchToCurrentWindow();
        }

        public void gotoReAssignClients()
        {
            _utilities.ClickButton();
            SelectDropdownOption(2);
        }

        private void SetSearchValues(string[] searchTypes, JToken testData)
        {
            foreach (var searchType in searchTypes)
            {
                switch (searchType)
                {
                    case "ClientCode":
                        _clientCode.SetValue(testData["ClientCode"].ToString());
                        break;
                    case "BPAY":
                        _bpay.SetValue(testData["BPAY"].ToString());
                        break;
                    case "ClientName":
                        _name.SetValue(testData["Name"].ToString());
                        break;
                    case "Broker":
                        _broker.SetValue(testData["Broker"].ToString());
                        break;
                    case "Dept":
                        _dept.SetValue(testData["Dept"].ToString());
                        break;
                    case "Segment":
                        _marketSegment.SetValue(testData["Segment"].ToString());
                        break;
                    case "Group":
                        _group.SetValue(testData["Group"].ToString());
                        break;
                    case "CompanyNumber":
                        _companyNumber.SetValue(testData["CompanyNumber"].ToString());
                        break;
                    case "ID":
                        _clientCode.SetValue(testData["ID"].ToString());
                        break;
                    default:
                        break;
                }
            }
        }


        public void home()
        {
            _homeButton.ClickButton();
            SwitchToCurrentWindow();
        }
    }
}
