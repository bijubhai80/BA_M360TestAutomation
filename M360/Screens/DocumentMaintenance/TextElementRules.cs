using ElementControl;
using M360.Pages;
using M360.Screens;
using OpenQA.Selenium.Appium;

namespace M360TestAutomation.Screens.DocumentMaintenance
{
    public class TextElementRules : BaseScreen
    {
        public AppiumWebElement _addButton
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(M360.Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonNew");
            }
        }


        public AppiumWebElement _saveButton
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(M360.Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonSave");
            }
        }

        public AppiumWebElement _closeButton
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(M360.Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonClose");
            }
        }

        public AppiumWebElement _exportButton
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(M360.Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonExport");
            }
        }

        public AppiumWebElement _removeButton
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(M360.Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonDelete");
            }
        }

        public AppiumWebElement _detailsButton
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(M360.Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonDetails");
            }
        }

        public void AddNewRule()
        {
            SwitchToCurrentWindow();
            _addButton.ClickButton();
        }

        public void RemoveRule()
        {
            SwitchToCurrentWindow();
            _removeButton.ClickButton();
            _saveButton.ClickButton();
        }

        public void SeeDetails()
        {
            SwitchToCurrentWindow();
            _detailsButton.ClickButton();
        }

        public void exportRules()
        {
            _exportButton.ClickButton();
            var yesButton = WinAppDriverControlMethods.GetElement(M360.Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonYes");
            yesButton.ClickButton();

            var excelDoc = new ExcelDocument();
            excelDoc.saveExcel();
            //var excelData = excelDoc.readExcel(@"C:\temp\excel.csv");
        }

        public void closeRules()
        {
            _closeButton.ClickButton();
        }
    }
}
