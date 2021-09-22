using AventStack.ExtentReports;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System;
using NUnit.Framework;
using Log;
using OpenQA.Selenium.Support.UI;
using M360.Session;

namespace ElementControl
{
    /// <summary>
    /// WinAppDriver Class
    /// </summary>
    public static partial class WinAppDriverControlMethods
    {
        public enum SearchBy
        {
            AccessibilityId,
            ClassName,
            Name,
            TagName,
            XPath
        };

        internal static AppiumWebElement GetElement(object m360Session, SearchBy name, string v)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets value in Checkbox
        /// </summary>
        /// <param name="control">control</param>
        /// <param name="newValue">New Value to be set in control</param>
        public static void CheckBoxSetValue(this WindowsElement control, bool newValue)
        {
            if (newValue)
            {
                if (control.GetAttribute("Toggle.ToggleState") == "0")
                {
                    control.ClickButton();
                    Log.Log.Message("[{0}]: value is set to '{1}'", control.GetAttribute("Name"), newValue);
                }
                else
                {
                    //do nothing
                    Log.Log.Message("[{0}]: value is set to '{1}'", control.GetAttribute("Name"), newValue);
                }
            }
            else
            {
                if (control.GetAttribute("Toggle.ToggleState") == "1")
                {
                    control.ClickButton();
                    Log.Log.Message("[{0}]: value is set to '{1}'", control.GetAttribute("Name"), newValue);
                }
                else
                {
                    //do nothing
                    Log.Log.Message("[{0}]: value is set to '{1}'", control.GetAttribute("Name"), newValue);
                }
            }
        }

        /// <summary>
        /// Sets value in Checkbox
        /// </summary>
        /// <param name="control">control</param>
        /// <param name="newValue">New Value to be set in control</param>
        public static void CheckBoxSetValue(this AppiumWebElement control, bool newValue)
        {
            if (newValue)
            {
                if (control.GetAttribute("Toggle.ToggleState") == "0")
                {
                    control.ClickButton();
                    Log.Log.Message("[{0}]: value is set to '{1}'", control.GetAttribute("Name"), newValue);
                }
                else
                {
                    //do nothing
                    Log.Log.Message("[{0}]: value is set to '{1}'", control.GetAttribute("Name"), newValue);
                }
            }
            else
            {
                if (control.GetAttribute("Toggle.ToggleState") == "1")
                {
                    control.ClickButton();
                    Log.Log.Message("[{0}]: value is set to '{1}'", control.GetAttribute("Name"), newValue);
                }
                else
                {
                    //do nothing
                    Log.Log.Message("[{0}]: value is set to '{1}'", control.GetAttribute("Name"), newValue);
                }
            }
        }

        
        /// <summary>
        /// Click button for WindowsElement
        /// </summary>
        /// <param name="control">control</param>
        public static void ClickButton(this WindowsElement button, string buttonName = "", int timeout = 10000)
        {
            //Assert.IsTrue(button.WaitForControlVisibleExistEnabledReady(timeout), "Button is not available");

            if (buttonName == string.Empty)
            {
                buttonName = button.GetAttribute("Name");
            }

            Log.Log.Message("Click '{0}' button", buttonName);

            //Mouse.Hover(button);
            //Mouse.Click(button);

            button.Click();
        }

        /// <summary>
        /// Click button for AppiumWebElement
        /// </summary>
        /// <param name="control">control</param>
        public static void ClickButton(this AppiumWebElement button, int timeout = 10000, bool nullElementPass = false)
        {
            if (button != null)
            {
                var buttonName = "";
                if (button.GetAttribute("Name") != "")
                    buttonName = button.GetAttribute("Name");
                else if (button.GetAttribute("AutomationId") != "")
                    buttonName = button.GetAttribute("AutomationId");
                else if (button.GetAttribute("ClassName") != "")
                    buttonName = button.GetAttribute("ClassName");

                Log.Log.Message("Click '{0}' button", buttonName);

                button.Click();
            }
            else if (!nullElementPass)
            {
                Assert.Fail("Element Missing");
            }
        }

        //public static WindowsElement GetElement(string automationId, string controlName, int timeOut = 10000)
        //{
        //    bool iterate = true;
        //    WindowsElement control = null;
        //    _elementTimeOut = TimeSpan.FromMilliseconds(timeOut);
        //    timer.Start();

        //    while (timer.Elapsed <= _elementTimeOut && iterate == true)
        //    {
        //        try
        //        {
        //            control = Driver.FindElementByAccessibilityId(automationId);
        //            iterate = false;
        //        }
        //        catch (WebDriverException ex)
        //        {
        //            LogSearchError(ex, automationId, controlName);
        //        }
        //    }

        //    timer.Stop();
        //    Assert.IsFalse(timer.Elapsed > _elementTimeOut, "Timeout Elapsed, element not found.");
        //    timer.Reset();

        //    return control;
        //}

        //public static WindowsElement GetElement(string automationId, WindowsDriver<WindowsElement> FusionAppSession, int timeOut = 10000)
        //{
        //    WindowsElement element = null;
        //    var wait = new DefaultWait<WindowsDriver<WindowsElement>>(FusionAppSession)
        //    {
        //        Timeout = TimeSpan.FromMilliseconds(timeOut),
        //        Message = $"Element with automationId \"{automationId}\" not found."
        //    };

        //    wait.IgnoreExceptionTypes(typeof(WebDriverException));

        //    try
        //    {
        //        wait.Until(Driver =>
        //        {
        //            //element = Driver.FindElementByAccessibilityId(automationId);
        //            element = FindElement("", "");

        //            return element != null;
        //        });
        //    }
        //    catch (WebDriverTimeoutException ex)
        //    {
        //        //LogSearchError(ex, automationId, propertyName);
        //        //Assert.Fail(ex.Message);
        //    }

        //    return element;
        //}

        /// <summary>
        /// Selects provided value in Combo box with SendKeys
        /// </summary>
        /// <param name="control"></param>
        /// <param name="newValue"></param>
        public static void ComboboxSelectValueBySendKeys(this WindowsElement control, string newValue)
        {
            if (control == null)
            {
                Log.Log.Message("Couldn't set value as control is null");
                return;
            }

            try
            {
                control.SendKeys(newValue);
                control.SendKeys(Keys.Enter);
            }
            catch { }

            //Verify
            VerifySetValue(control, newValue);
        }

        /// <summary>
        /// Selects provided value in Combo box with SendKeys
        /// </summary>
        /// <param name="control"></param>
        /// <param name="newValue"></param>
        public static void ComboboxSelectValueBySendKeys(this AppiumWebElement control, string newValue)
        {
            if (control == null)
            {
                Log.Log.Message("Couldn't set value as control is null");
                return;
            }

            try
            {
                control.SendKeys(newValue);
                control.SendKeys(Keys.Enter);
            }
            catch { }

            //Verify
            VerifySetValue(control, newValue);
        }

        /// <summary>
        /// Searches for value in table under given column
        /// </summary>
        public static AppiumWebElement FindCell(this WindowsElement grid, string columnHeader, string value)
        {
            if (grid == null)
                return null;
            var rows = grid.FindElementsByTagName(".//Custom");

            for (int i = 0; i < rows.Count - 1; i++)
            {
                string currentRowXpath = "//DataItem[@Name='" + columnHeader + " Row " + i + "']";
                AppiumWebElement cell = grid.FindElementByXPath(currentRowXpath);

                if (cell.GetAttribute("Value.Value") == value)
                {
                    return cell;
                }
            }
            return null;
        }

        /// <summary>
        /// Searches control with Selector and returns controls
        /// </summary>
        /// <param name="parentControl"></param>
        /// <param name="searchBy"></param>
        /// <param name="Selector"></param>
        /// <param name="isRetry"></param>
        /// <returns></returns>
        public static AppiumWebElement GetElement(
            WindowsDriver<WindowsElement> parentControl, SearchBy searchBy, string Selector, bool isRetry = true, int timeOutInSeconds = 30)
        {
            AppiumWebElement elementToFind = null;
            DefaultWait<WindowsDriver<WindowsElement>> wait = new DefaultWait<WindowsDriver<WindowsElement>>(parentControl)
            {
                Timeout = TimeSpan.FromSeconds(timeOutInSeconds),
                PollingInterval = TimeSpan.FromMilliseconds(500)
            };
            try
            {
                switch (searchBy)
                {
                    case SearchBy.AccessibilityId:
                        wait.Until(driver => { return driver.FindElementsByAccessibilityId(Selector).Count > 0; });
                        elementToFind = parentControl.FindElementByAccessibilityId(Selector);
                        break;

                    case SearchBy.ClassName:
                        wait.Until(driver => { return driver.FindElementsByClassName(Selector).Count > 0; });
                        elementToFind = parentControl.FindElementByClassName(Selector);
                        break;

                    case SearchBy.Name:
                        wait.Until(driver => { return driver.FindElementsByName(Selector).Count > 0; });
                        elementToFind = parentControl.FindElementByName(Selector);
                        break;

                    case SearchBy.TagName:
                        wait.Until(driver => { return driver.FindElementsByTagName(Selector).Count > 0; });
                        elementToFind = parentControl.FindElementByTagName(Selector);
                        break;

                    case SearchBy.XPath:
                        wait.Until(driver => { return driver.FindElementsByXPath(Selector).Count > 0; });
                        elementToFind = parentControl.FindElementByXPath(Selector);
                        break;
                }
            }
            catch (Exception e)
            {
                elementToFind = null;
            }
            return elementToFind;
        }

        /// <summary>
        /// Searches control with Selector and returns controls
        /// </summary>
        /// <param name="parentControl"></param>
        /// <param name="searchBy"></param>
        /// <param name="Selector"></param>
        /// <param name="isRetry"></param>
        /// <returns></returns>
        public static AppiumWebElement GetElement(AppiumWebElement parentControl, SearchBy searchBy, string Selector)
        {
            DefaultWait<WindowsDriver<WindowsElement>> wait = new DefaultWait<WindowsDriver<WindowsElement>>(Session.M360Session)
            {
                Timeout = TimeSpan.FromSeconds(30),
                PollingInterval = TimeSpan.FromSeconds(1)
            };

            AppiumWebElement elementToFind = null;
            switch (searchBy)
            {
                case SearchBy.AccessibilityId:
                    wait.Until(driver => { return driver.FindElementsByAccessibilityId(Selector).Count > 0; });
                    elementToFind = parentControl.FindElementByAccessibilityId(Selector);
                    break;
                case SearchBy.ClassName:
                    wait.Until(driver => { return driver.FindElementsByClassName(Selector).Count > 0; });
                    elementToFind = parentControl.FindElementByClassName(Selector);
                    break;
                case SearchBy.Name:
                    wait.Until(driver => { return driver.FindElementsByName(Selector).Count > 0; });
                    elementToFind = parentControl.FindElementByName(Selector);
                    break;
                case SearchBy.TagName:
                    wait.Until(driver => { return driver.FindElementsByTagName(Selector).Count > 0; });
                    elementToFind = parentControl.FindElementByTagName(Selector);
                    break;
                case SearchBy.XPath:
                    wait.Until(driver => { return driver.FindElementsByXPath(Selector).Count > 0; });
                    elementToFind = parentControl.FindElementByXPath(Selector);
                    break;
            }
            return elementToFind;
        }

        /// <summary>
        /// Searches controls with Selector and returns controls
        /// </summary>
        /// <param name="parentControl"></param>
        /// <param name="searchBy"></param>
        /// <param name="Selector"></param>
        /// <param name="isRetry"></param>
        /// <returns></returns>
        public static IReadOnlyCollection<AppiumWebElement> GetElements(WindowsDriver<WindowsElement> parentControl, SearchBy searchBy, string Selector, bool isRetry = true)
        {
            IReadOnlyCollection<AppiumWebElement> results = null;
            int retryCount = 0;
            int maxRetryCount = 1;
            bool isElementFound = false;

            if (parentControl == null)
                return null;

            do
            {
                try
                {
                    switch (searchBy)
                    {
                        case SearchBy.AccessibilityId:
                            results = parentControl.FindElementsByAccessibilityId(Selector);
                            break;

                        case SearchBy.ClassName:
                            results = parentControl.FindElementsByClassName(Selector);
                            break;

                        case SearchBy.Name:
                            results = parentControl.FindElementsByName(Selector);
                            break;

                        case SearchBy.TagName:
                            results = parentControl.FindElementsByTagName(Selector);
                            break;

                        case SearchBy.XPath:
                            results = parentControl.FindElementsByXPath(Selector);
                            break;
                    }
                    isElementFound = true;
                }
                catch (WebDriverException ex)
                {
                    string message = string.Format("Unable to find an element with given search criteria: {0}, Error message is: {1}", Selector, ex.Message);
                    Log.Log.Error(message);

                    retryCount++;
                }
            } while (isRetry != false && isElementFound == false && retryCount <= maxRetryCount);
            return results;
        }

        //public static dynamic GetElement(SearchBy searchBy, string Selector, dynamic parentControl = null, bool isRetry = true)
        //{
        //    dynamic resultControl = null, session = null;
        //    int retryCount = 0, maxRetryCount = 1;

        //    if (parentControl == null)
        //        session = WinAppDriver.FusionAppSession;
        //    else
        //        session = parentControl;

        //    do
        //    {
        //        try
        //        {
        //            switch (searchBy)
        //            {
        //                case SearchBy.AccessibilityId:
        //                    resultControl = session.FindElementByAccessibilityId(Selector);
        //                    break;

        //                case SearchBy.ClassName:
        //                    resultControl = session.FindElementByClassName(Selector);
        //                    break;

        //                case SearchBy.Name:
        //                    resultControl = session.FindElementByName(Selector);
        //                    break;

        //                case SearchBy.TagName:
        //                    resultControl = session.FindElementByTagName(Selector);
        //                    break;

        /// <summary>
        /// Gets selected Item from ComboBox
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static string GetSelectedItemInComboBox(this WindowsElement control)
        {
            return control.GetAttribute("Value.Value");
        }

        /// <summary>
        /// Waits for specified window is opened or not.
        /// </summary>
        /// <param name="control">Window control</param>
        /// <param name="title">Window title</param>
        /// <param name="expected">Is window expected or not</param>
        /// <param name="delay">Number of milliseconds to wait until the specified Window becomes available</param>
        public static void IsWindowOpen(WindowsElement control, bool expected, int delay = 60000)
        {
            //control.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            if (expected)
            {
                if (!control.WaitForControlVisible(delay))
                {
                    Assert.Fail("'{0}' window hasn't been opened!", control.GetAttribute("AutomationID"));
                }
                else
                {
                    Log.Log.Message("'{0}' window has been opened successfully", control.GetAttribute("AutomationID"));
                }
            }
            else
            {
                if (control.WaitForControlNotVisible(delay))
                {
                    Log.Log.Message("'{0}' window is not open (expected)", control.GetAttribute("AutomationID"));
                }
                else
                {
                    Assert.Fail("'{0}' window hasn't been closed!", control.GetAttribute("AutomationID"));
                }
            }
        }

        /// <summary>
        /// Waits for specified window is opened or not.
        /// </summary>
        /// <param name="actualTitle">Title of the current open window</param>
        /// <param name="expectedTitle">Expected Window title</param>
        /// <param name="expected">Is window expected or not</param>
        /// <param name="delay">Number of milliseconds to wait until the specified Window becomes available</param>
        public static void IsWindowOpen(string actualTitle, string expectedTitle, bool expected, int delay = 60000)
        {
            if (expected)
            {
                DateTime endTime = DateTime.Now.AddMilliseconds(delay);
                while (DateTime.Now < endTime)
                {
                    if ((actualTitle == expectedTitle) || Regex.IsMatch(actualTitle, expectedTitle) || actualTitle.Contains(expectedTitle))
                    {
                        Log.Log.Message("'{0}' window has been opened successfully", expectedTitle);
                        break;
                    }
                    else
                    {
                        Assert.Fail("Window title is incorrect. Actual '{0}'. Expected '{1}'", actualTitle, expectedTitle);
                    }
                }
            }
            else
            {
                DateTime endTime = DateTime.Now.AddMilliseconds(delay);
                while (DateTime.Now < endTime)
                {
                    if ((actualTitle == expectedTitle) || Regex.IsMatch(actualTitle, expectedTitle))
                    {
                        Assert.Fail("'{0}' window hasn't been closed!", expectedTitle);
                    }
                    else
                    {
                        Log.Log.Message("'{0}' window is not open (expected). '{1}' window is open", expectedTitle, actualTitle);
                    }
                }
            }
        }

        /// <summary>
        /// Gets selected item
        /// </summary>
        /// <param name="control">>Control</param>
        public static void SetValue(this WindowsElement control, string newValue, bool nullElementPass = false)
        {
            if (control == null)
            {
                Log.Log.Message("Couldn't set value as control is null");
                return;
            }

            try { control.SendKeys(newValue); }
            catch { }

            //Verify
            VerifySetValue(control, newValue);
        }

        /// <summary>
        /// Sets value of control
        /// </summary>
        /// <param name="control"></param>
        /// <param name="newValue"></param>
        public static void SetValue(this AppiumWebElement control, string newValue, bool nullElementPass = false)
        {
            if (control != null)
            {
                try { control.SendKeys(newValue); }
                catch { }
                VerifySetValue(control, newValue);
            }
            else if (!nullElementPass)
            {
                Assert.Fail("Missing Element");
            }
        }

        /// <summary>
        /// Verifies set value
        /// </summary>
        /// <param name="control"></param>
        /// <param name="valueTobeVerified"></param>
        /// <returns></returns>
        public static bool VerifySetValue(AppiumWebElement control, string valueTobeVerified)
        {
            try
            {
                if (control.Text.Trim() == valueTobeVerified.Trim())
                {
                    Log.Log.Message("[{0}]: value is set to '{1}'", control.GetAttribute("Name"), valueTobeVerified);
                    return true;
                }
                else
                {
                    Log.Log.Error("[{0}]: Values are different, Control value is '{1}' and expected value is '{2}'", control.GetAttribute("Name"),
                               control.Text, valueTobeVerified);
                    return false;
                }
            }
            catch { return false; }
        }

        /// <summary>
        /// Verifies validation message
        /// </summary>
        /// <param name="messageText">>Message text</param>
        /// <param name="btnName">Button Name</param>
        /// <param name="delay">Timeout to wait for a window</param>
        /// <param name="condition">Indicates whether the actual message text should contain/equal to the expected text</param>
        /// <param name="wndTitle">Window title</param>
        public static void VerifyValidationMsg(WindowsElement window, string messageText, string btnName, int delay = 5000, string condition = "Contains")
        {
            string messageActual = string.Empty;
            if (window.Displayed)
            {
                messageActual = WinAppDriverControlMethods.GetElement(window, SearchBy.TagName, ".//Text").GetAttribute("Name");

                if (condition == "Equals")
                {
                    Assert.AreEqual(messageText, messageActual);
                    Log.Log.Message("Expected Message:'{0}' is same as Actual Message:'{1}'", messageText, messageActual);
                }
                else if (condition == "Contains")
                {
                    if (!messageActual.Contains(messageText))
                    {
                        Assert.Fail("Expected message is: '{0}'. Current message is '{1}'", messageText, messageActual);
                    }
                }
            }

            Log.Log.Message("'" + messageText + "' - validation message was displayed correctly");

            // Close dialog window
            if (btnName != null)
            {
                var button = WinAppDriverControlMethods.GetElement(window, SearchBy.XPath, "//Button[@Name='" + btnName + "']");
                button.ClickButton();
            }
        }

        /// <summary>
        /// Verifies the value into a given edit control
        /// </summary>
        /// <param name="control">Control to check</param>
        /// <param name="expectedValue">Expected value</param>
        /// <param name="controlType">Control Type</param>
        public static void VerifyValue(this WindowsElement control, string expectedValue, string controlType)
        {
            if (controlType == "RadioButton")
            {
                string actualValue = control.Selected.ToString();
                if (actualValue == expectedValue)
                {
                    Log.Log.Message("value is correct: {0}", actualValue);
                }
                else
                {
                    Assert.Fail("value is incorrect! Expected: {0}. Actual: {1}", expectedValue, actualValue);
                    Log.Log.Message("value is incorrect! Expected: {0}. Actual: {1}", expectedValue, actualValue);
                }
            }
            else if (controlType == "CheckBox")
            {
                string actualValue = string.Empty;
                if (control.GetAttribute("Toggle.ToggleState") == "0")
                {
                    actualValue = "False";
                }
                else { actualValue = "True"; }
                if (actualValue == expectedValue)
                {
                    Log.Log.Message("value is correct: {0}", actualValue);
                }
                else
                {
                    Assert.Fail("value is incorrect! Expected: {0}. Actual: {1}", expectedValue, actualValue);
                    Log.Log.Message("value is incorrect! Expected: {0}. Actual: {1}", expectedValue, actualValue);
                }
            }
            else
            {
                string actualValue = control.GetAttribute("Value.Value");
                if (actualValue == expectedValue)
                {
                    Log.Log.Message("value is correct: {0}", actualValue);
                }
                else
                {
                    Assert.Fail("value is incorrect! Expected: {0}. Actual: {1}", expectedValue, actualValue);
                    Log.Log.Message("value is incorrect! Expected: {0}. Actual: {1}", expectedValue, actualValue);
                }
            }
        }

        /// <summary>
        /// Verifies the value into a given edit control
        /// </summary>
        /// <param name="control">Control to check</param>
        /// <param name="expectedValue">Expected value</param>
        /// <param name="controlType">Control Type</param>
        public static void VerifyValue(this AppiumWebElement control, string expectedValue, string controlType)
        {
            if (controlType == "RadioButton")
            {
                string actualValue = control.GetAttribute("IsSelected");
                if (actualValue == expectedValue)
                {
                    Log.Log.Message("value is correct: {0}", actualValue);
                }
                else
                {
                    Assert.Fail("value is incorrect! Expected: {0}. Actual: {1}", expectedValue, actualValue);
                    Log.Log.Message("value is incorrect! Expected: {0}. Actual: {1}", expectedValue, actualValue);
                }
            }
            else if (controlType == "Checkbox")
            {
                string actualValue = control.GetAttribute("Toggle.ToggleState");
                if (actualValue == expectedValue)
                {
                    Log.Log.Message("value is correct: {0}", actualValue);
                }
                else
                {
                    Assert.Fail("value is incorrect! Expected: {0}. Actual: {1}", expectedValue, actualValue);
                    Log.Log.Message("value is incorrect! Expected: {0}. Actual: {1}", expectedValue, actualValue);
                }
            }
            else
            {
                string actualValue = control.GetAttribute("Value.Value");
                if (actualValue == expectedValue)
                {
                    Log.Log.Message("value is correct: {0}", actualValue);
                }
                else
                {
                    Assert.Fail("value is incorrect! Expected: {0}. Actual: {1}", expectedValue, actualValue);
                    Log.Log.Message("value is incorrect! Expected: {0}. Actual: {1}", expectedValue, actualValue);
                }
            }
        }

        /// <summary>
        /// Checks whether a control is visible or not
        /// </summary>
        /// <param name="control">UI control</param>
        /// <param name="delay">Delay to wait for</param>
        /// <returns>Is control visible</returns>
        public static bool WaitForControlEnabled(this WindowsElement control, int delay)
        {
            DateTime endTime = DateTime.Now.AddMilliseconds(delay);
            while (DateTime.Now < endTime)
            {
                if (control.Enabled)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks whether a control is visible or not
        /// </summary>
        /// <param name="control">UI control</param>
        /// <param name="delay">Delay to wait for</param>
        /// <returns>Is control visible</returns>
        public static bool WaitForControlEnabled(this AppiumWebElement control, int delay)
        {
            DateTime endTime = DateTime.Now.AddMilliseconds(delay);
            while (DateTime.Now < endTime)
            {
                if (control.Enabled)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks whether a control is visible or not
        /// </summary>
        /// <param name="control">UI control</param>
        /// <param name="delay">Delay to wait for</param>
        /// <returns>Is control visible</returns>
        public static bool WaitForControlNotVisible(this WindowsElement control, int delay)
        {
            DateTime endTime = DateTime.Now.AddMilliseconds(delay);
            while (DateTime.Now < endTime)
            {
                if (!control.Displayed)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks whether a control is visible or not
        /// </summary>
        /// <param name="control">UI control</param>
        /// <param name="delay">Delay to wait for</param>
        /// <returns>Is control visible</returns>
        public static bool WaitForControlNotVisible(this AppiumWebElement control, int delay)
        {
            DateTime endTime = DateTime.Now.AddMilliseconds(delay);
            while (DateTime.Now < endTime)
            {
                if (!control.Displayed)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks whether a control is visible or not
        /// </summary>
        /// <param name="control">UI control</param>
        /// <param name="delay">Delay to wait for</param>
        /// <returns>Is control visible</returns>
        public static bool WaitForControlVisible(this WindowsElement control, int delay)
        {
            DateTime endTime = DateTime.Now.AddMilliseconds(delay);
            while (DateTime.Now < endTime)
            {
                if (control.Displayed)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Waits for control to be visible
        /// </summary>
        /// <param name="control">UITestControl control</param>
        /// <param name="millisecondsTimeout">The milliseconds timeout</param>
        /// <returns>true if available, false if not</returns>
        public static bool WaitForControlVisible(this AppiumWebElement control, int delay)
        {
            DateTime endTime = DateTime.Now.AddMilliseconds(delay);
            while (DateTime.Now < endTime)
            {
                if (control.Displayed)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Waits for control to be visible and enabled
        /// </summary>
        /// <param name="control">UITestControl control</param>
        /// <param name="millisecondsTimeout">The milliseconds timeout</param>
        /// <returns>true if available, false if not</returns>
        public static bool WaitForControlVisibleEnabled(this WindowsElement control, int millisecondsTimeout = 2000)
        {
            if (!control.WaitForControlEnabled(millisecondsTimeout))
            {
                Log.Log.Message("Control is not enabled");
                return false;
            }

            if (!control.WaitForControlVisible(millisecondsTimeout))
            {
                Log.Log.Message("Control is not ready");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Waits for control to be visible and enabled
        /// </summary>
        /// <param name="control">UITestControl control</param>
        /// <param name="millisecondsTimeout">The milliseconds timeout</param>
        /// <returns>true if available, false if not</returns>
        public static bool WaitForControlVisibleEnabled(this AppiumWebElement control, int millisecondsTimeout = 2000)
        {
            Thread.Sleep(3000);
            if (!control.WaitForControlEnabled(millisecondsTimeout))
            {
                Log.Log.Message("Control is not enabled");
                return false;
            }

            if (!control.WaitForControlVisible(millisecondsTimeout))
            {
                Log.Log.Message("Control is not ready");
                return false;
            }

            return true;
        }
    }
}
