using System;
using NUnit.Framework;
using M360.Pages;
using NUnitRetrying;
using NunitVideoRecorder;
using M360TestAutomation.Tests;
using System.Configuration;
using Newtonsoft.Json.Linq;
using ElementControl;

namespace M360
{
	public class ClientTests : BaseTest
	{
		[TestCase("SearchClientByBroker", new string[] { "Broker" })]
		[TestCase("SearchClientByMarketSegment", new string[] { "Segment" })]
		[TestCase("SearchClientByDept", new string[] { "Dept" })]
		[TestCase("SearchClientByGroup", new string[] { "Group" })]
		[TestCase("SearchClientByDeptSegmentGroup", new string[] { "Dept", "Segment", "Group" })]
		[TestCase("SearchClientByCompanyNumber", new string[] { "CompanyNumber" })]
		[TestCase("SearchClientByInactive", null)]
		[Retrying(Times = 3)]
		[Video(Name = "SearchAndVerifyByExcel", Mode = SaveMe.OnlyWhenFailed)]
		public static void SearchAndVerifyByExcel(string testCaseId, string[] searchParams)
		{
			testData.testCaseId = testCaseId;
			var homeScreen = new HomeScreen();
			homeScreen.gotoClients();
			var clientSearchScreen = new ClientSearchScreen();
			switch (testCaseId)
			{
				case "SearchClientByCompanyNumber":
					clientSearchScreen.SearchClientCompany(new string[] { "CompanyNumber" }, BaseTest.JSONObjects["Clients"]["SearchByCompanyNumber"]);
					clientSearchScreen.verifyClientExcel(BaseTest.JSONObjects["Clients"]["SearchByCompanyNumber"]["CompanyNumber"].ToString());
					break;
				case "SearchClientByInactive":
					clientSearchScreen.SearchClientInactive(new string[] { "ClientName" }, BaseTest.JSONObjects["Clients"]["SearchByInactive"]);
					clientSearchScreen.verifyClientExcel(BaseTest.JSONObjects["Clients"]["SearchByInactive"]["ClientCode"].ToString());
					break;
				default:
					clientSearchScreen.searchClient(searchParams, BaseTest.JSONObjects["Clients"]["Search"]);
					clientSearchScreen.verifyClientExcel(BaseTest.JSONObjects["Clients"]["Search"]["ClientCode"].ToString());
					break;
			}			
		}
		
		[TestCase("SearchClientByName", new string[] { "ClientName" })]
		[TestCase("SearchClientByCode", new string[] { "ClientCode" })]
		[TestCase("SearchClientById", new string[] { "ID" })]
		[Retrying(Times = 3)]
		[Video(Name = "SearchAndVerifyByClientScreen", Mode = SaveMe.OnlyWhenFailed)]
		public static void SearchAndVerifyByClientScreen(string testCaseId, string[] searchParams)
		{
			testData.testCaseId = testCaseId;
			var homeScreen = new HomeScreen();
			homeScreen.gotoClients();
			var clientSearchScreen = new ClientSearchScreen();
			switch (testCaseId)
			{
				case "SearchClientById":
					clientSearchScreen.SearchClientById(searchParams, BaseTest.JSONObjects["Clients"]["Search"]);
					break;
				default:
					clientSearchScreen.searchClient(searchParams, BaseTest.JSONObjects["Clients"]["Search"]);
					break;
			}
			clientSearchScreen.verifyClientScreen(BaseTest.JSONObjects["Clients"]["Search"]["ClientCode"].ToString());
		}

		[TestCase("ReAssignClients")]
		[Retrying(Times = 3)]
		[Ignore("Cannot perform file processing - pssible bug")]
		[Video(Name = "ReAssignClients", Mode = SaveMe.OnlyWhenFailed)]
		public static void ReAssignClients(string testCaseId)
		{
			testData.testCaseId = testCaseId;
			var homeScreen = new HomeScreen();
			homeScreen.gotoClients();
			var clientSearchScreen = new ClientSearchScreen();
			clientSearchScreen.SwitchToCurrentWindow();
			clientSearchScreen.gotoReAssignClients();
			var clientReAssignScreen = new ClientReassignScreen();
			clientReAssignScreen.importExcelSpreadSheet(ConfigurationManager.AppSettings.Get("ExcelTestData").Replace("TestData.xlsx", "reAssignClient1.xlsx"));
			clientReAssignScreen.importExcelSpreadSheet(ConfigurationManager.AppSettings.Get("ExcelTestData").Replace("TestData.xlsx", "reAssignClient2.xlsx"));
		}

		[TestCase("HistoryTab")]
		[Retrying(Times = 3)]
		[Ignore("Recent updates are not appearing in History - bug")]
		[Video(Name = "HistoryTab", Mode = SaveMe.OnlyWhenFailed)]
		public static void HistoryTab(string testCaseId)
		{
			testData.testCaseId = testCaseId;			
			var homeScreen = new HomeScreen();
			homeScreen.gotoClients();
			//Client search with History
			var searchClientScreen = new ClientSearchScreen();
			var testData1 = JObject.Parse(BaseTest.JSONObjects["Policies"]["Standard"].ToString());
			var testData2 = JObject.Parse(BaseTest.JSONObjects["Policies"]["Claim"].ToString());
			testData1.Merge(testData2);
			searchClientScreen.searchClientWithHistory(testData1);
			//Update Client details
			var formClientMaintenance = new ClientNewClientScreen();
			formClientMaintenance.enableEditClient();
			var testData3 = JObject.Parse(BaseTest.JSONObjects["Clients"]["New"].ToString());
			var testData4 = JObject.Parse(BaseTest.JSONObjects["Clients"]["History"].ToString());
			testData3.Merge(testData4);
			formClientMaintenance.editClientDetails(testData3);
			//Check History Tab for any updates
			formClientMaintenance.goToHistory(testData4);
			testData3["Name"] = "New Name Test";
			formClientMaintenance.editClientDetails(testData3);
		}

		[TestCase("ProfileTab_ServiceDiary")]
		[Retrying(Times = 0)]
		[Ignore("Test still in progress")]
		[Video(Name = "ProfileTab_ServiceDiary", Mode = SaveMe.OnlyWhenFailed)]
		public static void ProfileTab_ServiceDiary(string testCaseId)
		{
			testData.testCaseId = testCaseId;
			var homescreen = new HomeScreen();
			homescreen.gotoClients();
			var clientSearchScreen = new ClientSearchScreen();
			clientSearchScreen.searchClient(new string[] { "ClientCode" }, BaseTest.JSONObjects["Clients"]["Search"]);
			clientSearchScreen.SwitchToCurrentWindow();
			var clickProfileTab = new ClientProfileScreen();
			clickProfileTab.gotoProfileTab();
			//Enable ServiceDiary Tab//
			clickProfileTab.enableDiary();
			clickProfileTab.addDiary(BaseTest.JSONObjects["Clients"]["Search"]["ServiceDiary"]);
			//Disable ServiceDiary Tab//
			//clickProfileTab.disableDiary();



		}


		[TestCase("DMGClientPolicyValidation")]
		[Retrying(Times = 3)]
		[Ignore("DMG Tests do not work on all envs")]
		[Video(Name = "DMGClientPolicyValidation", Mode = SaveMe.OnlyWhenFailed)]
		public static void DMGClientPolicyValidation(string testCaseId)
		{
			testData.testCaseId = testCaseId;
			var homeScreen = new HomeScreen();
            //Need to go to roles under security to amend the brokers roles to DMG
            homeScreen.gotoRoles();
			//Open the Roles screen
			var rolesScreen = new RolesScreen();
			//rolesScreen.gotoBroker();
			rolesScreen.selectRoles();
			homeScreen.SwitchToCurrentWindow();
			//Open client with DMG review
			homeScreen.gotoClients();
			var searchClientScreen = new ClientSearchScreen();
			var testData1 = JObject.Parse(BaseTest.JSONObjects["Clients"]["New"].ToString());
			var testData2 = JObject.Parse(BaseTest.JSONObjects["Clients"]["DMG"].ToString());
			testData1.Merge(testData2);
			searchClientScreen.searchClientWithDMGReview(testData1);
			//Open client maintenance form
			var formClientMaintenance = new ClientNewClientScreen();
			//Approve the client and verify
			formClientMaintenance.goToPolicyTab();
			formClientMaintenance.createNewPolicy();
			formClientMaintenance.validateMessage();
			formClientMaintenance.closeFormClientMaintenace();
			var backToSearchClientScreen = new ClientSearchScreen();
			var testData3 = JObject.Parse(BaseTest.JSONObjects["Clients"]["New"].ToString());
			var testData4 = JObject.Parse(BaseTest.JSONObjects["Clients"]["Edit"].ToString());
			testData3.Merge(testData4);			
			backToSearchClientScreen.searchInactiveClient(testData3);
			formClientMaintenance.goToPolicyTab();
			formClientMaintenance.createNewPolicy();			
		}

		[TestCase("DMGApproveClient")]
		[Retrying(Times = 3)]
		[Ignore("DMG Tests do not work on all envs")]
		[Video(Name = "DMGApproveClient", Mode = SaveMe.Always)]
		public static void DMGApproveClient(string testCaseId)
		{
			testData.testCaseId = testCaseId;
			var homeScreen = new HomeScreen();
			//Need to go to roles under security to amend the brokers roles to DMG
			homeScreen.gotoRoles();
			//Open the Roles screen
			var rolesScreen = new RolesScreen();
			//rolesScreen.gotoBroker();
			rolesScreen.selectRoles();
			//Open client with DMG review
			//var backToHomeScreen = new HomeScreen();
			homeScreen.SwitchToCurrentWindow();
			homeScreen.gotoClients();
			var searchClientScreen = new ClientSearchScreen();
			var testData1 = JObject.Parse(BaseTest.JSONObjects["Clients"]["New"].ToString());
			var testData2 = JObject.Parse(BaseTest.JSONObjects["Clients"]["DMG"].ToString());
			testData1.Merge(testData2);
			searchClientScreen.searchClientWithDMGReview(testData1);
			//Open client maintenance form
			var formClientMaintenance = new ClientNewClientScreen();
			//Approve the client and verify
			formClientMaintenance.approveClient();
			//Set the role back to not DMG Review
			searchClientScreen.SwitchToCurrentWindow();
			searchClientScreen.closeSearchForm();
			homeScreen.SwitchToCurrentWindow();
			homeScreen.gotoRoles();
			//rolesScreen.gotoBroker();
			rolesScreen.selectRoles();
		}

		[TestCase("DMGRejectClient")]
		[Retrying(Times = 3)]
		[Ignore("DMG Tests do not work on all envs")]
		[Video(Name = "DMGRejectClient", Mode = SaveMe.Always)]
		public static void DMGRejectClient(string testCaseId)
		{
			testData.testCaseId = testCaseId;
			var homeScreen = new HomeScreen();
			//Need to go to roles under security to amend the brokers roles to DMG
			homeScreen.gotoRoles();
			//Open the Roles screen
			var rolesScreen = new RolesScreen();
			//rolesScreen.gotoBroker();
			rolesScreen.selectRoles();
			//Open client with DMG review
			homeScreen.SwitchToCurrentWindow();
			homeScreen.gotoClients();
			var searchClientScreen = new ClientSearchScreen();
			var testData1 = JObject.Parse(BaseTest.JSONObjects["Clients"]["New"].ToString());
			var testData2 = JObject.Parse(BaseTest.JSONObjects["Clients"]["DMG"].ToString());
			testData1.Merge(testData2);
			searchClientScreen.searchClientWithDMGReview(testData1);
			//Open client maintenance form
			var formClientMaintenance = new ClientNewClientScreen();
			//Approve the client and verify
			formClientMaintenance.rejectClient();
			formClientMaintenance.verifyClientIsRejected();

		}

		[TestCase("EditClientDetails1")]
        [Retrying(Times = 3)]
        [Video(Name = "EditClientDetails1", Mode = SaveMe.OnlyWhenFailed)]
        public static void EditClientDetails1(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreen = new HomeScreen();
            homeScreen.gotoClients();
            var clientSearchScreen = new ClientSearchScreen();
            var newClientScreen = new ClientNewClientScreen();
			clientSearchScreen.searchClient(new string[] {"ClientCode" }, BaseTest.JSONObjects["Clients"]["EditDetails1"]);
			newClientScreen.DeleteClient();

			// Create the client
			clientSearchScreen.createNewClient(BaseTest.JSONObjects["Clients"]["EditDetails1"], false);

			// Enter the header details
            //newClientScreen.enterHeaderDetails(BaseTest.JSONObjects["Clients"]["EditDetails1"]);
            newClientScreen._code.SetValue(BaseTest.JSONObjects["Clients"]["EditDetails1"]["ClientCode"].ToString());
            newClientScreen._name.SetValue(BaseTest.JSONObjects["Clients"]["EditDetails1"]["Name"].ToString());
            newClientScreen._dept.SetValue(BaseTest.JSONObjects["Clients"]["EditDetails1"]["Dept"].ToString());
            newClientScreen._segment.SetValue(BaseTest.JSONObjects["Clients"]["EditDetails1"]["Segment"].ToString());
            newClientScreen._sic.SetValue(BaseTest.JSONObjects["Clients"]["EditDetails1"]["SIC"].ToString());

			// Enter the details 1 tab data.
			var details1Screen = new ClientDetails1();
            details1Screen.enterDetails1(BaseTest.JSONObjects["Clients"]["EditDetails1"]["Details1A"]);

			// Save the client.
            newClientScreen.save();
            newClientScreen.closeClientScreen();

			clientSearchScreen.searchClient(new[] { "ClientCode" }, JSONObjects["Clients"]["EditDetails1"], switchWindow: false);
			details1Screen.SwitchToCurrentWindow();
			details1Screen.enterDetails1(BaseTest.JSONObjects["Clients"]["EditDetails1"]["Details1B"]);
            newClientScreen.save();

			// Verify then delete the client.
			details1Screen.verifyDetails1(BaseTest.JSONObjects["Clients"]["EditDetails1"]["Details1B"]);
			newClientScreen.DeleteClient();
        }

        [TestCase("EditClientDetails2")]
        [Retrying(Times = 3)]
        [Video(Name = "EditClientDetails2", Mode = SaveMe.OnlyWhenFailed)]
        public static void EditClientDetails2(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreen = new HomeScreen();
            homeScreen.gotoClients();
			var clientSearchScreen = new ClientSearchScreen();
			var newClientScreen = new ClientNewClientScreen();
			clientSearchScreen.searchClient(new string[] { "ClientCode" }, BaseTest.JSONObjects["Clients"]["New2"]);
			newClientScreen.DeleteClient();
			clientSearchScreen.createNewClient(JSONObjects["Clients"]["New2"], false);
            newClientScreen.enterHeaderDetails(JSONObjects["Clients"]["New2"]);
            newClientScreen.save();
            newClientScreen.close();
            clientSearchScreen.searchClient(new[] { "ClientCode" }, JSONObjects["Clients"]["New2"]);			
			
			////edit client
			newClientScreen.enableEditClient();
            var details2Screen = new ClientDetails2();
            details2Screen.GotoDetails2Tab();
            details2Screen.EnterDetails2(JSONObjects["Clients"]["Edit2"]);
            newClientScreen.save();
            newClientScreen.close();

            clientSearchScreen.searchClient(new[] { "ClientCode" }, JSONObjects["Clients"]["New2"]);
            newClientScreen.SwitchToCurrentWindow();
			details2Screen.GotoDetails2Tab();
			// verify new details updated
			details2Screen.VerifyDetails2(JSONObjects["Clients"]["Edit2"]);
            newClientScreen.DeleteClient();
        }

		[TestCase("CurrentStatementTab")]
		[Retrying(Times = 3)]
		[Video(Name = "CurrentStatementTab", Mode = SaveMe.OnlyWhenFailed)]
		public static void CurrentStatementTab(string testCaseId)
		{
			testData.testCaseId = testCaseId;
			var homescreen = new HomeScreen();
			homescreen.gotoClients();
			var clientSearchScreen = new ClientSearchScreen();
			clientSearchScreen.searchClient(new string[] { "ClientCode" }, BaseTest.JSONObjects["Clients"]["Search"]);
			clientSearchScreen.SwitchToCurrentWindow();
			var clientstatement = new ClientCurrentStatement();
			clientstatement.goToFinancialstab();
			clientstatement.goToCurrentStatementtab();
			clientstatement.selectTransaction();			
			clientstatement.clickDetails();
			clientstatement.SwitchToCurrentWindow();
			clientstatement.clickFeeInvoice();
			clientstatement.SwitchToCurrentWindow();
			clientstatement.clickledger();
			clientstatement.SwitchToCurrentWindow();
			clientstatement.changeCurrency();
		}
		
		[TestCase("EditClientAction")]
        [Retrying(Times = 3)]
		[Ignore("Action creation syas operation could not be completed")]
		[Video(Name = "EditClientAction", Mode = SaveMe.OnlyWhenFailed)]
        public static void EditClientAction(string testCaseId)
        {
            testData.testCaseId = testCaseId;
            var homeScreen = new HomeScreen();
            homeScreen.gotoClients();

            var clientSearchScreen = new ClientSearchScreen();
            clientSearchScreen.searchClient(new string[] { "ClientCode" }, BaseTest.JSONObjects["Clients"]["Search"]);

            // Create a new Action by pressing the New button
            // Select the Action Type as Call and add further details and save and they are successfully saved in the database.

            var newClientScreen = new ClientNewClientScreen();
            newClientScreen.SwitchToCurrentWindow();
            newClientScreen.createDiaryAction();
            var diaryClientScreen = new ClientActionScreen();
            diaryClientScreen.createAction();

            // Edit the action that was created just now and verify the edit is applied after save
            newClientScreen.editDiaryAction();
            diaryClientScreen.editAction();
            diaryClientScreen.verifyAction();

            // Delete the action that was created
            newClientScreen.deleteDiaryAction();
        }

		/// <summary>
		/// 1. Change team of client where jbs_team.marsh_force_enabled_yn=N to team where jbs_team.marsh_force_enabled_yn=Y, Save it.
		///    Confirm that company number is mandatory field for client where jbs_team.marsh_force_enabled_yn=Y.
		///    Once client it saved, Submitted for review text, displayed on client maintenance,
		///    Client is set as inactive
		/// TODO: 2. Change name(name_1/name_2) of client where jbs_team.marsh_force_enabled_yn=Y
		///    Once client it saved, Submitted for review text, displayed on client maintenance,
		///    Client is set as inactive
		/// TODO: 3. Change address of client where jbs_team.marsh_force_enabled_yn= Y
		///    Address(line-line4/state/postal code)
		///    If any of above field from address is modified, for review text,
		///    displayed on client maintenance,
		///    Client is set as inactive on Save
		/// TODO: 4. Change ABN where jbs_team.marsh_force_enabled_yn=Y
		///    Once client it saved, Submitted for review text, displayed on client maintenance,
		///    Client is set as inactive
		/// </summary>
		/// <param name="testCaseId"></param>
		[TestCase("MarshForceTest")]
		[Retrying(Times = 3)]
		[Ignore("DMG Label is not applied - possible data is outdated")]
		[Video(Name = "MarshForceTest", Mode = SaveMe.OnlyWhenFailed)]
		public static void MarshForceTest(string testCaseId)
		{
            testData.testCaseId = testCaseId;
            var homeScreen = new HomeScreen();
            homeScreen.gotoClients();
            var clientSearchScreen = new ClientSearchScreen();
            clientSearchScreen.createNewClient(JSONObjects["Clients"]["New3"]);
            var newClientScreen = new ClientNewClientScreen();
            newClientScreen.enterHeaderDetails(JSONObjects["Clients"]["New3"]);
            newClientScreen._name.SetValue($"{JSONObjects["Clients"]["New3"]["Name"]} {DateTime.Now:G}");
			newClientScreen.save();
			newClientScreen.close();
            clientSearchScreen.searchClient(new[] { "ClientCode" }, JSONObjects["Clients"]["New3"]);

			////edit client
			newClientScreen.enableEditClient();
			newClientScreen._dept.ClickButton();
            Session.Session.M360Session.FindElementByName(JSONObjects["Clients"]["Edit3"]["Dept"].ToString()).Click();
            //System.Threading.Thread.Sleep(5000);
 			if (newClientScreen.DialogBox != null)
            {
				if (newClientScreen.DialogBoxText.Text.Contains("The market segment is not valid for that dept."))
                {
                    newClientScreen.DialogBoxOkButton.Click();
                }
            }
            newClientScreen._segment.ClickButton();
            Session.Session.M360Session.FindElementByName(JSONObjects["Clients"]["Edit3"]["Segment"].ToString()).Click();
            newClientScreen._sic.ClickButton();
            Session.Session.M360Session.FindElementByName(JSONObjects["Clients"]["Edit3"]["SIC"].ToString()).Click();
			Assert.AreEqual(newClientScreen.DmgLabel, null);
            newClientScreen.save();
            if (newClientScreen.DialogBox != null)
            {
                if (newClientScreen.DialogBoxText.Text.Contains("The client must have a company #."))
                {
                    newClientScreen.DialogBoxOkButton.Click();
				}
            }
            newClientScreen._company.SetValue(JSONObjects["Clients"]["Edit3"]["Company"].ToString());
			newClientScreen.save();
			Assert.AreEqual(newClientScreen.DmgLabel.Text, "Pending DMG Review");
            newClientScreen.DeleteClient();

		}


        [TestCase("InsertClientProfile")]
        [Retrying(Times = 3)]
        [Video(Name = "InsertClientProfile", Mode = SaveMe.OnlyWhenFailed)]
        public static void InsertClientProfile(string testCaseId)
        {
	        testData.testCaseId = testCaseId;
	        
	        var homeScreen = new HomeScreen();
	        homeScreen.gotoClients();

	        var clientSearchScreen = new ClientSearchScreen();
	        clientSearchScreen.searchClient(new string[] {"ClientCode"}, 
		    BaseTest.JSONObjects["Clients"]["InsertClientProfile"]);
	        clientSearchScreen.SwitchToCurrentWindow();

	        var clientProfileTab = new ClientProfileScreen();
	        clientProfileTab._edit.Click();

	        if (clientProfileTab._insert == null)
	        {
		        // This test is supposed to be for adding a profile to a client that doesn't have one. 
				// Because these tests will be run regularly the client will end up having a profile.
				// If the insert button doesn't exist then the client has a profile now. Remove the profile first
				// so we can test adding a profile.
		        clientProfileTab.RemoveProfile();
	        }

	        clientProfileTab.InsertProfile(BaseTest.JSONObjects["Clients"]["InsertClientProfile"]);

	        clientProfileTab._save.Click();
			// Note: sometimes I thought there was a yes/no dialog.
	        clientProfileTab._close.Click();

	        clientSearchScreen.searchClient(new string[] {"ClientCode"},
		    BaseTest.JSONObjects["Clients"]["InsertClientProfile"]);

	        clientSearchScreen.SwitchToCurrentWindow();
	        clientProfileTab = new ClientProfileScreen();

			// The absence of the insert button indicates that the client has a profile.
	        Assert.IsTrue(clientProfileTab._insert == null);
        }
	}
}
