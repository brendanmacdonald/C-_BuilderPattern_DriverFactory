using System.Configuration;

namespace TestSuite.SetUp
{
    public class TestConfiguration
    {
        public static bool Remote { get; set; }
        public static string Browser { get; set; }
        public static string Platform { get; set; }
        public static string BrowserVersion { get; set; }
        public static string SeleniumHubUrl { get; set; }
        public static int SeleniumHubPort { get; set; }
        public static string ApplicationUrl { get; set; }

        //Because this is static it will be executed at the start of any test run.
        //Reads the keys from the app.config and assigns them to the properties declared above.
        static TestConfiguration()
        {
            var reader = new AppSettingsReader();

            Remote = (bool)reader.GetValue("Remote", typeof(bool));

            Browser = (string)reader.GetValue("Browser", typeof(string));

            if (Remote)
            {
                BrowserVersion = (string)reader.GetValue("BrowserVersion", typeof(string));
                Platform = (string)reader.GetValue("Platform", typeof(string));
                SeleniumHubUrl = (string)reader.GetValue("SeleniumHubUrl", typeof(string));
                SeleniumHubPort = (int)reader.GetValue("SeleniumHubPort", typeof(int));
            }

            ApplicationUrl = (string)reader.GetValue("URL", typeof(string));
        }
    }
}

