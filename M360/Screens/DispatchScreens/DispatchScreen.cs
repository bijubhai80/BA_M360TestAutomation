using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using OpenQA.Selenium.Support.UI;
using ElementControl;
using System.Threading;
using OpenQA.Selenium;
using System.IO;
using OpenQA.Selenium.Interactions;
using M360TestAutomation.Tests;
using Newtonsoft.Json.Linq;

namespace M360.Pages
{
    public class DispatchScreen : BaseScreen
    {
        public AppiumWebElement _brokers
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Brokers");
            }
        }
        
        public AppiumWebElement _fromDate
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_textboxFromDate");
            }
        }
        public AppiumWebElement _dispatched
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Dispatched");
            }
        }

        public AppiumWebElement _abandoned
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Abandoned");
            }
        }

        public AppiumWebElement _search
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Search");
            }
        }

        public AppiumWebElement _selectAll
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_buttonSelectAll");
            }
        }

        public AppiumWebElement _selectTransactionDocs
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Select transaction documents");
            }
        }

        public AppiumWebElement _dispatch
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Dispatch");
            }
        }

        public AppiumWebElement _yes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Yes", timeOutInSeconds: 60);
            }
        }

        public AppiumWebElement _ok
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "OK");
            }
        }

        public AppiumWebElement _buildingFile
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_labelMessage");
            }
        }
        
        public AppiumWebElement _fileName
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Edit[@ClassName=\"Edit\"][@Name=\"File name:\"]");
            }
        }

        public AppiumWebElement _transaction
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Transaction");
            }
        }

        public AppiumWebElement _closings
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "View Closings");
            }
        }

        public AppiumWebElement _close
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Close");
            }
        }
        

        public AppiumWebElement _nextUW
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonBarNext");
            }
        }


        public void dispatchInvoices()
        {
            var fileName = @"C:\temp\Dispatch.pdf";
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            _dispatch.ClickButton();
            wait.Timeout = new TimeSpan(0, 0, 120);
            wait.Until(driver => _yes!=null);
            wait.Timeout = new TimeSpan(0, 0, 60);
            _yes.ClickButton();
            if (_ok != null)
            {
                _ok.ClickButton();

                if (_fileName == null) SwitchToCurrentWindow();
                          
                _fileName.ClickButton();
                _fileName.SetValue(fileName);
                Session.Session.M360Session.Keyboard.PressKey(Keys.Enter);
                if (_yes != null)
                {
                    _yes.ClickButton();
                }
                wait.Until(driver =>
                {
                    return File.Exists(fileName);
                });
            }
            else
            {
                _close.ClickButton();
            }
        }

        public void searchPolicy(JToken testData, string searchType, string date, bool selectAll= false)
        {
            Thread.Sleep(10000);
            SwitchToCurrentWindow();
            try
            {
                _brokers.SetValue(testData["Broker"].ToString());
            }
            catch(Exception e)
            {
                SwitchToCurrentWindow();
                _brokers.SetValue(testData["Broker"].ToString());
            }

            _fromDate.SetValue(date);
            
            switch(searchType)
            {
                case "Outstanding":
                    break;
                case "Dispatched":
                    _dispatched.ClickButton();
                    break;
                case "Abandoned":
                    _abandoned.ClickButton();
                    break;
                default:
                    break;

            }

            _search.ClickButton();
            wait.Timeout = new TimeSpan(0,0,120);
            wait.Until(driver => _selectAll.Enabled);
            wait.Timeout = new TimeSpan(0, 0, 60);
            if (selectAll)
            {
                _selectAll.ClickButton();
                wait.Until(driver => _selectTransactionDocs.Displayed);
                _selectTransactionDocs.ClickButton();                                             
            }
            else
            {
                var actions = new Actions(Session.Session.M360Session);
                actions.MoveToElement(_selectAll);
                actions.MoveByOffset(5, -320);
                actions.Click();
                actions.Perform();
            }            
        }

        public void viewTransaction()
        {
            _transaction.ClickButton();
            SwitchToCurrentWindow();
        }

        public void viewClosing()
        {
            var actions = new Actions(Session.Session.M360Session);
            actions.MoveToElement(_selectAll);
            actions.MoveByOffset(5, -300);
            actions.Click();
            actions.Perform();
            _closings.ClickButton();
            SwitchToCurrentWindow();
        }

        public void ensureLapse()
        {
            wait.Until(driver => _nextUW.Displayed);            
        }

    }
}
