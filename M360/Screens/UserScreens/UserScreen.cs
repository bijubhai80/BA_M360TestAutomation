using ElementControl;
using M360.Pages;
using OpenQA.Selenium.Appium;
using System;

namespace M360TestAutomation.Screens.UserScreens
{
    public class UserScreen : BaseScreen
    {
        private AppiumWebElement TabPageRoles => WinAppDriverControlMethods.GetElement(M360.Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "tabPageRoles");

        private AppiumWebElement ButtonSave =>
            WinAppDriverControlMethods.GetElement(M360.Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Save");

        private AppiumWebElement ButtonClose =>
            WinAppDriverControlMethods.GetElement(M360.Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Close");

        /// <summary>
        /// Toggles the role in the user screen.
        /// TODO: Have not found a way to set the checkbox in the TreeView. Toggle.ToggleState always returns 2
        /// </summary>
        /// <param name="treeItemName">Name of the role.</param>
        public void ToggleRole(string treeItemName)
        {
            //Log.Log.Message("User Test: Before Tab Roles");
            TabPageRoles.ClickButton();
            var treeItem = WinAppDriverControlMethods.GetElement(M360.Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, treeItemName);
            //var test = treeItem.GetAttribute("Toggle.ToggleState");
            treeItem.Click();
            //test = treeItem.GetAttribute("Toggle.ToggleState");
            treeItem.SetValue(" ");
            //test = treeItem.GetAttribute("Toggle.ToggleState");
            //Log.Log.Message("User Test: After Toggle Roles");
        }

        public void Save()
        {
            ButtonSave.ClickButton();
            Log.Log.Message("User Test: After UserScreen Button Save");
        }


        public void CloseScreen()
        {
            //SwitchToCurrentWindow();
            var origTimeout = wait.Timeout;
            var origPollingInterval = wait.PollingInterval;
            wait.Timeout = new TimeSpan(0, 0, 7, 0);
            wait.PollingInterval = new TimeSpan(0, 0, 1, 0);
            Log.Log.Message($"User Test: waitForWindowHandles() for at least {wait.Timeout:g}");
            waitForWindowHandles();
            wait.Timeout = origTimeout;
            wait.PollingInterval = origPollingInterval;
            ButtonClose.ClickButton();
        }
    }
}
