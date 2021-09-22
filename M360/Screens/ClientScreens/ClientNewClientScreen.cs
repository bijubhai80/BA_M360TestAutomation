using ElementControl;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace M360.Pages
{
    public class ClientNewClientScreen : BaseScreen
    {


        public AppiumWebElement _code
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textCode");
            }
        }

        public AppiumWebElement _name
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textName");
            }
        }

        public AppiumWebElement _dept
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "jltaCodeTandemTeam");
            }
        }

        public AppiumWebElement _segment
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "jltaCodeTandemMarSeg");
            }
        }

        public AppiumWebElement _sic
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "jltaCodeTandemStandardIndustryClass");
            }
        }

        public AppiumWebElement _broker
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[starts-with(@AutomationId,'jltaCodeTandemBroker')]/ComboBox[@AutomationId='comboBoxItem']");
            }
        }

        public AppiumWebElement _save
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonSave");
            }
        }
        public AppiumWebElement _buildingFile
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_labelMessage");
            }
        }

        public AppiumWebElement _actions
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "tabActions");
            }
        }

        public AppiumWebElement _editButton
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonEdit");
            }
        }

        public AppiumWebElement _yes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Yes");
            }
        }

        public AppiumWebElement _currentStatement
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "_tabPageCurrentStatement");
            }
        }

        public AppiumWebElement _generateStatement
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonStatement");
            }
        }

        public AppiumWebElement _new
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "New");
            }
        }

        public AppiumWebElement _remove
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Remove");
            }
        }

        public AppiumWebElement _close
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Close");
            }
        }


        public AppiumWebElement _historyTab
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "tabChangeHistory");
            }
        }

        public AppiumWebElement _address
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textAddress");
            }
        }

        public AppiumWebElement _company
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textCompanyNumber");
            }
        }
        public AppiumWebElement _delete
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonDelete");
            }
        }
        public AppiumWebElement _financials
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "tabFinancials");
            }
        }


        public AppiumWebElement _approve
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonApprove");
            }
        }

        public AppiumWebElement _currentstatement
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "_tabPageCurrentStatement");
            }
        }
        public AppiumWebElement _reject
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonReject");
            }
        }
        public AppiumWebElement _pendingLabel
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "labelDmgPendingReview");
            }
        }
        //=\"_tabPageCurrentStatement
        public AppiumWebElement ButtonApprove =>
            WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name,
                "Approve");

        public AppiumWebElement ButtonReject =>
            WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name,
                "Reject");

        public AppiumWebElement DmgLabel =>
            WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name,
                "Pending DMG Review");

        public AppiumWebElement DialogBox =>
            WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath,
                "//*[@AutomationId='JibMessageBox']");

        public AppiumWebElement DialogBoxOkButton => GetElementByAccessibilityId("buttonOk", 30);
        public AppiumWebElement DialogBoxText => WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath,
            "//*[@AutomationId='JibMessageBox']/*[@AutomationId=\"textBoxMessage\"]");


        public void goToFinancialstab()
        {
            _financials.Click();
        }

        public void goToCurrentStatementtab()
        {
            _currentstatement.Click();
        }
        public AppiumWebElement _policyTab
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "tabPolicies");
            }
        }
        public AppiumWebElement _newPolicy
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonPolNew");
            }
        }
        public AppiumWebElement _textBoxMessage
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textBoxMessage");
            }
        }
        public AppiumWebElement _ok
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonOk");
            }
        }
        public AppiumWebElement _buttonClose
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonClose");
            }
        }
        public AppiumWebElement _comboReason
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "comboReason");
            }
        }

        public AppiumWebElement _textFeedback
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textFeedback");
            }
        }

        public AppiumWebElement _submit
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Submit");
            }
        }
        //=\"_tabPageCurrentStatement





        public void goToHistory(JToken testData)
        {
            _historyTab.ClickButton();
            var rows = SyncFusionGrid.GetRows();
            var cells = SyncFusionGrid.GetCells(rows[0]);
            Assert.AreEqual(cells[1].Text, "Client Name");
            Assert.AreEqual(cells[0].Text, DateTime.Now.ToString("dd/MM/yyyy"));
            Assert.AreEqual(cells[2].Text, "New Name Test");
            Assert.AreEqual(cells[3].Text, testData["Name"].ToString());
        }

        public void goToPolicyTab()
        {
            _policyTab.ClickButton();
        }

        public void createNewPolicy()
        {
            Thread.Sleep(2000);
            _newPolicy.ClickButton();
        }

        public void validateMessage()
        {
            _textBoxMessage.ClickButton();
            _ok.ClickButton();
        }

        public void closeFormClientMaintenace()
        {
            _buttonClose.ClickButton();
        }
        public void editClientDetails(JToken testData)
        {

            _name.SetValue(testData["Name"].ToString());
            _sic.SetValue(testData["SIC"].ToString());
            _company.ClickButton();
            Session.Session.M360Session.Keyboard.SendKeys(Keys.Tab);
            Session.Session.M360Session.Keyboard.SendKeys(Keys.Tab);
            Session.Session.M360Session.Keyboard.SendKeys(testData["Address1"].ToString());
            _save.ClickButton();

        }

        public void closeClientScreen()
        {
            _close.ClickButton();
            SwitchToCurrentWindow();
            if (_ok != null)
            {
                _ok.ClickButton();
                SwitchToCurrentWindow();
                _close.ClickButton();
                SwitchToCurrentWindow();
            }
        }

        public void enableEditClient()
        {
            SwitchToCurrentWindow();
            _editButton.ClickButton();
        }

        public void enterHeaderDetails(JToken testData)
        {
            _code.SetValue(testData["ClientCode"].ToString());
            _name.SetValue(testData["Name"].ToString());
            _dept.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["Dept"].ToString()).Click();
            _segment.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["Segment"].ToString()).Click();
            _sic.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["SIC"].ToString()).Click();
            _broker.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["Broker"].ToString()).Click();

        }

        public void save()
        {
            _save.ClickButton();
            if (_ok != null) _ok.ClickButton();
        }

        public void close()
        {
            _close.ClickButton();
        }

        public void verifyHeader(JToken testData)
        {
            Assert.IsTrue(_code.Text.Contains(testData["ClientCode"].ToString()));
            Assert.IsTrue(_name.Text.Contains(testData["Name"].ToString()));
            var x = _dept.Text;
            //Assert.IsTrue(_dept.Text.Contains(testData["Dept"].ToString()));
            //Assert.IsTrue(_segment.Text.Contains(testData["Segment"].ToString()));
            //Assert.IsTrue(_sic.Text.Contains(testData["SIC"].ToString()));
            //Assert.IsTrue(_broker.Text.Contains(testData["Broker"].ToString()));
        }

        public void generateStatement()
        {
            _currentStatement.ClickButton();
            _generateStatement.ClickButton();
            _yes.ClickButton();
            wait.Timeout = TimeSpan.FromMinutes(10);
            wait.Until(driver => _buildingFile != null);
            wait.Until(driver => _buildingFile == null);
        }

        //DMG Client Approve
        public void approveClient()
        {
            _approve.ClickButton();
            wait.Timeout = new TimeSpan(0, 3, 60);
            // wait.Until(driver => !_pendingLabel.Displayed);
            // wait.Until(driver => _pendingLabel != null);
            //wait.Timeout = new TimeSpan(0, 0, 60);
            _close.ClickButton();
        }
        //DMG client reject
        public void rejectClient()
        {
            _reject.ClickButton();
            wait.Timeout = new TimeSpan(0, 3, 60);
            _comboReason.ClickButton();
            _comboReason.ComboboxSelectValueBySendKeys("Client name does not match ABR website");
            //Session.Session.M360Session.FindElementByName("Client name does not match ABR website").Click();
            _textFeedback.ClickButton();
            _textFeedback.SetValue("Testing");
            _submit.ClickButton();
            // wait.Until(driver => _pendingLabel.Displayed && _pendingLabel.Text == "Pending DMG review");//or try _pendingLabel== null
            // _close.ClickButton();
        }
        public void verifyClientIsRejected()
        {
            var isRejected = _pendingLabel.Displayed;
            if (isRejected != null)
            {
                _close.ClickButton();
            }
        }


        public void createDiaryAction()
        {
            _actions.ClickButton();
            wait.Until(driver => { return _editButton != null; });

            //            Thread.Sleep(5000);
            var actions = new Actions(Session.Session.M360Session);
            actions.MoveToElement(_actions);
            actions.Click();
            actions.Perform();
            _editButton.ClickButton();
            wait.Until(driver => { return _new != null && _new.Enabled; });
            _new.ClickButton();
        }

        public void editDiaryAction()
        {
            var actions = new Actions(Session.Session.M360Session);
            actions.MoveToElement(_actions).MoveByOffset(0, 50);
            actions.DoubleClick();
            actions.Perform();
        }

        public void deleteDiaryAction()
        {
            if (_editButton.Enabled)
            {
                _editButton.ClickButton();
            }

            // Remove Action type – Diary and ensure they are deleted from the DB as well.
            var actions = new Actions(Session.Session.M360Session);
            actions.MoveToElement(_actions).MoveByOffset(0, 50);
            actions.Click();
            actions.Perform();
            _remove.ClickButton();

            // "Do you want to remove the selection action?" dialog
            if (_yes.Enabled)
            {
                _yes.ClickButton();
            }
        }

        public void DeleteClient()
        {
            if (_ok != null)
            {
                _ok.ClickButton();
            }
            else
            {
                if (_delete == null)
                {
                    SwitchToCurrentWindow();
                }
                if (_ok != null)
                {
                    _ok.ClickButton();
                    SwitchToCurrentWindow();
                }

                _delete.ClickButton();
                _yes.ClickButton();
                SwitchToCurrentWindow();
            }
        }
    }
}







