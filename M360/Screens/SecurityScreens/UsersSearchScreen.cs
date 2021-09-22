using M360.Pages;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M360
{
    public class UsersSearchScreen: BaseScreen
    {
        public AppiumWebElement _userName => GetElementByAccessibilityId("textBoxUserName");
        public AppiumWebElement _buttonSearch => GetElementByAccessibilityId("buttonSearch");

        public void checkMyPermissions(JToken TestData)
        {
            
        }
    }
}
