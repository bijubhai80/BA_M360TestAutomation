using M360.Pages;
using M360TestAutomation.Screens.DocumentMaintenance;
using M360TestAutomation.Tests;
using NUnit.Framework;
using NUnitRetrying;
using NunitVideoRecorder;

namespace M360
{
    public class DocumentMaintainence : BaseTest
    {
        [TestCase("SearchByClass", new string[] { "ElementClass" })]
        [TestCase("SearchByElementType", new string[] { "ElementTypeText" })]
        [TestCase("SearchByDescription", new string[] { "ElementDescription" })]
        [TestCase("SearchByOffice", new string[] { "Office" })]
        [TestCase("SearchBySegment", new string[] { "Segment" })]
        //[TestCase("SearchByInactive",null)]
        [Retrying(Times = 3)]
        [Video(Name = "SearchAndVerify", Mode = SaveMe.OnlyWhenFailed)]
        public static void Search_TextElement(string testCaseId, string[] searchParams)
        {
            testData.testCaseId = testCaseId;
            var homeScreenPage = new HomeScreen();
            homeScreenPage.gotoMenu();
            homeScreenPage.gotoUtilities();
            homeScreenPage.gotoDocumentMaintenance();
            homeScreenPage.gotoTextElement();
            var textElement = new TextElement();
            /* switch (testCaseId)
             {
                 case "SearchByClass":
                     textElement.SearchByClass(BaseTest.JSONObjects["DocumentMaintainence"]["TextElement"]["Document"]);
                     break;
                 case "SearchByElementType":
                     textElement.SearchByElementType(BaseTest.JSONObjects["DocumentMaintainence"]["TextElement"]["Document"]);
                     break;
                 case "SearchByDescription":
                     textElement.SearchByDescription(BaseTest.JSONObjects["DocumentMaintainence"]["TextElement"]["Document"]);
                     break;
                 case "SearchByOffice":
                     textElement.SearchByOffice(BaseTest.JSONObjects["DocumentMaintainence"]["TextElement"]["Document"]);
                     break;
                 case "SearchByInactive":
                     textElement.SearchByInactive(BaseTest.JSONObjects["DocumentMaintainence"]["TextElement"]["Document"]);
                     break;                     
                 case "SearchBySegment":
                     textElement.SearchBySegment(BaseTest.JSONObjects["DocumentMaintainence"]["TextElement"]["Document"]);
                     break;
                default:
                     textElement.SearchByClassTypeDescription(BaseTest.JSONObjects["DocumentMaintainence"]["TextElement"]["Document"]);
                     break;
             }*/

        }

        [TestCase("Search_View_TextElements_AllTypes")]
        [Retrying(Times = 3)]
        [Ignore("Test not working")]
        [Video(Name = "Search_View_TextElements_AllTypes", Mode = SaveMe.OnlyWhenFailed)]
        public static void Search_View_TextElements_AllTypes(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreenPage = new HomeScreen();
            homeScreenPage.gotoMenu();
            homeScreenPage.gotoUtilities();
            homeScreenPage.gotoDocumentMaintenance();
            homeScreenPage.gotoTextElement();

            var textElement = new TextElement();
            //Search Text Element of type "Document"//
            textElement.SearchByClassTypeDescription(BaseTest.JSONObjects["DocumentMaintainence"]["TextElement"]["Document"]);
            homeScreenPage.SwitchToCurrentWindow();

            homeScreenPage.gotoMenu();
            homeScreenPage.gotoUtilities();
            homeScreenPage.gotoDocumentMaintenance();
            homeScreenPage.gotoTextElement();

            textElement.SearchByClassTypeDescription(BaseTest.JSONObjects["DocumentMaintainence"]["TextElement"]["Component"]);
            homeScreenPage.SwitchToCurrentWindow();

            homeScreenPage.gotoMenu();
            homeScreenPage.gotoUtilities();
            homeScreenPage.gotoDocumentMaintenance();
            homeScreenPage.gotoTextElement();

            textElement.SearchByClassTypeDescription(BaseTest.JSONObjects["DocumentMaintainence"]["TextElement"]["Profile"]);
            homeScreenPage.SwitchToCurrentWindow();
        }


        [TestCase("TextElement_Rules")]
        [Retrying(Times = 3)]
        [Ignore("Test not working")]
        [Video(Name = "TextElement_Rules", Mode = SaveMe.OnlyWhenFailed)]
        public static void TextElement_Rules(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            // Utilities->Document Maintenance->Text Element->Utilities :GoToRules
            var homeScreenPage = new HomeScreen();
            homeScreenPage.gotoMenu();
            homeScreenPage.gotoUtilities();
            homeScreenPage.gotoDocumentMaintenance();
            homeScreenPage.gotoTextElement();

            var textElement = new TextElement();
            textElement.gotoRules();

            //  Details Button: View rule details
            var textElementRules = new TextElementRules();
            textElementRules.SeeDetails();

            var textElementRule1 = new TextElementRule();
            textElementRule1.closeDetails();

            // Add Button:Add new Rule
            textElementRules.AddNewRule();

            var textElementRule2 = new TextElementRule();
            textElementRule2.addNewRule();

            // Remove Button : Remove newly added Rule
            textElementRules.RemoveRule();

            // Export Rules to excel
            textElementRules.exportRules();
            textElementRules.closeRules();
        }

        [TestCase("CreateNewRelease_Component")]
        [Retrying(Times = 3)]
        //[Ignore("Test not working")]
        [Video(Name = "CreateNewRelease_Component", Mode = SaveMe.OnlyWhenFailed)]
        public static void CreateNewRelease_Component(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreenPage = new HomeScreen();
            homeScreenPage.gotoMenu();
            homeScreenPage.gotoUtilities();
            homeScreenPage.gotoDocumentMaintenance();
            homeScreenPage.gotoTextElement();
            var textElement = new TextElement();
            textElement.SearchComponent(BaseTest.JSONObjects["DocumentMaintainence"]["TextElement"]["Component"]);
            textElement.ViewDetails(BaseTest.JSONObjects["DocumentMaintainence"]["TextElement"]["Component"]);
            textElement.CreateNewRelease(BaseTest.JSONObjects["DocumentMaintainence"]["TextElement"]["Component"]);
            homeScreenPage.SwitchToCurrentWindow();

        }

        [TestCase("CreateNewRelease_Profile")]
        [Retrying(Times = 3)]
        [Ignore("Test not working")]
        [Video(Name = "CreateNewRelease_Profile", Mode = SaveMe.OnlyWhenFailed)]
        public static void CreateNewRelease_Profile(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreenPage = new HomeScreen();
            homeScreenPage.gotoMenu();
            homeScreenPage.gotoUtilities();
            homeScreenPage.gotoDocumentMaintenance();
            homeScreenPage.gotoTextElement();
            var textElement = new TextElement();
            textElement.SearchComponent(BaseTest.JSONObjects["DocumentMaintainence"]["TextElement"]["Profile"]);
            textElement.ViewDetails(BaseTest.JSONObjects["DocumentMaintainence"]["TextElement"]["Profile"]);
            textElement.NewRelease_Profile(BaseTest.JSONObjects["DocumentMaintainence"]["TextElement"]["Profile"]);
            homeScreenPage.SwitchToCurrentWindow();
        }

        [TestCase("CreateNewRelease_Document")]
        [Retrying(Times = 3)]
        [Ignore("Test not working")]
        [Video(Name = "CreateNewRelease_Document", Mode = SaveMe.OnlyWhenFailed)]
        public static void CreateNewRelease_Document(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreenPage = new HomeScreen();
            homeScreenPage.gotoMenu();
            homeScreenPage.gotoUtilities();
            homeScreenPage.gotoDocumentMaintenance();
            homeScreenPage.gotoTextElement();
            var textElement = new TextElement();
            textElement.SearchComponent(BaseTest.JSONObjects["DocumentMaintainence"]["TextElement"]["Document"]);
            textElement.ViewDetails(BaseTest.JSONObjects["DocumentMaintainence"]["TextElement"]["Document"]);
            textElement.CreateNewRelease(BaseTest.JSONObjects["DocumentMaintainence"]["TextElement"]["Document"]);

            homeScreenPage.SwitchToCurrentWindow();

        }

        //[TestCase("Clone_ExistingElement")]
        //[Retrying(Times = 1)]
        //[Ignore("Test not working")]
        //[Video(Name = "Clone_ExistingElement", Mode = SaveMe.OnlyWhenFailed)]
        //public static void Clone_ExistingElement(string testCaseId)
        //{
        //    testData.testCaseId = testCaseId;
        //    var homeScreenPage = new HomeScreen();
        //    homeScreenPage.gotoMenu();
        //    homeScreenPage.gotoUtilities();
        //    homeScreenPage.gotoDocumentMaintenance();
        //    homeScreenPage.gotoTextElement();

        //    var textElement = new TextElement();
        //    textElement.SearchComponent(BaseTest.JSONObjects["DocumentMaintainence"]["TextElement"]["Component"]);
        //    textElement.ViewDetails(BaseTest.JSONObjects["DocumentMaintainence"]["TextElement"]["Component"]);
        //    textElement.CloneElement(BaseTest.JSONObjects["DocumentMaintainence"]["TextElement"]["Component"]);
        //    //textElement
        //    homeScreenPage.SwitchToCurrentWindow();
        //}


        [TestCase("TextElement_Types")]
        [Retrying(Times = 3)]

        [Video(Name = "TextElement_Types", Mode = SaveMe.OnlyWhenFailed)]
        public static void TextElement_Types(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            // Utilities->Document Maintenance->Text Element->Utilities :Element Types
            var homeScreenPage = new HomeScreen();
            homeScreenPage.gotoMenu();
            homeScreenPage.gotoUtilities();
            homeScreenPage.gotoDocumentMaintenance();
            homeScreenPage.gotoTextElement();

            var textElement = new TextElement();
            textElement.gotoElementTypes();

            //  Details Button : View element type details
            var textElementTypes = new TextElementTypes();
            textElementTypes.seeDetails();
            textElementTypes.closeDetails();

            // Add Button:Add new element type
            textElementTypes.addTextElementType("Test", "This is a test");

            // Remove Button:remove newly added element type
            textElementTypes.removeSelectedElementType();

            // Export Rules to excel
            textElementTypes.exportRules();
            textElementTypes.closeRules();
        }
    }
}
