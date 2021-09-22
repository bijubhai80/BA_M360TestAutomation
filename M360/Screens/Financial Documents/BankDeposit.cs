using OpenQA.Selenium.Appium;
using ElementControl;
using M360TestAutomation.Tests;
using System;
using Newtonsoft.Json.Linq;

namespace M360.Pages
{
    public class BankDeposit : BaseScreen
    {
        public AppiumWebElement _bankDepositForm => GetElementByAccessibilityId("LedgerBankDepositForm");
        public AppiumWebElement _office => GetElementByName("Office");
        public AppiumWebElement _fromDate => GetElementByAccessibilityId("textDateFrom");
        public AppiumWebElement _toDate => GetElementByAccessibilityId("textDateTo");
        public AppiumWebElement _searchButton => GetElementByName("Search");
        public AppiumWebElement _printButton => GetElementByName("Print");
        public void searchBankDeposit(JToken testData)
        {
            _office.SetValue(testData["Office"].ToString());
            _searchButton.ClickButton();            
        }

        public void searchBankDepositDateRange(JToken testData)
        {
            _office.SetValue(testData["Office"].ToString());
            _fromDate.SetValue(testData["DateFrom"].ToString());
            _toDate.SetValue(testData["DateTo"].ToString());
            _searchButton.ClickButton();
        }


        public void printBankDeposit()
        {
            _printButton.ClickButton();
        }

    }
}





