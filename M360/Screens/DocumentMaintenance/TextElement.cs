using ElementControl;
using M360.Screens;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace M360.Pages
{
    public class TextElement : BaseScreen
    {
        public AppiumWebElement _elementClass
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "comboElementClass");
            }
        }

        public AppiumWebElement _tbElementType
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "TextBoxCode");
            }
        }
        public AppiumWebElement _cbElementType
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "ComboBoxItem");
            }
        }
        public AppiumWebElement _txtDescription
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textDescription");
            }
        }
        public AppiumWebElement _chkBoxActive
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "checkBoxActive");
            }
        }
        public AppiumWebElement _btnSearch
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonSearch");
            }
        }
        public AppiumWebElement _btnDetails
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonDetails");
            }
        }

        public AppiumWebElement _tabRelease
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, " tabPageReleases");
            }
        }
        public AppiumWebElement _btnDocument
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonDocumentOrPreview");
            }
        }

        public AppiumWebElement _tboxElementType
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session,
                    WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@AutomationId=\"codeTandemElementType\"]//Edit[@AutomationId=\"TextBoxCode\"]");
            }
        }
        
        public AppiumWebElement _btnDetailsClose
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session,WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonClose");
            }
        }
        public AppiumWebElement _btnClose
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session,WinAppDriverControlMethods.SearchBy.Name,"Close");
                
            }
        }
      
        public AppiumWebElement _utilities
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Utilities");
            }
        }

        public AppiumWebElement _rules
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Rules");
            }
        }
        public AppiumWebElement _elementOffice
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@AutomationId=\"codeTandemBranch\"]//Edit[@AutomationId=\"TextBoxCode\"]");
            }
        }
        public AppiumWebElement _elementSegment
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@AutomationId=\"codeTandemMarketSegment\"]//Edit[@AutomationId=\"TextBoxCode\"]");
            }
        }
        public AppiumWebElement _elementBusiness
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath,"");
            }
        }

        public AppiumWebElement _elementUnderwriter
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "");
                }
        }

        public AppiumWebElement _elementInsuranceClass
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "");
            }
        }

        public AppiumWebElement _checkBoxInactive
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "checkBoxInactive"); 
            }
        }

        public AppiumWebElement _btnCreate
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonCreate"); 
            }
        }

        public AppiumWebElement _newRelease
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonNewRelease"); 
            }
        }

        public AppiumWebElement _btnYes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonYes"); 
            }
        }
        public AppiumWebElement _btnClone
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonClone");
            }
        }


        public AppiumWebElement _status
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "comboStatus"); 
            }
        }

        public AppiumWebElement _newReleaseYes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Yes");
            }
        }


        public AppiumWebElement _btnSave
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonSave");
            }
        }

        
        public AppiumWebElement _btnProfileYes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonYes");
            }
        }

        
        public AppiumWebElement _radioExisting
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "radioButtonUseExisting");
            }
        }
       
        public AppiumWebElement _txtCloneDescription
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textDescription");
            }
        }

        public void SearchComponent(JToken testData)
        {

            SwitchToCurrentWindow();
            _elementClass.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["ElementClass"].ToString()).Click();
            _tboxElementType.SetValue(testData["ElementTypeText"].ToString());
            _txtDescription.SetValue(testData["ElementDescription"].ToString());
            _btnSearch.ClickButton();
            var actions = new Actions(Session.Session.M360Session);
            actions.MoveToElement(_chkBoxActive).MoveByOffset(6, -115);
            actions.Click();
            actions.Perform();
        }
        public void ViewDetails(JToken testData)
        {
            _btnDetails.ClickButton();
            SwitchToCurrentWindow();

        }
        public void CreateNewRelease(JToken testData)
        {
            NewRelease(testData);
        }

        public void Details_Document(JToken testData)
        {
            _btnDocument.ClickButton();
            wait.Timeout = TimeSpan.FromSeconds(1000);
            var worddoc = new WordDocument();

            if (testData["ElementClass"].ToString() == "Profile")
            {
                SwitchToCurrentWindow();
                _btnCreate.ClickButton();
                worddoc.verifyText(" ");

            }
            //var Searchstring=Session.Session.M360Session.FindElementByName(testData["ElementDescription"].ToString());
            if (testData["ElementClass"].ToString() == "Component")
            {
                worddoc.verifyText("a");
            }
            worddoc.verifyText(testData["ElementDescription"].ToString());
            _btnDetailsClose.ClickButton();
        }
        public void NewRelease_Profile(JToken testData)
        {
            _newRelease.ClickButton();
            _btnYes.ClickButton();
            _status.ClickButton();
            //SelectDropdownOption(0);
            //_status.ClickButton();
            Thread.Sleep(1000);
                  Session.Session.M360Session.FindElementByName(testData["comboStatus"].ToString()).Click();
                _btnSave.ClickButton();
                _newReleaseYes.ClickButton();
                _btnClose.ClickButton();
            
        }

            public void NewRelease(JToken testData)
            {
            _newRelease.ClickButton();
            _btnYes.ClickButton();
            if (testData["ElementClass"].ToString() == "Profile")
            {
                _status.ClickButton();
                 Session.Session.M360Session.FindElementByAccessibilityId(testData["comboStatus"].ToString()).Click();
                _btnSave.ClickButton();
                _newReleaseYes.ClickButton();
                _btnClose.ClickButton();
            }
            else 
            {
                _btnDocument.ClickButton();
                wait.Timeout = TimeSpan.FromSeconds(2000);
                var worddoc = new WordDocument();
                worddoc.editDocument("test");
                _status.ClickButton();
                Session.Session.M360Session.FindElementByName(testData["Status"].ToString()).Click();
                _btnSave.ClickButton();
                _newReleaseYes.ClickButton();
                _btnClose.ClickButton();
            }
        }

        public void CloneElement(JToken testData)
        {
            _btnClone.ClickButton();
            _radioExisting.Click();
            _btnYes.ClickButton();
            SwitchToCurrentWindow();
            Thread.Sleep(1000);
            _txtCloneDescription.SetValue(testData["CloneTextElementDescription"].ToString());



        }

        public void gotoRules()
        {
            SwitchToCurrentWindow();
            _utilities.ClickButton();

            var actions = new Actions(Session.Session.M360Session);
            actions.MoveByOffset(25, 38);
            actions.Click();
            actions.Perform();
        }
        public void gotoElementTypes()
        {
            SwitchToCurrentWindow();
            _utilities.ClickButton();

            var actions = new Actions(Session.Session.M360Session);
            actions.MoveByOffset(42, 14);
            actions.Click();
            actions.Perform();
        }
        public void SearchByClassTypeDescription(JToken testData)
        {

            SwitchToCurrentWindow();
            _elementClass.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["ElementClass"].ToString()).Click();
            _tboxElementType.SetValue(testData["ElementTypeText"].ToString());
            _txtDescription.SetValue(testData["ElementDescription"].ToString());
            _btnSearch.ClickButton();
            var actions = new Actions(Session.Session.M360Session);
            actions.MoveToElement(_chkBoxActive).MoveByOffset(6, -115);
            actions.Click();
            actions.Perform();
            View_Details(testData);
            Details_Document(testData);
            SwitchToCurrentWindow();
            _btnClose.ClickButton();
            Thread.Sleep(1000);


        }
        public void View_Details(JToken testData)
        {
            var actions = new Actions(Session.Session.M360Session);
            actions.MoveToElement(_chkBoxActive).MoveByOffset(6, -115);
            actions.Click();
            actions.Perform();

            _btnDetails.ClickButton();
            SwitchToCurrentWindow();
        }
        public void SearchByClass(string[] searchTypes, JToken testData)
        {
            SwitchToCurrentWindow();
            _elementClass.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["ElementClass"].ToString()).Click();
            SetSearchValues(searchTypes, testData);
            _btnSearch.ClickButton();
            View_Details(testData);
            SwitchToCurrentWindow();
            Thread.Sleep(1000);
            _btnClose.ClickButton();
            Thread.Sleep(1000);


        }
        public void SearchByElementType(string[] searchTypes, JToken testData)
        {
            SwitchToCurrentWindow();
            _tboxElementType.SetValue(testData["ElementTypeText"].ToString());
            SetSearchValues(searchTypes, testData);
            _btnSearch.ClickButton();
            View_Details(testData);
            SwitchToCurrentWindow();
            Thread.Sleep(1000);
            _btnClose.ClickButton();
            Thread.Sleep(1000);
        }


        public void SearchByDescription(string[] searchTypes, JToken testData)
        {
            SwitchToCurrentWindow();
            _txtDescription.SetValue(testData["ElementDescription"].ToString());
            //SetSearchValues(searchTypes, testData);
            _btnSearch.ClickButton();

            View_Details(testData);
            SwitchToCurrentWindow();
            Thread.Sleep(1000);
            _btnClose.ClickButton();
            Thread.Sleep(1000);

        }
        public void SearchByOffice(string[] searchTypes, JToken testData)
        {
            SwitchToCurrentWindow();
            _elementOffice.SetValue(testData["Office"].ToString());
            SetSearchValues(searchTypes, testData);
            _btnSearch.ClickButton();

            View_Details(testData);
            SwitchToCurrentWindow();
            Thread.Sleep(1000);
            _btnClose.ClickButton();
            Thread.Sleep(1000);

        }

        public void SearchByInactive(string[] searchTypes, JToken testData)
        {
            SwitchToCurrentWindow();
            _elementOffice.SetValue(testData["Office"].ToString());
            _checkBoxInactive.Click();
            _btnSearch.ClickButton();

        }

        public void SearchBySegment(string[] searchTypes, JToken testData)
        {
            SwitchToCurrentWindow();
            _elementSegment.SetValue(testData["Segment"].ToString());
            _btnSearch.ClickButton();

            View_Details(testData);
            SwitchToCurrentWindow();
            Thread.Sleep(1000);
            _btnClose.ClickButton();
            Thread.Sleep(1000);


        }

        private void SetSearchValues(string[] searchTypes, JToken testData)
        {
            foreach (var searchType in searchTypes)
            {
                switch (searchType)
                {
                    case "ElementClass":
                        _elementBusiness.SetValue(testData["ElementClass"].ToString());
                        break;
                    case "ElementTypeText":
                        _tbElementType.SetValue(testData["ElementTypeText"].ToString());
                        break;
                    case "ElementDescription":
                        _txtDescription.SetValue(testData["ElementDescription"].ToString());
                        break;
                    case "Office":
                        _txtDescription.SetValue(testData["Office"].ToString());
                        break;
                    case "Segement":
                        _txtDescription.SetValue(testData["Segment"].ToString());
                        break;
                    default:
                        break;
                }
            }
        }


       


    }

}
