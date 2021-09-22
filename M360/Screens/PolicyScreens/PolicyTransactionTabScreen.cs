using ElementControl;
using M360.Screens;
using NUnit.Framework;
using OpenQA.Selenium.Appium;

namespace M360.Pages
{
    public class PolicyTransactionTabScreeen : BaseScreen
    {
        public AppiumWebElement _transactionTab
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "tab12");
            }
        }

        public AppiumWebElement _export
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Export");
            }
        }

        public AppiumWebElement _details
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Details");
            }
        }

        // public AppiumWebElement _transactiongrid
        // {
        // get
        // {
        // return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "tab11");
        // }
        //  }


        public void VerifyReferenceNumber(string invoiceFileName)
        {
            _transactionTab.Click();
            _export.ClickButton();
            var excelDoc = new ExcelDocument();
            excelDoc.saveExcel();
            var excelData = excelDoc.readExcel(@"C:\temp\excel.csv");
            var items = invoiceFileName.Split();

            Assert.IsTrue(excelData.Contains(items[1].Split('-')[1]));
        }

        public void goToTransactionTab()
        {
            _transactionTab.ClickButton();
        }

        public void export()
        {
            _export.ClickButton();
            var excelDoc = new ExcelDocument();
            excelDoc.saveExcel();
        }

        public void verifyExcelResults(string excelTestExpected)
        {
            var excelDoc = new ExcelDocument();
            var excelTestActual = excelDoc.readExcel(@"C:\temp\excel.csv");
            Assert.IsTrue(excelTestActual.Contains(excelTestExpected));
        }

        public void gotoDetails()
        {
            _details.ClickButton();
            SwitchToCurrentWindow();
        }
    }
}
