using DriverFactory.Configurations;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;

namespace DriverFactory.Common
{
    public class IDriverFactory
    {
        private IWebDriver driver;

        public IWebDriver InitBrowser(LocalDriverConfiguration configuration)
        {
            IWebDriver driver = null;

            switch (configuration.Browser)
            {
                case "FIREFOX":
                    FirefoxOptions fOptions = new FirefoxOptions();
                    fOptions.AddArguments("platform", "LINUX");
                    fOptions.AddArguments("version", "66");

                    driver = new FirefoxDriver(fOptions);
                    break;

                case "CHROME":
                    ChromeOptions cOptions = new ChromeOptions();
                    cOptions.AddArguments("--headless");

                    driver = new ChromeDriver(cOptions);
                    break;
            }
            return driver;
        }

        /// <summary>
        /// This method will create a remotedriver, as it takes the RemoteDriver configuation object
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public IWebDriver InitBrowser(RemoteDriverConfiguration configuration)
        {
            var remoteServer = BuildRemoteServer(configuration.SeleniumHubUrl, configuration.SeleniumHubPort);
            var remoteChromeOptions = new ChromeOptions();

            switch (configuration.Browser)
            {
                case "chrome":
                    remoteChromeOptions.PlatformName = configuration.Platform;
                    remoteChromeOptions.BrowserVersion = configuration.BrowserVersion;

                    driver = new RemoteWebDriver(new Uri(remoteServer), remoteChromeOptions);
                    break;

                case "firefox":
                    //TBC
                    break;
            }

            return driver;
        }

        /// <summary>
        /// Build a Uri for your GRID Hub instance
        /// </summary>
        /// <param name="remoteServer">The hostname or IP address of your GRID instance, include the http://</param>
        /// <param name="remoteServerPort">Port of your GRID Hub instance</param>
        /// <returns>The correct Uri as a string</returns>
        private static string BuildRemoteServer(string remoteServer, int remoteServerPort)
        {
            return string.Format("{0}:{1}/wd/hub", remoteServer, remoteServerPort);
        }
    }
}
