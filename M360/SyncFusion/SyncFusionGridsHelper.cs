using M360.Session;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System.Collections.ObjectModel;

namespace ElementControl
{
    public static class SyncFusionGrid
    {

        public static string _rows => "GridRow";
        public static string _cells => "GridCell";

        public static ReadOnlyCollection<WindowsElement> GetRows()
        {
            return Session.M360Session.FindElementsByName(_rows);
        }

        public static ReadOnlyCollection<AppiumWebElement> GetCells(WindowsElement row)
        {
            return row.FindElementsByName(_cells);
        }

        public static void ClickCell(int row, int cell)
        {
            Session.M360Session.FindElementsByName(_rows)[row].FindElementsByName(_cells)[cell].ClickButton();
        }

        public static void SetCell(int row, int cell, string text)
        {
            Session.M360Session.FindElementsByName(_rows)[row].FindElementsByName(_cells)[cell].ClickButton();
            Session.M360Session.FindElementsByName(_rows)[row].FindElementsByName(_cells)[cell].SendKeys(text);
        }
    }

}