using System;
using M360.Support;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System.Configuration;
using M360.Pages;
using ElementControl;
using NUnitRetrying;
using NunitVideoRecorder;
using M360TestAutomation.Tests;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Interactions;

namespace M360
{
    public class FinancialDocumentTests : BaseTest
    {
        [TestCase("BankDeposit")]
        [Retrying(Times = 3)]
        [Video(Name = "BankDeposit", Mode = SaveMe.OnlyWhenFailed)]
        public static void SearchBankDeposit(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreenPage = new HomeScreen();
            var bankDepositForm = new BankDeposit();
            var actions = new Actions(Session.Session.M360Session);
            homeScreenPage.gotoMenu();
            homeScreenPage.gotoFinancials();
            homeScreenPage.gotoBankDeposit();
            homeScreenPage.SwitchToCurrentWindow();
            
            //Search bank deposit with default values
            bankDepositForm.searchBankDeposit(JSONObjects["FinancialDocuments"]["BankDeposit"]);

            //Search bank deposit with date range values
            bankDepositForm.searchBankDepositDateRange(JSONObjects["FinancialDocuments"]["BankDeposit"]);

            //Print bank deposit
            actions.MoveByOffset(843, 15);
            actions.Click();
            actions.Click();
            actions.MoveByOffset(11,30);
            actions.Click();
            bankDepositForm.printBankDeposit();

        }

       
    }
}
