using OpenQA.Selenium;

namespace TestSuite.PageObjects
{
    public class SecureAreaPage : Page
    {

        private readonly IWebDriver driver;

        public SecureAreaPage(IWebDriver driver) : base(driver, PageHeading.SecureArea)
        {
            this.driver = driver;
        }
    }
}
