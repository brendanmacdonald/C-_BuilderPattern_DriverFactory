using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestSuite.PageObjects
{
    public class HomePage : Page
    {
        //public static string url = "https://the-internet.herokuapp.com";
        private readonly IWebDriver driver;

        [FindsBy(How = How.LinkText, Using = "Form Authentication")]
        [CacheLookup]
        public IWebElement formAuthenticationLnk;

        public HomePage(IWebDriver driver) : base(driver, PageHeading.HomePage)
        {
            this.driver = driver;
        }

        public LoginPage WhenBasicAuthLnkClicked()
        {
            formAuthenticationLnk.Click();
            return new LoginPage(driver);
        }
    }
}
