using ElementControl;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Appium;

namespace M360.Pages
{
    public class AuthorisePaymentsScreen : BaseScreen
    {
        public AppiumWebElement _officeEllipses
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_ellipsisBranches");
            }
        }

        public AppiumWebElement _office
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.XPath, "//TreeItem[@Name='Benefit Solutions (Company)']");
            }
        }
        public AppiumWebElement _ouBtnAll
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonAll");
            }
        }

        public AppiumWebElement _ouBtnOk
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonOK");
            }
        }

        public AppiumWebElement _comboLedger
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_comboBoxLedger");
            }
        }

        public AppiumWebElement _comboCurrency
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_comboBoxCurrency");
            }
        }
        public AppiumWebElement _btnSearch
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_buttonSearch");
            }
        }

        public AppiumWebElement _paymentTypeEllipses
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_ellipsisPaymentTypes");
            }
        }


        public AppiumWebElement _paymentBtnAll
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonSelectAll");
            }
        }


        public AppiumWebElement _paymentBtnOk
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonClose");
            }
        }

        public AppiumWebElement _fromTransDate
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_textBoxDateFrom");
            }
        }

        public AppiumWebElement _scrollUp
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "UpButton");
            }
        }
        public AppiumWebElement _statusEllipsis
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_ellipsisStatus");
            }
        }
        public AppiumWebElement _statusBtnAll
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonSelectAll");
            }
        }
        public AppiumWebElement _statusBtnClose
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonClose");
            }
        }

        public AppiumWebElement _btnAuthorise
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_buttonAuthorise");
            }
        }
        public AppiumWebElement _txtBoxPassword
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_textBoxPassword");
            }
        }
        public AppiumWebElement _btnOK
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_buttonOK");
            }
        }
        public AppiumWebElement _btnReview
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_buttonReview");
            }
        }
        public AppiumWebElement _btnReviewAll
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_buttonReviewAll");
            }
        }

        public AppiumWebElement _btnUnReviewAll
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_buttonUnreviewAll");
            }
        }

        public AppiumWebElement _btnPaymentDetails
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_buttonDetails");
            }
        }


        public AppiumWebElement _btnSave
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "_buttonSave");
            }
        }

        public void searchAuthorisePayment(JToken testData)
        {
            _officeEllipses.ClickButton();
            _ouBtnAll.Click();
            _ouBtnOk.Click();
            _comboLedger.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["LedgerType"].ToString()).Click();
            _comboCurrency.ClickButton();
            Session.Session.M360Session.FindElementByName(testData["Currency"].ToString()).Click();
            _paymentTypeEllipses.ClickButton();
            _paymentBtnAll.Click();
            _paymentBtnOk.Click();
            _statusEllipsis.Click();
            _statusBtnAll.Click();
            _statusBtnClose.Click();
            _fromTransDate.SetValue(testData["FromTransDate"].ToString());
            _btnSearch.Click();
            SyncFusionGrid.ClickCell(0, 0);
            //Details_Payment(testData);
            //Review_Payment(testData);
            Authorise_Payment(testData);
        }
        public void Authorise_Payment(JToken testData)
        {
            //searchAuthorisePayment(testData);
            _btnAuthorise.ClickButton();
            _txtBoxPassword.SetValue(testData["UserPassword"].ToString());
            _btnOK.ClickButton();
        }
        public void Review_Payment(JToken testData)
        {
            searchAuthorisePayment(testData);
            _btnReview.ClickButton();
            _btnReviewAll.ClickButton();
            _btnSave.ClickButton();
        }
        public void Details_Payment(JToken testData)
        {
            _btnPaymentDetails.ClickButton();
            //_btnPaymentClose.ClickButton();

        }


    }
}





