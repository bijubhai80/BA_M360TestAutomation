using OpenQA.Selenium.Appium;
using ElementControl;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;
using M360TestAutomation.Tests;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using M360.Pages;
using M360.Session;

namespace M360.Pages
{
    public class ClientCurrentStatement: BaseScreen


    {
        public AppiumWebElement _financial
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "tabFinancials");
            }
        }


        public AppiumWebElement _currentstatement
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "_tabPageCurrentStatement");
            }
        }

        public AppiumWebElement _reprint
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Reprint");
            }
        }

        public AppiumWebElement _edit
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "buttonEdit");
            }
        }

        public AppiumWebElement _details
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Details");
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


        public AppiumWebElement _statement
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Statement");
            }
        }

        public AppiumWebElement _yes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Yes");
            }
        }

        public AppiumWebElement _fee
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Fee Invoice");
            }
        }

        public AppiumWebElement _ledger
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Ledger");
            }
        }

        public AppiumWebElement _ledgerClose
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonClose");
            }
        }

        public AppiumWebElement _feeClose
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonClose");
            }
        }


        
        public AppiumWebElement _postingAnalysis
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "tabPagePostingAnalysis");
            }
        }




        public AppiumWebElement _buildingFile
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_labelMessage");
            }
        }

        public AppiumWebElement _currencycombo
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Currency");
            }
        }

        public AppiumWebElement _closeclient
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonClose");
            }
        }






        public void goToFinancialstab()
        {
            _financial.Click();
        }

        public void goToCurrentStatementtab()
        {
            _currentstatement.Click();
        }

        public void selectTransaction()
        {

            var actions = new Actions(Session.Session.M360Session);
            actions.MoveToElement(_currentstatement).MoveByOffset(0, 84);
            actions.Click();
            actions.Perform();
          
        }

        public void clickDetails()
        {

            _details.ClickButton();
            SwitchToCurrentWindow();
            _close.ClickButton();
            

        }

        public void clickFeeInvoice()
        {

            _fee.ClickButton();
            SwitchToCurrentWindow();
            var actions = new Actions(Session.Session.M360Session);
            actions.MoveToElement(_feeClose);
            actions.Click();
            actions.Perform();
        }

        public void clickstatement()
        {
            _statement.ClickButton();
            _yes.ClickButton();
            wait.Timeout = TimeSpan.FromSeconds(60);
            wait.Until(driver => _buildingFile != null);
            wait.Until(driver => _buildingFile == null);

        }

        public void clickledger()
        {
            _ledger.ClickButton();
            SwitchToCurrentWindow();
            var actions = new Actions(Session.Session.M360Session);
            actions.MoveToElement(_ledgerClose);
            actions.Click();
            actions.Perform();

        }



        public void Reprint()
        {

            _reprint.ClickButton();
            _ok.ClickButton();
            wait.Timeout = TimeSpan.FromSeconds(60);
            wait.Until(driver => _buildingFile != null);
            wait.Until(driver => _buildingFile == null);



        }

        public void changeCurrency()
        {

            _currencycombo.ClickButton();
            SelectDropdownOption(2);
            Thread.Sleep(1000);
            _closeclient.ClickButton();

            



        }
    }
}
