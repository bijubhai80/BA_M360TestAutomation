using M360.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace M360.Screens
{
    public class WordDocument : BaseScreen
    {
        //word doc
        public string _wordContent = "Page 1 content";
        public string _wordClose = "Close";
        public string _wordYes = "Yes";
        public string _file = "FileTabButton";
        public string _wordSave = "Save";

        public void editDocument(string text)
        {
            AppiumOptions rootCapabilities = new AppiumOptions();
            rootCapabilities.AddAdditionalCapability("app", "Root");
            WindowsDriver<WindowsElement> desktopSession = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), rootCapabilities);
            var wait = new DefaultWait<WindowsDriver<WindowsElement>>(desktopSession)
            {
                Timeout = TimeSpan.FromSeconds(60),
                PollingInterval = TimeSpan.FromSeconds(1)
            };
            //Ivan: below works, please check in and remove this comment.
            wait.Until(driver =>
            {
                return driver.FindElementsByXPath("//Button[contains(@Name,'Word')]").Count > 0;
            });
            try
            {
                wait.Timeout = new TimeSpan(0, 0, 30);
                wait.Until(driver => driver.FindElementByName(_wordContent).Displayed);
            }
            catch (Exception e)
            {
                desktopSession.FindElementByXPath("//Button[contains(@Name,'Word')]").Click();
            }

            desktopSession.FindElementByName(_wordContent).SendKeys(text);
            //desktopSession.FindElementByAccessibilityId(_file).Click();
            desktopSession.FindElementByName(_wordClose).Click();
            wait.Until(driver => driver.FindElementByName(_wordYes).Displayed);
            desktopSession.FindElementByName(_wordYes).Click();
            Thread.Sleep(5000);
        }

        public void saveDocument(string text)
        {
            AppiumOptions rootCapabilities = new AppiumOptions();
            rootCapabilities.AddAdditionalCapability("app", "Root");
            WindowsDriver<WindowsElement> desktopSession = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), rootCapabilities);
            var wait = new DefaultWait<WindowsDriver<WindowsElement>>(desktopSession)
            {
                Timeout = TimeSpan.FromSeconds(60),
                PollingInterval = TimeSpan.FromSeconds(1)
            };
            //Ivan: below works, please check in and remove this comment.
            wait.Until(driver =>
            {
                return driver.FindElementsByXPath("//Button[contains(@Name,'Word')]").Count > 0;
            });
            try
            {
                wait.Timeout = new TimeSpan(0, 0, 30);
                wait.Until(driver => driver.FindElementByName(_wordContent).Displayed);
            }
            catch (Exception e)
            {
                desktopSession.FindElementByXPath("//Button[contains(@Name,'Word')]").Click();
            }

            //desktopSession.FindElementByName(_wordContent).SendKeys(text);
            //desktopSession.FindElementByAccessibilityId(_file).Click();
            desktopSession.FindElementByName(_wordClose).Click();
            wait.Until(driver => driver.FindElementByName(_wordYes).Displayed);
            desktopSession.FindElementByName(_wordSave).Click();
            Thread.Sleep(5000);
        }
        public void verifyText(string text)
        {
            AppiumOptions rootCapabilities = new AppiumOptions();
            rootCapabilities.AddAdditionalCapability("app", "Root");
            WindowsDriver<WindowsElement> desktopSession = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), rootCapabilities);
            var wait = new DefaultWait<WindowsDriver<WindowsElement>>(desktopSession)
            {
                Timeout = TimeSpan.FromSeconds(60),
                PollingInterval = TimeSpan.FromSeconds(1)
            };
            wait.Until(driver =>
            {
                return driver.FindElementsByXPath("//Button[contains(@Name,'Word')]").Count > 0;
            });
            try
            {
                desktopSession.FindElementByName(_wordContent);
            }
            catch (Exception e)
            {
                desktopSession.FindElementByXPath("//Button[contains(@Name,'Word')]").Click();
            }
            var textContent = desktopSession.FindElementByName(_wordContent).Text;
            Assert.IsTrue(textContent.Contains(text));
            desktopSession.FindElementByName(_wordClose).Click();
            Thread.Sleep(5000);
        }
    }
}
