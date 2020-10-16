using NUnit.Framework;
using OpenQA.Selenium;
using TestSuite.SetUp;

namespace TestSuite
{
    /// <summary>
    /// This will Setup a driver instance at the start of each Fixture.
    /// NUnit does this because the name space of this class is the highest therefore all tests fall under it.
    /// </summary>
    [SetUpFixture]
    public class DriverSetup
    {
        internal static IWebDriver Driver;

        [OneTimeSetUp]
        public void StartTestServer()
        {
            Driver = new TestDriverFactory().CreateDriver();
        }

        [OneTimeTearDown]
        public void StopTestServer()
        {
            Driver.Quit();
        }
    }
}

