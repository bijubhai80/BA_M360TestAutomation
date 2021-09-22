using ElementControl;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Appium;

namespace M360.Pages
{
    public class BuildingContentsScreen : BaseScreen
    {
        public AppiumWebElement _save
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@Name='Script Error']//Button[@AutomationId='btnYes']");
            }
        }

        public AppiumWebElement _yes
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@Name='Script Error']//Button[@AutomationId='btnYes']");
            }
        }

        public AppiumWebElement _typeOfCover
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@Name='Home Risk']//DataItem[position()=5]/ComboBox/Text");
            }
        }

        public AppiumWebElement _doB
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Table[position()=3]//DataItem[position()=13]/Edit");
            }
        }

        public AppiumWebElement _building
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@Name=\"Home Risk\"]/Table[position()=3]/DataItem[position()=3]/Table/DataItem[position()=9]/Table/DataItem[position()=7]/Edit");
            }
        }

        public AppiumWebElement _totalContents
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@Name=\"Home Risk\"]/Table[position()=3]/DataItem[position()=3]/Table/DataItem[position()=9]/Table/DataItem[position()=11]");
            }
        }

        public AppiumWebElement _totalValuables
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@Name=\"Home Risk\"]/Table[position()=3]/DataItem[position()=3]/Table/DataItem[position()=9]/Table/DataItem[position()=17]/Edit");
            }
        }

        public AppiumWebElement _excess
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Table[position()=3]//DataItem[position()=23]/ComboBox/Text");
            }
        }

        public AppiumWebElement _occupiedBy
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buildingOccupancy");
            }
        }

        public AppiumWebElement _construction
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Table[position()=3]/DataItem[position()=4]//DataItem[position()=2]//DataItem[position()=5]//DataItem[position()=9]/ComboBox/Text");
            }
        }

        public AppiumWebElement _buildingType
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buildingType");
            }
        }

        public AppiumWebElement _yearBuilt
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//DataItem[position()=15]/Edit");
            }
        }
        public AppiumWebElement _size
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Table[position()=3]/DataItem[position()=4]/Table/DataItem[position()=2]/Table/DataItem[position()=5]/Table/DataItem[position()=23]");
            }
        }

        public AppiumWebElement _previousInsurer
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@Name=\"Home Risk\"]/Table[position()=3]/DataItem[position()=4]/Table/DataItem[position()=2]/Table/DataItem[position()=10]/Table/DataItem[position()=2]/ComboBox/Text");
            }
        }

        public AppiumWebElement _last5years
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//Pane[@Name=\"Home Risk\"]/Table[position()=3]/DataItem[position()=4]/Table/DataItem[position()=2]/Table/DataItem[position()=11]/Table/DataItem[position()=6]/ComboBox/Text");
            }
        }

        public AppiumWebElement _next
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.Name, "Next");
            }
        }


        public void fillBuildingContentsDetails(JToken testData)
        {
            _yes.ClickButton();
            _typeOfCover.ClickButton();
            SelectDropdownOption(1);
            _doB.SetValue(testData["DateOfBirth"].ToString());
            _building.SetValue(testData["Building"].ToString());
            _totalContents.SetValue(testData["TotalContents"].ToString());
            _totalValuables.SetValue(testData["TotalValuables"].ToString());
            _excess.ClickButton();
            SelectDropdownOption(4);
            _occupiedBy.ClickButton();
            SelectDropdownOption(1);
            _construction.ClickButton();
            SelectDropdownOption(1);
            _buildingType.ClickButton();
            SelectDropdownOption(1);
            _yearBuilt.SetValue(testData["YearBuilt"].ToString());
            _size.SetValue(testData["Size"].ToString());
            _previousInsurer.ClickButton();
            SelectDropdownOption(1);
            _last5years.ClickButton();
            SelectDropdownOption(2);
            _next.ClickButton();
        }
    }
}






