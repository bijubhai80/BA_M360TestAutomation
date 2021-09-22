using ElementControl;
using M360.Pages;
using M360.Session;
using OpenQA.Selenium.Appium;

namespace M360TestAutomation.Screens.Financials
{
    public class GeneralLedgerInquiryScreen : BaseScreen
    {
        public AppiumWebElement _officeDropdown
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.M360Session,
                    WinAppDriverControlMethods.SearchBy.AccessibilityId, "comboBoxItem");
            }
        }

        public AppiumWebElement _officeCodeBox
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.M360Session,
                    WinAppDriverControlMethods.SearchBy.AccessibilityId, "textBoxCode");
            }
        }

        public AppiumWebElement _currencyCombobox
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.M360Session,
                    WinAppDriverControlMethods.SearchBy.AccessibilityId, "jltaComboBoxCurrency");
            }
        }

        public AppiumWebElement _accountSelectionButton
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.M360Session,
                    WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonAccount");
            }
        }

        public AppiumWebElement _accountCodeTextBox
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.M360Session,
                    WinAppDriverControlMethods.SearchBy.AccessibilityId, "textAccount");
            }
        }

        public AppiumWebElement _formDateTextBox
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.M360Session,
                    WinAppDriverControlMethods.SearchBy.AccessibilityId, "textDateFrom");
            }
        }

        public AppiumWebElement _toDateTextBox
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.M360Session,
                    WinAppDriverControlMethods.SearchBy.AccessibilityId, "textDateTo");
            }
        }

        public AppiumWebElement _refreshButton
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.M360Session,
                    WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonRefresh");
            }
        }

        public AppiumWebElement _convertButton
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.M360Session,
                    WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonConvert");
            }
        }

        public AppiumWebElement _detailsButton
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.M360Session,
                    WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonDetails");
            }
        }

        public AppiumWebElement _exportButton
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.M360Session,
                    WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonExportGLInquiry");
            }
        }

        public AppiumWebElement _filterCheckBox
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.M360Session,
                    WinAppDriverControlMethods.SearchBy.AccessibilityId, "checkFilter");
            }
        }

        public AppiumWebElement _closeButton
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.M360Session,
                    WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonClose");
            }
        }

    }
}
