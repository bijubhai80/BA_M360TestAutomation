using OpenQA.Selenium.Appium;
using ElementControl;
using Newtonsoft.Json.Linq;

namespace M360.Pages
{
    public class ClaimSearchScreen : BaseScreen
    {
        public AppiumWebElement Office => GetElementByAccessibilityId("jltaCodeTandemBranch");
        public AppiumWebElement TextSearchFor => GetElementByAccessibilityId("textSearchFor");
        public AppiumWebElement RadioDescription => GetElementByAccessibilityId("radioDescription");
        public AppiumWebElement RadioClientRef => GetElementByAccessibilityId("radioClientRef");
        public AppiumWebElement RadioAssessorRef => GetElementByAccessibilityId("radioAssessorRef");
        public AppiumWebElement RadioRego => GetElementByAccessibilityId("radioRego");
        public AppiumWebElement RadioUwRef => GetElementByAccessibilityId("radioUWRef");
        public AppiumWebElement RadioSolicitorRef => GetElementByAccessibilityId("radioSolicitorRef");
        public AppiumWebElement RadioInjury => GetElementByAccessibilityId("radioInjury");
        public AppiumWebElement RadioPartyName => GetElementByAccessibilityId("radioPartyName");
        public AppiumWebElement CheckBoxOutstanding => GetElementByAccessibilityId("checkOutstanding");
        public AppiumWebElement CheckBoxSettled => GetElementByAccessibilityId("checkSettled");
        public AppiumWebElement ClaimNumber => GetElementByAccessibilityId("textClaimNumber");
        public AppiumWebElement ClientCode => GetElementByAccessibilityId("textClientCode");
        public AppiumWebElement LossDateFrom => GetElementByAccessibilityId("textLossDateFrom");
        public AppiumWebElement LossDateTo => GetElementByAccessibilityId("textLossDateTo");
        public AppiumWebElement SearchButton => GetElementByAccessibilityId("buttonSearch");
        public AppiumWebElement ClearButton => GetElementByAccessibilityId("buttonClear");
        public AppiumWebElement ExportButton => GetElementByAccessibilityId("buttonExport");
        public AppiumWebElement NewButton => GetElementByName("New");
        public AppiumWebElement Class => GetElementByAccessibilityId("jltaCodeTandemClass");
        public AppiumWebElement Underwriter => GetElementByAccessibilityId("jltaCodeTandemUW");
        public AppiumWebElement Operator => GetElementByAccessibilityId("jltaCodeTandemOperator");
        public AppiumWebElement DialogBox => GetElementByAccessibilityId("JibMessageBox", 5);
        public AppiumWebElement DialogBoxOkButton => GetElementByAccessibilityId("buttonOk");
        public AppiumWebElement DialogBoxText => GetElementByAccessibilityId("textBoxMessage");


        public bool SearchByClaimNumber(string claimNumber)
        {
            ClaimNumber.SetValue(claimNumber);
            SearchButton.ClickButton();
            SwitchToCurrentWindow();

            var claimScreen = new ClaimCreateNewScreen();
            return claimNumber == claimScreen.ClaimNumber.Text;
        }

        public bool SearchByJsonData(JToken testData)
        {
            ClearButton.Click();

            SetSearchValues(testData);
            SearchButton.ClickButton();

            bool expectSuccess = (bool) testData["ExpectSuccess"];

            if (DialogBox != null)
            {
                try
                {
                    if (DialogBoxText.Text.Contains("Your search criteria returned no results"))
                    {
                        return !expectSuccess;
                    }

                    if (DialogBoxText.Text.Contains("Your search criteria returned more than 1500 claims"))
                    {
                        // Consider success for now, but we can potentially introduce 3rd success/failure criteria.
                        return expectSuccess;
                    }
                }
                finally
                {
                    DialogBoxOkButton.Click();
                }
            }

            return ExportButton.Enabled == expectSuccess;
        }

        public void CreateNewClaim(JToken testData)
        {
            SwitchToCurrentWindow();
            Office.SetValue(testData["Office"].ToString());
            NewButton.ClickButton();
            SwitchToCurrentWindow();
        }

        private void SetSearchValues(JToken testData)
        {
            if (testData["Office"] != null)
            {
                Office.SetValue(testData["Office"].ToString());
            }

            if (testData["SearchText"] != null)
            {
                TextSearchFor.SetValue(testData["SearchText"].ToString());
            }

            var searchIn = testData["SearchIn"];
            if (searchIn != null)
            {
                switch (searchIn.ToString())
                {
                    case "Description":
                        RadioDescription.ClickButton();
                        break;
                    case "ClientReference":
                        RadioClientRef.ClickButton();
                        break;
                    case "AssessorReference":
                        RadioAssessorRef.ClickButton();
                        break;
                    case "Registration":
                        RadioRego.ClickButton();
                        break;
                    case "UwReference":
                        RadioUwRef.ClickButton();
                        break;
                    case "SolicitorReference":
                        RadioSolicitorRef.ClickButton();
                        break;
                    case "Injury":
                        RadioInjury.ClickButton();
                        break;
                    case "PartyName":
                        RadioPartyName.ClickButton();
                        break;
                }
            }

            if (testData["IsOutstanding"] != null &&
                !(bool)testData["IsOutstanding"]) // Outstanding is checked by default.
            {
                // Uncheck
                CheckBoxOutstanding.ClickButton();
            }

            if (testData["IsSettled"] != null &&
                (bool)testData["IsSettled"])
            {
                CheckBoxSettled.ClickButton();
            }

            if (testData["ClientCode"] != null)
            {
                ClientCode.SetValue(testData["ClientCode"].ToString());
            }

            if (testData["LossDateFrom"] != null)
            {
                LossDateFrom.SetValue(testData["LossDateFrom"].ToString());
            }

            if (testData["LossDateTo"] != null)
            {
                LossDateTo.SetValue(testData["LossDateTo"].ToString());
            }

            if (testData["Class"] != null)
            {
                Class.SetValue(testData["Class"].ToString());
            }

            if (testData["Underwriter"] != null)
            {
                Underwriter.SetValue(testData["Underwriter"].ToString());
            }

            if (testData["Operator"] != null)
            {
                Operator.SetValue(testData["Operator"].ToString());
            }
        }
    }
}
