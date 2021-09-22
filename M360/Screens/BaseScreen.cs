using ElementControl;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace M360.Pages
{
    public abstract class BaseScreen
    {
        public DefaultWait<WindowsDriver<WindowsElement>> wait = new DefaultWait<WindowsDriver<WindowsElement>>(Session.Session.M360Session)
        {
            Timeout = TimeSpan.FromSeconds(10),
            PollingInterval = TimeSpan.FromSeconds(1)
        };

        public void waitForWindowHandles()
        {
            try
            {
                wait.Until(driver =>
                {
                    return driver.WindowHandles.Count > 0;
                });
            }
            catch (Exception e)
            {
                Thread.Sleep(100);
                waitForWindowHandles();
            }
        }

        public bool WindowHasChanged()
        {
            return Session.Session.M360Session.CurrentWindowHandle != Session.Session.M360Session.WindowHandles[0];
        }

        public void SwitchToCurrentWindow()
        {
            waitForWindowHandles();
            wait.Until(driver => { return WindowHasChanged(); });
            Session.Session.M360Session.SwitchTo().Window(Session.Session.M360Session.WindowHandles[0]);
        }

        public void WaitTillElementDoesNotExist(string accessibilityID)
        {
            wait.Until(driver =>
            {
                try
                {
                    return driver.FindElementsByAccessibilityId(accessibilityID).Count == 0;
                }
                catch (Exception ex)
                {
                    return true;
                }
            });
        }

        public void SelectDropdownOption(int option)
        {
            for (var i = 0; i < option; i++)
            {
                Session.Session.M360Session.Keyboard.PressKey(Keys.Down);
            }
            Session.Session.M360Session.Keyboard.PressKey(Keys.Enter);
        }

        protected AppiumWebElement GetElementByAccessibilityId(string id, int timeOutInSeconds = 30)
        {
            return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, id, timeOutInSeconds: timeOutInSeconds);
        }

        protected AppiumWebElement GetElementByName(string name, int timeOutInSeconds = 30)
        {
            return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, name, timeOutInSeconds: timeOutInSeconds);
        }
    }
}
