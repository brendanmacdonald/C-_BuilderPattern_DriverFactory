using OpenQA.Selenium;

namespace DriverFactory.Configurations
{
    /// <summary>
    /// A RemoteDriverConfiguration class
    /// Used to construct driver requirements to send to the GRID Hub
    /// </summary>
    public class RemoteDriverConfiguration
    {
        public string Browser { get; set; }

        public string Platform { get; set; }

        public string BrowserVersion { get; set; }

        public string SeleniumHubUrl { get; set; }

        public int SeleniumHubPort { get; set; }

        public RemoteDriverConfiguration(string browser, string platform, string browserVersion, string seleniumHubUrl, int seleniumHubPort)
        {
            Browser = browser;
            Platform = platform;
            BrowserVersion = browserVersion;
            SeleniumHubUrl = seleniumHubUrl;
            SeleniumHubPort = seleniumHubPort;
        }
    }
}

