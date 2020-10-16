using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace TestSuite.PageObjects
{
    public abstract class Page
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public Page(IWebDriver driver, String heading)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            ThenPageIsLoaded(heading);
        }

        [FindsBy(How = How.CssSelector, Using = "h2")]
        [CacheLookup]
        public IWebElement h2;

        public void ThenPageIsLoaded(String heading)
        {
            string actual = h2.GetAttribute("innerText");
            Assert.AreEqual(heading.ToString(), actual, $"Expected page: {heading}. Actual page: {actual}");
        }

        public void ThenVerifyValidationMsg(IWebElement element, string validation)
        {
            string actual = element.Text;
            Assert.IsTrue(actual.Contains(validation), $"Expected validation msg: {validation}. Actual validation is: {actual}");
        }
    }
}