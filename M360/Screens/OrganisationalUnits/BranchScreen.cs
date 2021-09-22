using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElementControl;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Appium;

namespace M360.Pages
{
    public class BranchScreen : BaseScreen
    {
        public AppiumWebElement _office => GetElementByAccessibilityId("SelectOrganisationalUnitsDialog\"]/Tree[starts-with(@ClassName,\"WindowsForms10\")][@Name=\"treeView\"]/TreeItem[@Name=\"JLTA (Group)\"]/TreeItem[@Name=\"Specialty (Company)\"]/TreeItem[@Name=\"Perth (Office 060)\"]");
        public AppiumWebElement _allButton => GetElementByAccessibilityId("buttonAll");
        public AppiumWebElement _okButton => GetElementByAccessibilityId("buttonOK");

        public void selectBranch(JToken testData)
        {
            _allButton.ClickButton();
            _okButton.ClickButton();
        }
    }
}
