using ElementControl;
using M360.Pages;
using M360.Screens;
using OpenQA.Selenium.Appium;

namespace M360TestAutomation.Screens.DocumentMaintenance
{
    public class TextElementTypes : BaseScreen
    {
        public AppiumWebElement _detailsButton
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(M360.Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonDetails");
            }
        }

        public AppiumWebElement _removeButton
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(M360.Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonDelete");
            }
        }

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

        public void seeDetails()
        {
            SwitchToCurrentWindow();
            _detailsButton.ClickButton();
        }

        public void closeDetails()
        {
           var okButton = WinAppDriverControlMethods.GetElement(M360.Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonCreateOk");
           okButton.ClickButton();
        }

        public void addTextElementType(string elementTypeId, string description)
        {
            _addButton.ClickButton();
           
            var elementTypeIdTextBox = WinAppDriverControlMethods.GetElement(M360.Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textElementTypeId");
            elementTypeIdTextBox.SetValue(elementTypeId);
            
            var elementTypeDescTextBox = WinAppDriverControlMethods.GetElement(M360.Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textDescription");
            elementTypeDescTextBox.SetValue(description);

            var createButton = WinAppDriverControlMethods.GetElement(M360.Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonCreateOk");
            createButton.ClickButton();
        }

        public void removeSelectedElementType()
        {
            _removeButton.ClickButton();
            _saveButton.ClickButton();
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
