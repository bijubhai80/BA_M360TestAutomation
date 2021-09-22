using System;
using ElementControl;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Appium;

namespace M360.Pages
{
    public class ClaimCreateNewScreen : BaseScreen
    {
        public AppiumWebElement PolicyNumber => GetElementByAccessibilityId("textPolRef");
        public AppiumWebElement LossDate => GetElementByAccessibilityId("textLossDate");
        public AppiumWebElement Description => GetElementByAccessibilityId("textDescription");
        public AppiumWebElement Status => GetElementByAccessibilityId("textStatus");
        public AppiumWebElement Rego1 => GetElementByAccessibilityId("textRego1");
        public AppiumWebElement Rego2 => GetElementByAccessibilityId("textRego2");
        public AppiumWebElement Rego3 => GetElementByAccessibilityId("textRego3");
        public AppiumWebElement ReportClass => GetElementByAccessibilityId("020I");
        public AppiumWebElement Injury => GetElementByAccessibilityId("textInjury");
        public AppiumWebElement Deductible => GetElementByAccessibilityId("textDeductible");
        public AppiumWebElement ActionsTab => GetElementByName("tabActions");
        public AppiumWebElement ActionsNewButton => GetElementByAccessibilityId("buttonNewAction");
        public AppiumWebElement ClaimNumber => GetElementByAccessibilityId("textClaimNumber");
        public AppiumWebElement SaveButton => GetElementByAccessibilityId("buttonSave");
        public AppiumWebElement CloseButton => GetElementByAccessibilityId("buttonClose");

        public string CreateNewClaim(JToken testData)
        {
            PolicyNumber.SetValue(testData["Policy"].ToString());

            LossDate.SetValue(testData["LossDate"].ToString());
            Description.SetValue(testData["Description"].ToString());
            Status.SetValue(testData["Status"].ToString());
            Rego1.SetValue(testData["Registration1"].ToString());
            Rego2.SetValue(testData["Registration2"].ToString());
            Rego3.SetValue(testData["Registration3"].ToString());
            Injury.SetValue(testData["Injury"].ToString());
            Deductible.SetValue(testData["Deductible"].ToString());

            ReportClass.Click();
            SelectDropdownOption(Convert.ToInt16(testData["ReportClassIndex"]));

            ActionsTab.Click();

            ActionsNewButton.Click();

            var claimActionScreen = new ClaimActionScreen();
            claimActionScreen.CreateNewDiary(testData["Actions"]["Diary"]);

            var claimNumber = ClaimNumber.Text;

            SaveButton.Click();
            CloseButton.Click();
            SwitchToCurrentWindow();

            return claimNumber;
        }
    }
}
