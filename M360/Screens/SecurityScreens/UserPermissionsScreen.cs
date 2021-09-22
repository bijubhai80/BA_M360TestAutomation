using M360.Pages;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M360
{
    public class UserPermissionsScreen : BaseScreen
    {
        public AppiumWebElement _rolesTab => GetElementByName("tabPageRoles");
        public AppiumWebElement _officeTab => GetElementByName("tabPageBranches");
        public AppiumWebElement _buttonAllOffices => GetElementByAccessibilityId("buttonAllBranches");
        public AppiumWebElement _buttonNoOffices => GetElementByAccessibilityId("buttonNoBranches");
        public AppiumWebElement _buttonNoDepartments => GetElementByAccessibilityId("buttonNoTeams");
        public AppiumWebElement _buttonAllOfBoth => GetElementByAccessibilityId("buttonAllOfBoth");
        public AppiumWebElement _buttonSave => GetElementByAccessibilityId("buttonSave");
        public AppiumWebElement _buttonClose => GetElementByAccessibilityId("buttonClose");
        public AppiumWebElement _assignRole => GetElementByName("_All privileges");
        public AppiumWebElement _buttonYes => GetElementByAccessibilityId("buttonYes");
    }
}
