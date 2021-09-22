using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElementControl;
using Log;
using M360.Pages;
using M360.Session;
using M360TestAutomation.Screens.UserScreens;
using M360TestAutomation.Tests;
using NUnit.Framework;
using NUnitRetrying;
using NunitVideoRecorder;

namespace M360
{
    public class UserTest : BaseTest
    {
        [TestCase("TestToggleDmgReviewRole")]
        [Retrying(Times = 3)]
        [Ignore("Test Not Working")]
        [Video(Name = "TestToggleDmgReviewRole", Mode = SaveMe.OnlyWhenFailed)]
        public void TestToggleDmgReviewRole(string testCaseId)
        {
            FileLogger.Instance.Configure();
            testData.testCaseId = testCaseId;
            ToggleRoleDmgReviewClients();
        }

        public static void ToggleRoleDmgReviewClients()
        {
            var homeScreen = new HomeScreen();
            homeScreen._menu.ClickButton();
            homeScreen._utilities.ClickButton();
            homeScreen._security.ClickButton();
            homeScreen._users.ClickButton();
            var userSearchScreen = new UserSearchScreen();
            userSearchScreen.SearchUser(homeScreen.Username);
            var userScreen = new UserScreen();
            userScreen.ToggleRole("_DMG Review Clients");
            userScreen.Save();
            userScreen.CloseScreen();
            userSearchScreen.SwitchToCurrentWindow();
            userSearchScreen.ButtonClose.ClickButton();
        }
    }
}
