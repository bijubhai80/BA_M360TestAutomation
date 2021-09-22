using OpenQA.Selenium.Appium;
using ElementControl;
using M360TestAutomation.Tests;
using OpenQA.Selenium;
using M360.Screens;
using NUnit.Framework;

namespace M360.Pages
{
    public class PolicyPostingAnalysisScreen : BaseScreen
    {
        public AppiumWebElement _postingAnalysisTab
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "tab6");
            }
        }

        public AppiumWebElement _edit
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_buttonEditRecord");
            }
        }
        public AppiumWebElement _addRecord
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Add Record");
            }
        }

        public AppiumWebElement _accountTypeDropdown
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_comboBoxAccountType");
            }
        }

        public AppiumWebElement _OK
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "OK");
            }
        }

        public AppiumWebElement _export
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Export");
            }
        }

        public AppiumWebElement _yes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Yes");
            }
        }

        public void gotoPostingAnalysis()
        {
            _postingAnalysisTab.ClickButton();
        }

        public void addRecord()
        {
            _edit.ClickButton();
            _yes.ClickButton();
            _addRecord.ClickButton();
            _accountTypeDropdown.ClickButton();
            SelectDropdownOption(2);
            Session.Session.M360Session.Keyboard.SendKeys("AIRSERV");
            Session.Session.M360Session.Keyboard.SendKeys(Keys.Tab);
            Session.Session.M360Session.Keyboard.SendKeys(Keys.Tab);
            Session.Session.M360Session.Keyboard.SendKeys("2000.00");
            Session.Session.M360Session.Keyboard.SendKeys(Keys.Tab);
        }

        public void export() { 
            _export.ClickButton();
            var excelDoc = new ExcelDocument();
            excelDoc.saveExcel();
            var excelText = excelDoc.readExcel(@"C:\temp\excel.xlsx");
            Assert.IsTrue(excelText.Contains("Client,ALBAN,City of Albany,5000,0,100,510,75,0,7.5,0,0,,,,,,,5692.5,;Underwriter,AIGS,AIG Australia Limited,-5000,0,-100,-510,,,,0,0,0,0,100,10,,,-5500,;GST,GST,Goods and Services Tax,,,,0,,,-7.5,,,,,,-10,,1,-16.5,;Agent,WAG,Western Australian Local Govt Associatn,,,,,,,,,,,,,,-10,-1,-11,;Brokerage Income,,,,,,,,,,,,,,-100,,,,-100,;Fee Income,,,,,,,-75,0,,,,,,,,,,-75,;Agent Commission,,,,,,,,,,,,,,,,10,,10,;,,Balance,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,;"));
        }
    }
}
