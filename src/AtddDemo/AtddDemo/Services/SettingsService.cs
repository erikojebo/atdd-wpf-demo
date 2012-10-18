using System;
using System.IO;
using System.Reflection;
using System.Text;
using AtddDemo.Settings;

namespace AtddDemo.Services
{
    public class SettingsService
    {
        public const string SettingsFileName = "settings.ini";

        public void Save(ServerSettings serverSettings)
        {
            var settingsFilePath = GetSettingsFilePath();

            File.WriteAllText(settingsFilePath, WriteToString(serverSettings));
        }

        private static string GetSettingsFilePath()
        {
            var assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return Path.Combine(assemblyDirectory, SettingsFileName);
        }

        public string WriteToString(ServerSettings serverSettings)
        {
            var sb = new StringBuilder();

            sb.AppendFormatLine(@"server:{0}", serverSettings.ServerIp);
            sb.AppendFormatLine(@"port:{0}", serverSettings.Port);
            sb.AppendLine(";Timeout in seconds");
            sb.AppendFormatLine(@"timeout:{0}", serverSettings.TimeoutInSeconds);

            return sb.ToString();
        }

        public ServerSettings Load()
        {
            var fileContents = File.ReadAllText(GetSettingsFilePath());
            return Parse(fileContents);
        }

        private ServerSettings Parse(string fileContents)
        {
            throw new NotImplementedException();
        }
    }
}