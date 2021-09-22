using ElementControl;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Appium;

namespace M360.Pages
{
    public class FloodScreen : BaseScreen
    {
        public AppiumWebElement _yes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@Name='Script Error']//Button[@AutomationId='btnYes']");
            }
        }

        public AppiumWebElement _groundSwimmingPool
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@Name=\"Flood Questions\"]/Table[position()=3]/DataItem/Table/DataItem/Table/DataItem[position()=3]/Table/DataItem[position()=6]/ComboBox");
            }
        }

        public AppiumWebElement _belowGroundLevel
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@Name=\"Flood Questions\"]/Table[position()=3]/DataItem/Table/DataItem/Table/DataItem[position()=3]/Table/DataItem[position()=9]/ComboBox/Text");
            }
        }

        public AppiumWebElement _twoStoreys
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@Name=\"Flood Questions\"]/Table[position()=3]/DataItem/Table/DataItem/Table/DataItem[position()=3]/Table/DataItem[position()=12]/ComboBox");
            }
        }

        public AppiumWebElement _stilts
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@Name=\"Flood Questions\"]/Table[position()=3]/DataItem/Table/DataItem/Table/DataItem[position()=3]/Table/DataItem[position()=15]");
            }
        }

        public AppiumWebElement _privateFloodMitigation
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@Name=\"Flood Questions\"]/Table[position()=3]/DataItem/Table/DataItem/Table/DataItem[position()=3]/Table/DataItem[position()=18]/ComboBox");
            }
        }

        public AppiumWebElement _next
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Next");
            }
        }

        public void fillFloodDetails(JToken testData)
        {
            _yes.ClickButton();
            _groundSwimmingPool.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["GroundSwimmingPool"].ToString()).Click();
            _belowGroundLevel.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["BelowGroundLevel"].ToString()).Click();
            _twoStoreys.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["TwoStoreys"].ToString()).Click();
            _stilts.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["Stilts"].ToString()).Click();
            _privateFloodMitigation.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["PrivateMeasures"].ToString()).Click();
            _next.ClickButton();
        }
    }
}
