using ElementControl;
using M360.Screens;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using System;

namespace M360.Pages
{
    public class GeneralLedgerInterfaceScreen : BaseScreen
    {
        public AppiumWebElement _dateFrom
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textDateFrom");
            }
        }

        public AppiumWebElement _search
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonSearch");
            }
        }

        public AppiumWebElement _process
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonProcess");
            }
        }
        public AppiumWebElement _rebuild
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonRebuild");
            }
        }
        public AppiumWebElement _export
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonDataExport");
            }
        }

        public AppiumWebElement _yes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonYes");
            }
        }


        public void process()
        {
            _dateFrom.SetValue(DateTime.Now.ToString("dd/MM/yyyy"));
            _search.ClickButton();
            var actions = new Actions(Session.Session.M360Session);
            actions.MoveToElement(_dateFrom);
            actions.MoveByOffset(20, 80);
            actions.DoubleClick();
            actions.Perform();
            wait.Until(driver => _process.Enabled);
            _process.ClickButton();
            _yes.ClickButton();
            wait.Until(driver => !_process.Enabled);
            _dateFrom.SetValue(DateTime.Now.ToString("dd/MM/yyyy"));
        }

        public void rebuild()
        {
            //_dateFrom.SetValue(DateTime.Now.ToString("dd/MM/yyyy"));
            //_search.ClickButton();
            var actions = new Actions(Session.Session.M360Session);
            actions.MoveToElement(_dateFrom);
            actions.MoveByOffset(20, 80);
            actions.DoubleClick();
            actions.Perform();
            wait.Until(driver => _rebuild.Enabled);
            _rebuild.ClickButton();
            _yes.ClickButton();
            wait.Until(driver => !_rebuild.Enabled);
            // _dateFrom.SetValue(DateTime.Now.ToString("dd/MM/yyyy"));
        }

        public void export(string policyNo)
        {
            _export.ClickButton();
            var excelDoc = new ExcelDocument();
            excelDoc.saveExcel();
            var text = excelDoc.readExcel(@"C:\temp\excel.csv");
            Assert.IsTrue(text.Contains(policyNo));
        }
    }
}





