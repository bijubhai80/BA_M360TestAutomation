using M360.Pages;
using M360TestAutomation.Tests;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NunitVideoRecorder;

namespace M360
{
    public class ClaimsTest : BaseTest
    {
        [TestCase("SearchClaimByClaimNumber")]
        [Video(Name = "SearchClaimByClaimNumber", Mode = SaveMe.OnlyWhenFailed)]
        public static void SearchAndVerifyByClaimScreen(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreenPage = new HomeScreen();
            homeScreenPage.gotoClaims();

            var claimSearchScreen = new ClaimSearchScreen();
            claimSearchScreen.CreateNewClaim(JSONObjects["Claims"]["New"]);

            var claimCreateScreen = new ClaimCreateNewScreen();
            string newClaimNumber = claimCreateScreen.CreateNewClaim(JSONObjects["Claims"]["New"]);

            bool isFound = claimSearchScreen.SearchByClaimNumber(newClaimNumber);
            Assert.IsTrue(isFound);
        }

        [TestCase("SearchClaimByJsonData")]
        [Video(Name = "SearchClaimByJsonData", Mode = SaveMe.OnlyWhenFailed)]
        public static void SearchAndVerifyByResultGrid(string testCaseId)
        {
            var homeScreenPage = new HomeScreen();
            homeScreenPage.gotoClaims();

            var claimSearchScreen = new ClaimSearchScreen();
            claimSearchScreen.SwitchToCurrentWindow();

            foreach (var testCase in (JArray)JSONObjects["Claims"]["Search"])
            {
                bool result = claimSearchScreen.SearchByJsonData(testCase);
                Assert.IsTrue(result);
            }
        }
    }
}
