using OpenQA.Selenium.Appium;
using ElementControl;
using M360TestAutomation.Tests;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using M360.Session;
using System;
using NUnit.Framework;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace M360.Pages
{
    public class CreateAuthorisePaymentsUser : BaseScreen
    {
        //public AppiumWebElement _masterUserList
        //{
        //    get
        //    {
        //        return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "Hitha Mohanan (MOHAH)\");
        //    }
        //}


        public AppiumWebElement _btnYes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonYes");
            }
        }
        public AppiumWebElement _btnNo
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonNo");
            }
        }
        public AppiumWebElement _cBoxMasterUserId
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_comboBoxMasterUserID");
            }
        }

        public AppiumWebElement _txtBoxMasterPwd
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_textBoxMasterPassword");
            }
        }

        public AppiumWebElement _txtBoxRepeatPwd
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_textBoxRepeatPassword");
            }
        }
        public AppiumWebElement _txtBoxUserPwd
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_textBoxUserPassword");
            }
        }

        public AppiumWebElement _btnOk
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_buttonOK");
            }
        }

        public AppiumWebElement _labelErrorSingleline
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_labelErrorSingleliner");
            }
        }
        public AppiumWebElement _labelErrorMultiline
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, " _labelErrorMultiliner");
            }
        }

       

        public void createAuthoriseUser(JToken testData)
        {
                if(_btnYes != null) _btnYes.ClickButton();
               
                _cBoxMasterUserId.ClickButton();
                Session.Session.M360Session.FindElementByName(testData["MasterUser"].ToString()).Click();

                wait.Until(driver => _cBoxMasterUserId.Text.Contains(testData["MasterUser"].ToString()));

                _txtBoxMasterPwd.SetValue(testData["MasterPassword"].ToString());

                _txtBoxUserPwd.SetValue(testData["UserPassword"].ToString());

                _txtBoxRepeatPwd.SetValue(testData["RepeatPassword"].ToString());

                _btnOk.ClickButton();

                validateNullFields(testData);
            

        }

        public void validateNullFields(JToken testData)
        {
            var Actual1 = "Enter all the fields.";
            var Actual2 = "Incorrect master password";
            var Actual3 = "User and repeat passwords were not the same.";
            if(_labelErrorSingleline.Text.Contains(Actual1))
            {
                createAuthoriseUser(testData);
            }
            else if(_labelErrorSingleline.Text.Contains(Actual2))
            {
                _txtBoxMasterPwd.SetValue(BaseTest.testData.GetData("Financials", BaseTest.testData.testCaseId, "MasterPassword"));
            }
            else if(_labelErrorMultiline.Text.Contains(Actual3))
            {
                _txtBoxUserPwd.SetValue(BaseTest.testData.GetData("Financials", BaseTest.testData.testCaseId, "UserPassword"));
                _txtBoxRepeatPwd.SetValue(BaseTest.testData.GetData("Financials", BaseTest.testData.testCaseId, "RepeatPassword"));

            }

            //if (_labelErrorSingleline.Text.Contains("Enter all the fields.")==true)
            //{
            //    Assert.IsTrue(_labelErrorSingleline.Text.Contains("Enter all the fields."));
            //    createAuthoriseUser();
            //}
            //else if (_labelErrorSingleline.Text.Contains("Incorrect master password")==true)
            //{
            //    Assert.IsTrue(_labelErrorSingleline.Text.Contains("Incorrect master password"));
            //    _txtBoxMasterPwd.SetValue(BaseTest.testData.GetData("Financials", BaseTest.testData.testCaseId, "MasterPassword"));
            //}
            //else if (_labelErrorMultiline.Text.Contains("User and repeat passwords were not the same.")==true)
            //{
            //    Assert.IsTrue(_labelErrorMultiline.Text.Contains("User and repeat passwords were not the same."));
            //    _txtBoxUserPwd.SetValue(BaseTest.testData.GetData("Financials", BaseTest.testData.testCaseId, "UserPassword"));
            //    _txtBoxRepeatPwd.SetValue(BaseTest.testData.GetData("Financials", BaseTest.testData.testCaseId, "RepeatPassword"));


            //}

        }

    }
}
