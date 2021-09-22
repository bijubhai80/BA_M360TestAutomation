using OpenQA.Selenium.Appium;
using ElementControl;
using M360TestAutomation.Tests;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using M360.Session;
using System;
using Newtonsoft.Json.Linq;
using M360.Screens;
using NUnit.Framework;

namespace M360.Pages
{
    public class PaymentInstruction: BaseScreen
    {
            
      
        public AppiumWebElement _cBoxLedger
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_comboBoxLedger");
            }
        }

        public AppiumWebElement _tBoxDescription
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_textBoxDescription");
            }
        }

        public AppiumWebElement _cBoxCurrency
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_comboBoxCurrency");
            }
        }

        public AppiumWebElement _cBoxPaymentType
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_comboBoxPaymentType");
            }
        }

      
        public AppiumWebElement _btnSearch
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_buttonSearch");
            }
        }

        public AppiumWebElement _upScroll
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "UpButton");
            }
        }

        public AppiumWebElement _btnDetails
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_buttonDetails");
            }
        }
        public AppiumWebElement _btnAuthorise
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_buttonAuthorise");
            }
        }

        public AppiumWebElement _txtBoxPassword
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_textBoxPassword");
            }
        }

        public AppiumWebElement _btnOk
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_buttonOK");
            }
        }

        public AppiumWebElement _btnAdd
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_buttonAdd");
            }
        }
        public AppiumWebElement _tabAccount
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_tabAccount");
            }
        }
        public AppiumWebElement _ledgerType
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_comboBoxLedger");
            }
        }

        public AppiumWebElement _textBoxDescription
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_textBoxDescription");
            }
        }
        public AppiumWebElement _comboBoxCurrency
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_comboBoxCurrency");
            }
        }
        public AppiumWebElement _comboBoxPaymentType
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_comboBoxPaymentType");
            }
        }

        public AppiumWebElement _PayeeACName
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_comboBoxPaymentType");
            }
        }
        public AppiumWebElement _BankName
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_comboBoxPaymentType");
            }
        }
        public AppiumWebElement _BankAddress
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_comboBoxPaymentType");
            }
        }

        public AppiumWebElement _BankBSB
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_comboBoxPaymentType");
            }
        }
        public AppiumWebElement _BankACNumber
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_comboBoxPaymentType");
            }
        }  
        
        public AppiumWebElement _PayeeAddress_1
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_comboBoxPaymentType");
            }
        }
        public AppiumWebElement _PayeeAddress_2
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_comboBoxPaymentType");
            }
        }
        public AppiumWebElement _PayeeAddress_3
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_comboBoxPaymentType");
            }
        }
        public AppiumWebElement _btnExport
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_buttonExport");
            }
        }
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
        public AppiumWebElement _btnCancel
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonCancel");
            }
        }

        public AppiumWebElement _btnClose
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_buttonClose");
            }
        }

        public void PaymentInstructions(JToken testData)
        {
            Search_PaymentInstruction(testData);
            Details_PaymentInstruction(testData);
            SwitchToCurrentWindow();
           //Export_PaymentInstruction(testData);
        }
        public void Search_PaymentInstruction(JToken testData)
        {
            _cBoxLedger.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["LedgerType"].ToString()).Click();
            _tBoxDescription.SetValue(testData["Description"].ToString());
            _cBoxCurrency.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["Currency"].ToString()).Click();
            _cBoxPaymentType.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["PaymentType"].ToString()).Click();
            _btnSearch.ClickButton();
            var actions = new Actions(Session.Session.M360Session);
            actions.MoveToElement(_upScroll);
            actions.MoveByOffset(-3, -389);
            actions.Click();
            actions.Perform();
           
        }
        public void Details_PaymentInstruction(JToken testData)
        {
            _btnDetails.ClickButton();
            SwitchToCurrentWindow();
                       
            var actions = new Actions(Session.Session.M360Session);
            actions.MoveToElement(_tabAccount).MoveByOffset(0, 39);
            actions.Click();
            actions.Perform();

            Authorise_PaymentInstruction(testData);
            _btnClose.ClickButton();
        }
        public void Authorise_PaymentInstruction(JToken testData) 
        {
            _btnAuthorise.ClickButton();
            _txtBoxPassword.SetValue(testData["UserPassword"].ToString());
            _btnOk.ClickButton();
            
        }
        public void Export_PaymentInstruction(JToken testData)
        {
            _btnExport.ClickButton();
            _btnYes.ClickButton();

            var excelDoc = new ExcelDocument();
            excelDoc.saveExcel();

            var excelData = excelDoc.readExcel(@"C:\temp\excel.xlsx");
         
            Assert.IsTrue(excelData.Split(';').Length > 1);

        }
        public void Export_PaymentInstruction(string dataStandard)
        {
            _btnExport.ClickButton();
            _btnYes.ClickButton();

            var excelDoc = new ExcelDocument();
            excelDoc.saveExcel();
            var text = excelDoc.readExcel(@"C:\temp\excel.csv");
            Assert.IsTrue(text.Contains(dataStandard));
            _btnClose.ClickButton();
           
        }

    }       
}

