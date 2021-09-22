using ElementControl;
using OpenQA.Selenium.Appium;

namespace M360.Pages
{
    public class ClientPopUpMessage : BaseScreen
    {
        public AppiumWebElement _ok
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "buttonOk");
            }
        }
        public AppiumWebElement _clientManageWarningMessageBox
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "JibMessageBox");
            }
        }
        public AppiumWebElement _textBoxMessage
        {
            get
            {
                return WinAppDriverControlMethods.GetElement(Session.Session.M360Session, WinAppDriverControlMethods.SearchBy.AccessibilityId, "textBoxMessage");
            }
        }


        /*  public void validateMessage(JToken TestData)
          {
              // wait.Until(driver => { return _textBoxMessage.Displayed && _textBoxMessage.Text == "Cannot proceed. Client is awaiting DMG approval."; });
              var textMessage = _textBoxMessage.Text;
              if (textMessage == TextMesssage(TestData["Message"].ToString())) ;
              _ok.ClickButton();
          }*/
    }
}
