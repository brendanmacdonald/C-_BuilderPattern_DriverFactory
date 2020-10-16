using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestSuite.Model;

namespace TestSuite.PageObjects
{
    public class LoginPage : Page
    {

        private readonly IWebDriver driver;
        //private static readonly string url = "/login";
        public static string invalidUsernameValidation = "Your username is invalid!";
        public static string invalidPasswordValidation = "Your password is invalid!";

        public LoginPage(IWebDriver driver) : base(driver, PageHeading.LoginPage)
        {
            this.driver = driver;
        }

        [FindsBy(How = How.Id, Using = "username")]
        [CacheLookup]
        public IWebElement usernameTxt;

        [FindsBy(How = How.Id, Using = "password")]
        [CacheLookup]
        public IWebElement passwordTxt;

        [FindsBy(How = How.ClassName, Using = "radius")]
        [CacheLookup]
        public IWebElement loginBtn;

        [FindsBy(How = How.Id, Using = "flash")]
        [CacheLookup]
        public IWebElement flashMsg;

        public SecureAreaPage WhenLoginWith(User user)
        {
            usernameTxt.SendKeys(user.username);
            passwordTxt.SendKeys(user.password);
            loginBtn.Click();
            return new SecureAreaPage(driver);
        }

        public void WhenLoginValidationWith(User user, string validation)
        {
            usernameTxt.SendKeys(user.username);
            passwordTxt.SendKeys(user.password);
            loginBtn.Click();
            ThenVerifyValidationMsg(flashMsg, validation);
        }
    }
}
