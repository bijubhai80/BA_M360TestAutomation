using ElementControl;
using M360.Screens;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace M360.Pages
{
    public class ClientReassignScreen : BaseScreen
    {
        public AppiumWebElement _spreadsheetTab
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "tabSpreadsheet");
            }
        }

        public AppiumWebElement _openFile
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonOpenFile");
            }

        }

        public IReadOnlyCollection<AppiumWebElement> _fileName
        {
            get
            {
                return WinAppDriverControlMethods.GetElements(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "File name:");
            }

        }

        public IReadOnlyCollection<AppiumWebElement> _Open
        {
            get
            {
                return WinAppDriverControlMethods.GetElements(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Open");
            }

        }

        public AppiumWebElement _process
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonProcess");
            }

        }

        public AppiumWebElement _toolbar
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//ToolBar[contains(@Name,'Address')]");
            }

        }

        public AppiumWebElement _ok
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Ok");
            }

        }

        public AppiumWebElement _close
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Close");
            }

        }

        public void importExcelSpreadSheet(string filePath)
        {
            _spreadsheetTab.ClickButton();
            _openFile.ClickButton();
            _toolbar.ClickButton();
            _toolbar.SetValue(ConfigurationManager.AppSettings["JSONTestData"]);
            _fileName.ElementAt(1).ClickButton();
            _fileName.ElementAt(1).SetValue(filePath);
            _Open.ElementAt(5).ClickButton();
            _process.ClickButton();
            var excelDoc = new ExcelDocument();
            excelDoc.saveExcel();
            _ok.ClickButton();
            var excelText = excelDoc.readExcel(@"C:\temp\excel.xlsx");
            Assert.IsTrue(excelText.Contains("Client updated successfully"));
            _close.ClickButton();
        }
    }
}







