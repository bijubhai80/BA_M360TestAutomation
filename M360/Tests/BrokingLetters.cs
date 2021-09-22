using M360.Pages;
using M360TestAutomation.Tests;
using NUnit.Framework;
using NUnitRetrying;
using NunitVideoRecorder;

namespace M360
{
    public class BrokingLetters : BaseTest
    {
        [TestCase("Create Broking Letters")]
        [Retrying(Times = 0)]
        [Video(Name = "Create Broking Letters", Mode = SaveMe.OnlyWhenFailed)]

        public static void CreateBrokingLetters(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreen = new HomeScreen();
            homeScreen.gotoMenu();
            homeScreen.gotoUtilities();
            homeScreen.gotoBrokingLetters();

            var brokingLettersScreen = new BrokingLettersScreen();
            brokingLettersScreen.CreateCofC(JSONObjects["BrokingLetters"]["CofC"]);
            brokingLettersScreen.saveCofCDocument();

        }

    }
}
