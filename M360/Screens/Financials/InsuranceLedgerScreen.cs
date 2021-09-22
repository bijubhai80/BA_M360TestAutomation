using ElementControl;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M360.Pages
{
    public class InsuranceLedgerScreen : BaseScreen
    {
        public AppiumWebElement _new => GetElementByAccessibilityId("buttonNew");
        public AppiumWebElement _allocation => GetElementByAccessibilityId("buttonAllocate");
        public AppiumWebElement _close => GetElementByAccessibilityId("buttonClose");
        public AppiumWebElement _home => GetElementByAccessibilityId("buttonHome");
        public AppiumWebElement _allRadioButton => GetElementByAccessibilityId("jltaRadioAll");
        public AppiumWebElement _outstanding => GetElementByAccessibilityId("jltaRadioOutstanding");
        public AppiumWebElement _export => GetElementByAccessibilityId("buttonExport");
        public AppiumWebElement _client => GetElementByAccessibilityId("buttonLedger");

        public void gotoNew()
        {
            _new.ClickButton();
        }

        public void goToAllocate()
        {
            _allocation.ClickButton();
        }
    }
}
