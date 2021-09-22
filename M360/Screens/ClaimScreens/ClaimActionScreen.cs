using System;
using System.Threading;
using ElementControl;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;

namespace M360.Pages
{
    public class ClaimActionScreen : BaseScreen
    {
        public AppiumWebElement ActionTypeCombo => GetElementByAccessibilityId("comboActionType");
        public AppiumWebElement Details => GetElementByAccessibilityId("textDetails");
        public AppiumWebElement Weeks1Radio => GetElementByAccessibilityId("radioButtonWeek1");
        public AppiumWebElement Weeks2Radio => GetElementByAccessibilityId("radioButtonWeek2");
        public AppiumWebElement Weeks3Radio => GetElementByAccessibilityId("radioButtonWeek3");
        public AppiumWebElement Weeks4Radio => GetElementByAccessibilityId("radioButtonWeek4");
        public AppiumWebElement Weeks8Radio => GetElementByAccessibilityId("radioButtonWeek8");
        public AppiumWebElement Weeks12Radio => GetElementByAccessibilityId("radioButtonWeek12");
        public AppiumWebElement OkButton => GetElementByAccessibilityId("buttonOk");
       
        public void CreateNewDiary(JToken testData)
        {
            ActionTypeCombo.Click();
            SelectDropdownOption(Convert.ToInt16(testData["ActionTypeIndex"]));

            Details.SetValue(testData["Details"].ToString());

            int weeksOption = Convert.ToInt16(testData["Weeks"]);
            AppiumWebElement weeksRadio;
            switch (weeksOption)
            {
                case 1:
                    weeksRadio = Weeks1Radio;
                    break;
                case 2:
                    weeksRadio = Weeks2Radio;
                    break;
                case 3:
                    weeksRadio = Weeks3Radio;
                    break;
                case 4:
                    weeksRadio = Weeks4Radio;
                    break;
                case 8:
                    weeksRadio = Weeks8Radio;
                    break;
                case 12:
                    weeksRadio = Weeks12Radio;
                    break;
                default:
                    throw new ApplicationException("Unsupported weeks option.");
            }
            weeksRadio.ClickButton();

            OkButton.Click();
        }
    }
}
