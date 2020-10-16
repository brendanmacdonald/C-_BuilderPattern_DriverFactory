using DriverFactory.Common;
using DriverFactory.Configurations;
using OpenQA.Selenium;

namespace TestSuite.SetUp
{
    public class TestDriverFactory
    {
        public IWebDriver CreateDriver()
        {
            //If remote is true, then create a RemoteDriverConfig and pass it to the factory
            if (TestConfiguration.Remote)
            {
                return new IDriverFactory().InitBrowser(
                    new RemoteDriverConfiguration(
                            TestConfiguration.Browser,
                            TestConfiguration.Platform,
                            TestConfiguration.BrowserVersion,
                            TestConfiguration.SeleniumHubUrl,
                            TestConfiguration.SeleniumHubPort));
            }

            //Else (false) create a LocalDriverConfig and pass this to the factory
            return new IDriverFactory().InitBrowser(
                new LocalDriverConfiguration(
                    TestConfiguration.Browser));
        }

    }
}

