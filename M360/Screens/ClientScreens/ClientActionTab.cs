using ElementControl;
using NUnit.Framework;
using OpenQA.Selenium.Appium;

namespace M360.Pages
{
    public class ClientActionScreen : BaseScreen
    {
        public AppiumWebElement _diaryRadioButton => GetElementByAccessibilityId("radioDiaryOnly");


        public AppiumWebElement _partyContacted
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textPartyContacted");
            }
        }

        public AppiumWebElement _partyType
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "comboPartyType");
            }
        }

        public AppiumWebElement _actionReason
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "comboCallDiaryReason");
            }
        }

        public AppiumWebElement _policy
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "comboPolicy");
            }
        }
        public AppiumWebElement _claim
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "comboClaim");
            }
        }

        public AppiumWebElement _diaryDate
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textDiaryDate");
            }
        }

        public AppiumWebElement _28Days
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_radioDayTwentyEight");
            }
        }

        public AppiumWebElement _comments
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "richTextBox");
            }
        }

        public AppiumWebElement _feedback
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Feedback");
            }
        }

        public AppiumWebElement _save
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonSave");
            }
        }

        public AppiumWebElement _close
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonClose");
            }
        }

        public AppiumWebElement _buttonNo => GetElementByAccessibilityId("buttonNo");


        public void createAction(bool diaryActionType = false)
        {
            SwitchToCurrentWindow();

            // Action type – Diary
            if (diaryActionType)
            {
                _diaryRadioButton.ClickButton();
            }
            // Action type – Call
            else
            {
                _partyContacted.SetValue("Sample Party");
                _partyType.ClickButton();
                SelectDropdownOption(2);
            }

            _actionReason.ClickButton();
            SelectDropdownOption(3);
            _policy.ClickButton();
            SelectDropdownOption(2);
            _claim.ClickButton();
            SelectDropdownOption(1);
            _28Days.ClickButton();
            _comments.SetValue("Comments");
            _feedback.ClickButton();
            SelectDropdownOption(2);
            _save.ClickButton();
            SwitchToCurrentWindow();
        }

        public void editAction()
        {
            SwitchToCurrentWindow();
            _comments.Clear();
            _comments.SetValue("Comments MODIFIED");
            _save.ClickButton();
            SwitchToCurrentWindow();
        }

        public void verifyAction()
        {
            SwitchToCurrentWindow();
            Assert.IsTrue(_diaryRadioButton.Selected);
            Assert.IsTrue(_comments.GetAttribute("value").Contains("Comments MODIFIED"));
            _close.ClickButton();

            // Click No if asked to save changes
            if (_buttonNo != null) _buttonNo.ClickButton();
        }

    }
}







