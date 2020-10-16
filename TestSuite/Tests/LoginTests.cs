using NUnit.Framework;
using OpenQA.Selenium;
using System.Configuration;
using TestSuite.Model;
using TestSuite.PageObjects;
using TestSuite.SetUp;

namespace TestSuite.Tests
{
    [TestFixture]
    public class LoginTests
    {
        private IWebDriver driver;
        protected HomePage hp;
        protected LoginPage lp;

        [SetUp]
        public void SetUp()
        {
            driver = DriverSetup.Driver;
            driver.Navigate().GoToUrl(TestConfiguration.ApplicationUrl);

            hp = new HomePage(driver);
            lp = hp.WhenBasicAuthLnkClicked();
        }

        [Test(Description = "Login with valid user")]
        public void LoginWithValidUser()
        {
            User user = new UserBuilder()
                    .Username(ConfigurationManager.AppSettings["Username"])
                    .Password(ConfigurationManager.AppSettings["Password"])
                    .Build();

            SecureAreaPage sap = lp.WhenLoginWith(user);
        }

        [Test(Description = "Login with invalid username")]
        public void LoginWithInvalidUsername()
        {
            User user = new UserBuilder()
                    .Username("")
                    .Password("")
                    .Build();

            lp.WhenLoginValidationWith(user, LoginPage.invalidUsernameValidation);
        }

        [Test(Description = "Login with invalid password")]
        public void LoginWithInvalidPassword()
        {
            User user = new UserBuilder()
                    .Username("tomsmith")
                    .Password("")
                    .Build();

            lp.WhenLoginValidationWith(user, LoginPage.invalidPasswordValidation);
        }
    }
}
