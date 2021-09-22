using ElementControl;
using M360.Screens;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;

namespace M360.Pages
{
    public class ClientProfileScreen : BaseScreen
    {
        // private const char V = 'testtestxt';

        public AppiumWebElement _profileTab
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "tabProfile");
            }
        }

        public AppiumWebElement _edit
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonEdit");
            }
        }

        public AppiumWebElement _close
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Close");
            }
        }

        public AppiumWebElement _profile
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Profile");

            }
        }

        public AppiumWebElement _profileType
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "comboProfileType");
            }
        }

        public AppiumWebElement _delete
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonDelete");
            }
        }

        public AppiumWebElement _profileTypeDropdown
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "comboProfileType");
            }
        }
        public AppiumWebElement _insert
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Insert");
            }
        }
        public AppiumWebElement _yes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Yes");
            }
        }

        public AppiumWebElement _no
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "No");
            }
        }

        public AppiumWebElement _save
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonSave");
            }
        }

        public AppiumWebElement _remove
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonProfileDelete");
            }
        }

        public AppiumWebElement _enableDiary
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "checkBoxEnableDiary");
            }
        }

        public AppiumWebElement _tabServiceDiary
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "tabPageServiceDiary");
            }
        }



        public AppiumWebElement _btnDiaryAdd
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_buttonDiaryAdd");
            }
        }
        public void gotoProfileTab()
        {
            // SwitchToCurrentWindow();
            _profileTab.ClickButton();
        }

        public void enableDiary()
        {
            _edit.ClickButton();
            _enableDiary.ClickButton();


        }
        public void addDiary(JToken testData)
        {
            _tabServiceDiary.ClickButton();
            _btnDiaryAdd.ClickButton();

            var actions = new Actions(Session.Session.M360Session);
            actions.MoveToElement(_btnDiaryAdd).MoveByOffset(1, 292);
            actions.DoubleClick();
            SyncFusionGrid.SetCell(2, 1, "test");
            actions.Perform();







        }
        public void disableDiary()
        {
            _enableDiary.ClickButton();

        }
        public void editProfileDocs()
        {
            wait.Until(driver => _profile.Displayed);
            Session.Session.M360Session.Mouse.MouseMove(_edit.Coordinates);
            editWordDoc();
        }

        private void editWordDoc()
        {
            _edit.ClickButton();
            Actions action = new Actions(Session.Session.M360Session);
            action.MoveByOffset(50, -280);
            action.Click();
            action.DoubleClick();
            action.Perform();

            var wordDocument = new WordDocument();
            wordDocument.editDocument("Sample Text");

            wait.Until(driver => _profile.Displayed);
            action = new Actions(Session.Session.M360Session);
            action.MoveToElement(_edit);
            action.MoveByOffset(50, -280);
            action.Click();
            action.DoubleClick();
            action.Perform();

            wordDocument.verifyText("Sample Text");
        }

        public void InsertProfile(JToken testData)
        {
            _profileTab.ClickButton();
            _profileTypeDropdown.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["ProfileType"].ToString()).Click();
            _insert.ClickButton();
        }

        public void RemoveProfile()
        {
            _profileTab.ClickButton();
            _remove.Click();
            _yes.ClickButton();
        }

        public void DeleteClient()
        {
            _delete.ClickButton();
            _yes.ClickButton();
            SwitchToCurrentWindow();
        }
    }
}







